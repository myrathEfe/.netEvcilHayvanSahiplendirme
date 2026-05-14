ASP.NET Core MVC kullanarak katmanlı mimariye uygun bir web uygulaması geliştir.

Proje konusu: Evcil Hayvan Sahiplendirme Sistemi

Bu proje, kullanıcıların sahiplendirilecek evcil hayvan ilanlarını görüntüleyebileceği; yetkili kullanıcıların ilan ekleyip güncelleyip silebileceği bir web uygulaması olacaktır.

Teknolojiler:
- ASP.NET Core MVC
- C#
- Entity Framework Core
- SQL Server
- Razor Views
- Bootstrap
- Session tabanlı login sistemi

Katmanlı mimari zorunludur:
- Models
- Data Access Layer
- Services
- Controllers
- Views
- ViewModels kullanılabiliyorsa kullan

Temel gereksinimler:

1. Login sistemi:
- Kullanıcı adı ve şifre ile giriş yapılmalı.
- Kullanıcı bilgileri SQL Server veritabanında tutulmalı.
- Hatalı girişlerde kullanıcıya anlaşılır hata mesajı gösterilmeli.
- Başarılı girişten sonra session oluşturulmalı.
- Login olmayan kullanıcılar yönetim sayfalarına erişememeli.
- Logout işlemi olmalı.
- En az iki rol olsun:
  - ADMIN: İlan ekleme, silme, güncelleme yapabilir.
  - USER: İlanları sadece görüntüleyebilir.

2. Hayvan ilanı CRUD işlemleri:
Pet entity/model şu alanlara sahip olsun:
- Id
- Name
- Species: Kedi / Köpek / Kuş / Diğer
- Breed
- Age
- Gender
- City
- Description
- AdoptionStatus: Sahiplendirilebilir / Sahiplendirildi
- ImageData: byte[]
- ImageContentType: string
- CreatedDate

CRUD işlemleri:
- İlan ekleme
- İlan listeleme
- İlan detay görüntüleme
- İlan güncelleme
- İlan silme

3. Resim yükleme:
- İlan eklerken veya güncellerken hayvan fotoğrafı yüklenebilmeli.
- Resim dosya sisteminde değil, doğrudan SQL Server veritabanında VARBINARY(MAX) olarak saklanmalı.
- Model içinde byte[] ImageData kullanılmalı.
- Resim arayüzde görüntülenebilmeli.
- Bunun için özel bir action yaz:
  GET /Pet/Image/{id}
- Bu action veritabanındaki binary veriyi okuyup uygun content-type ile dönmeli.

4. Arama sistemi:
Kullanıcılar hayvan ilanları üzerinde arama yapabilmeli.
Arama alanları:
- Tür
- Cins
- Şehir
- Yaş aralığı
- Sahiplenme durumu
- İsim

Arama dinamik ve kullanıcı dostu olsun.
Listeleme sayfasında filtre formu bulunsun.
Sonuçlar kart yapısında gösterilsin.

5. Razor View arayüz:
Aşağıdaki sayfaları oluştur:
- Login.cshtml
- Index.cshtml
- Details.cshtml
- Create.cshtml
- Edit.cshtml
- Delete.cshtml
- Dashboard.cshtml
- Shared/_Layout.cshtml
- Shared/_Navbar.cshtml

Arayüz sade, anlaşılır ve öğrenci projesine uygun olsun.
Bootstrap kullan.
Form validasyon mesajları gösterilsin.

6. Validasyon:
- Name boş olamaz.
- Species boş olamaz.
- City boş olamaz.
- Age negatif olamaz.
- Description çok uzun olmamalı.
- Resim opsiyonel olabilir ama varsa image/jpeg veya image/png olmalı.

7. Veritabanı:
- SQL Server kullanılacak.
- Entity Framework Core kullanılacak.
- DbContext sınıfı oluştur.
- Migration yapısına uygun kod yaz.
- Program.cs içinde gerekli servis kayıtlarını yap.
- appsettings.json içinde connection string hazırla.
- Başlangıç için örnek admin ve user verisi eklenebilecek seed yapısı yaz.
- Örnek kullanıcılar:
  admin / admin123
  user / user123

8. Güvenlik:
ASP.NET Identity kullanmak zorunlu değil.
Basit session tabanlı authentication yapılabilir.
Ancak yönetim işlemleri session kontrolü ile korunmalı.
Admin olmayan kullanıcı Create/Edit/Delete sayfalarına erişememeli.

9. Kod kalitesi:
- Controller içinde fazla iş mantığı yazma.
- İş mantığı Service katmanında olsun.
- Data Access Layer veritabanı işlemleri için kullanılsın.
- Model, ViewModel, Service ayrımı düzgün olsun.
- Gereksiz karmaşık yapı kurma.
- Öğrenci projesi seviyesinde ama temiz, okunabilir ve sürdürülebilir olsun.

10. Teslim edilecek çıktı:
Bana tüm proje dosya yapısını oluştur.
Her dosyanın içeriğini eksiksiz ver.
Proje çalıştırma adımlarını da yaz:
- SQL Server veritabanı ayarı
- appsettings.json ayarı
- migration komutları
- dotnet run komutu
- Tarayıcıdan giriş adresi

Proje adı:
PetAdoptionSystem

Kodları eksiksiz, çalıştırılabilir ve açıklamalı şekilde oluştur.
