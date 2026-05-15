# PetAdoptionSystem

ASP.NET Core MVC, Entity Framework Core ve SQL Server kullanılarak geliştirilmiş katmanlı bir evcil hayvan sahiplendirme sistemidir.

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
- İlanlarda iletişim numarası
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

## Çalıştırma Adımları

1. `appsettings.json` veya `appsettings.Development.json` içindeki `DefaultConnection` değerini kendi SQL Server bilginize göre güncelleyin.
2. Paketleri geri yükleyin:

```bash
dotnet restore
```

3. Projeyi derleyin:

```bash
dotnet build
```

4. Veritabanını oluşturun veya güncelleyin:

```bash
dotnet ef database update
```

`dotnet ef` komutu tanınmazsa EF Core CLI aracını yükleyin:

```bash
dotnet tool install --global dotnet-ef
```

5. Uygulamayı çalıştırın:

```bash
dotnet run
```

6. Tarayıcıdan açın:

- `https://localhost:xxxx/Account/Login`
- `https://localhost:xxxx/Pet`

Port numarasını terminal çıktısındaki `Now listening on` satırından görebilirsiniz.
