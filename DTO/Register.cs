using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChannel.Core.DTO
{
    public class Register


    {
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public decimal? Age { get; set; }
        public string? Emaile { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? RegisterDate { get; set; }

        public string? UserName { get; set; }
        public string? Password { get; set; }

        public string? Phonenumber { get; set; }

        public string? Image { get; set; }
    }
}
