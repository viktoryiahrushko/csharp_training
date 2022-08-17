using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests

{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        
        [Test]
        public void ContactCreationTest()
        {

            ContactData group = new ContactData("Victoria");
            group.Lname = "Vysotsky";
            
            app.Contacts.CreateContact(group);
     //       app.Logouts.Logout();

        }

       
    }
}

