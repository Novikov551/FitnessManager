using Microsoft.EntityFrameworkCore;

namespace FitnessManager.Models
{
    public class ManagerContext : DbContext
    {
        public ManagerContext()
        {

        }

        public ManagerContext(DbContextOptions<ManagerContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Trainer> Trainers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("name=ConnectionStrings:DefaultConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                 .Entity<Course>()
                 .HasMany(c => c.Students)
                 .WithMany(s => s.Courses)
                 .UsingEntity<StudentEnrolment>(
                    j => j
                     .HasOne(pt => pt.Student)
                     .WithMany(t => t.StudentEnrollments)
                     .HasForeignKey(pt => pt.StudentId),
                 j => j
                     .HasOne(pt => pt.Course)
                     .WithMany(p => p.StudentEnrollments)
                     .HasForeignKey(pt => pt.CourseId),
                 j =>
                 {
                     j.Property(pt => pt.EnrollmentDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
                     j.HasKey(t => new { t.CourseId, t.StudentId });
                     j.ToTable("STUDENTS_ENROLLMENTS");
                 });

            modelBuilder
                 .Entity<Course>()
                 .HasMany(c => c.Trainers)
                 .WithMany(s => s.Courses)
                 .UsingEntity<TrainerEnrollment>(
                    j => j
                     .HasOne(pt => pt.Trainer)
                     .WithMany(t => t.TrainerEnrollments)
                     .HasForeignKey(pt => pt.TrainerId),
                 j => j
                     .HasOne(pt => pt.Course)
                     .WithMany(p => p.TrainersEnrollments)
                     .HasForeignKey(pt => pt.CourseId),
                 j =>
                 {
                     j.Property(pt => pt.EnrollmentDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
                     j.HasKey(t => new { t.CourseId, t.TrainerId });
                     j.ToTable("TRAINERS_ENROLLMENTS");
                 });
        }
    }
}
