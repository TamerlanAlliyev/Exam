using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;
using ExamApp.Application.Repositories;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace ExamApp.Infrastructure.Repositories;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
{
    private readonly ApplicationDbContext _context;

    public BaseRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task CreateAsync(TEntity entity)
    {
        await _context.Set<TEntity>().AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _context.Set<TEntity>().FindAsync(id);
        _context.Set<TEntity>().Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<TEntity?> GetAsync(int id)
    {
        return await _context.Set<TEntity>().FindAsync(id);
    }


    public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression = null, params string[] includes)
    {
        var entity = _context.Set<TEntity>().AsQueryable();
        foreach (var type in includes)
        {
            entity = entity.Include(type);
        }
        return expression == null ?
               await entity.ToListAsync() :
               await entity.Where(expression).ToListAsync();
    }
}
