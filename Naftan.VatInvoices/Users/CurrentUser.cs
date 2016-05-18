using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Security.Principal;

namespace Naftan.VatInvoices.Users
{
    public static class CurrentUser
    {
        private const char DomainSplitter = '\\';

        private static WindowsPrincipal GetPrincipal()
        {
            var identity = WindowsIdentity.GetCurrent() ?? WindowsIdentity.GetAnonymous();
            return new WindowsPrincipal(identity);
        }

        private static string IdentityName
        {
            get { return GetPrincipal().Identity.Name; }
        }

        public static string Login
        {
            get { return IdentityName.Split(DomainSplitter)[1]; }
        }

        public static string Name
        {
            get
            {
                var context = UserPrincipal.Current;
                return context.DisplayName;
            }
        }

        public static IEnumerable<string> Roles
        {
            get
            {
                var userRoles = new List<string>();
                var principal = GetPrincipal();

                Enum.GetNames(typeof (UserRoles)).ToList().ForEach(x =>
                {
                    if (principal.IsInRole(x))
                    {
                        userRoles.Add(x);
                    }
                });

                return userRoles;
            }
        }

        private static bool IsInRole(UserRoles role)
        {
            return GetPrincipal().IsInRole(role.ToString());
        }

        public static bool IsAdmin()
        {
            return IsInRole(UserRoles.NDSInvoices_Admins);
        }

    }
}
