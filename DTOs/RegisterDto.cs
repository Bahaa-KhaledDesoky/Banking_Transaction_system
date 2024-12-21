using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Banking_system.DTOs
{
    public class RegisterDto
    {
        [Required]
        public string name { get; set; }
        [Required]
        public string userName { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string address { get; set; }
        [Required]
        public string password { get; set; }
    }
}