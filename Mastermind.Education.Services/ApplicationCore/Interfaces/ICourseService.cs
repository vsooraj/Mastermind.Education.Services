using Mastermind.Education.Services.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mastermind.Education.Services.ApplicationCore.Interfaces
{
    public interface ICourseService
    {
        Task<IEnumerable<Course>> ListAllAsync();
        Task<Course> AddAsync(Course course);
    }
}
