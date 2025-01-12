using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entities;
using ExamApp.Application.Common.Extensions;
using ExamApp.Application.Repositories;
using ExamApp.Application.Services;
using ExamApp.Application.ViewModels.Student;
using ExamApp.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting;

namespace ExamApp.Infrastructure.Services;

public class StudentManager : IStudentService
{
    private readonly IStudentRepository _repository;
    private readonly IMapper _mapper;
    private readonly IHostEnvironment _environment;
    public StudentManager(IStudentRepository studentRepository, IMapper mapper, IHostEnvironment environment )
    {
        _repository = studentRepository;
        _mapper = mapper;
        _environment = environment;
    }

    public async Task<List<Student>> GetAllStudent()
    {
        return await _repository.GetAllAsync(null, "SchoolClass");
    }

    public async Task<StudentVM> GetStudentAsync(int id)
    {
        var s = await _repository.GetAsync(s => s.Id == id, "SchoolClass");
        return _mapper.Map<StudentVM>(s);
    }

    public async Task DeleteStudentAsync(int id)
    {
         await _repository.DeleteAsync(id);
    }

    public async Task CreateStudentAsync(StudentCreateVM vm)
    {
        var fileName = await vm.Image.SaveFileAsync(Path.Combine(_environment.ContentRootPath, "wwwroot", "assets", "images", "students"));
        //Student student = _mapper.Map<Student>(fileName);
        Student student = new Student()
        {
            Name = vm.Name,
            Surname = vm.Surname,
            Number = vm.Number,
            SchoolClassId = vm.ClassId,
            ImageURL = fileName,
        };

        await _repository.CreateAsync(student);
    }

    public async Task<IEnumerable<SelectListItem>> GetSelectionClass()
    {
        return await _repository.SelectionClass();
    }

    public async Task<bool> GetAnyStudentAsync(int num)
    {
        return await _repository.AnyStudentAsync(num);
    }
}
