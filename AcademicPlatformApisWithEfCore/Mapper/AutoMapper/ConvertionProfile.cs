using AcademicPlatformApisWithEfCore.Domain.DTOs.Request;
using AcademicPlatformApisWithEfCore.Domain.DTOs.Response;
using AcademicPlatformApisWithEfCore.Domain.Entities;
using AutoMapper;

namespace AcademicPlatformApisWithEfCore.Mapper.AutoMapper
{
    public class ConvertionProfile : Profile
    {
        public ConvertionProfile()
        {
            CreateMap<User, UserResponseDto>();
            CreateMap<UserCreationRequestDto, User>();
            CreateMap<Teacher, TeacherResponseDto>();
            CreateMap<TeacherCreationRequestDto, Teacher>();
            CreateMap<Course, CourseResponseDto>();
            CreateMap<CourseCreationRequestDto, Course>();
            CreateMap<CourseEntry, CourseEntryResponseDto>();
            CreateMap<CourseEntryCreationRequestDto, CourseEntry>();
        }
    }
}
