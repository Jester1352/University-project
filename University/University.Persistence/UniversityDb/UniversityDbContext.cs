using Microsoft.EntityFrameworkCore;
using University.Core.Domain.Departments.Models;
using University.Core.Domain.Faculties.Models;
using University.Core.Domain.RecordBooks.Models;
using University.Core.Domain.StudentGroups.Models;
using University.Core.Domain.Students.Models;
using University.Core.Domain.Subjects.Models;
using University.Core.Domain.Teachers.Models;
using University.Persistence.UniversityDb.EntityConfigurations;

namespace University.Persistence.UniversityDb;

public class UniversityDbContext : DbContext
{
    public DbSet<Student> Students { get; set; }

    public DbSet<Subject> Subjects { get; set; }

    public DbSet<Teacher> Teachers { get; set; }

    public DbSet<TeacherSubject> TeachersSubjects { get; set; }

    public DbSet<RecordBook> RecordBooks { get; set; }

    public DbSet<RecordBookSubject> RecordBooksSubjects { get; set; }

    public DbSet<StudentGroup> StudentGroups { get; set; }

    public DbSet<Faculty> Faculties { get; set; }

    public DbSet<Department> Departments { get; set; }

    public DbSet<FacultyDepartment> FacultyDepartments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = @"Server=DESKTOP-76QFO57;Database=University;Integrated Security=true";
        optionsBuilder.UseSqlServer(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new StudentEntityConfigurations());
        modelBuilder.ApplyConfiguration(new SubjectEntityConfigurations());
        modelBuilder.ApplyConfiguration(new TeacherEntityConfigurations());
        modelBuilder.ApplyConfiguration(new TeacherSubjectEntityConfiguration());
        modelBuilder.ApplyConfiguration(new RecordBookEntityConfiguration());
        modelBuilder.ApplyConfiguration(new RecordBookSubjectEntityConfiguration());
        modelBuilder.ApplyConfiguration(new StudentGroupEntityConfiguration());
        modelBuilder.ApplyConfiguration(new FacultyEntityConfiguration());
        modelBuilder.ApplyConfiguration(new DepartmentEntityConfiguration());
        modelBuilder.ApplyConfiguration(new FacultyDepartmentEntityConfiguration());
    }
}