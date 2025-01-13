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
using SendGrid.Helpers.Errors.Model;

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
        if (entity == null)
        {
            throw new KeyNotFoundException($"Entity with id {id} was not found.");
        }
        _context.Set<TEntity>().Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<TEntity?> GetAsync(int id)
    {
        return await _context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> expression, params string[] includes)
    {
        var query = _context.Set<TEntity>().AsQueryable();
        foreach (var include in includes)
        {
            query = query.Include(include);
        }
        return await query.FirstOrDefaultAsync(expression);
    }

    public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? expression = null, params string[] includes)
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

    public async Task UpdateAsync(TEntity entity)
    {
        _context.Set<TEntity>().Update(entity);
        await _context.SaveChangesAsync();
    }
}
