using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace WebAddressbookTests
{
    [Table(Name = "addressbook")]
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmails;
        private string address;
        private string fullinfo;
        private object mobilePhone;
        private object homePhone;
        private object workPhone;
        
        

        public ContactData(string fname, string lname)
        {
            Fname = fname;
            Lname = lname;

        }
        public ContactData(string fname)
        {

            Fname = fname;

        }
        public ContactData()
        {

          

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
            return "name: " + Lname + " " + Fname;
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

        [Column(Name = "firstname")]
        public string Fname { get; set; }

        [Column(Name = "lastname")]
        public string Lname { get; set; }


        [Column(Name = "id"), PrimaryKey, Identity]
        public string Id { get; set; }


        [Column(Name = "home")] 
        public string HomePhone { get; set; }

        [Column(Name = "mobile")]
        public string MobilePhone { get; set; }

        [Column(Name = "work")]
        public string WorkPhone { get; set; }

        [Column(Name = "email")]
        public string EmailFirst { get; set; }

        [Column(Name = "email2")]
        public string EmailSecond { get; set; }

        [Column(Name = "email3")]
        public string EmailThird { get; set; }


        [Column(Name = "address")]
        public string Address
        {
            get
            {
                if (address == null)
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
             //return Regex.Replace(phone, "[ -()]", "")  + "\r\n";


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
                   string result = "";
                    
                    
                    
                    if (Fname != null || Fname != "")
                    {
                        result = result + Fname.Trim();
                    }
                    else
                    {
                       
                    }

                    if (Lname == null || Lname == "")
                    {
                        
                    }
                    else
                    {
                        result = result.Trim() + " " + Lname;

                    }

                   
                    if (Address == null || Address == "")
                    {
                        
                    }
                    else
                    {
                        result = result + "\r\n" + Address;
                    }
                    if (HomePhone == null || HomePhone == "")
                    {
                        result = result + "\r\n";
                    }
                    else
                    {
                        result = result + "\r\n\r\n" + "H: " + HomePhone;
                    }
                    if (MobilePhone == null || MobilePhone == "")
                    {
                        result = result + "\r\n";
                    }
                    else
                    {
                        result = result + "\r\n" + "M: " + MobilePhone + "\r\n";
                    }

                    if (WorkPhone == null || WorkPhone == "")
                    {
                      
                    }
                    else
                    {
                        result = result  + "W: " + WorkPhone ;
                    }

                    if (EmailFirst == null || EmailFirst == "")
                    {
                        result = result.Trim() + "\r\n" ;
                    }
                    else
                    {
                        result = result.Trim() + "\r\n\r\n" + EmailFirst ;
                    }
                     
                    if (EmailSecond == null || EmailSecond == "")
                    {
                        result = result + "\r\n";
                    }
                    else
                    { 
                     result = result + "\r\n" + EmailSecond + "\r\n";
                    }

                    if (EmailThird == null || EmailThird == "")
                    {
                      
                    }
                    else
                    {
                        result = result + EmailThird;
                    }
                    return result.Trim();
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

        public static List<ContactData> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from g in db.Contacts select g).ToList();
            }
        }
    }

      
    }


