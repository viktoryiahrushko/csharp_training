using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests.tests
{

    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]

        public void ContactRemovalTest()
        {
            if (!app.Contacts.IsContactPresent())
            {
                app.Contacts.CreateContact(ContctData contact);
            }
            app.Contacts.RemoveContact(17);
        }
        
    }
}
