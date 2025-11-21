using Libraries.core;
using Libraries.core.Entities;
using Libraries.core.Entitis;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebShared.CO;
using WebShared.DTO;

namespace Libraries.Services.PersonelIslemleri
{
    public class PersonelIslemleriService : IPersonelIslemleriService
    {

        //PersonelListeGetir metodu yazacağız.
        //Parametre olarak PersonelListeCO alacak (CO => Criteria Object)
        //Method PersonelListeDTO[] dönecek  (DTO => Data Transfer Object)

        //--WebShared
        //----DTO (Klasör)
        //------PersonelListeDTO.cs 
        //----CO (Klasör)
        //------PersonelListeCO.cs


        //public PersonelListeDTO[] PersonelListeGetir(PersonelListeCO kriter) {     }
        public DbSet<Personel> Personel { get; set; }
        public DbSet<PersonelDetay> PersonelDetay { get; set; }
        private readonly ApplicationDbContext _context;
        public PersonelIslemleriService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PersonelListeDTO[]> PersonelListeGetirAsync(PersonelListeCO kriter)
        {

            var query = _context.Personel.Include(p => p.PersonelDetay).AsQueryable();

            if (!string.IsNullOrEmpty(kriter.Adi)) { 
            query = query.Where(x => x.Adi.Contains(kriter.Adi)); }

            if (!string.IsNullOrEmpty(kriter.Soyadi))
            {
                query = query.Where(x => x.Soyadi.Contains(kriter.Soyadi));
            }
            if (!string.IsNullOrEmpty(kriter.Adres))
            {
                query = query.Where(x => x.Adres.Contains(kriter.Adres));
            }

            return await query.Select(x => new PersonelListeDTO
            {
                Id = x.Id,
                Adi = x.Adi,
                Soyadi = x.Soyadi,
                Yas = x.Yas,
                Kilo = x.Kilo,
                Adres = x.Adres,
                DogumTarihi = x.DogumTarihi,
                MezuniyetTarihi = x.MezuniyetTarihi,
            }).ToArrayAsync();
        }
        public async Task<Personel> GetByIdAsync(long id)
        {
            return null;
        }

        public async Task<List<Personel>> GetAllAsync()
        {
            return new List<Personel>();
        }

        public async Task<Personel> AddAsync(Personel personel)
        {
            return personel;
        }
    }
}
