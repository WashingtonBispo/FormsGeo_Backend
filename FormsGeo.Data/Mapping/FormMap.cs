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
    public class FormMap : IEntityTypeConfiguration<FormEntity>
    {
        public void Configure(EntityTypeBuilder<FormEntity> builder)
        {
            builder.ToTable("Form");

            builder.HasKey(e => e.idForm);

            builder.Property(e => e.questions).IsRequired();
            builder.Property(e => e.name).IsRequired();

            builder.Property(e => e.linkConsent).IsRequired();
            builder.Property(e => e.description).IsRequired();

            builder.Property(e => e.finalMessage).IsRequired();
            builder.Property(e => e.createdAt).IsRequired();

            builder.Property(e => e.updatedAt).IsRequired(false);
            builder.Property(e => e.deletedAt).IsRequired(false);

            builder.Property(e => e.gatherEnd).IsRequired();
            builder.Property(e => e.gatherPassage).IsRequired();

            builder.Property(e => e.icon).IsRequired();
            builder.Property(e => e.status).IsRequired();
        }
    }
}

