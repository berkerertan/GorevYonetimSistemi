using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GorevYonetimSistemi.Entities.Concretes;

namespace GorevYonetimSistemi.Data.Concretes.Configurations
{
    public class TaskConfiguration : IEntityTypeConfiguration<ToDoTask>
    {

        public void Configure(EntityTypeBuilder<ToDoTask> builder)
        {
            builder.ToTable("Tasks").HasKey(x => x.Id);
            builder.Property(x => x.Title).HasColumnName("Title").IsRequired();
            builder.Property(x => x.Status).HasColumnName("Status").IsRequired();
            builder.Property(x => x.Description).HasColumnName("Description").IsRequired();
            builder.Property(x => x.UserId).HasColumnName("UserId").IsRequired();

            builder.HasOne(x => x.User);
        }
    }
}
