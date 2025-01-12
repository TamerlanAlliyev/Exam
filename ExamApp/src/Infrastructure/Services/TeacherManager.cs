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
using ExamApp.Application.ViewModels.Teacher;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;


namespace ExamApp.Infrastructure.Services;

public class TeacherManager : ITeacherService
{
    private readonly ITeacherRepository _repository;
    private readonly IHostEnvironment _environment;
    private readonly IMapper _mapper;
    public TeacherManager(IHostEnvironment environment, IMapper mapper, ITeacherRepository repository)
    {
        _environment = environment;
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<TeacherCreateVM> CreateTeacherAsync(TeacherCreateVM vm)
    {
        var fileName = await vm.Image.SaveFileAsync(Path.Combine(_environment.ContentRootPath, "wwwroot", "assets", "images", "teachers"));
        Teacher teacher = _mapper.Map<Teacher>(vm);
        teacher.ImageURL = fileName;
        await _repository.CreateAsync(teacher);
        return vm;
    }


    public async Task DeleteTeacherAsync(int id)
    {
        TeacherVM teacher = await GetTeacherAsync(id);
        if (teacher == null) throw new Exception("Id is incorrect");
        await _repository.DeleteAsync(id);
        FileExtension.DeleteFile(Path.Combine(_environment.ContentRootPath, "wwwroot", "assets", "images", "teachers"), teacher.ImageURL);
    }

    public async Task<IEnumerable<TeacherVM>> GetAllTeacherAsync()
    {
        var teachers = await _repository.GetAllAsync();
        return _mapper.Map<List<TeacherVM>>(teachers);
    }

 
    public async Task<bool> GetAnyTeacherAsync(int number)
    {
        return await _repository.GetAnyAsync(number);
    }

    public async Task<TeacherVM> GetTeacherAsync(int id)
    {
        Teacher? teachers = await _repository.GetAsync(id);
        return _mapper.Map<TeacherVM>(teachers);
    }

}
