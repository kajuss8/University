using Microsoft.EntityFrameworkCore;
using University.Entity;

namespace University
{
    public class UniversityContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(@"Server=LAPTOP-PHEKU5ND\SQLEXPRESS;Database=UniversityCA;Trusted_Connection=True;");

        public DbSet<Department> Departments { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<DepartmentSubject> DepartmentSubjects { get; set; }
        public DbSet<StudentSubject> StudentSubject { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DepartmentSubject>().HasKey(x => new { x.DepartmentId, x.SubjectId });
            modelBuilder.Entity<StudentSubject>().HasKey(x => new { x.StudentId, x.SubjectId });
        }
    }
}
