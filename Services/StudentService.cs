using StudentManagementAPI.Db;
using StudentManagementAPI.Models;

namespace StudentManagementAPI.Services;

public class StudentService : IStudentService
{
    public void Delete(int id)
    {

        StudentManagementDbContext _dbContext = new StudentManagementDbContext();
        Student? selectedStudent = _dbContext.Students.Where(x => x.Id == id).FirstOrDefault();

        _dbContext.Students.Remove(selectedStudent);
        _dbContext.SaveChanges();
    }

    public Student Get(int id)
    {

        // get data from db using db context and return that value
        StudentManagementDbContext _dbContext = new StudentManagementDbContext();
        Student? selectedStudent = _dbContext.Students.Where(x => x.Id == id).FirstOrDefault();

        return selectedStudent;
    }

    public List<Student> GetAll()
    {
        // get data from db using db context and return that value
        StudentManagementDbContext _dbContext = new StudentManagementDbContext();
        List<Student> allStudents = _dbContext.Students.ToList();

        return allStudents;
    }

    public void Insert(Student student)
    {
        //insert data using db context
        StudentManagementDbContext _dbContext = new StudentManagementDbContext();

        _dbContext.Students.Add(student);
        _dbContext.SaveChanges();
    }

    public void Update(Student student, int id)
    {
        StudentManagementDbContext _dbContext = new StudentManagementDbContext();
        Student? existingStudent = _dbContext.Students.Where(x => x.Id == id).FirstOrDefault();
        if (existingStudent != null)
        {
            // Update specific properties of existingStudent with updateValue
            existingStudent.Name = student.Name;
            existingStudent.Description = student.Description;

            _dbContext.Students.Update(existingStudent); // Update the student in the database
            _dbContext.SaveChanges();
        }
    }
}
