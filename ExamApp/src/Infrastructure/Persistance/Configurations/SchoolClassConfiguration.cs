using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure.Persistance.Configurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExamApp.Infrastructure.Persistance.Configurations;

public class SchoolClassConfiguration:BaseConfiguration<SchoolClass>
{
    public override void Configure(EntityTypeBuilder<SchoolClass> builder)
    {
        builder.Property(x => x.Class)
               .HasColumnType("numeric(2, 0)")
               .IsRequired(true);

        builder.HasMany(x => x.Students)
               .WithOne(x => x.SchoolClass)
               .HasForeignKey(x => x.SchoolClassId);

        builder.HasOne(x => x.Teacher)
               .WithMany(x => x.Classes)
               .HasForeignKey(x => x.TeacherId);

        base.Configure(builder);
    }
}
