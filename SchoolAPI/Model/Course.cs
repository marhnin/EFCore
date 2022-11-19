using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAPI.Model
{
    public class Course
    {
            public Course()
            {
                this.Students = new HashSet<Student>();
            }
            public int CourseId { get; set; }
            public string CourseName { get; set; }
            public ICollection<Student> Students { get; set; }
    }
    public class CourseDTO
    {
        [Required]
        public string CourseName { get; set; }
    }
}
