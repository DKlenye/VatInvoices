using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using Naftan.VatInvoices.Extensions;

namespace Naftan.VatInvoices.Users
{
    public static class CurrentUser
    {
        public static string Name
        {
            get
            {
                return UserPrincipal.Current.DisplayName;
            }
        }

        public static IEnumerable<UserRoles> Roles
        {
            get
            {
                var userRoles = new List<UserRoles>();
                var userRolesMap = new Dictionary<string, UserRoles>();

                Enum.GetNames(typeof (UserRoles)).ToList().ForEach(x => userRolesMap.Add(x,x.ConvertToEnum<UserRoles>()));
                
                UserPrincipal.Current.
                    GetGroups(new PrincipalContext(ContextType.Domain, "lan.naftan.by")).ToList()
                    .ForEach(x =>
                    {
                        if( userRolesMap.ContainsKey(x.Name))
                            userRoles.Add(x.Name.ConvertToEnum<UserRoles>());
                    });

                return userRoles;
            }
        }

    }
}
