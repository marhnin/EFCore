using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAPI.Model
{
    public class Grade
    {
        public int GradeId { get; set; }
        public string GradeName { get; set; }
        public string Section { get; set; }
        public ICollection<Student> Students { get; set; }
    }
    public class GradeDTO
    {
        [Required]
        public string GradeName { get; set; }
        [Required]
        public string Section { get; set; }
        public ICollection<StudentDTO> Students { get; set; }
    }
  
}
