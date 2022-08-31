using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;

namespace WebAddressbookTests
{
    [TestFixture]
    public class UnitTest2
    {
        [Test]
        public void TestContactCompareTo()
        {
            ContactData contact1 = new ContactData("Dzmit") { Lname = "B" };
            ContactData contact2 = new ContactData("Dzmitry") { Lname = "A" };
            NUnit.Framework.Assert.AreEqual(contact1.CompareTo(contact2), 1);
        }
    }
}