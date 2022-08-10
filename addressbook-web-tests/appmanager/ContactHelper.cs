using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        

        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        
        }
        public ContactHelper FillOutContactInformation(ContactData group)
        {
            driver.FindElement(By.LinkText("add new")).Click();
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(group.Fname);
            driver.FindElement(By.Name("lastname")).Click();
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(group.Lname);
            return this;
        }


        public ContactHelper SubmitNewContact()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
            return this;
        }
        public ContactHelper CreateContact(ContactData group)
        {
            manager.Contacts.FillOutContactInformation(group);
            SubmitNewContact();
            return this;
        }

    }
}
