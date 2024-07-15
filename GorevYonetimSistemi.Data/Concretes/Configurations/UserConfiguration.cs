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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users").HasKey(x => x.Id);
            builder.Property(x => x.Username).HasColumnName("Username").IsRequired();
            builder.Property(x => x.Password).HasColumnName("Password").IsRequired();
            builder.Property(x => x.RoleId).HasColumnName("RoleId").IsRequired(false);

            builder.HasMany(x => x.ToDoTasks);
        }
    }
}
