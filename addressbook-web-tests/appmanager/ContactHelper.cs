using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Text.RegularExpressions;


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
                    string lname = cells[1].Text;
                    string fname = cells[2].Text;



                    contactCache.Add(new ContactData(fname, lname)
                    {

                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                        
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
            SubmitModifiedContact();
            return this;

        }


        public ContactHelper InitContactModification()
        {
            driver.FindElement(By.XPath("//img[@alt='Edit']")).Click();
            //     driver.FindElements(By.Name("entry"))[index]
            //        .FindElements(By.TagName("td"))[7]
            //        .FindElement(By.TagName("a").Click();
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
        public ContactHelper SubmitModifiedContact()
        {
            driver.FindElement(By.XPath("//input[@value='Update']")).Click();
            contactCache = null;
            return this;
        }

        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.GoToHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"));
            string lname = cells[1].Text;
            string fname = cells[2].Text;
            string address = cells[3].Text;
            string allEmails = cells[4].Text;
            string allPhones = cells[5].Text;
          

            return new ContactData(lname, fname)
            {
                Address = address,
                AllPhones = allPhones,
                AllEmails = allEmails,
            

            };



        }

        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification();
            string fname = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lname = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string emailFirst = driver.FindElement(By.Name("email")).GetAttribute("value");
            string emailSecond = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string emailThird = driver.FindElement(By.Name("email3")).GetAttribute("value");

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");

            return new ContactData(fname, lname)
            {
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                EmailFirst = emailFirst,
                EmailSecond = emailSecond,
                EmailThird = emailThird


            };

        }
            

        public int GetNumberOfSearchResults()
        {
            manager.Navigator.GoToHomePage();
            string text = driver.FindElement(By.TagName("label")).Text;

            Match m = new Regex(@"\d+").Match(text);
            return Int32.Parse(m.Value);


        }



        public ContactData GetContactDetailedInformationFromDetailsPage()
        {
            manager.Navigator.GoToHomePage();
            InitContactDetailsLookUp(0);

            string fullinfo = driver.FindElement(By.XPath("//div[@id='content']")).Text;

        
            return new ContactData(fullinfo);

          
        }

        public ContactHelper InitContactDetailsLookUp(int index)
        {
            driver.FindElement(By.XPath("//img[@alt='Details']")).Click();
       
            return this;
        }

       



    }
}
