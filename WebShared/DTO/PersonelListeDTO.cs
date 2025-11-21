using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShared.DTO
{
    public class PersonelListeDTO
    {
        public long Id { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public int Yas { get; set; }
        public decimal Kilo { get; set; }
        public DateTime DogumTarihi { get; set; }
        public DateTime? MezuniyetTarihi { get; set; }
        public string Adres { get; set; }
        public long PersonelId { get; set; }
        public string AnneAdi { get; set; }
        public string BabaAdi { get; set; }
        public string KanGrubu { get; set; }
        public string TelNo { get; set; }
        public string MailAdresi { get; set; }
    }
}
