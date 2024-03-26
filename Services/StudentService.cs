using Microsoft.EntityFrameworkCore;
using StudentManagementAPI.Db;
using StudentManagementAPI.Dtos;
using StudentManagementAPI.Exceptions;
using StudentManagementAPI.Models;

namespace StudentManagementAPI.Services;

public class StudentService : IStudentService
{
    private readonly StudentManagementDbContext _dbContext;
    public StudentService()
    {
        //todo Need to use Dependency injection
        _dbContext = new StudentManagementDbContext();
    }
    public void Delete(int id)
    {
        Student? selectedStudent = _dbContext.Students.Where(x => x.Id == id).FirstOrDefault();

        _dbContext.Students.Remove(selectedStudent);
        _dbContext.SaveChanges();
    }

    public StudentDetailsDto Get(int id)
    {
        
        // get data from db using db context and return that value
        Student? selectedStudent = _dbContext.Students
          .Include(x => x.StudentAddress)
          .Where(x => x.Id == id)
          .FirstOrDefault();
        //once we get the data from db we need to convert it into DTO.

        if (selectedStudent == null)
        {
            throw new NotFoundCustomException($"Student with ID {id} not found."); // Throw your custom exception here
        }

        //todo  Use Auto mapper
        return new StudentDetailsDto()
        {
            Id = selectedStudent.Id,
            Name = selectedStudent.Name,
            Description = selectedStudent.Description,
            Address = new StudentAddressDto()
            {
                City = selectedStudent.StudentAddress == null ? String.Empty : selectedStudent?.StudentAddress?.City ?? String.Empty,
                PostalCode = selectedStudent!.StudentAddress == null ? String.Empty : selectedStudent.StudentAddress.City ?? String.Empty,
                Street = selectedStudent!.StudentAddress == null ? String.Empty : selectedStudent.StudentAddress?.Street ?? String.Empty,
            }
        };
    }

    public List<StudentDetailsDto> GetAll()
    {
        // get data from db using db context and return that value
        List<Student> students = _dbContext.Students
          .Include(x => x.StudentAddress)
          .ToList();
        // mapping
        //todo use auto mapper
        #region Methode1
        List<StudentDetailsDto>? detailsDtoList = new List<StudentDetailsDto>();
        foreach (Student item in students)
        {
            detailsDtoList.Add(new StudentDetailsDto()
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                Address = new StudentAddressDto()
                {
                    City = item.StudentAddress == null ? String.Empty : item?.StudentAddress?.City ?? String.Empty,
                    PostalCode = item!.StudentAddress == null ? String.Empty : item.StudentAddress.City ?? String.Empty,
                    Street = item!.StudentAddress == null ? String.Empty : item.StudentAddress?.Street ?? String.Empty,
                }
            });

        }
        #endregion

        #region Methode2
        List<StudentDetailsDto> result = students.Select(item =>
        {
            return new StudentDetailsDto()
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                Address = new StudentAddressDto()
                {
                    City = item.StudentAddress == null ? String.Empty : item?.StudentAddress?.City ?? String.Empty,
                    PostalCode = item!.StudentAddress == null ? String.Empty : item.StudentAddress.City ?? String.Empty,
                    Street = item!.StudentAddress == null ? String.Empty : item.StudentAddress?.Street ?? String.Empty,
                }
            };
        }).ToList();
        #endregion

        return detailsDtoList;
    }

    public void Insert(CreateUpdateStudentDto studentDto)
    {
        //we need to convert this DTO(Data Transfer Object) to Entity type
        //Enity Framework only works with Entity (  public DbSet<Student> Students { get; set; })

        //the convertion (also known as mapping)
        //todo  Use Auto mapper
        Student studentEntity = new Student()
        {
            Name = studentDto?.Name ?? String.Empty,
            Description = studentDto?.Description ?? String.Empty,
        };

        //insert data using db context
        _dbContext.Students.Add(studentEntity);
        _dbContext.SaveChanges();
    }

    public void Update(CreateUpdateStudentDto studDto, int id)
    {
        Student? existingStudent = _dbContext.Students.Include(x => x.StudentAddress).Where(x => x.Id == id).FirstOrDefault();

        if (existingStudent == null)
        {
            throw new Exception();
        }

        if (existingStudent.Name != studDto.Name)
        {
            existingStudent.Name = studDto.Name;
        }

        if (existingStudent.Description != studDto.Description)
        {
            existingStudent.Description = studDto.Description;
        }

        if (existingStudent.StudentAddress != null
            && existingStudent.StudentAddress.PostalCode != studDto.StudentAddress?.PostalCode)
        {
            existingStudent.StudentAddress.PostalCode = studDto.StudentAddress.PostalCode;
        }

        if (existingStudent.StudentAddress != null
           && existingStudent.StudentAddress.City != studDto.StudentAddress?.City)
        {
            existingStudent.StudentAddress.City = studDto.StudentAddress.City;
        }

        if (existingStudent.StudentAddress != null
         && existingStudent.StudentAddress.Street != studDto.StudentAddress?.Street)
        {
            existingStudent.StudentAddress.Street = studDto.StudentAddress?.Street;
        }

        _dbContext.SaveChanges();
    }

    public List<StudentDto> GetStudentDetails()
    {
        List<Student> a = _dbContext.Students.ToList();
        List<StudentDto> b = new List<StudentDto>();
        foreach (Student item in a)
        {
            b.Add(new StudentDto()
            {
                Id = item.Id,
                Name = item.Name


            });

        

        }
        return b;

    }
}