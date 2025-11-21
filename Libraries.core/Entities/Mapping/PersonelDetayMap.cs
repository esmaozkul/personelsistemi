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
    public class PersonelDetayMap : IEntityTypeConfiguration<PersonelDetay>
    {
        public void Configure(EntityTypeBuilder<PersonelDetay> builder)
        {
            builder.ToTable(nameof(PersonelDetay));
            builder.HasKey(p => p.Id);
            //builder.Property(p => p.Id).HasDefaultValueSql("NEWSEQUENTIALID()");

            builder.Property(d => d.MailAdresi).HasMaxLength(512);
            builder.Property(d => d.AnneAdi).HasMaxLength(128);
            builder.Property(d => d.BabaAdi).HasMaxLength(128);            
        }
    }
}
