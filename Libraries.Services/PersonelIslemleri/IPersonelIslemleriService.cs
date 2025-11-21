using Libraries.core.Entities;
using Libraries.core.Entitis;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebShared.CO;
using WebShared.DTO;

namespace Libraries.Services.PersonelIslemleri
{
    public interface IPersonelIslemleriService
    {
        Task<Personel> GetByIdAsync(long id);
        Task<List<Personel>> GetAllAsync();
        Task<Personel> AddAsync(Personel personel);
        Task<PersonelListeDTO[]> PersonelListeGetirAsync(PersonelListeCO kriter);
    }
}
