using Microsoft.AspNetCore.Mvc;
using StudentManagementAPI.Db;
using StudentManagementAPI.Models;
using StudentManagementAPI.Services;


namespace StudentManagementAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
    // GET: api/<StudentController>

    private readonly IStudentService _studentService;
    public StudentController()
    {
        _studentService = new StudentService(); //  remove new 
    }
    [HttpGet]
    public List<Student> GetList()
    {
        return _studentService.GetAll();
    }

    // GET api/<StudentController>/5
    [HttpGet("{id}")]
    public Student Get(int id)
    {
        Student studentDetail=_studentService.Get(id);
        return  studentDetail;
    }

    // POST api/<StudentController>
    [HttpPost]
    public void Post( Student value)
    {
        _studentService.Insert(value);

    }

    // PUT api/<StudentController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] Student updateValue)
    {
       _studentService.Update(updateValue, id);
    }

    // DELETE api/<StudentController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        _studentService.Delete(id);
    }
}
