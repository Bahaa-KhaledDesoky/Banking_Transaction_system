using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Banking_system.DataInstanse
{
    public class LogInDto
    {
        [Required]
        public string username {get;set;}
        [Required]
        public string password { get; set; }

    }
}