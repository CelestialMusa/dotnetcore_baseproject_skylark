using System;
using Skylark.Models;

namespace Skylark.Security
{
    public interface IAuthenticationService
    {
        User Login(string username, string password, string domain);
    }
}
