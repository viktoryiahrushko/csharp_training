using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;
using OpenQA.Selenium;
using System.IO;
using System.Xml.Serialization;

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
        public static IEnumerable<ContactData> ContactDataFromFile()
        {
            List<ContactData> contacts = new List<ContactData>();
            string[] lines = File.ReadAllLines(@"contacts.csv");
            foreach (string l in lines)
            {
                string[] cparts = l.Split(',');
                contacts.Add(new ContactData(cparts[0])
                {
                    Fname = cparts[1],
                    Lname = cparts[2]
                });
            }
            return contacts;
        }

        public static IEnumerable<ContactData> ContactDataFromXmlFile()
        {

            return (List<ContactData>)
                new XmlSerializer(typeof(List<ContactData>))
                .Deserialize(new StreamReader(@"contacts.xml"));

        }


        [Test, TestCaseSource("ContactDataFromXmlFile")]
        //[Test, TestCaseSource("ContactDataFromFile")]

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

