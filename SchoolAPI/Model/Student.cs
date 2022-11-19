using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAPI.Model
{
    public class Student
    {
        public Student()
        {
            this.Courses = new HashSet<Course>();
            this.Address = new StudentAddress();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public StudentAddress Address { get; set; }
        public  ICollection<Course> Courses { get; set; }
    } 
}
