using AutoMapper;
using Mastermind.Education.Services.Entities;
using Mastermind.Education.Services.ViewModels;

namespace Mastermind.Education.Services.Infrastructure.Mappings
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<StudentViewModel, Student>().ReverseMap();
        }
        
    }
}