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
                ContactData contact = new ContactData("Victoria");
                contact.Lname = "Vysotsky";

                app.Contacts.CreateContact(contact);
            }

            ContactData newData = new ContactData("Dzmitry");
            newData.Lname = "Vysotski";


            List<ContactData> oldContacts = app.Contacts.GetContactList();
            app.Contacts.ModifyContact(0, newData);

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts[0].Fname = newData.Fname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }


    }
    }

