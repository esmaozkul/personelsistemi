using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libraries.core.Entitis
{
    public class PersonelDetay
    {
        public long Id { get; set; }
        public long PersonelId { get; set; }
        public string AnneAdi {  get; set; }
        public string BabaAdi { get; set; }
        public string KanGrubu { get; set; }
        public string TelNo {  get; set; }
        public string MailAdresi {  get; set; }
    }
}
