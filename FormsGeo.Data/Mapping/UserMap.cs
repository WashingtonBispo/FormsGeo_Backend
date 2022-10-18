using FormsGeo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormsGeo.Data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("User");

            builder.HasKey(e => e.Email);

            builder.Property(e => e.Name).IsRequired();
            builder.Property(e => e.Password).IsRequired();

            builder.Property(e => e.Status).IsRequired();
            builder.Property(e => e.isAdmin).IsRequired();
        }
    }
}
