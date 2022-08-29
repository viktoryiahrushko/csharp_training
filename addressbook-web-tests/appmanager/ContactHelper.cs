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

            return IsElementPresent(By.Name("selected[]"));


        }
        private List<ContactData> contactCache = null;

        public List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                
                contactCache = new List<ContactData>();
                manager.Navigator.GoToHomePage();
                ICollection<IWebElement> elements = driver.FindElements(By.XPath("//tr[@name='entry']"));

                //driver.FindElements(By.CssSelector("td.center"));
                foreach (IWebElement element in elements)
                {
                    
                    IList<IWebElement> cells = element.FindElements(By.TagName("td"));
                    string lastname = cells[1].Text;
                    string firstname = cells[2].Text;



                    contactCache.Add(new ContactData(firstname) { 
                      
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value"),
                        Lname = lastname
                });
                    
                }
            }

      

            return new List<ContactData>(contactCache);
        }

        public int GetContactCount()
        {
            return driver.FindElements(By.XPath("//tr[@name='entry']")).Count;
        }

        public ContactHelper RemoveContact(int v)
        {
           
            
            manager.Navigator.GoToHomePage();
            SelectContact(v);
            DeleteContact();
            driver.SwitchTo().Alert().Accept();
          
            driver.FindElement(By.CssSelector("div.msgbox"));
            return this;


        }
        public ContactHelper SelectContact(int index)
        {

            
            driver.FindElement(By.XPath("//input[@type='checkbox']")).Click();
            //driver.FindElement(By.XPath("//div[@id='content']/form/table/tbody/td[" + index + "]/input")).Click();
            

            return this;
        }
        public ContactHelper DeleteContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            contactCache = null;

            return this;
        }

        public ContactHelper ModifyContact(int v, ContactData newdata)
        {
            
                manager.Navigator.GoToHomePage();
                SelectContact(v);
                InitContactModification();
                FillOutContactInformationModify(newdata);
                SubmitNewContact();
                return this;

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
        public ContactHelper FillOutContactInformationModify(ContactData newData)
        {
            
            Type(By.Name("firstname"), newData.Fname);
            Type(By.Name("lastname"), newData.Lname);

            return this;
        }



        public ContactHelper SubmitNewContact()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
            contactCache = null;
            return this;
        }
        public ContactHelper CreateContact(ContactData contact)
        {
            manager.Contacts.FillOutContactInformation(contact);
            SubmitNewContact();
            return this;
        }
        public ContactHelper ReturnToHomePage()
        {
            driver.FindElement(By.LinkText("home")).Click();
            return this;
        }

        

    }
}
