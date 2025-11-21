using Libraries.core.Entitis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libraries.core.Entities.Mapping
{
    public class PersonelMap : IEntityTypeConfiguration<Personel>
    {
        public void Configure(EntityTypeBuilder<Personel> builder)
        {
            builder.ToTable(nameof(Personel));
            builder.Property(p => p.Id);


            builder.Property(d => d.Adi).HasMaxLength(256);
            builder.Property(d => d.Soyadi).HasMaxLength(256);
            builder.Property(d => d.Adres).HasMaxLength(1024);
            builder.Property(d => d.DogumTarihi).IsRequired(true);
        }
    }
}
