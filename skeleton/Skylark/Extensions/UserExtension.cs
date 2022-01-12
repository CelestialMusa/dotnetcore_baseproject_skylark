using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Novell.Directory.Ldap;

namespace Skylark.Extensions
{
    public class UserExtension
    {
        public static string GetCurrentUserName(String username)
        {
            if (String.IsNullOrEmpty(username))
                return null;

            string currentUserName = "";
            //default domain set to CORP
            string password = "Shadow#193";
            try
            {
                int index = username.IndexOf(@"\", StringComparison.CurrentCulture);
                string ABNumber;
                LdapEntry user;
                if (index > 0)
                {
                    // a domain has been specified so get information from that domain
                    string domain = username.Substring(0, index);
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
                    currentUserName = user.getAttribute("givenName").StringValue;
                }
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
                //throw new Exception("Failed to find user.");
            }
            return currentUserName;
        }

        public static string GetCurrentUserSurname(String username)
        {
            if (String.IsNullOrEmpty(username))
                return null;

            string currentUserSurname = "";
            //default domain set to CORP
            string password = "Shadow#193";
            try
            {
                int index = username.IndexOf(@"\", StringComparison.CurrentCulture);
                string ABNumber;
                LdapEntry user;
                if (index > 0)
                {
                    // a domain has been specified so get information from that domain
                    string domain = username.Substring(0, index);
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
                    currentUserSurname = user.getAttribute("sn").StringValue;
                }
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
                //throw new Exception("Failed to find user.");

            }
            return currentUserSurname;
        }

        public static string GetCurrentUserManager(String username)
        {
            if (String.IsNullOrEmpty(username))
                return null;

            string currentUserManager = "";
            //default domain set to CORP
            string password = "Shadow#193";
            try
            {
                int index = username.IndexOf(@"\", StringComparison.CurrentCulture);
                string ABNumber;
                LdapEntry user;
                if (index > 0)
                {
                    // a domain has been specified so get information from that domain
                    string domain = username.Substring(0, index);
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
                    currentUserManager = user.getAttribute("manager").StringValue;
                    if (currentUserManager != "" || currentUserManager != null)
                    {
                        currentUserManager = currentUserManager.Split(',')[0];
                        currentUserManager = currentUserManager.Split('=')[1];
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
                //throw new Exception("Failed to find user.");

            }
            return currentUserManager;
        }

        public static string GetCurrentUserEmail(String username)
        {
            if (String.IsNullOrEmpty(username))
                return null;

            string userEmail = "";
            //default domain set to CORP
            string password = "Shadow#193";
            try
            {
                int index = username.IndexOf(@"\", StringComparison.CurrentCulture);
                string ABNumber;
                LdapEntry user;
                if (index > 0)
                {
                    // a domain has been specified so get information from that domain
                    string domain = username.Substring(0, index);
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
                    userEmail = user.getAttribute("mail").StringValue;
                }
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
                //throw new Exception("Failed to find user.");

            }

            return userEmail;
        }

        public static LdapEntry SearchLDAP(string ldapHost, string baseUrl, string bindDN, string bindPassword, string userName)
        {
            LdapEntry ldapEntry = null;
            using (LdapConnection _connection = new LdapConnection())
            {
                _connection.SecureSocketLayer = true;
                _connection.Connect(ldapHost, LdapConnection.DEFAULT_SSL_PORT);
                _connection.Bind(bindDN, bindPassword);

                var searchFilter = string.Format("(&(objectCategory=person)(objectClass=user)(CN={0}))", userName);
                var result = _connection.Search(baseUrl, LdapConnection.SCOPE_SUB, searchFilter,
                    new[] { "memberOf", "displayName", "sAMAccountName", "mail", "DistinguishedName", "extensionAttribute2", "sn", "givenName", "manager" }, false
                );

                try
                {
                    ldapEntry = result.next();
                }
                catch (LdapException ex)
                {
                    Debug.Write(ex);

                }

                _connection.Disconnect();
                return ldapEntry;
            }
        }

        public string GetLoggedInUserABNumber(string username)
        {
            int index = username.IndexOf(@"\", StringComparison.CurrentCulture);
            string ABNumber;

            if (index > 0)
            {
                // a domain has been specified so get information from that domain
                string domain = username.Substring(0, index);
                ABNumber = username.Substring(index + 1);
            }
            else
            {
                ABNumber = username;
            }

            return ABNumber;
        }

    }
}
