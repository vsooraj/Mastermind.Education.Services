using AutoMapper;
using Mastermind.Education.Services.Entities;
using Mastermind.Education.Services.ViewModels;

namespace Mastermind.Education.Services.Infrastructure.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<EnrollmentRequestViewModel, Enrollment>()
            .ForMember(dest => dest.Course, opt => opt.Ignore())
            .ForMember(dest => dest.Student, opt => opt.Ignore())
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ReverseMap();

            CreateMap<StudentViewModel, Student>().ReverseMap();
            CreateMap<CourseViewModel, Course>().ReverseMap();

        }
    }
}
