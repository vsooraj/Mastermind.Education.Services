using Mastermind.Education.Services.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mastermind.Education.Services.ApplicationCore.Interfaces
{
    public interface ICourseService
    {
        Task<IEnumerable<Course>> ListAllAsync();
        Task<Course> AddAsync(Course course);
        Task<IEnumerable<Course>> ListAsync(Course course);
        Task UpdateAsync(Course course);
        Task DeleteAsync(Course course);
    }
}
