using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entities;
using ExamApp.Application.Repositoriesp;
using ExamApp.Application.Services;
using ExamApp.Application.ViewModels.Lesson;
using ExamApp.Application.ViewModels.SchoolClass;
using ExamApp.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ExamApp.Infrastructure.Services;

public class LessonManager : ILessonService
{
    private readonly IMapper _mapper;

    private readonly ILessonRepository _repository;
    public LessonManager(IMapper mapper, ILessonRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<List<Lesson>> GetAllLessonAsync()
    {
        return await _repository.GetAllIncludeAsync();
    }

    public async Task CreateLessonAsync(LessonVM vm)
    {
        var lesson = _mapper.Map<Lesson>(vm);
        await _repository.CreateAsync(lesson);
    }


    public async Task<IEnumerable<SelectListItem>> GetSelectionClassAsync()
    {
        return await _repository.SelectionClassAsync();
    }

    public async Task<Lesson> GetIncludeAsync(int id)
    {
     return  await _repository.GetIncludeAsync(id);
    }

    public async Task LessonDeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }
}
