﻿using System;
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
                ContactData contact = new ContactData("Victoria");
                contact.Lname = "Vysotsky";
                app.Contacts.CreateContact(contact);
            }

           

            List<ContactData> oldContacts = app.Contacts.GetContactList();
            app.Contacts.RemoveContact(1);

            List<ContactData> newContacts = app.Contacts.GetContactList();
           Assert.AreEqual(oldContacts.Count - 1, newContacts.Count);
        }
        
    }
}
