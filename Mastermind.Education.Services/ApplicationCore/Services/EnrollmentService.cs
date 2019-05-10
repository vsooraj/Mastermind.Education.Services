using AutoMapper;
using Mastermind.Education.Services.ApplicationCore.Interfaces;
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
        private readonly IMapper _mapper;

        public EnrollmentService(IAsyncRepository<Enrollment> enrollmentRepository, IAsyncRepository<Student> studentRepository, IMapper mapper)
        {
            _enrollmentRepository = enrollmentRepository;
            _studentRepository = studentRepository;
            _mapper = mapper;
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

        public async Task<IEnumerable<EnrollmentViewModel>> ListAllAsync()
        {
            IEnumerable<Enrollment> enrollment = await _enrollmentRepository.ListAllAsync();
            IEnumerable<Student> student = await _studentRepository.ListAllAsync();
            //IEnumerable<Course> course =new Course() { }

            var result = enrollment
               .Select(e => new
               {
                   e.Id,
                   e.CourseId,
                   Course = e.Course.Name,
                   e.StudentId,
                   Student = e.Student.Name,
                   e.Grade
               }).ToList();

            //var list = enrollment
            //    .Join(student,
            //        c => c.StudentId,
            //        o => o.Id,
            //        (c, o) => new
            //                {
            //                c.Id,
            //                Student = o.Name,
            //                Course = c.CourseId,
            //                c.Grade
            //                })
            //    .ToList();
            IEnumerable<EnrollmentViewModel> _newEnrollmentViewModel = _mapper.Map<IEnumerable<EnrollmentViewModel>>(result);

            return _newEnrollmentViewModel;

        }
    }
}
