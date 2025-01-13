using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamApp.Application.Repositories;
using ExamApp.Application.ViewModels.ExamResul;
using ExamApp.Domain.Entities;
using Infrastructure.Persistance;

namespace ExamApp.Infrastructure.Repositories
{
    public class ExamResultRepository : BaseRepository<Domain.Entities.ExamResult>, IExamResultRepository
    {
        private readonly ApplicationDbContext _context;
        public ExamResultRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task CreateRangeAsync(List<ExamResult> entity)
        {
            await _context.AddRangeAsync(entity);
            await _context.SaveChangesAsync();
        }

        public Task<ExamResultVM> GetExamResltIncludeAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateExam(Exam exam)
        {
            _context.Update(exam);
            await _context.SaveChangesAsync();
        }
    }
}
