using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamApp.Domain.Entities;
using Infrastructure.Persistance.Configurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExamApp.Infrastructure.Persistance.Configurations;

public class ExamConfiguration:BaseConfiguration<Exam>
{
    public override void Configure(EntityTypeBuilder<Exam> builder)
    {
        builder.Property(x=>x.Status)
               .HasColumnType("bit")
               .HasDefaultValue(false);

        builder.Property(x=>x.Date)
               .HasColumnType("datetime2")
               .IsRequired(true);

        builder.Property(x=>x.ClassAverage)
               .HasColumnType("decimal(5,2)")
               .IsRequired(false);


        builder.HasOne(x => x.Lesson)
               .WithOne(x => x.Exam)
               .HasForeignKey<Lesson>(x => x.ExamId);

        base.Configure(builder);
    }
}
