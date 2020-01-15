using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Skylark.Extensions;
using Skylark.Models.ViewModels;
using Skylark.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Skylark.Security;
using Microsoft.AspNetCore.Http;

namespace Skylark.Controllers
{
    public class UserAccountsController : Controller
    {
        private readonly Security.IAuthenticationService _authService;
        private readonly SkylarkDBContext _context;
        private readonly ISignInManager _signInManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserAccountsController(Security.IAuthenticationService authService, SkylarkDBContext context, ISignInManager signInManager, IHttpContextAccessor httpContextAccessor)
        {
            _authService = authService;
            _context = context;
            _signInManager = signInManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {

            model.Domain = "CORP";
            var basePath = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
            var returnUrl = basePath + "/Home/Index";
            if (!String.IsNullOrEmpty(model.ReturnUrl))
            {
                if (model.ReturnUrl.Length > 1)
                {
                    returnUrl = basePath + model.ReturnUrl;
                }
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var user = _authService.Login(model.Username.ToUpper(), model.Password, model.Domain);
                    if (user != null)
                    {
                        User currentUser = _context.Users.Where(u => u.Logon == model.Username.ToUpper()).ToList().FirstOrDefault();
                        if (currentUser != null)
                        {
                            var usersRoles = _context.UserRoles.Where(p => p.UserId == currentUser.Id);
                            var userRolesNames = _context.Roles.Join(usersRoles, roles => roles.Id, userRoles => userRoles.RoleId, (roles, userRoles) => roles).Select(roles => roles.Name).ToList();

                            await _signInManager.SignInAsync(model.Username.ToUpper(), userRolesNames);
                            return Redirect("/Home/Index");
                        }

                        List<string> rolesList = new List<string>();
                        await _signInManager.SignInAsync(model.Username.ToUpper(), rolesList);

                        return Redirect("/Home/Index");
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }

            ViewBag.MessageError = "Incorrect Username or Password. Please try again.";

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();

            var basePath = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";

            var returnUrl = basePath + "/Home/Index";

            return Redirect(returnUrl);
        }
    }

}
