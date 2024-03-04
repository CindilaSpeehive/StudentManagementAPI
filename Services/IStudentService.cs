using StudentManagementAPI.Models;

namespace StudentManagementAPI.Services
{
    public interface IStudentService
    {

        List<Student> GetAll();
        Student Get(int id);
        void Insert(Student student);
        void Delete(int id);
        void Update(Student student,int id);

    }
}
