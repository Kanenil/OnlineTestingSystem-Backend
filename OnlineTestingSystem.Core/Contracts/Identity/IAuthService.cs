﻿using OnlineTestingSystem.Application.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTestingSystem.Application.Contracts.Identity
{
    public interface IAuthService
    {
        Task<AuthResponse> Login(AuthRequest request);
        Task<AuthResponse> Register(RegistrationRequest request);
        Task<AuthResponse> GoogleLogin(string googleToken);
        Task<AuthResponse> GoogleRegister(GoogleRegister model);
        Task<TokenModel> RefreshToken(TokenModel model);
    }
}
