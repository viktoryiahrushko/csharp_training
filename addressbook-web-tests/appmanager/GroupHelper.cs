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
    public class GroupHelper : HelperBase
    {
       

        public GroupHelper(ApplicationManager manager) 
            : base (manager)
        {
            
        }

        public void Remove(int v)
        {
            manager.Navigator.GoToTheGroupPage();

            if (IsGroupPresent())
            {
                SelectGroup(v);
                RemoveGroup();
                ReturnToGroupPage();
            }

            
            
            


        }

        public bool IsGroupPresent()
        {
            //return IsElementPresent(By.XPath("//input[@type='checkbox']"));
            return IsElementPresent(By.Name("selected[]"));

        }
        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.GoToTheGroupPage();
            InitNewGroupsCreation();
            FillOutTheNewGroupForm(group);
            SubmitTheNewGroupAndReturnToTheGroupPage();
            return this;
        }

        public void Modify(int v, GroupData newData)
        {
            manager.Navigator.GoToTheGroupPage();

            if (!IsGroupPresent())
            {
                InitNewGroupsCreation();
                FillOutTheNewGroupForm(newData);
                SubmitTheNewGroupAndReturnToTheGroupPage();


            }

            
            SelectGroup(v);
            InitGroupModification();
            FillOutTheNewGroupForm(newData);
            SubmitGroupModification();
            ReturnToGroupPage();

        }

        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public  GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

       
        public GroupHelper SubmitTheNewGroupAndReturnToTheGroupPage()
        {
            driver.FindElement(By.Name("submit")).Click();
            driver.FindElement(By.LinkText("groups")).Click();
            driver.FindElement(By.LinkText("Logout")).Click();
            return this;
        }

        public GroupHelper FillOutTheNewGroupForm(GroupData group)
        {
           
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
            return this;
        }

       

        public GroupHelper InitNewGroupsCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

       

        public GroupHelper ReturnToGroupPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
            return this;
        }

        public void RemoveGroup()
        {
            if (IsGroupPresent())
            {
                driver.FindElement(By.Name("delete")).Click();
            }
            
            
        }

       

        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/span[" + index + "]/input")).Click();
            return this;
        }
       

    }
}
