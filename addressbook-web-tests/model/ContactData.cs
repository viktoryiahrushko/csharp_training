﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmails;
        private string address;
        private string fullinfo;

        public ContactData(string fname, string lname)
        {
            Fname = fname;
            Lname = lname;
            
        }
           public ContactData(string lname)
          {

             Lname = lname;

         }

     

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Fname == other.Fname && Lname == other.Lname;
            //  return Fname == other.Fname;
        }

        public override int GetHashCode()
        {
            return Fname.GetHashCode();

        }


        public override string ToString()
        {
            return "name= " + Lname + " " + Fname;
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (!Object.ReferenceEquals(other.Lname, Lname))
            {
                return Lname.CompareTo(other.Lname);
            }
            return Fname.CompareTo(other.Fname);

        }

        public string Fname { get; set; }

        public string Lname { get; set; }
     

        public string Id { get; set; }

        public string HomePhone { get; set; }

        public string MobilePhone { get; set; }

        public string WorkPhone { get; set; }

        public string EmailFirst { get; set; }

        public string EmailSecond { get; set; }

        public string EmailThird { get; set; }

        public string Address
        {
            get
            {
                if (address != null)
                {
                    return address;
                }
                else
                {
                    return Address.Trim() + "\r\n";
                }
            }
            set
            {
                address = value;
            }
        }


        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }

        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")

            {
                return "";
            }
            return phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "") + "\r\n";
             // return Regex.Replace(phone, "[ -()]", "")  + "\r\n";


        }

        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (CutEmailLines(EmailFirst) + CutEmailLines(EmailSecond) + CutEmailLines(EmailThird)).Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }

        public string FullInfo
        {
            get
            {
                if (fullinfo != null)
                {

                    return fullinfo;
                }
                else
                {
                    return (Fname + " " + Lname + "\r\n" + Address + "\r\n" + "\r\n" +
                         "H: " + HomePhone + "\r\n" + "M: " + MobilePhone + "\r\n" + "W: " + WorkPhone + "\r\n" + "\r\n" +
                      EmailFirst + "\r\n" + EmailSecond + "\r\n" + EmailThird).Trim();
                }
            }
            set
            {
                fullinfo = value;
            }
        }

        public string CutEmailLines(string email)
        {
           
            if (email == null || email == "")
             {
                 return "";
                }
             return email + "\r\n";
         }
         }

      
    }


