using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entities;
using ExamApp.Application.Repositories;
using ExamApp.Application.Services;
using ExamApp.Application.ViewModels.SchoolClass;
using ExamApp.Application.ViewModels.Teacher;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting;


namespace ExamApp.Infrastructure.Services;

public class SchoolClassManager : ISchoolClassService
{
    private readonly ISchoolClassRepository _repository;
    private readonly IMapper _mapper;

    public SchoolClassManager(IMapper mapper, ISchoolClassRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<SchoolClassCreateVM> CreateSchoolClassAsync(SchoolClassCreateVM vm)
    {
        var schoolClass = _mapper.Map<SchoolClass>(vm);
        await _repository.CreateAsync(schoolClass);
        return vm;
    }

    public async Task CreateSchoolClassAsync(SchoolClassVM vm)
    {
        var schoolClass = _mapper.Map<SchoolClass>(vm);
        await _repository.CreateAsync(schoolClass);
    }

    public async Task<List<SchoolClass>> GetAllSchoolClassAsync()
    {
        return await _repository.GetAllAsync(null, "Teacher", "Students");
    }

    public async Task<SchoolClassVM> GetSchoolClassAsync(int id)
    {
        SchoolClass? schoolClass = await _repository.GetAsync(id);
        return _mapper.Map<SchoolClassVM>(schoolClass);
    }

    public async Task DeleteSchoolClassAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }

    public async Task<IEnumerable<SelectListItem>> GetSelectionTeacher()
    {
        return await _repository.SelectionTeacher();
    }

   
}

