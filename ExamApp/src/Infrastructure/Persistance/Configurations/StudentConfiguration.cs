using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamApp.Domain.Entities;
using ExamApp.Infrastructure.Persistance.Configurations.Common;
using Infrastructure.Persistance.Configurations.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExamApp.Infrastructure.Persistance.Configurations;

public class StudentConfiguration: BaseAuditableConfiguration<Student>
{
    public override void Configure(EntityTypeBuilder<Student> builder)
    {
        
        base.Configure(builder);
    }
}
