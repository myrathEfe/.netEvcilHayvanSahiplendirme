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
- Bootstrap tabanlı arayüz

## Varsayılan kullanıcılar

- `admin / admin123`
- `user / user123`

## Çalıştırma Adımları

1. `appsettings.json` içindeki `DefaultConnection` değerini kendi SQL Server bilginize göre güncelleyin.
2. Paketleri geri yükleyin:

```bash
dotnet restore
```

3. Bu teslimde `InitialCreate` migration dosyaları hazır geliyor. Veritabanını oluşturmak için şunu çalıştırın:

```bash
dotnet ef database update
```

4. Uygulamayı çalıştırın:

```bash
dotnet run
```

5. Tarayıcıdan açın:

- `https://localhost:xxxx/Account/Login`
- `https://localhost:xxxx/Pet`

Port numarasını terminal çıktısındaki `Now listening on` satırından görebilirsiniz.
