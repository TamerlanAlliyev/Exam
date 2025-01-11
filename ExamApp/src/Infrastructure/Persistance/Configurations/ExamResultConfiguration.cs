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

public class ExamResultConfiguration : BaseConfiguration<ExamResult>
{
    public override void Configure(EntityTypeBuilder<ExamResult> builder)
    {
        builder.Property(x => x.LessonAverage)
               .HasColumnType("decimal(5,2)")
               .IsRequired(true); ;

        builder.Property(x => x.ExamRes)
               .HasColumnType("decimal(5,2)")
               .IsRequired(true);

        builder.Property(x => x.Average)
               .HasColumnType("decimal(5,2)")
               .IsRequired(true);

        builder.HasOne(x=>x.Exam)
               .WithOne(x=>x.ExamResult)
               .HasForeignKey<ExamResult>(x=>x.ExamId);

        base.Configure(builder);
    }
}
