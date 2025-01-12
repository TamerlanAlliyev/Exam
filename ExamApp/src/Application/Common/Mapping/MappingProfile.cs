using System;
using AutoMapper;
using Domain.Entities;
using ExamApp.Application.ViewModels.SchoolClass;
using ExamApp.Application.ViewModels.Teacher;

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
    }
}

