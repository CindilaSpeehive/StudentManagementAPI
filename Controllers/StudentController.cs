using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentManagementAPI.Dtos;
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

    //GetList() requires authorization to fetch data.
    [HttpGet,Authorize]
    public List<StudentDetailsDto> GetList()
    {

        return _studentService.GetAll();
    }

    // GET api/<StudentController>/5
    [HttpGet("{id}")]
    public StudentDetailsDto Get(int id)
    {
        StudentDetailsDto studentDetail = _studentService.Get(id);
        return studentDetail;
    }

    // POST api/<StudentController>
    [HttpPost]
    public void Post(CreateUpdateStudentDto studentDto)
    {
        _studentService.Insert(studentDto);
    }

    // PUT api/<StudentController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] CreateUpdateStudentDto updateValue)
    {
        _studentService.Update(updateValue, id);
    }

    // DELETE api/<StudentController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        _studentService.Delete(id);
    }

    [HttpGet, Route("getstudentdetails")]
    public List<StudentDto> GetStudentDetails()
    {

        return _studentService.GetStudentDetails();
    }
}
