using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests

{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        
        [Test]
        public void ContactCreationTest()
        {
            GoToHomePage();
            Login(new AccountContactData("admin", "secret"));
            OpenContactPage();
            ContactData group = new ContactData("Victoria");
            group.Lname = "Vysotsky";
            FillOutContactInformation(group);
            SubmitNewContact();
            Logout();
        
        }
    }
}

