using Domain.Entities;
using ExamApp.Infrastructure.Persistance.Configurations.Common;
using Infrastructure.Persistance.Configurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistance.Configurations
{
    public class TeacherConfiguration : BaseAuditableConfiguration<Teacher>
    {
        public override void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.Property(x=>x.Specialization)
                   .HasMaxLength(30)
                   .HasColumnType("varchar")
                   .IsRequired(true);

            base.Configure(builder); 
        }
    }
}
