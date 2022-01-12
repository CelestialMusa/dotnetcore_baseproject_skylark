﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skylark.Models
{
    public partial class Role : IdentityRole<string>
    {
        public Role()
        {
        }

        public Role(string roleName) : base(roleName)
        {
        }
    }
}