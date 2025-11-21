using System;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Libraries.Services.PersonelIslemleri;
using Libraries.core;
using WebShared.CO;
using WebShared.DTO;

namespace WinFormsApp
{
    public partial class Form1 : Form
    {
        // 1️⃣ _personelService field olarak tanımlandı
        private readonly IPersonelIslemleriService _personelService;

        public Form1()
        {
            InitializeComponent();

            // 2️⃣ DbContext oluşturuluyor
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer("Server=.;Database=DbName;Trusted_Connection=True;") // kendi veritabanın
                .Options;

            var context = new ApplicationDbContext(options);

            // 3️⃣ Servisi oluştur
            _personelService = new PersonelIslemleriService(context);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 4️⃣ DataGridView ayarları
          //  dgvPersonelListe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
          //  dgvPersonelListe.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
          //  dgvPersonelListe.ReadOnly = true;
        }

        // 5️⃣ Buton click async olmalı
        private async void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var kriter = new PersonelListeCO
                {
                    Adi = "",
                    Soyadi = "",
                    Adres = ""
                };

                // 6️⃣ Servisten veri çek
                PersonelListeDTO[] personeller = await _personelService.PersonelListeGetirAsync(kriter);

                // 7️⃣ DataGridView'e bağla
              //  dgvPersonelListe.DataSource = personeller;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }
    }
}
