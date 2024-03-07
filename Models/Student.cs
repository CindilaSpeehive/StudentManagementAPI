using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace StudentManagementAPI.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }


       // Navigation props
        public StudentAddress? StudentAddress { get; set; }

    }
}
