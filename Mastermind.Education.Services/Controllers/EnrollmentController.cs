using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mastermind.Education.Services.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mastermind.Education.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private readonly IEnrollmentService _enrollmentService;

        public EnrollmentController(IEnrollmentService enrollmentService)
        {
            _enrollmentService = enrollmentService;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var items = await _enrollmentService.ListAllAsync();
            return Ok(items);

        }
        //// POST api/values
        //[HttpPost]
        //public void Post([FromBody] int courseId, int studentId)
        //{
        //    _enrollmentService.CreateEnrollmentAsync(courseId, studentId);
        //}

    }
}