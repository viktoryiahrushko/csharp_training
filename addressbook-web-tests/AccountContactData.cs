using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_tests
{
    class AccountContactData
    {
        public string username1;
        public string password1;

        public AccountContactData(string username1, string password1)
        {
            this.username1 = username1;
            this.password1 = password1;
        }

        public string Username1
        {
            get
            {
                return username1;
            }
            set
            {
                username1 = value;
            }
        }
        public string Password1
        {
            get
            {
                return password1;
            }
            set
            {
                password1 = value;
            }
        }
    }
}
