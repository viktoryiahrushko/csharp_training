﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        [Test]
        public void LoginWithValidCredentials()
        {
            app.Auth.LogoutFrom();

            AccountData account = new AccountData("admin", "secret");
            app.Auth.Login(account);
            Assert.IsTrue(app.Auth.IsLoggedIn(account));
        }

        [Test]
        public void LoginWithInValidCredentials()
        {
            app.Auth.LogoutFrom();

            AccountData account = new AccountData("admin", "123456");
            app.Auth.Login(account);
            Assert.IsFalse(app.Auth.IsLoggedIn(account));
        }
    }
}
