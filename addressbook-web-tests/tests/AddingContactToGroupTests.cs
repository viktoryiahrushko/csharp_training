using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
  
    public class AddingContactToGroupTests : AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroup()
        {
            List<GroupData> groupAll = GroupData.GetAll();
            if (groupAll.Count == 0)
            {
                GroupData groupdata = new GroupData("group1");
                groupdata.Header = "hhh";
                groupdata.Footer = "hjj";
                app.Groups.Create(groupdata);
            }
            GroupData group = GroupData.GetAll()[0];


            ContactData contact = new ContactData();

            List<ContactData> contactAll = ContactData.GetAll();
            if (contactAll.Count == 0)
            {
                contact = new ContactData("vvv");
                contact.Fname = "hhh";
                contact.Lname = "ghjnk";
                app.Contacts.CreateContact(contact);
                contactAll.Add(contact);

            }

            List<ContactData> oldList = group.GetContacts();
            if (oldList.Count != 0)
            {
                List<ContactData> contactList = contactAll.Except(oldList).ToList();
                if (contactList.Count == 0)
                {
                    contact = oldList.First();
                    app.Contacts.RemoveContactFromGroup(contact, group);
                    oldList = group.GetContacts();
                }

            }

            contactAll = ContactData.GetAll();
            contact = contactAll.Except(oldList).First();
          
            app.Contacts.AddContactToGroup(contact, group);
            oldList.Add(contact);
            List<ContactData> newList = group.GetContacts();


            

            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);
        }
    }
}
