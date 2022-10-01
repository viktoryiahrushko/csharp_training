using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;
using OpenQA.Selenium;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Excel = Microsoft.Office.Interop.Excel;

namespace WebAddressbookTests

{

    [TestFixture]
    public class ContactCreationTests : ContactTestBase
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
        public static IEnumerable<ContactData> ContactDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<ContactData>>(
                File.ReadAllText(@"contacts.json"));


        }

        public static IEnumerable<ContactData> ContactDataFromExcelFile()
        {

            List<ContactData> contacts = new List<ContactData>();
            Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            Excel.Workbook wb = app.Workbooks.Open(Path.Combine(Directory.GetCurrentDirectory(), @"contacts.xlsx"));
            Excel.Worksheet sheet = wb.ActiveSheet;
            Excel.Range range = sheet.UsedRange;
            for (int i = 1; i <= range.Rows.Count; i++)
            {
                contacts.Add(new ContactData()
                {
                    Fname = range.Cells[i, 1].Value,
                    Lname = range.Cells[i, 2].Value
                    
                });
            }

            wb.Close();
            app.Visible = false;
            app.Quit();
            return contacts;

        }

        [Test, TestCaseSource("ContactDataFromExcelFile")]
        //[Test, TestCaseSource("ContactDataFromJsonFile")]
        //[Test, TestCaseSource("ContactDataFromXmlFile")]
        //[Test, TestCaseSource("ContactDataFromFile")]
        //[Test]

        public void ContactCreationTest(ContactData contact)
        {
            List<ContactData> oldContacts = ContactData.GetAll();
            app.Contacts.CreateContact(contact);
            app.Contacts.ReturnToHomePage();
            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactCount());
            List<ContactData> newContacts = ContactData.GetAll();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }

        //[Test, TestCaseSource("RandomContactDataProvider")]
       // [Test]
        public void BadContactCreationTest(ContactData contact)
        {

           // ContactData contact = new ContactData("V'v");
            //contact.Lname = "Vysotsky";

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
        [Test]
        public void TestDBConnectivityContact()
        {
            DateTime start = DateTime.Now;
            List<ContactData> fromUi = app.Contacts.GetContactList();
            DateTime end = DateTime.Now;
            System.Console.Out.WriteLine(end.Subtract(start));

            start = DateTime.Now;
            List<ContactData> fromDb = ContactData.GetAll();
            end = DateTime.Now;
            System.Console.Out.WriteLine(end.Subtract(start));
        }


    }
}

