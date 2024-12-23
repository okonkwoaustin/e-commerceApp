﻿using e_commerceApp.Shared.Models.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commerceApp.Application.Services.Interface
{
    public interface ITokenService
    {
        string GenerateToken(User user, List<string> roles);
    }
}
