using Mastermind.Education.Services.ApplicationCore.Interfaces;
using Mastermind.Education.Services.ApplicationCore.Specification;
using Mastermind.Education.Services.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mastermind.Education.Services.ApplicationCore.Services
{
    public class CourseService : ICourseService
    {
        public readonly ICourseRepository _courseRepository;
        public CourseService(ICourseRepository courseRepository)
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
            var tempCourse = await _courseRepository.AddAsync(course);

            return tempCourse;
        }
        public async Task UpdateAsync(Course course)
        {
            await _courseRepository.UpdateAsync(course);

        }

        public async Task DeleteAsync(Course course)
        {
            await _courseRepository.DeleteAsync(course);

        }

        public async Task<IEnumerable<Course>> ListAsync(Course course)
        {
            var specification = new Specification<Course>(x => x.Name.Contains(course.Name) && x.Id == course.Id);
            IEnumerable<Course> tempCourse = await _courseRepository.ListAsync(specification);

            return tempCourse;
        }


    }

}
