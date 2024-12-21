using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Banking_system.DTOs
{
    public class SendCashDto
    {
        [Required]
        public string senderUsername {get;set;}
        [Required]
        public string password { get; set; }
        [Required]
        public int cash { get; set; }
        [Required]
        public string receiverUserName { get; set; }
        [Required]
        public string receiverPhone { get; set; }

    }
}