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
    public class LoginHelper : HelperBase
    {
        

        public LoginHelper(ApplicationManager manager) 
            : base(manager)
        {
            
        }
        public LoginHelper Login(AccountData account)
        {
            Type(By.Name("user"), account.Username);
            Type(By.Name("pass"), account.Password);
            
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
            return this;
        }
        public LoginHelper Login(AccountContactData account)
        {
            Type(By.Name("user"), account.Username1);
            Type(By.Name("pass"), account.Password1);
            
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
            return this;
        }
        public LoginHelper LoginAsUser()
        {
            Type(By.Name("user"), "user");
            Type(By.Name("pass"), "qwerty");
            
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
            return this;
        }
    }
}
