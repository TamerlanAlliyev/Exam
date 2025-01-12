using System;
using AutoMapper;
using Domain.Entities;
using ExamApp.Application.ViewModels.Exam;
using ExamApp.Application.ViewModels.Lesson;
using ExamApp.Application.ViewModels.SchoolClass;
using ExamApp.Application.ViewModels.Student;
using ExamApp.Application.ViewModels.Teacher;
using ExamApp.Domain.Entities;

namespace ExamApp.Application.Common.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<TeacherCreateVM, Teacher>()
            .ForMember(dest => dest.ImageURL, opt => opt.MapFrom(src => src.Image != null ? src.Image.FileName : null));
        CreateMap<Teacher, TeacherVM>().ReverseMap();

        CreateMap<SchoolClass, SchoolClassVM>().ReverseMap();
        CreateMap<SchoolClass, SchoolClassCreateVM>().ReverseMap();

        // Student Mapping
        CreateMap<StudentCreateVM, Student>()
            .ForMember(dest => dest.ImageURL, opt => opt.MapFrom(src => src.Image != null ? src.Image.FileName : null)) 
            .ForMember(dest => dest.SchoolClassId, opt => opt.MapFrom(src => src.ClassId)); 

        CreateMap<Student, StudentVM>().ReverseMap();

        CreateMap<Lesson, LessonVM>().ReverseMap();

        CreateMap<Exam, ExamVM>().ReverseMap();
        CreateMap<Exam, ExamCreateVM>().ReverseMap();
    }
}

