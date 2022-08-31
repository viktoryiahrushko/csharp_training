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

        public GroupHelper Remove(int v)
        {
            manager.Navigator.GoToTheGroupPage();

          
                SelectGroup(v);
                RemoveGroup();
                ReturnToGroupPage();
                return this;
      
        }

        private List<GroupData> groupCache = null;
        


        public List<GroupData> GetGroupList()
        {
            if (groupCache == null)
            {
                groupCache = new List<GroupData>();
                manager.Navigator.GoToTheGroupPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
                foreach (IWebElement element in elements)
                {
                    

                    groupCache.Add(new GroupData(null) { 
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    });
                }

                string allGroupNames = driver.FindElement(By.CssSelector("div#content form")).Text;
                string [] parts = allGroupNames.Split('\n');
                int shift = groupCache.Count - parts.Length;
                for (int i = 0; i < groupCache.Count; i++)
                {
                    if (i < shift)
                    {
                        groupCache[i].Name = "";
                    }
                    else
                    {
                        groupCache[i].Name = parts[i - shift].Trim();
                    }
                    
                }

            }
            List<GroupData> groups = new List<GroupData>();

           
            return new List<GroupData>(groupCache);
        }

        public int GetGroupCount()
        {
            return driver.FindElements(By.CssSelector("span.group")).Count;
        }

        public bool IsGroupPresent()
        {
            
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

        public GroupHelper Modify(int v, GroupData newData)
        {
            manager.Navigator.GoToTheGroupPage();

            SelectGroup(v);
            InitGroupModification();
            FillOutTheNewGroupForm(newData);
            SubmitGroupModification();
            ReturnToGroupPage();
            return this;

        }

        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            groupCache = null;
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
            groupCache = null;
            driver.FindElement(By.LinkText("groups")).Click();
            
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
     
            driver.FindElement(By.Name("delete")).Click();
            groupCache = null;

        }

       

        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/span[" + (index + 1) + "]/input")).Click();
            return this;
        }
       

    }
}
