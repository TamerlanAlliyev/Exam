using Domain.Entities;
using ExamApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Teacher> Teachers { get; }
    DbSet<SchoolClass> SchoolClasses { get; }
    DbSet<Student> Students { get; }
    DbSet<Lesson> Lessons { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
