using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamApp.Domain.Entities;
using Infrastructure.Persistance.Configurations.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExamApp.Infrastructure.Persistance.Configurations
{
    public class StudentExamResultConfiguration:BaseConfiguration<StudentExamResult>
    {
        public override void Configure(EntityTypeBuilder<StudentExamResult> builder)
        {
            builder.HasOne(x=>x.Student)
                   .WithMany(x=>x.ExamResults)
                   .HasForeignKey(x=>x.Id);

            base.Configure(builder);
        }
    }
}
