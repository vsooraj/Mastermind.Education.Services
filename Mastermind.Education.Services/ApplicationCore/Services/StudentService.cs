﻿using Mastermind.Education.Services.ApplicationCore.Interfaces;
using Mastermind.Education.Services.ApplicationCore.Specification;
using Mastermind.Education.Services.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mastermind.Education.Services.ApplicationCore.Services
{
    public class StudentService : IStudentService
    {
        public readonly IAsyncRepository<Student> _studentRepository;
        public StudentService(IAsyncRepository<Student> studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<IEnumerable<Student>> ListAllAsync()
        {
            IEnumerable<Student> student = await _studentRepository.ListAllAsync();

            return student;
        }
        public async Task<IEnumerable<Student>> ListAsync(Student student)
        {
            var spec = new Specification<Student>(x => x.Name == student.Name);
            IEnumerable<Student> tempstudent = await _studentRepository.ListAsync(spec);

            return tempstudent;
        }
        public async Task<Student> AddAsync(Student student)
        {
           var tempStudent =  await _studentRepository.AddAsync(student);

            return tempStudent;
        }
        public async Task UpdateAsync(Student student)
        {
             await _studentRepository.UpdateAsync(student);

        }

        public async Task DeleteAsync(Student student)
        {
            await _studentRepository.DeleteAsync(student);

        }
    }
}
