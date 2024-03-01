using Microsoft.AspNetCore.Mvc;
using StudentManagementAPI.Db;
using StudentManagementAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        // GET: api/<StudentController>
        [HttpGet]
        public List<Student> Get()
        {   // get data from db using db context and return that value
            StudentManagementDbContext _dbContext = new StudentManagementDbContext();
            List<Student> allStudents=_dbContext.Students.ToList();


            return allStudents;

        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public Student Get(int id)
        {

            // get data from db using db context and return that value
            StudentManagementDbContext _dbContext = new StudentManagementDbContext();
            Student? selectedStudent=  _dbContext.Students.Where(x=>x.Id==id).FirstOrDefault();


            return  selectedStudent;
        }

        // POST api/<StudentController>
        [HttpPost]
        public void Post( Student value)
        {
            //insert data using db context
            StudentManagementDbContext _dbContext = new StudentManagementDbContext();

            _dbContext.Students.Add(value);
            _dbContext.SaveChanges();
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            // Explore
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            StudentManagementDbContext _dbContext = new StudentManagementDbContext();
            Student? selectedStudent = _dbContext.Students.Where(x => x.Id == id).FirstOrDefault();

            _dbContext.Students.Remove(selectedStudent);
            _dbContext.SaveChanges();
        }
    }
}
