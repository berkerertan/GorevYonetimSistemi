using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GorevYonetimSistemi.Data.Concretes.Configurations
{
    public class TaskConfiguration : IEntityTypeConfiguration<Entities.Concretes.Task>
    {

        public void Configure(EntityTypeBuilder<Entities.Concretes.Task> builder)
        {
            builder.ToTable("Task");
            builder.Property(x => x.Title).HasColumnName("Title").IsRequired();
            builder.Property(x => x.Status).HasColumnName("Status").IsRequired();
            builder.Property(x => x.Description).HasColumnName("Description").IsRequired();
            builder.Property(x => x.UserId).HasColumnName("UserId").IsRequired();

            builder.HasOne(x => x.User);
        }
    }
}
