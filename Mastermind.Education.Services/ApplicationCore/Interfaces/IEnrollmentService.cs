using Mastermind.Education.Services.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mastermind.Education.Services.ApplicationCore.Interfaces
{
    public interface IEnrollmentService
    {
        //Task CreateEnrollmentAsync(int CourseId, int StudentId);
        //Task ListAllAsync(int v, int itemsPage, int? brandFilterApplied, int? typesFilterApplied);
        Task<IEnumerable<Enrollment>> ListAllAsync();


    }
}
