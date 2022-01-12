using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Skylark.Models.ViewModels
{
    public class UserVM
    {
        public UserVM()
        {
            RoleList = new List<SelectListItem>();
        }

        public string Id { get; set; }

        [StringLength(50)]
        [Display(Name = "AB Number")]
        [Required]
        public string Logon { get; set; }

        [Display(Name = "Role")]
        public string RoleName { get; set; }

        [Display(Name = "Counter Number")]
        public int? CounterNumber { get; set; }

        public List<SelectListItem> RoleList { get; set; }
    }
}
