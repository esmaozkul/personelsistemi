using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libraries.core.Entitis
{
    public class Personel
    {
        public long Id { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public int Yas { get; set; }
        public decimal Kilo { get; set; }
        public DateTime DogumTarihi { get; set; }
        public DateTime? MezuniyetTarihi { get; set; }
        public string Adres { get; set; }
        public PersonelDetay PersonelDetay { get; set; }
    }
}
