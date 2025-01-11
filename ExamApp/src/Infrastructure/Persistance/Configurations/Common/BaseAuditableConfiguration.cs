using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Common;

namespace ExamApp.Infrastructure.Persistance.Configurations.Common;

public class BaseAuditableConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseAuditableEntity
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.Property(x => x.Number)
                    .HasColumnType("numeric(5, 0)")
                    .IsRequired(true);

        builder.HasIndex(x => x.Number)
               .IsUnique();

        builder.Property(x => x.Name)
               .HasColumnType("varchar")
               .HasMaxLength(30)
               .IsRequired(true);

        builder.Property(x => x.Surname)
               .HasColumnType("varchar")
               .HasMaxLength(30)
               .IsRequired(true);
    }
}


