using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
       
        public ContactData(string fname)
        {
            Fname = fname;
         
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
            if (Object.ReferenceEquals(other, other))
            {
                return Fname.CompareTo(other.Fname);
            }
            if (Object.ReferenceEquals(this, other))
            {
                return Lname.CompareTo(other.Lname);
            }
            return Fname.CompareTo(other.Fname);
            
        }

        public string Fname { get; set; }
        
        public string Lname { get; set; }

        public string Id { get; set; }

        
    }
}
