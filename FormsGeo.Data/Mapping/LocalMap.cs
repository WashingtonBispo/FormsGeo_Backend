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
    public class LocalMap : IEntityTypeConfiguration<LocalEntity>
    {
        public void Configure(EntityTypeBuilder<LocalEntity> builder)
        {
            builder.ToTable("Local");

            builder.HasKey(e => e.idLocal);

            builder.Property(e => e.radius).IsRequired();
            builder.Property(e => e.longitude).IsRequired();

            builder.Property(e => e.latitude).IsRequired();
        }
    }
}
