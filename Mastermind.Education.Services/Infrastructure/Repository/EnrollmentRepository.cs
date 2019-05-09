using Mastermind.Education.Services.ApplicationCore.Interfaces;
using Mastermind.Education.Services.Data;
using Mastermind.Education.Services.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mastermind.Education.Services.Infrastructure.Data.Repository
{
    public class EnrollmentRepository : EfRepository<Enrollment>, IEnrollmentRepository
    {
        public EnrollmentRepository(EducationContext dbContext) : base(dbContext)
        {
        }
       
    }
}
