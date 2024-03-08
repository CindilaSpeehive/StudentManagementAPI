using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        StudentManagementDbContext _dbContext = new StudentManagementDbContext();

       List<Student> studentsWithAddress = _dbContext
                                            .Students
                                            .Include(x => x.StudentAddress)
                                            .ToList();


        foreach (Student item in studentsWithAddress)
        {
            Console.WriteLine($" {item.Name} {item.StudentAddress?.City ?? string.Empty}");

        }

        // todo dto mapping

        return studentsWithAddress;
        // return _studentService.GetAll();
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
    public void Post()
    {
        StudentManagementDbContext _dbContext = new StudentManagementDbContext();

        #region Method1
        Student studentObj = new Student();
        studentObj.Name = "Test";
        studentObj.Description = "Des";

        studentObj.StudentAddress = new StudentAddress()
        {
            City = "Test",
            PostalCode = "22222",
            Street = "Test",
        };
        _dbContext.Students.Add(studentObj); // Adding value to Student, StudentAddress
        _dbContext.SaveChanges();
        #endregion

        /////////////////////////////////////////////////////////////////////////////////
        #region Method2
        Student studentObj2 = new Student();
        studentObj2.Name = "Test2";
        studentObj2.Description = "Test2";
        studentObj2.StudentAddress = null;

        _dbContext.Students.Add(studentObj2);
        _dbContext.SaveChanges();

        StudentAddress address = new StudentAddress();
        address.Street = "Teststs";
        address.PostalCode = "1212";
        address.City = "Kollam";
        address.StudentId = studentObj2.Id; //FK

        _dbContext.StudentAddresses.Add(address);
        _dbContext.SaveChanges(); 
        #endregion



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
