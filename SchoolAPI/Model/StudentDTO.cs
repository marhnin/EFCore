using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAPI.Model
{
    public class StudentDTO
    {
        [Required]
        public string name { get; set; }
        public StudentAddressDTO Address { get; set; }
        public ICollection<CourseDTO> Courses { get; set; }
    }
  
}
