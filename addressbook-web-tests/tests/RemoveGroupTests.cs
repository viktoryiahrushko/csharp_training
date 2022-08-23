using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class RemoveGroupTests : AuthTestBase

    {
        
       

        [Test]
        public void RemoveGroupTest()
        {
           if (!app.Groups.IsGroupPresent())
            {
                GroupData group = new GroupData("aaa");
                group.Header = "sss";
                group.Footer = "hhh";
                app.Groups.Create(group);
                
            }

            List<GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.Remove(2);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            Assert.AreEqual(oldGroups.Count - 1, newGroups.Count);

        }
      

    }
}
