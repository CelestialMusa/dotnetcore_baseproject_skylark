using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Skylark.Models;
using Microsoft.AspNetCore.Authorization;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Skylark.Models.ViewModels;
using Novell.Directory.Ldap;

namespace Skylark.Controllers
{
    [Authorize(Roles = "Admin,Developer")]
    public class UsersController : Controller
    {
        private readonly SkylarkDBContext _context;
        private UserManager<User> _userManager;

        public UsersController(SkylarkDBContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            return View(await _context.User.ToListAsync());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            var model = new UserVM();
            var roles = _context.Roles.ToList();
            foreach (var role in roles)
            {
                model.RoleList.Add(new SelectListItem() { Text = role.Name, Value = role.Name });
            }
            return View(model);
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserVM user)
        {

            var roles = _context.Roles.ToList();

            foreach (var UserRole in roles)
            {
                user.RoleList.Add(new SelectListItem() { Text = UserRole.Name, Value = UserRole.Name });
            }
            if (ModelState.IsValid)
            {

                User newUser = LookupAdUser(user.Logon);

                if (newUser == null)
                {
                    return View(user);
                }

                User existingUser = _context.Users.Where(m => m.Logon == newUser.Logon).SingleOrDefault();
                if (existingUser != null)
                {
                    TempData["error"] = "User already exists!";
                    return View(user);
                }

                string userPWD = "Vision1!";

                var createNewUser = await _userManager.CreateAsync(newUser, userPWD);
                if (createNewUser.Succeeded)
                {
                    //here we tie the new user to the role : Question 3
                    await _userManager.AddToRoleAsync(newUser, user.RoleName);

                }

                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, UserVM user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var user = await _context.User.FindAsync(id);
            _context.User.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        public User LookupAdUser(string username)
        {

            if (String.IsNullOrEmpty(username))
                return null;

            User existingUser = null;
            //default domain set to CORP
            string domain = "CORP";
            string ABNumber = "";
            string password = "Shadow#193";
            LdapEntry user = null;
            try
            {
                int index = username.IndexOf(@"\", StringComparison.CurrentCulture);
                if (index > 0)
                {
                    // a domain has been specified so get information from that domain
                    domain = username.Substring(0, index);
                    ABNumber = username.Substring(index + 1);

                    //Search CORP Domain
                    user = SearchLDAP("corp.dsarena.com", "DC=corp,DC=dsarena,DC=com", "CN=SVC-VIPA,OU=Service Accounts,OU=CORP Accounts,DC=corp,DC=dsarena,DC=com", password, ABNumber);
                }
                else
                {
                    //Search CORP Domain as Default
                    ABNumber = username;
                    user = SearchLDAP("corp.dsarena.com", "DC=corp,DC=dsarena,DC=com", "CN=SVC-VIPA,OU=Service Accounts,OU=CORP Accounts,DC=corp,DC=dsarena,DC=com", password, ABNumber);
                }

                if (user != null)
                {
                    existingUser = new User
                    {
                        Logon = ABNumber,
                        Email = user.getAttribute("mail").StringValue,
                        UserName = ABNumber,
                        EmailConfirmed = true,
                        Active = true,
                        NormalizedEmail = user.getAttribute("mail").StringValue.ToUpper(),
                        NormalizedUserName = ABNumber.ToUpper(),

                    };
                }
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
                //throw new Exception("Failed to find user.");

            }

            return existingUser;
        }


        private LdapEntry SearchLDAP(string ldapHost, string baseUrl, string bindDN, string bindPassword, string userName)
        {
            LdapEntry ldapEntry = null;
            using (LdapConnection _connection = new LdapConnection())
            {
                _connection.SecureSocketLayer = true;
                _connection.Connect(ldapHost, LdapConnection.DEFAULT_SSL_PORT);
                _connection.Bind(bindDN, bindPassword);

                var searchFilter = string.Format("(&(objectCategory=person)(objectClass=user)(CN={0}))", userName);
                var result = _connection.Search(baseUrl, LdapConnection.SCOPE_SUB, searchFilter,
                    new[] { "memberOf", "displayName", "sAMAccountName", "mail", "DistinguishedName", "extensionAttribute2", "sn", "givenName", "manager", "employeeNumber" }, false
                );

                try
                {
                    ldapEntry = result.next();
                }
                catch (LdapException ex)
                {
                    Debug.WriteLine(ex.Message + " : " + ex.StackTrace);

                }
                _connection.Disconnect();
                return ldapEntry;
            }
        }

        private bool UserExists(string id)
        {
            return _context.User.Any(e => e.Id == id);
        }
    }
}
