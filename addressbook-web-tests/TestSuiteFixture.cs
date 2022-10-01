using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    [SetUpFixture]
    public class TestSuiteFixture
    {


        [OneTimeSetUp]
        public void InitApplicationManager()
        {
            ApplicationManager app = ApplicationManager.GetInstance();
           
            
        }

        [OneTimeTearDown]
        public void StopApplicationManager()
        {
            ApplicationManager.GetInstance().Stop();
        }

       
    }
}
