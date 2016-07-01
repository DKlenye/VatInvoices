using System;
using System.Linq;
using Naftan.VatInvoices.Users;
using NUnit.Framework;

namespace Naftan.VatInvoices.Tests.Users
{
    public class CurrentUserTest
    {

        [Test]
        public void RolesTest()
        {
            CurrentUser.Roles.ToList().ForEach(x=>Console.Write(x.ToString()));
        }

        [Test]
        public void NameTest()
        {
            Console.Write(CurrentUser.Name);
        }

    }
}
