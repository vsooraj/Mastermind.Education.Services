using Mastermind.Education.Services.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mastermind.Education.Services.Entities
{
    public class Enrollment : BaseEntity
    {
        public int CourseId { get; set; }
        public int StudentId { get; set; }

        public Course Course { get; set; }
        public Student Student { get; set; }
    }
}
