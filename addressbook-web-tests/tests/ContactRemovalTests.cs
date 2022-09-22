using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{

    [TestFixture]
    public class ContactRemovalTests : ContactTestBase
    {
        [Test]

        public void ContactRemovalTest()
        {
            

            if (!app.Contacts.IsContactPresent())
            {
                ContactData contact = new ContactData("Victoria");
                contact.Lname = "Vysotsky";
                app.Contacts.CreateContact(contact);
            }

           

            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData toBeRemoved = oldContacts[0];
            app.Contacts.RemoveContact(toBeRemoved);
            app.Contacts.ReturnToHomePage();


            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactCount());
            


            List<ContactData> newContacts = ContactData.GetAll();


            
            oldContacts.RemoveAt(0);
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
            }

        }

    }
}
