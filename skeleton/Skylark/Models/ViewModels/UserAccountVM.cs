using System;
namespace Skylark.Models.ViewModels
{
    public class UserAccountVM
    {
    }

    public class LoginViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Domain { get; set; }

        public string ReturnUrl { get; set; }
    }
}
