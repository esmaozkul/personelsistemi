using Libraries.core.Entities.Mapping;
using Libraries.core.Entitis;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libraries.core
{
    ////dotnet tool install --global dotnet-ef --version 9.0.0    

    // cd  C:\Users\yazilim-2\Desktop\deneme\proje1
    // dotnet ef migrations add DbCreate --project Libraries.core --startup-project webApplication1
    // dotnet ef migrations add UpdateyyyyMMddHHmmss --project Libraries.core --startup-project webApplication1
    // dotnet ef migrations remove --project Libraries.core --startup-project webApplication1
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new PersonelMap());
            modelBuilder.ApplyConfiguration(new PersonelDetayMap());
        }

        public DbSet<Personel> Personel { get; set; }
        public DbSet<PersonelDetay> PersonelDetay { get; set; }
        //public DbSet<Birim> Birimler { get; set; }
        // diğer entity DbSet'leri...
    }
}
