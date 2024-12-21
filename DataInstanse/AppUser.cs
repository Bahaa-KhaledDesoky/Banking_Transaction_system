using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banking_system.DataInstanse
{
    public class AppUser
    {
        public int id {get;set;}
        public string name { get; set; }
        public string userName { get; set; }
        public string Phone { get; set; }
        public string address { get; set; }
        public byte[] passwordHash  { get; set; }
        public byte[] passwordSalt { get; set; }
        public int balanc { get; set; }=10000;

    }
}