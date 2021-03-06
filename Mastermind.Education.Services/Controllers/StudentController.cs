﻿using AutoMapper;
using Mastermind.Education.Services.ApplicationCore.Interfaces;
using Mastermind.Education.Services.Entities;
using Mastermind.Education.Services.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

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
        // GET api/student
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var items = await _studentService.ListAllAsync();
            return Ok(items);
        }

        // GET api/student/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id, string name)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var tempStud = new Student() { Id = id, Name = name };
            var items = await _studentService.ListAsync(tempStud);
            return Ok(items);
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

            return Ok(_newStudent);
        }

        // PUT: api/Student/5
        [HttpPut("{id}")]
        public IActionResult Put(int? id, [FromBody] StudentViewModel student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var tempStud = new Student() { Id = Convert.ToInt32(id), Name = student.Name };
            Student _newStudent = _mapper.Map<Student>(tempStud);
            _studentService.UpdateAsync(_newStudent);

            return Ok(_newStudent);
        }

        // DELETE: api/Student/5
        [HttpDelete("{Id}")]
        public IActionResult Delete(int? id)
        {

            if (id == null)
            {
                return BadRequest();
            }
            var _newStudent = new Student() { Id = Convert.ToInt32(id) };
            _studentService.DeleteAsync(_newStudent);

            return Ok();
        }
    }
}
