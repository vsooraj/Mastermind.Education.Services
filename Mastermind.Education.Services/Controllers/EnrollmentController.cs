using AutoMapper;
using Mastermind.Education.Services.ApplicationCore.Interfaces;
using Mastermind.Education.Services.ApplicationCore.Services;
using Mastermind.Education.Services.Entities;
using Mastermind.Education.Services.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mastermind.Education.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : Controller
    {
        private readonly IEnrollmentService _enrollmentService;
        private readonly IStudentService _studenttService;
        private readonly ICourseService _coursetService;
        private readonly IMapper _mapper;

        public EnrollmentController(IEnrollmentService enrollmentService, ICourseService coursetService, IStudentService studenttService, IMapper mapper)
        {
            _enrollmentService = enrollmentService;
            _studenttService = studenttService;
            _coursetService = coursetService;

            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            ResponseModel responseData = new ResponseModel
            {
                Enrollments = await _enrollmentService.ListAllAsync(),
                Students = await _studenttService.ListAllAsync(),
                Courses = await _coursetService.ListAllAsync()
            };

            return Ok(responseData);

        }
        // POST: api/Enrollment
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]EnrollmentRequestViewModel enrollment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Enrollment _newEnrollment = _mapper.Map<Enrollment>(enrollment);
            await _enrollmentService.AddAsync(_newEnrollment);

            return Ok(_newEnrollment);
        }

        // PUT: api/Student/5
        [HttpPut("{id}")]
        public IActionResult Put(int? id, [FromBody] EnrollmentRequestViewModel enrollment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var tempEnrollment = new Enrollment() { Id = Convert.ToInt32(id), StudentId = enrollment.StudentId, CourseId = enrollment.CourseId, Grade = enrollment.Grade };
            Enrollment _newEnrollment = _mapper.Map<Enrollment>(tempEnrollment);
            _enrollmentService.UpdateAsync(_newEnrollment);

            return Ok(_newEnrollment);
        }
        // DELETE: api/Student/5
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int? id)
        {

            if (id == null)
            {
                return BadRequest();
            }
            var _newEnrollment = new Enrollment() { Id = Convert.ToInt32(id) };
            await _enrollmentService.DeleteAsync(_newEnrollment);

            return Ok(id);
        }



    }
    public class ResponseModel
    {
        public IEnumerable<EnrollmentViewModel> Enrollments { get; set; }
        public IEnumerable<Student> Students { get; set; }
        public IEnumerable<Course> Courses { get; set; }
    }

}