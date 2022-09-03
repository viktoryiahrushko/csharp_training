using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    [TestFixture]
    public class SearchTests : AuthTestBase
    
    {
        [Test]
        public void TestSearch()
        {
            Console.Out.Write(app.Contacts.GetNumberOfSearchResults());
        }

        [Test]
        public void TestData()
        {
            Console.Out.Write(app.Contacts.GetContactInformationFromEditForm(0));
            Console.Out.Write(app.Contacts.GetContactDetailedInformationFromDetailsPage(0));
        }
    }
}
