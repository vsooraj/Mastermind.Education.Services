using Mastermind.Education.Services.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mastermind.Education.Services.ApplicationCore.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> ListAllAsync();
        Task<IEnumerable<Student>> ListAsync(Student student);
        Task<Student> AddAsync(Student student);
        Task UpdateAsync(Student student);
        Task DeleteAsync(Student newStudent);
    }
}
