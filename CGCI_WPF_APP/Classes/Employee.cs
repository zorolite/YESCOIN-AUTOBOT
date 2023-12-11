using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGCI_WPF_APP.Classes
{
    internal class Employee
    {
        //private int id;
        //private string firstName;
        //private string lastName;
        //private string email;
        //private string phone;
        //private string city;
        //private string country;
        //private string zip;
        //private string title;

        public int id { get; private set; } //lecture seule

        private string lastName;
        public string LastName
        {
            private get { return lastName; }//ecriture seule
            set { lastName = value; }
        }

        private string _firstName;
        public string firstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string DateOfBirth { get; set; }
        public string Email { get; set; }
    }
}
