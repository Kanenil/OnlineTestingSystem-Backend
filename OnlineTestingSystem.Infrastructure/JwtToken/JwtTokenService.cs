using Google.Apis.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OnlineTestingSystem.Application.Constants;
using OnlineTestingSystem.Application.Contracts.Infrastructure;
using OnlineTestingSystem.Domain.Identity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTestingSystem.Infrastructure.JwtToken
{
    public class JwtTokenService : IJwtTokenService
    {
        private readonly IConfiguration _config;
        private readonly UserManager<UserEntity> _userManager;

        public JwtTokenService(IConfiguration config, UserManager<UserEntity> userManager)
        {
            _config = config;
            _userManager = userManager;
        }

        public async Task<string> CreateTokenAsync(UserEntity user)
        {
            var roles = await _userManager.GetRolesAsync(user);
            List<Claim> claims = new()
            {
                new Claim("slug", user.Slug),
                new Claim("email", user.Email),
                new Claim("name", $"{user.FirstName} {user.LastName}"),
                new Claim("emailConfirmed", $"{user.EmailConfirmed}"),
                new Claim("image", user.Image ?? string.Empty)
            };

            foreach (var role in roles)
                claims.Add(new Claim("roles", role));

            var signinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetValue<String>("JwtSecretKey")));
            var signinCredentials = new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256);

            var jwt = new JwtSecurityToken(
                signingCredentials: signinCredentials,
                expires: DateTime.Now.AddDays(Token.Life),
                claims: claims
            );
            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        public async Task<GoogleJsonWebSignature.Payload> VerifyGoogleTokenAsync(string tokenId)
        {
            string clientID = _config["GoogleAuthSettings:ClientId"];

            var setting = new GoogleJsonWebSignature.ValidationSettings()
            {
                Audience = new List<string>() { clientID }
            };

            var payload = await GoogleJsonWebSignature.ValidateAsync(tokenId, setting);
            return payload;
        }
    }
}
