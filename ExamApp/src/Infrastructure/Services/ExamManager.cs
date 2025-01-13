using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DocumentFormat.OpenXml.Bibliography;
using Domain.Entities;
using ExamApp.Application.Repositories;
using ExamApp.Application.Services;
using ExamApp.Application.ViewModels.Exam;
using ExamApp.Application.ViewModels.ExamResul;
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

    public async Task<Exam> GetIncludeAsync(int id)
    {
        return await _repository.GetIncludeAsync(id);
    }
    public async Task<ExamResultVM> GetExamResltIncludeAsync(int id)
    {
        Exam exam = await _repository.GetIncludeAsync(id);

        List<ExamResultCreateVM> vm = new List<ExamResultCreateVM>();

        if (exam?.Lesson.SchoolClass.Students!=null)
        {
            foreach (var item in exam.Lesson.SchoolClass.Students)
            {
                vm.Add(new ExamResultCreateVM
                {
                    StudentId = item.Id,
                    StudentNumber = item.Number,
                    StudentFullName = item.Name + " " +item.Surname,
                });
            }
        }

        ExamResultVM examResult = new ExamResultVM()
        {
            ExamId = exam.Id,
            LessonName=exam.Lesson.LessonName,
            LessonCode = exam.Lesson.LessonCode,
            ClassNumber = exam.Lesson.SchoolClass.Class,
            TeacherFullName = exam.Lesson.SchoolClass.Teacher.Name+" "+ exam.Lesson.SchoolClass.Teacher.Name,
            StudentCount = exam.Lesson.SchoolClass.Students.Count(),
            Date = exam.Date,   

            ExamResultStudents = vm
        };

        return examResult;
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



    public async Task CreateExamResult(ExamResultVM vm)
    {
        List<ExamResult> examResults = new List<ExamResult>();

        foreach (var result in vm.ExamResultStudents!)
        {
            examResults.Add(new ExamResult
            {
                LessonAverage = result.LessonAverage,
                ExamRes = result.ExamRes,
                Average = (result.LessonAverage + result.ExamRes) / 2,
                ExamId = vm.ExamId,
                StudentId = result.StudentId,
            });
        }
        Exam? ex = await _repository.GetAsync(vm.ExamId);

        ex.Status = true;
        ex.ClassAverage = examResults.Sum(x => x.Average) / examResults.Count();

        await _repository.CreateRangeAsync(examResults);
    }

}
