using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Mastermind.Education.Services.ApplicationCore.Interfaces;
using Mastermind.Education.Services.Entities;
using Mastermind.Education.Services.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mastermind.Education.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : Controller
    {
        private readonly IEnrollmentService _enrollmentService;
        private readonly IMapper _mapper;

        public EnrollmentController(IEnrollmentService enrollmentService, IMapper mapper)
        {
            _enrollmentService = enrollmentService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var items = await _enrollmentService.ListAllAsync();
            return Ok(items);

        }
        // POST: api/Enrollment
        [HttpPost]
        public IActionResult Post([FromBody]EnrollmentRequestViewModel enrollment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            Enrollment _newEnrollment = _mapper.Map<Enrollment>(enrollment);

            _enrollmentService.AddAsync(_newEnrollment);

            return Ok();
        }

    }
}