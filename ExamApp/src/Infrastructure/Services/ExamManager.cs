using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ExamApp.Application.Repositories;
using ExamApp.Application.Services;
using ExamApp.Application.ViewModels.Exam;
using ExamApp.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ExamApp.Infrastructure.Services;

public class ExamManager : IExamService
{
    private readonly IExamRepository _repository;
    private readonly IMapper _mapper;
    public ExamManager(IExamRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<Exam>> GetAllExamAsync()
    {
        var exam = await _repository.GetAllIncludeAsync();
        return exam;
    }
    public async Task DeleteExamAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }
    public async Task CreateExamAsync(ExamCreateVM vm)
    {
       await _repository.CreateAsync(_mapper.Map<Exam>(vm));
    }

    public async Task<IEnumerable<SelectListItem>> GetSelectionLessonAsync()
    {
        return await _repository.SelectionLessonAsync();
    }
}
