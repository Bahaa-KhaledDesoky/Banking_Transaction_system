using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Banking_system.DataInstanse
{
    public class Transaction
    {
        public int id {get;set;}

        public int mountOfTransaction { get; set; }

        public DateTime time {get;set;}
        public int senderId { get; set; }
        [JsonIgnore]
        public AppUser sender { get; set; }
        public int receiverId { get; set; }
        [JsonIgnore]
        public AppUser receiver { get; set; }

    }
}