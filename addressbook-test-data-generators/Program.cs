﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAddressbookTests;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;


namespace addressbook_test_data_generators
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = Convert.ToInt32(args[0]);
            StreamWriter writer = new StreamWriter(args[1]);
            string type = args[2];
            string format = args[3];



            if (type == "contacts")
            {
                List<ContactData> contacts = new List<ContactData>();
                for (int i = 0; i < count; i++)
                {
                    contacts.Add(new ContactData(TestBase.GenerateRandomString(10))
                    {
                        Fname = TestBase.GenerateRandomString(10),
                        Lname = TestBase.GenerateRandomString(10)

                    });


                }
                if (format == "csv")
                {
                    writeContactsToCsvFile(contacts, writer);
                }
                else if (format == "xml")
                {
                    writeContactsToXmlFile(contacts, writer);
                }
                else if (format == "json")
                {
                    writeContactsToJsonFile(contacts, writer);
                }
                else
                {
                    System.Console.Out.Write("Unrecognized format " + format);
                }
                writer.Close();
            }


            else if (type == "groups")
            {
                List<GroupData> groups = new List<GroupData>();
                for (int i = 0; i < count; i++)
                {
                    groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                    {
                        Header = TestBase.GenerateRandomString(10),
                        Footer = TestBase.GenerateRandomString(10)
                    });


                }
                if (format == "csv")
                {
                    writeGroupsToCsvFile(groups, writer);
                }
                else if (format == "xml")
                {
                    writeGroupsToXmlFile(groups, writer);
                }
                else if (format == "json")
                {
                    writeGroupsToJsonFile(groups, writer);
                }
                else
                {
                  Console.Out.Write("Unrecognized format " + format);
                }

                writer.Close();
            }
            else
            {
                Console.Out.Write("Unrecognized type " + type);
            }



            static void writeGroupsToCsvFile(List<GroupData> groups, StreamWriter writer)
            {
                foreach (GroupData group in groups)
                {
                    writer.WriteLine(String.Format("${0}, ${1}, ${2}",
                       group.Name, group.Header, group.Footer));
                }
            }

            static void writeGroupsToXmlFile(List<GroupData> groups, StreamWriter writer)
            {
                new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
            }

            static void writeGroupsToJsonFile(List<GroupData> groups, StreamWriter writer)
            {
                writer.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented));
            }
            static void writeContactsToJsonFile(List<ContactData> contacts, StreamWriter writer)
            {
                writer.Write(JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented));
            }



            static void writeContactsToCsvFile(List<ContactData> contacts, StreamWriter writer)
            {
                foreach (ContactData contact in contacts)
                {
                    writer.WriteLine(String.Format("${0}, ${1}",
                      contact.Fname, contact.Lname));
                }
            }

            static void writeContactsToXmlFile(List<ContactData> contacts, StreamWriter writer)
            {
                new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, contacts);
            }
        }
    }
}
    
    



    

    


         


   

