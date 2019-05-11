using AutoMapper;
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
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;
        private readonly IMapper _mapper;

        public CourseController(ICourseService courseService, IMapper mapper)
        {
            _courseService = courseService;
            _mapper = mapper;
        }
        // GET api/student
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var items = await _courseService.ListAllAsync();
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
            var tempCourse = new Course() { Id = id, Name = name };
            var items = await _courseService.ListAsync(tempCourse);
            return Ok(items);
        }

        // POST: api/Student
        [HttpPost]
        public IActionResult Post([FromBody]CourseViewModel course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Course _newCourse = _mapper.Map<Course>(course);
            _courseService.AddAsync(_newCourse);

            return Ok(_newCourse);
        }

        // PUT: api/Student/5
        [HttpPut("{id}")]
        public IActionResult Put(int? id, [FromBody] CourseViewModel course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var tempCourse = new Course() { Id = Convert.ToInt32(id), Name = course.Name };
            Course _newCourse = _mapper.Map<Course>(tempCourse);
            _courseService.UpdateAsync(_newCourse);

            return Ok(_newCourse);
        }

        // DELETE: api/Student/5
        [HttpDelete("{Id}")]
        public IActionResult Delete(int? id)
        {

            if (id == null)
            {
                return BadRequest();
            }
            var _newCourse = new Course() { Id = Convert.ToInt32(id) };
            _courseService.DeleteAsync(_newCourse);

            return Ok();
        }
    }
}