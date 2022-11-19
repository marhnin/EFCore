using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolAPI.DAL;
using SchoolAPI.Model;
using System.Collections.Generic;
using System.Linq;

namespace SchoolAPI.Controllers
{
    [ApiController]
    [Route("api/home")]
    public class SchoolController : Controller
    {
        private readonly SchoolContext _context;
        public SchoolController(SchoolContext context)
        {
            this._context = context;
        }

        [HttpPost]
        [Route("addData")]
        public IActionResult addDataV2([FromBody] GradeDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            Grade objGrade = new Grade();
            objGrade.GradeName = model.GradeName;
            objGrade.Section = model.Section;
            List<Student> stuList = new List<Student>();
            foreach (StudentDTO obj in model.Students)
            {
                Student objStudent = new Student();
                objStudent.Name = obj.name;
                StudentAddress objAddress = new StudentAddress();
                objAddress.State = obj.Address.State;
                objAddress.City = obj.Address.City;
                objAddress.Country = obj.Address.Country;
                objAddress.Student = objStudent;
                objStudent.Address = objAddress;
                List<Course> courseList = new List<Course>();
                foreach (CourseDTO course in obj.Courses)
                {
                    Course objCourse = new Course();
                    objCourse.CourseName = course.CourseName;
                    courseList.Add(objCourse);
                }
                objStudent.Courses = courseList;
                stuList.Add(objStudent);
            }
            objGrade.Students = stuList;
            _context.Grades.Add(objGrade);
            int count = _context.SaveChanges();
            if (count > 0)
            {
                return Ok(new ResponseModel { code = "200", message = "Insert Success" });
            }
            else
            {
                return BadRequest(new ResponseModel { code = "400", message = "Insert Fail" });
            }
        }
        
        [HttpGet]
        [Route("getGrades")]
        public IActionResult getGrades()
        {
            var grades = _context.Grades;
            if (grades.Count() == 0)
            {
                return Ok(new ResponseModel { code = "404", message = "No data found" });
            }
            return Ok(grades);
        }
        
        [HttpGet]
        [Route("getStudents")]
        public IActionResult getStudentsAsync()
        {
           List<Student> students =  _context.Students
                        .Include(p => p.Courses)
                        .Include(p => p.Address)
                        .ToList(); 
            if (students.Count == 0)
            {
                return Ok(new ResponseModel { code = "404", message = "No data found" });
            }
            return Ok(students);
        }

        [HttpGet]
        [Route("getGradeStudents")]
        public IActionResult getGradeStudents()
        {
            var grades = _context.Grades.Include(p=>p.Students).ToList();
            if (grades.Count == 0)
            {
                return Ok(new ResponseModel { code = "404", message = "No data found" });
            }
            return Ok(grades);
        }
    }
}
