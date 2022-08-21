using System;
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
            app.Groups.Remove(1);
            
        }
      




    }
}
