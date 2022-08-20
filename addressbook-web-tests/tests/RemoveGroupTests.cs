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
           
            app.Groups.Remove(1);
            
        }

       
        
       
    }
}
