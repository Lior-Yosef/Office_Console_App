using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Office_Console_App
{
    public class Employee
    {
        public string FullName;
        public int Born;
        public string Email;
        public int Pay;

        public Employee(string _FullName, int _Born, string _Email, int _Pay)
        {
            this.FullName = _FullName;
            this.Born = _Born;
            this.Email = _Email;
            this.Pay = _Pay;
        }



    }
}
