using Google.Apis.Auth;
using OnlineTestingSystem.Application.Models.Identity;
using OnlineTestingSystem.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTestingSystem.Application.Contracts.Infrastructure
{
    public interface IJwtTokenService
    {
        Task<GoogleJsonWebSignature.Payload> VerifyGoogleTokenAsync(string tokenId);
        Task<AuthResponse> CreateTokenAsync(UserEntity user);
        Task<TokenModel> RefreshTokenAsync(string? accessToken, string? refreshToken);
    }
}
