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
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public StudentController(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var items = await _studentService.ListAllAsync();
            return Ok(items);

        }

        // GET: api/Student/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "student";
        }

        // POST: api/Student
        [HttpPost]
        public IActionResult Post([FromBody]StudentViewModel student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

 
            Student _newStudent = _mapper.Map<Student>(student);

            _studentService.AddAsync(_newStudent);

            return Ok();
        }

        // PUT: api/Student/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
           
        }
    }
}
