using Microsoft.AspNetCore.Mvc;
using StudentManagementAPI.Db;
using StudentManagementAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        // GET: api/<TeacherController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<TeacherController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TeacherController>
        [HttpPost]
        public void Post(Teacher value)
        {
            //insert data using db context
            StudentManagementDbContext _dbContext = new StudentManagementDbContext();

            _dbContext.Teachers.Add(value);
            _dbContext.SaveChanges();
        }

        

        // DELETE api/<TeacherController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            StudentManagementDbContext _dbContext = new StudentManagementDbContext();
            Teacher? selectedTeacher = _dbContext.Teachers.Where(x => x.Id == id).FirstOrDefault();

            _dbContext.Teachers.Remove(selectedTeacher);
            _dbContext.SaveChanges();
        }

        // PUT api/<TeacherController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Teacher updateValue)
        {
            StudentManagementDbContext _dbContext = new StudentManagementDbContext();
            Teacher? existingStudent = _dbContext.Teachers.Where(x => x.Id == id).FirstOrDefault();
            if (existingStudent != null)
            {
                // Update specific properties of existingStudent with updateValue
                existingStudent.Name = updateValue.Name;
                existingStudent.Subject = updateValue.Subject;

                _dbContext.Teachers.Update(existingStudent); // Update the student in the database
                _dbContext.SaveChanges();
            }
        }
    }
}
