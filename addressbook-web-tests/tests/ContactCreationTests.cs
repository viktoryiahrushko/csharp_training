using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace WebAddressbookTests

{
    
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contact = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                contact.Add(new ContactData(GenerateRandomString(30))
                {
                    Lname = GenerateRandomString(100),
                    Fname = GenerateRandomString(100)

                });
            }
            return contact;

        }


              [Test, TestCaseSource("RandomContactDataProvider")]
              public void ContactCreationTest(ContactData contact)
                   {
             
                    

                       List<ContactData> oldContacts = app.Contacts.GetContactList();
                       app.Contacts.CreateContact(contact);
                       app.Contacts.ReturnToHomePage();


                     Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactCount());


                       List<ContactData> newContacts = app.Contacts.GetContactList();
                      oldContacts.Add(contact);
                      oldContacts.Sort();
                      newContacts.Sort();
                       Assert.AreEqual(oldContacts, newContacts);

                   }

        [Test, TestCaseSource("RandomContactDataProvider")]
        public void BadContactCreationTest(ContactData contact)
        {

     //       ContactData contact = new ContactData("V'v");
      //      contact.Lname = "Vysotsky";

            List<ContactData> oldContacts = app.Contacts.GetContactList();
            app.Contacts.CreateContact(contact);
            app.Contacts.ReturnToHomePage();

            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);




        }


    }
}

