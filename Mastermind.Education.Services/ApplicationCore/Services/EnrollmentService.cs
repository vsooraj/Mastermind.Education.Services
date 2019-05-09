using Mastermind.Education.Services.ApplicationCore.Interfaces;
using Mastermind.Education.Services.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mastermind.Education.Services.ApplicationCore.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IAsyncRepository<Enrollment> _enrollmentRepository;

        public EnrollmentService(IAsyncRepository<Enrollment> enrollmentRepository)
        {
            _enrollmentRepository = enrollmentRepository;
        }
        //public async Task CreateEnrollmentAsync(int courseId, int studentId)
        //{
          
        //    var enrollment = new Enrollment() { CourseId = courseId, StudentId = studentId };

        //   await _enrollmentRepository.AddAsync(enrollment);
        //}

        //public async Task ListAllAsync(int v, int itemsPage, int? brandFilterApplied, int? typesFilterApplied)
        //{
        //    await  _enrollmentRepository.ListAllAsync();
        //}

        public async Task<IEnumerable<Enrollment>> ListAllAsync()
        {
            IEnumerable<Enrollment> enrollment = await _enrollmentRepository.ListAllAsync();

            return enrollment;

        }
    }
}
