using System;
using Skylark.Models;
using Novell.Directory.Ldap;

namespace Skylark.Security
{
    class LdapAuthenticationService : IAuthenticationService
    {
        private const string MemberOfAttribute = "memberOf";
        private const string DisplayNameAttribute = "displayName";
        private const string SAMAccountNameAttribute = "sAMAccountName";

        public User Login(string username, string password, string domain)
        {
            //Alter bindDN accounts
            var ldapHost = "corp.dsarena.com";
            var bindDN = string.Format("CN={0},OU=Users,OU=CORP Accounts,DC=corp,DC=dsarena,DC=com", username.ToUpper());
            var baseUrl = "DC=corp,DC=dsarena,DC=com";
            var userPassword = password;
            if (username.ToUpper().Contains("-ADMIN"))
            {
                ldapHost = "corp.dsarena.com";
                bindDN = string.Format("CN={0},OU=Admins,OU=CORP Accounts,DC=corp,DC=dsarena,DC=com", username.ToUpper());
                baseUrl = "DC=corp,DC=dsarena,DC=com";
                userPassword = password;
            }

            LdapConnection _connection = new LdapConnection
            {
                SecureSocketLayer = true
            };

            _connection.Connect(ldapHost, LdapConnection.DEFAULT_SSL_PORT);
            _connection.Bind(bindDN, password);

            var searchFilter = string.Format("(&(objectCategory=person)(objectClass=user)(CN={0}))", username.ToUpper());

            var result = _connection.Search(
                baseUrl,
                LdapConnection.SCOPE_SUB,
                searchFilter,
                new[] { MemberOfAttribute, DisplayNameAttribute, SAMAccountNameAttribute },
                false
            );

            try
            {
                var user = result.next();
                if (user != null)
                {
                    _connection.Bind(user.DN, password);
                    if (_connection.Bound)
                    {
                        return new User
                        {
                            UserName = user.getAttribute(SAMAccountNameAttribute).StringValue
                        };
                    }
                }
            }
            catch
            {
                throw new Exception("Login failed.");
            }
            _connection.Disconnect();
            return null;
        }
    }
}
