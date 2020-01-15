using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Skylark.Models
{
    public partial class User : IdentityUser<string>
    {

        [StringLength(256)]
        public override string UserName { get; set; }

        [StringLength(256)]
        public override string NormalizedUserName { get; set; }

        [StringLength(50)]
        [Required]
        public string Logon { get; set; }

        public bool Active { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }

    }
}
