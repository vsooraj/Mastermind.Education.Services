using Mastermind.Education.Services.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mastermind.Education.Services.Data
{
    public class EducationSeed
    {
        public static async Task SeedAsync(EducationContext context)
        {
            if (!context.Courses.Any())
            {
                context.Courses.AddRange(GetPreconfiguredCourses());
                await context.SaveChangesAsync();
            }
            if (!context.Students.Any())
            {
                context.Students.AddRange(GetPreconfiguredStudents());
                await context.SaveChangesAsync();
            }

            if (!context.Enrollments.Any())
            {
                context.Enrollments.AddRange(GetPreconfiguredEnrollments());
                await context.SaveChangesAsync();
            }

        }
        static IEnumerable<Course> GetPreconfiguredCourses()
        {
            return new List<Course>()
            {
                new Course() { Name = "C#",NoOfDays=60},
                new Course() { Name = "Angualr",NoOfDays=100 },
                new Course() { Name = ".NET Core",NoOfDays=150 }

            };
        }
        static IEnumerable<Student> GetPreconfiguredStudents()
        {
            return new List<Student>()
            {
                new Student() { Name = "Jon Doe"},
                new Student() { Name = "Jane Doe" },
                new Student() { Name = "Willy Doe" },

            };
        }
        static IEnumerable<Enrollment> GetPreconfiguredEnrollments()
        {
            return new List<Enrollment>()
            {
                new Enrollment() { CourseId=2,StudentId=3},
                new Enrollment() { CourseId=1,StudentId=2},
                new Enrollment() { CourseId=2,StudentId=3},
                new Enrollment() { CourseId=2,StudentId=2},
                new Enrollment() { CourseId=2,StudentId=1},
                new Enrollment() { CourseId=2,StudentId=2},
                new Enrollment() { CourseId=2,StudentId=1},
                new Enrollment() { CourseId=1,StudentId=1},
                new Enrollment() { CourseId=1,StudentId=2},
                new Enrollment() { CourseId=2,StudentId=3},
                new Enrollment() { CourseId=1,StudentId=2},
                new Enrollment() { CourseId=2,StudentId=1},
                new Enrollment() { CourseId=3,StudentId=3},
                new Enrollment() { CourseId=3,StudentId=2},
                new Enrollment() { CourseId=3,StudentId=1}

            };
        }
    }
}
