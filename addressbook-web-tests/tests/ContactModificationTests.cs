using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
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
            newData.Lname = "Vysotsk";


            List<ContactData> oldContacts = app.Contacts.GetContactList();
            ContactData oldData = oldContacts[0];
            app.Contacts.ModifyContact(0, newData);
            app.Contacts.ReturnToHomePage();

            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());


            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts[0].Fname = newData.Fname;
            oldContacts[0].Lname = newData.Lname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                if (contact.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Fname, contact.Fname);
                    Assert.AreEqual(newData.Lname, contact.Lname);
                   

                }
            }
        }


    }
    }

