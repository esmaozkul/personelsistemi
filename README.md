Personel Takip Sistemi

Bu proje, C# MVC, Entity Framework ve Angular kullanarak geliştirilmiş bir personel takip sistemidir. Proje, personel verilerini yönetmek, listelemek ve görüntülemek için bir backend servis katmanı ve Angular tabanlı bir frontend içerir.

Teknolojiler

Backend: .NET 8 / MVC

ORM: Entity Framework Core

Frontend: Angular

Proje Yapısı:

Libraries.core → Entity ve DbContext tanımlamaları

Libraries.Services → Servis ve interface implementasyonları

WebShared → DTO ve CO (Criteria Object) sınıfları

WebApplication1 → MVC uygulaması

AngularProject → Angular frontend

Kurulum ve Çalıştırma
1. MVC Projesi Oluşturma ve Migration

Proje dizinine git:

cd C:\Users\yazilim-2\Desktop\deneme\proje1


Gerekli EF Core aracını yükle:

dotnet tool install --global dotnet-ef --version 9.0.0


Migration ekle:

dotnet ef migrations add DbCreate --project Libraries.core --startup-project WebApplication1
dotnet ef migrations add UpdateyyyyMMddHHmmss --project Libraries.core --startup-project WebApplication1


Eğer gerekirse migration kaldır:

dotnet ef migrations remove --project Libraries.core --startup-project WebApplication1

2. Libraries.core Yapılandırması

DbContext içerisine entityleri ekle:

public DbSet<PersonelDetay> PersonelDetay { get; set; }
// public DbSet<Birim> Birimler { get; set; }
// Diğer entity DbSet'leri buraya


MVC Controller'da servis çağrısını kullan:

public void PersonelListeGetir([FromBody] string[] Id /*PersonelListeCO kriter*/)
{
    // Burada servis çağrısı yapılacak
    // Dependency Injection unutma
}

3. Libraries.Services Projesi

Proje yapısı:

Libraries.Services/
  PersonelIslemleri/
    IPersonelIslemleri.cs
    PersonelIslemleri.cs


IPersonelIslemleri → interface, metod tanımları

PersonelIslemleri → interface implementasyonu, veri getirme ve kaydetme metodları

Örnek metod:

public PersonelListeDTO[] PersonelListeGetir(PersonelListeCO kriter)
{
    // Personel listesini getir
}

4. WebShared

DTO ve CO sınıfları:

WebShared/
  DTO/
    PersonelListeDTO.cs
  CO/
    PersonelListeCO.cs


Servisler bu DTO ve CO sınıflarını kullanarak veri aktarımı yapacak.

5. Angular Frontend

Angular proje dizinine git:

cd C:\Users\yazilim-2\Desktop\deneme\proje1\AngularProject


Angular uygulamasını başlat:

npx ng serve


İlk controller’dan API çağrısı yap ve ikinci controller’da göster.

Solution’da Properties kısmından hem MVC hem Angular projelerini seçerek birlikte çalıştığından emin ol.

Notlar

Migration işlemlerini yapmadan önce database bağlantısını appsettings.json üzerinden kontrol edin.

Servis çağrıları Dependency Injection ile yapılmalıdır.

Angular arayüzü API’dan veri çektikten sonra kullanıcıya listeler halinde gösterecek şekilde tasarlanmıştır.
