using Mastermind.Education.Services.ApplicationCore.Services;
using Mastermind.Education.Services.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mastermind.Education.Services.ApplicationCore.Interfaces
{
    public interface IEnrollmentService
    {
        Task<Enrollment> AddAsync(Enrollment student);
        Task<IEnumerable<EnrollmentViewModel>> ListAllAsync();
        Task DeleteAsync(Enrollment newEnrollment);
    }
}
