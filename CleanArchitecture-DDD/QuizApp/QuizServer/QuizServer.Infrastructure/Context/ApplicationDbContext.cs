using Microsoft.EntityFrameworkCore;
using QuizServer.Domain.Entities;

namespace QuizServer.Infrastructure.Context;

public sealed class ApplicationDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=TUGAY\\SQLEXPRESS;Initial Catalog=QuizDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
    }

    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Exam> Exams { get; set; }
    public DbSet<ExamDetail> ExamDetail { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        List<Teacher> teachers = new()
        {
            new Teacher()
            {
                Id = 1,
                Name = "Taner",
                UserName = "taner"
            },
            new Teacher()
            {
                Id = 2,
                Name = "Adem",
                UserName = "adem"
            },
        };
        modelBuilder.Entity<Teacher>().HasData(teachers);

        List<Student> students = new()
        {
            new Student()
            {
                Id = 1,
                Name = "Gülay",
                UserName = "gülay"
            },
            new Student()
            {
                Id = 2,
                Name = "Akın",
                UserName = "akın"
            },
        };

        modelBuilder.Entity<Student>().HasData(students);
    }
}