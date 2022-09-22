using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{

    [TestFixture]
    public  class ContactModificationTests : ContactTestBase
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


            List<ContactData> oldContacts = ContactData.GetAll();

            ContactData toBeModified = oldContacts[0];
            app.Contacts.ModifyContact(toBeModified, newData);
            app.Contacts.ReturnToHomePage();

            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());


            List<ContactData> newContacts = ContactData.GetAll();
            toBeModified.Fname = newData.Fname;
            toBeModified.Lname = newData.Lname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                if (contact.Id == toBeModified.Id)
                {
                    Assert.AreEqual(newData.Fname, toBeModified.Fname);
                    Assert.AreEqual(newData.Lname, toBeModified.Lname);
                   

                }
            }
        }


    }
    }

