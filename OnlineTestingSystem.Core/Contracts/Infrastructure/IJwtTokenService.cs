using Google.Apis.Auth;
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
        Task<string> CreateTokenAsync(UserEntity user);
    }
}
