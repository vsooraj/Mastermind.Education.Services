using Mastermind.Education.Services.ApplicationCore.Interfaces;
using Mastermind.Education.Services.Data;
using Mastermind.Education.Services.Entities;
using Mastermind.Education.Services.Infrastructure.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mastermind.Education.Services.Infrastructure.Data.Repository
{
    public class StudentRepository : EfRepository<Student>, IStudentRepository
    {
        public StudentRepository(EducationContext dbContext) : base(dbContext)
        {

        }
    }
}
