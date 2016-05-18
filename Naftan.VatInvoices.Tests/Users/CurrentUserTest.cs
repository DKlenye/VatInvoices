using System;
using System.Linq;
using Naftan.VatInvoices.Users;
using NUnit.Framework;

namespace Naftan.VatInvoices.Tests.Users
{
    public class CurrentUserTest
    {
        [Test]
        public void LoginTest()
        {
            Console.Write(CurrentUser.Login);
        }

        [Test]
        public void RolesTest()
        {
            CurrentUser.Roles.ToList().ForEach(Console.Write);
        }

        [Test]
        public void NameTest()
        {
            Console.Write(CurrentUser.Name);
        }

        [Test]
        public void IsAdminTest()
        {
            Console.Write(CurrentUser.IsAdmin());
        }
    }
}
