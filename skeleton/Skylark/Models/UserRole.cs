using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skylark.Models
{
    public partial class UserRole : IdentityUserRole<string>
    {
        public UserRole()
        {

        }

        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
    }
}
