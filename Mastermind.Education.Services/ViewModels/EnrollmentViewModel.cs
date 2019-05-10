namespace Mastermind.Education.Services.ApplicationCore.Services
{
    public class EnrollmentViewModel
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public string Course { get; set; }
        public int StudentId { get; set; }
        public string Student { get; set; }
        public string Grade { get; set; }
    }
}