using System.Collections.Generic;
using System.Threading.Tasks;
using Skylark.Models;

namespace Skylark.Security
{
    public interface ISignInManager
    {
        Task SignInAsync(string UserName, IList<string> roleNames);

        Task SignOutAsync();
    }
}