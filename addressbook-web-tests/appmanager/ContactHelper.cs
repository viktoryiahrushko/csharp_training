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
        public bool IsContactPresent()
        {
            
            return IsElementPresent(By.XPath("//input[@type='checkbox']"));
            

        }

        public void RemoveContact(int v)
        {
            if (!IsContactPresent())
            {
                //  CreateContact(contact);
                return;
            }
            
            manager.Navigator.GoToHomePage();
            SelectContact(v);
            DeleteContact();
            driver.SwitchTo().Alert().Accept();


        }
        public ContactHelper SelectContact(int index)
        {
            
            driver.FindElement(By.XPath("//input[@type='checkbox']")).Click();

            return this;
        }
        public ContactHelper DeleteContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
           
            return this;
        }

        public void ModifyContact(int v, ContactData contact)
        {
            if (IsContactPresent())
            {
                manager.Navigator.GoToHomePage();
                SelectContact(v);
                InitContactModification();
                FillOutContactInformation(contact);
                SubmitNewContact();

            }
            manager.Contacts.FillOutContactInformation(contact);
            SubmitNewContact();

        }

        public ContactHelper InitContactModification()
        {
            driver.FindElement(By.XPath("//img[@alt='Edit']")).Click();
            return this;
        }

        

        

        public ContactHelper FillOutContactInformation(ContactData contact)
        {
            driver.FindElement(By.LinkText("add new")).Click();
            Type(By.Name("firstname"), contact.Fname);
            Type(By.Name("lastname"), contact.Lname);
            
            return this;
        }


        public ContactHelper SubmitNewContact()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
            return this;
        }
        public ContactHelper CreateContact(ContactData contact)
        {
            manager.Contacts.FillOutContactInformation(contact);
            SubmitNewContact();
            return this;
        }

        

    }
}
