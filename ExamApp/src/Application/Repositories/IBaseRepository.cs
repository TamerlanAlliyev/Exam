using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;

namespace ExamApp.Application.Repositories;

public interface IBaseRepository<TEntity> where TEntity : BaseEntity
{
    Task CreateAsync(TEntity entity);
    Task DeleteAsync(int id);
    Task<TEntity?> GetAsync(int id);
    Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> expression, params string[] includes);
    Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? expression = null, params string[] includes);
}
