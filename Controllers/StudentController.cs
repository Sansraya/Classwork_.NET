using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Sem2.Modals;

namespace StudentAPI.Controllers
{
    [ApiController]
    [Route("api/student")]
    public class StudentController : ControllerBase
    {
        
        private static List<Student> students = new List<Student>();
        private readonly IConfiguration config;
       
        public StudentController(IConfiguration config)
        {
            this.config = config;
        }

        [HttpGet("getall")]
        public IActionResult GetAllStudent()
        {
            return Ok(students);
        }
        
        [HttpGet("{id}")]
        public IActionResult GetStudentById(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);

               if (student == null)
            {
                return NotFound("Student not found.");
            }

            return Ok(student);
        }

        
        [HttpPost("add")]
        public IActionResult Add([FromBody] Student student)
        {
            if (student == null)
            {
                return BadRequest("Student data is required.");
            }

            
            var existing = students.FirstOrDefault(s => s.Id == student.Id);
            if (existing != null)
            {
                return BadRequest("A student with this ID already exists.");
            }

            students.Add(student);
            return Ok("Student added successfully.");
        }

        
        [HttpPut("update")]
        public IActionResult Update([FromBody] Student updatedStudent)
        {
            if (updatedStudent == null)
            {
                return BadRequest("Student data is required.");
            }

            var student = students.FirstOrDefault(s => s.Id == updatedStudent.Id);

            if (student == null)
            {
                return NotFound("Student not found.");
            }

            student.Name = updatedStudent.Name;
            student.Course = updatedStudent.Course;
            student.Age = updatedStudent.Age;

            return Ok("Student updated successfully.");
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);

            if (student == null)
            {
                return NotFound("Student not found.");
            }

            students.Remove(student);
            return Ok("Student deleted successfully.");
        }

        [HttpGet("GetStudentFromSettings")]
        public IActionResult GetFromSettings(IOptions<Student> options)
        {

            //int id = Convert.ToInt32(setting["Student:Id"]);
            //string ?name = setting["Student:Name"];
            //string ?email= setting["Student:Email"];
            //int age = Convert.ToInt32(setting["Student:Age"]);


            //return Ok(new {id,name,email,age});

            Student student = options.Value;

            return Ok(student);

        }
    }
}