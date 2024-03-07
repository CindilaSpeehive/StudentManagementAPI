using Microsoft.EntityFrameworkCore;
using StudentManagementAPI.Models;

namespace StudentManagementAPI.Db
{
    public class StudentManagementDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<StudentAddress> StudentAddresses { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string path = "workstation id=SpeehiveTrainingdb.mssql.somee.com;packet size=4096;user id=codedstrings_SQLLogin_1;pwd=ltvx1dh9m3;data source=SpeehiveTrainingdb.mssql.somee.com;persist security info=False;initial catalog=SpeehiveTrainingdb;TrustServerCertificate=True";
            optionsBuilder.UseSqlServer(path);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
