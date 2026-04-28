using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sem2.Data;
using Sem2.Data.Entities;

namespace Sem2.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CourseController: ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        private readonly Course course;
        public CourseController(ApplicationDbContext dbContext)
        {
            this.dbContext= dbContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCourse()
        {
            var courses = await dbContext.Courses.Select(c => new {c.Id,c.Name,c.DurationYears,c.Modules})
                .ToListAsync();
            return Ok(courses);
        }
        [HttpGet("{id}")]
        public IActionResult GetCourse(int id) {
                        var course = dbContext.Courses.FirstOrDefault(c => c.Id == id);
            if (course == null)
            {
                return NotFound("Course not found.");
            }
            return Ok(course);
        }
        [HttpGet("{id}/modules")]
        public IActionResult GetModuleCourse(int id)
        {
            var module = dbContext.Modules.Where(m => m.CourseId == id)
                                           .ToList();
            if (module == null || module.Count == 0)
                {
                return NotFound("No modules found for this course.");
            }
            return Ok(module);
        }
        [HttpGet("{id}/fromCourseModules")]
        public async Task <IActionResult> GetModuleCourseFromCourse(int id)
        {
            var module = await dbContext.Courses.Where(c => c.Id == id)
                                           .Select(c => new {CourseName= c.Name,ModuleCount= c.Modules.Count,c.Modules })
                                           .ToListAsync();
            if (module == null )
            {
                return NotFound("No modules found for this course.");
            }
            return Ok(module);
        }

        [HttpGet("{id}/student")]
        public async Task<IActionResult> GetCourseStudent(int id)
        {
            var student = await dbContext.Enrollments.Where(m => m.CourseId == id)
                                                    .ToListAsync();

            if(student==null || student.Count == 0)
            { 
                return NotFound("No students found for this course.");
            }

            return Ok(student);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCourse(int id, string name, int durationYears)
        {
            Course course = new Course
            {
                Id = id,
                Name = name,
                DurationYears = durationYears
            };

            await dbContext.Courses.AddAsync(course);
            await dbContext.SaveChangesAsync();
            
            return Ok("Course Added Successfully!");

        }

        [HttpPost("{id}/modules")]
        public async Task<IActionResult> AddModule(int id,string moduleTitle, int credit)
        {
            var course = await dbContext.Courses
            .Include(c => c.Modules)
            .FirstOrDefaultAsync(c => c.Id == id);
            if (course == null)
            {
                return NotFound("Course not found.");
            }
            var module = new Module
            {
                Title = moduleTitle,
                Credit = credit,
                CourseId = id
            };
            await dbContext.Modules.AddAsync(module);
            await dbContext.SaveChangesAsync();
            
            return Ok("Module Added Successfully!");
        }
    }
}
