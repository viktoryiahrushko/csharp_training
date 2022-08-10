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
            
            ContactData group = new ContactData("Victoria");
            group.Lname = "Vysotsky";
            app.Contacts
                .FillOutContactInformation(group)
                .SubmitNewContact();
            app.Logouts.Logout();
        
        }
    }
}

