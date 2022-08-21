using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests.tests
{

    [TestFixture]
    public  class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            if (!app.Contacts.IsContactPresent())
            {
                

                app.Contacts.CreateContact(ContactData contact);
            }
            
            ContactData newData = new ContactData("Dzmitry");
            newData.Lname = "Vysotski";

            app.Contacts.ModifyContact(1, newData);
  //          app.Logouts.Logout();
            
        }
    }
}
