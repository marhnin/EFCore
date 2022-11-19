using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAPI.Model
{
    public class StudentAddress
    {
            [ForeignKey("Student")]
            public int StudentAddressId { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string Country { get; set; }
            public Student Student { get; set; }
    }
    public class StudentAddressDTO
    {
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Country { get; set; }
    }
}
