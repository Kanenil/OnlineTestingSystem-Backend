﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineTestingSystem.Application.Models;
using OnlineTestingSystem.Application.Contracts.Infrastructure;
using OnlineTestingSystem.Infrastructure.Mail;
using OnlineTestingSystem.Application.Contracts.Identity;
using OnlineTestingSystem.Infrastructure.Identity;
using OnlineTestingSystem.Infrastructure.JwtToken;

namespace OnlineTestingSystem.Infrastructure
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<IJwtTokenService, JwtTokenService>();
            services.AddTransient<IAuthService, AuthService>();

            return services;
        }
    }
}
