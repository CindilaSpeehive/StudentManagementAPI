using Microsoft.EntityFrameworkCore;
using StudentManagementAPI.Models;

namespace StudentManagementAPI.Db
{
    public class StudentManagementDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string path = "Server=localhost\\SQLEXPRESS;Database=StudentManagementDb;Trusted_Connection=True;Encrypt=false;TrustServerCertificate=true";
            optionsBuilder.UseSqlServer(path);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
