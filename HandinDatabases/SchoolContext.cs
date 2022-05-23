using HandinDatabases.Models;
using Microsoft.EntityFrameworkCore;

namespace HandinDatabases
{
    public class SchoolContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Loan> Loans { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            const string connectionString = "server=localhost;user=school;password=school;database=school;";
            optionsBuilder.UseMySql(
                connectionString,
                ServerVersion.AutoDetect(connectionString)
            );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasMany<Enrollment>(s => s.Enrollments);
            modelBuilder.Entity<Student>()
                .HasMany<Loan>(s => s.Loans);
            modelBuilder.Entity<Book>()
                .HasOne<Loan>(b => b.Loan);
            modelBuilder.Entity<Course>()
                .HasMany<Enrollment>(c => c.Enrollments);
        }
    }
}