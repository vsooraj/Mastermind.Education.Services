using Mastermind.Education.Services.ApplicationCore.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mastermind.Education.Services.ApplicationCore.Interfaces
{
    public interface IEnrollmentService
    {
        //Task CreateEnrollmentAsync(int CourseId, int StudentId);
        //Task ListAllAsync(int v, int itemsPage, int? brandFilterApplied, int? typesFilterApplied);
        Task<IEnumerable<EnrollmentViewModel>> ListAllAsync();


    }
}
