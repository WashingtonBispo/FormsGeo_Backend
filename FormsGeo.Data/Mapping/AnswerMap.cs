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
    public class AnswerMap : IEntityTypeConfiguration<AnswerEntity>
    {
        public void Configure(EntityTypeBuilder<AnswerEntity> builder)
        {
            builder.ToTable("Answer");

            builder.HasKey(e => e.answerId);

            builder.Property(e => e.answer).IsRequired();
            builder.Property(e => e.geolocation).IsRequired();

            builder.Property(e => e.typeAnswer).IsRequired();
            builder.Property(e => e.idParticipante).IsRequired();
        }
    }
}
