﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTestingSystem.Application.Models.Identity
{
    public class AuthResponse
    {
        public TokenModel Tokens { get; set; }
        public DateTime Expires { get; set; }
    }
}
