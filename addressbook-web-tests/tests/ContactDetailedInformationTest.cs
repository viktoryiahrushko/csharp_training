using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactDetailedInformationTest : AuthTestBase
    {
        [Test]
        public void TestContactDetailedInformation()
        {
            ContactData fromPage = app.Contacts.GetContactDetailedInformationFromDetailsPage(0);
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(0);

            Assert.AreEqual(fromPage, fromForm);
          Assert.AreEqual(fromPage.FullInfo, fromForm.FullInfo);
            

        }
    }
}
