﻿using NUnit.Framework;
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
        

        [SetUp]
        public void InitApplicationManager()
        {
            ApplicationManager app = ApplicationManager.GetInstance();
           
            
        }

        [TearDown]
        public void StopApplicationManager()
        {
            ApplicationManager.GetInstance().Stop();
        }

       
    }
}
