using Mastermind.Education.Services.ApplicationCore.Entities;

namespace Mastermind.Education.Services.Entities
{
    public class Enrollment : BaseEntity
    {
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public string Grade { get; set; }

        public Course Course { get; set; }
        public Student Student { get; set; }
    }
}
