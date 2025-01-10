using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamApp.Domain.Entities;
using Infrastructure.Persistance.Configurations.Common;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExamApp.Infrastructure.Persistance.Configurations;

public class LessonConfiguration : BaseConfiguration<Lesson>
{
    public override void Configure(EntityTypeBuilder<Lesson> builder)
    {
        builder.Property(x => x.LessonCode)
               .HasColumnType("char(3)")
               .IsRequired(true);

        builder.Property(x => x.LessonName)
               .HasColumnType("varchar")
               .HasMaxLength(30);

        builder.HasOne(x => x.Teacher)
               .WithMany(x => x.Lessons)
               .HasForeignKey(x => x.TeacherId)
               .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(x => x.SchoolClass)
               .WithMany(x => x.Lessons)
               .HasForeignKey(x => x.SchoolClassId)
               .OnDelete(DeleteBehavior.NoAction);


        base.Configure(builder);
    }
}
