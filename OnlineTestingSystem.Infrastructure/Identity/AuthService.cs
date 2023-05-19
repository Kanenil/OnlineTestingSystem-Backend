using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json.Linq;
using OnlineTestingSystem.Application.Constants;
using OnlineTestingSystem.Application.Contracts.Identity;
using OnlineTestingSystem.Application.Contracts.Infrastructure;
using OnlineTestingSystem.Application.Exeptions;
using OnlineTestingSystem.Application.Models.Identity;
using OnlineTestingSystem.Domain.Identity;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTestingSystem.Infrastructure.Identity
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly SignInManager<UserEntity> _signInManager;
        private readonly IJwtTokenService _jwtTokenService;

        public AuthService(UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager, IJwtTokenService jwtTokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtTokenService = jwtTokenService;
        }

        public async Task<AuthResponse> GoogleLogin(string googleToken)
        {
            if (string.IsNullOrWhiteSpace(googleToken))
                throw new BadRequestException("Token is not valid.");
            

            var payload = await _jwtTokenService.VerifyGoogleTokenAsync(googleToken);

            if (payload == null)
                throw new BadRequestException("Token is long not valid.");

            string provider = "Google";
            var info = new UserLoginInfo(provider, payload.Subject, provider);
            var user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);

            if (user == null)
            {
                user = await _userManager.FindByEmailAsync(payload.Email);
                if (user == null)
                    throw new BadRequestException("GoogleLogin: User not found.");

                var resultUserLogin = await _userManager.AddLoginAsync(user, info);
                if (!resultUserLogin.Succeeded)
                    throw new BadRequestException("Some thing went wrong, try later.");
            }

            var time = await _userManager.GetLockoutEndDateAsync(user);
            if (time != null)
                throw new BadRequestException($"Account is banned until {time.ToString()}.");

            var token = await _jwtTokenService.CreateTokenAsync(user);
            return new AuthResponse() { Token = token };
        }

        public async Task<AuthResponse> GoogleRegister(GoogleRegister model)
        {
            var payload = await _jwtTokenService.VerifyGoogleTokenAsync(model.Token);

            if (payload == null)
                throw new BadRequestException("Token is long not valid.");

            string provider = "Google";
            var info = new UserLoginInfo(provider, payload.Subject, provider);
            var user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);

            if (user == null)
            {
                user = await _userManager.FindByEmailAsync(payload.Email);
                if (user == null)
                {
                    user = new UserEntity
                    {
                        Email = payload.Email,
                        FirstName = model.FirstName,
                        UserName = payload.Email,
                        LastName = model.LastName,
                        Image = model.Image
                    };

                    var resultCreate = await _userManager.CreateAsync(user);
                    if (!resultCreate.Succeeded)
                        throw new BadRequestException("Some thing went wrong, try later.");
                    await _userManager.AddToRoleAsync(user, Roles.User);
                }

                var resultUserLogin = await _userManager.AddLoginAsync(user, info);
                if (!resultUserLogin.Succeeded)
                    throw new BadRequestException("Some thing went wrong, try later.");
            }

            var token = await _jwtTokenService.CreateTokenAsync(user);
            return new AuthResponse() { Token = token };
        }

        public async Task<AuthResponse> Login(AuthRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null)
            {
                throw new NotFoundException($"User with", request.Email);
            }

            var result = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, false, lockoutOnFailure: false);

            if (!result.Succeeded)
            {
                throw new BadRequestException($"Credentials for '{request.Email} aren't valid'.");
            }

            var token = await _jwtTokenService.CreateTokenAsync(user);

            AuthResponse response = new()
            {
                Token = token,
            };

            return response;
        }

        public async Task<AuthResponse> Register(RegistrationRequest request)
        {
            var existingUser = await _userManager.FindByNameAsync(request.UserName);

            if (existingUser != null)
            {
                throw new BadRequestException($"Username '{request.UserName}' already exists.");
            }

            var user = new UserEntity
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
                Image = string.Empty
            };

            var existingEmail = await _userManager.FindByEmailAsync(request.Email);

            if (existingEmail == null)
            {
                var result = await _userManager.CreateAsync(user, request.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "User");

                    var token = await _jwtTokenService.CreateTokenAsync(user);

                    AuthResponse response = new()
                    {
                        Token = token,
                    };

                    return response;
                }
                else
                {
                    throw new BadRequestException($"{result.Errors}");
                }
            }
            else
            {
                throw new BadRequestException($"Email {request.Email} already exists.");
            }
        }
    }
}
