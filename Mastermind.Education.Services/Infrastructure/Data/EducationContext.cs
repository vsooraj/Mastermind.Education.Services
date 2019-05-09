using Mastermind.Education.Services.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mastermind.Education.Services.Data
{
    public class EducationContext : DbContext
    {
        public EducationContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {          
            builder.Entity<Course>(ConfigureCourse);
            builder.Entity<Enrollment>(ConfigureEnrollment);
            builder.Entity<Student>(ConfigureStudent);
        }      

        private void ConfigureCourse(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Course");
            builder.Property(c => c.Id)
                .ForSqlServerUseSequenceHiLo("Course_hilo")
                .IsRequired(true);
            builder.Property(c => c.Name)
                .IsRequired(true)
                .HasMaxLength(150);
            builder.Property(c => c.NoOfDays)
               .IsRequired(true);
        }
        private void ConfigureEnrollment(EntityTypeBuilder<Enrollment> builder)
        {
            builder.ToTable("Enrollment");
            builder.Property(c => c.Id)
                .ForSqlServerUseSequenceHiLo("Enrollment_hilo")
                .IsRequired(true);
            builder.Property(c => c.CourseId)
                .IsRequired(true);
            builder.Property(c => c.StudentId)
              .IsRequired(true);
            builder.HasOne(c => c.Course)
              .WithMany()
              .HasForeignKey(c => c.CourseId);

            builder.HasOne(c => c.Student)
               .WithMany()
               .HasForeignKey(c => c.StudentId);
        }

        private void ConfigureStudent(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Student");
            builder.Property(c => c.Id)
                .ForSqlServerUseSequenceHiLo("Student_hilo")
                .IsRequired(true);
            builder.Property(c => c.Name)
                .IsRequired(true)
                .HasMaxLength(100);
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Student> Students { get; set; }
        public object Course { get; internal set; }
    }
}
