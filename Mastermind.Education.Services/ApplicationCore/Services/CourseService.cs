using Mastermind.Education.Services.ApplicationCore.Interfaces;
using Mastermind.Education.Services.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mastermind.Education.Services.ApplicationCore.Services
{
    public class CourseService : ICourseService
    {

        public readonly IAsyncRepository<Course> _courseRepository;
        public CourseService(IAsyncRepository<Course> courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<IEnumerable<Course>> ListAllAsync()
        {
            IEnumerable<Course> course = await _courseRepository.ListAllAsync();

            return course;
        }
        public async Task<Course> AddAsync(Course course)
        {
            var tempcourse = await _courseRepository.AddAsync(course);

            return tempcourse;
        }
    }

}