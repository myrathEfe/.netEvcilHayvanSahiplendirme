# Nilüfer Hayvan Sahiplendirme

ASP.NET Core MVC, Entity Framework Core ve SQL Server kullanilarak gelistirilmis, barinaga ait evcil hayvan sahiplendirme servisidir. Tum ilanlar icin sabit iletisim numarasi `444 16 03` kullanilir.

## Katmanlar

- `Models`: Entity ve enum sınıfları
- `Data`: `DbContext` ve seed yapısı
- `DataAccess`: Repository katmanı
- `Services`: İş mantığı
- `Controllers`: İstek yönetimi
- `ViewModels`: Form ve ekran modelleri
- `Views`: Razor arayüzü

## Proje Yapısı

```text
PetAdoptionSystem
|-- Controllers
|   |-- AccountController.cs
|   |-- DashboardController.cs
|   |-- HomeController.cs
|   `-- PetController.cs
|-- Data
|   |-- ApplicationDbContext.cs
|   |-- ApplicationDbContextFactory.cs
|   `-- SeedData.cs
|-- DataAccess
|   `-- Repositories
|-- Filters
|   `-- SessionAuthorizeAttribute.cs
|-- Helpers
|-- Migrations
|-- Models
|   |-- AppUser.cs
|   |-- Pet.cs
|   `-- Enums
|-- Services
|   |-- AuthService.cs
|   |-- IAuthService.cs
|   |-- IPetService.cs
|   |-- PetService.cs
|   `-- Models
|-- ViewModels
|-- Views
|   |-- Account
|   |-- Dashboard
|   |-- Pet
|   `-- Shared
|-- wwwroot
|-- Program.cs
|-- appsettings.json
`-- PetAdoptionSystem.csproj
```

## Özellikler

- Session tabanlı login ve logout
- `ADMIN` ve `USER` rol ayrımı
- Pet ilanları için CRUD işlemleri
- SQL Server içinde `VARBINARY(MAX)` olarak fotoğraf saklama
- `/Pet/Image/{id}` action'ı ile görsel gösterimi
- Tür, cins, şehir, yaş aralığı, durum ve isim filtreleriyle arama
- Tum ilanlarda sabit barinak telefonu kullanimi
- Bootstrap tabanlı arayüz

## Varsayılan Kullanıcılar

- `admin / admin123`
- `user / user123`

## SQL Server Bağlantı Ayarı

Bu proje ASP.NET Core MVC, Entity Framework Core ve SQL Server kullanır. Pet ilanlarına yüklenen görseller SQL Server içinde `VARBINARY(MAX)` olarak saklanır.

Projeyi çalıştırmadan önce `appsettings.json` içindeki `ConnectionStrings:DefaultConnection` değeri kendi SQL Server kurulumunuza göre güncellenmelidir. Geliştirme ortamında `appsettings.Development.json` varsa buradaki değer `appsettings.json` değerini override edebilir.

Windows + SQL Server Express için örnek:

```json
"DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=PetAdoptionSystemDb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;"
```

Windows default SQL Server instance için örnek:

```json
"DefaultConnection": "Server=localhost;Database=PetAdoptionSystemDb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;"
```

macOS kullanıcıları için not: SQL Server macOS üzerinde doğrudan `SQLEXPRESS` instance olarak çalışmaz. MacBook/macOS kullanıcıları genellikle Docker ile SQL Server container çalıştırarak bağlanır.

Mac Docker SQL Server için örnek:

```json
"DefaultConnection": "Server=localhost,1433;Database=PetAdoptionSystemDb;User Id=sa;Password=YourStrong!Passw0rd;TrustServerCertificate=True;MultipleActiveResultSets=true;"
```

`YourStrong!Passw0rd` sadece örnek şifredir. Docker container oluştururken hangi `SA` şifresini verdiyseniz connection string içinde de aynı şifreyi yazmalısınız. `appsettings.json` içindeki connection string kişisel geliştirme ortamına göre değişebilir.

Örnek Docker SQL Server komutu:

```bash
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=YourStrong!Passw0rd" -p 1433:1433 --name pet-adoption-sql -d mcr.microsoft.com/mssql/server:2022-latest
```

## Windows'ta Calistirma

1. Bilgisayarda .NET 8 SDK kurulu olsun.
2. SQL Server veya SQL Server Express kurulu olsun.
3. `appsettings.json` ya da `appsettings.Development.json` icindeki `DefaultConnection` degerini kendi SQL Server bilginize gore guncelleyin.
4. Proje klasorunde terminal acin:

```powershell
cd PetAdoptionSystem
dotnet restore
dotnet build
```

5. Gerekirse EF Core CLI aracini yukleyin:

```powershell
dotnet tool install --global dotnet-ef
```

6. Veritabanini olusturun/guncelleyin:

```powershell
dotnet ef database update
```

7. Uygulamayi baslatin:

```powershell
dotnet run
```

8. Terminalde yazan `Now listening on` adresini tarayicida acin. Genelde giris sayfasi `https://localhost:xxxx/Account/Login` olur.

## macOS'ta Calistirma

1. Bilgisayarda .NET 8 SDK kurulu olsun.
2. Docker Desktop kurulu olsun.
3. SQL Server container'ini baslatin:

```bash
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=YourStrong!Passw0rd" -p 1433:1433 --name pet-adoption-sql -d mcr.microsoft.com/mssql/server:2022-latest
```

4. `appsettings.json` ya da `appsettings.Development.json` icindeki `DefaultConnection` degerini container sifresine gore guncelleyin.
5. Proje klasorunde terminal acin:

```bash
cd PetAdoptionSystem
dotnet restore
dotnet build
```

6. Gerekirse EF Core CLI aracini yukleyin:

```bash
dotnet tool install --global dotnet-ef
```

7. Veritabanini olusturun/guncelleyin:

```bash
dotnet ef database update
```

8. Uygulamayi baslatin:

```bash
dotnet run
```

9. Terminalde yazan `Now listening on` adresini tarayicida acin.

## Hızlı Notlar

- Varsayilan kullanicilar: `admin / admin123` ve `user / user123`
- Uygulama ilk calistiginda `SeedData` migration'lari uygular ve eksik kullanicilari ekler.
- Iletisim numarasi sabittir: `444 16 03`
