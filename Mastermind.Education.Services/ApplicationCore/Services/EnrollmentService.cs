using AutoMapper;
using Mastermind.Education.Services.ApplicationCore.Interfaces;
using Mastermind.Education.Services.ApplicationCore.Specification;
using Mastermind.Education.Services.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mastermind.Education.Services.ApplicationCore.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IAsyncRepository<Enrollment> _enrollmentRepository;

        public readonly IAsyncRepository<Student> _studentRepository;
        public readonly IAsyncRepository<Course> _courseRepository;
        private readonly IMapper _mapper;

        public EnrollmentService(IAsyncRepository<Enrollment> enrollmentRepository,
            IAsyncRepository<Student> studentRepository,
            IAsyncRepository<Course> courseRepository,
            IMapper mapper)
        {
            _enrollmentRepository = enrollmentRepository;
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
            _mapper = mapper;
        }
        public async Task<Enrollment> AddAsync(Enrollment enrollment)
        {
            var tempEnrollment = await _enrollmentRepository.AddAsync(enrollment);
            return tempEnrollment;

        }
        public async Task<IEnumerable<Enrollment>> ListAsync(Enrollment enrollment)
        {
            var spec = new Specification<Enrollment>(x => x.Student.Name.Contains(enrollment.Student.Name) || x.Course.Id == enrollment.CourseId);
            IEnumerable<Enrollment> tempEnrollment = await _enrollmentRepository.ListAsync(spec);
            return tempEnrollment;
        }

        public async Task<IEnumerable<EnrollmentViewModel>> ListAllAsync()
        {
            IEnumerable<Enrollment> enrollment = await _enrollmentRepository.ListAllAsync();
            IEnumerable<Student> student = await _studentRepository.ListAllAsync();
            IEnumerable<Course> course = await _courseRepository.ListAllAsync();
            var result = enrollment
               .Select(e => new
               {
                   e.Id,
                   e.CourseId,
                   Course = e.Course.Name,
                   NoOfDays = e.Course.NoOfDays,
                   e.StudentId,
                   Student = e.Student.Name,
                   e.Grade
               }).ToList();

            IEnumerable<EnrollmentViewModel> _newEnrollmentViewModel = _mapper.Map<IEnumerable<EnrollmentViewModel>>(result);

            return _newEnrollmentViewModel;

        }
        public async Task DeleteAsync(Enrollment enrollment)
        {
            await _enrollmentRepository.DeleteAsync(enrollment);
        }

    }


}
