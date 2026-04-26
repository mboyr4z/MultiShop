# 🛒 MultiShop — Mikroservis E-Ticaret Platformu

MultiShop, **ASP.NET Core** ve **mikroservis mimarisi** kullanılarak geliştirilmiş kapsamlı bir e-ticaret platformudur. Her servis bağımsız olarak çalışır, kendi veritabanına sahiptir ve REST API üzerinden iletişim kurar.

---

## 🏗️ Mimari

```
MultiShop
├── IdentityServer          → Kimlik doğrulama & yetkilendirme (Port: 5001)
├── Services
│   ├── Catalog             → Ürün & kategori yönetimi (Port: 7070)
│   ├── Discount            → İndirim kuponu yönetimi (Port: 7071)
│   ├── Order               → Sipariş yönetimi (Port: 7072)
│   ├── Cargo               → Kargo yönetimi (Port: 7073)
│   └── Basket              → Sepet yönetimi (Port: 7074)
└── FrontEnds
    └── WebUI               → Kullanıcı arayüzü (Port: 7203)
```

---

## 🚀 Teknolojiler

| Katman | Teknoloji |
|--------|-----------|
| Framework | ASP.NET Core 8.0 |
| Kimlik Doğrulama | IdentityServer4, JWT Bearer Token |
| Veritabanı | MongoDB, Microsoft SQL Server, Redis |
| ORM | Entity Framework Core 8 |
| API Dokümantasyon | Swagger / OpenAPI |
| Mimari | Mikroservis, Clean Architecture, CQRS |
| Tasarım Deseni | Repository Pattern, CQRS (Order servisi) |

---

## 📦 Servisler

### 🔐 IdentityServer (Port: 5001)
- IdentityServer4 ile merkezi kimlik doğrulama
- JWT token üretimi ve yönetimi
- Kullanıcı kaydı ve girişi
- **Veritabanı:** SQL Server

### 📋 Catalog Servisi (Port: 7070)
- Ürün CRUD işlemleri
- Kategori yönetimi
- Ürün detay ve görsel yönetimi
- **Veritabanı:** MongoDB

### 💰 Discount Servisi (Port: 7071)
- İndirim kuponu oluşturma ve yönetimi
- Kupon doğrulama
- **Veritabanı:** SQL Server

### 📦 Order Servisi (Port: 7072)
- Sipariş oluşturma ve takibi
- Adres yönetimi
- **Mimari:** Clean Architecture + CQRS
- **Veritabanı:** SQL Server

### 🚚 Cargo Servisi (Port: 7073)
- Kargo şirketi yönetimi
- Kargo müşteri takibi
- Kargo operasyon yönetimi
- **Veritabanı:** SQL Server

### 🛒 Basket Servisi (Port: 7074)
- Kullanıcı sepet işlemleri
- Ürün ekleme / çıkarma
- **Veritabanı:** Redis

### 🖥️ WebUI (Port: 7203)
- ASP.NET Core MVC
- Tüm servislere HTTP Client ile bağlantı
- Kullanıcı dostu alışveriş arayüzü
- Admin paneli (Kategori & Ürün yönetimi)

---

## ⚙️ Kurulum

### Gereksinimler

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [MongoDB](https://www.mongodb.com/try/download/community)
- [Microsoft SQL Server](https://www.microsoft.com/tr-tr/sql-server/sql-server-downloads)
- [Redis](https://github.com/tporadowski/redis/releases)

### 1. Servisleri Başlat

**MongoDB, SQL Server ve Redis'in çalıştığından emin ol:**

```powershell
Get-Service | Where-Object {$_.Name -like "*mongo*" -or $_.Name -like "*redis*" -or $_.Name -like "*mssql*"}
```

### 2. Projeyi Klonla

```bash
git clone https://github.com/kullanici-adi/MultiShop.git
cd MultiShop
```

### 3. Visual Studio'da Çalıştır

1. `MultiShop.sln` dosyasını Visual Studio ile aç
2. Solution'a sağ tıkla → **"Başlangıç Projelerini Yapılandır"**
3. Aşağıdaki projeleri **"Başlat"** olarak işaretle:
   - MultiShop.IdentityServer
   - MultiShop.Catalog
   - MultiShop.Discount
   - MultiShop.Order.WebApi
   - MultiShop.Cargo.WebApi
   - MultiShop.Basket
   - MultiShop.WebUI
4. **F5** ile başlat

### 4. Tarayıcıda Aç

```
http://localhost:5123
```

---

## 🗄️ Veritabanı Bağlantıları

| Servis | Veritabanı | Bağlantı |
|--------|-----------|----------|
| Catalog | MongoDB | mongodb://localhost:27017 |
| Basket | Redis | localhost:6379 |
| Discount | SQL Server | Server=localhost |
| Order | SQL Server | Server=localhost |
| Cargo | SQL Server | Server=localhost |
| IdentityServer | SQL Server | Server=localhost |

---

## 📡 API Endpointleri (Swagger)

| Servis | Swagger URL |
|--------|-------------|
| Catalog | https://localhost:7070/swagger |
| Discount | https://localhost:7071/swagger |
| Order | https://localhost:7072/swagger |
| Cargo | https://localhost:7073/swagger |
| Basket | https://localhost:7074/swagger |

---

## 📁 Proje Yapısı

```
MultiShop/
├── FrontEnds/
│   ├── MultiShop.WebUI/          → MVC Web Arayüzü
│   └── MultiShop.DtoLayer/       → Paylaşılan DTO'lar
├── IdentityServer/
│   └── MultiShop.IdentityServer/ → Kimlik Servisi
└── Services/
    ├── Basket/
    ├── Cargo/
    ├── Catalog/
    ├── Discount/
    └── Order/
        ├── Core/                 → Domain + Application
        ├── Infrastructure/       → Persistence
        └── Presentation/         → WebApi
```

---

## 📸 Ekran Görüntüleri

### Ana Sayfa
<img width="1920" height="1080" alt="image" src="https://github.com/user-attachments/assets/21783c21-becf-4659-865a-94b1e5d71a2b" />

<img width="1920" height="1080" alt="image" src="https://github.com/user-attachments/assets/1609af8b-62ff-4cdc-a2a6-8b1b1e1735c3" />


---

## 👤 Geliştirici

**Muhammet Boyraz**

- GitHub: [@mboyr4z](https://github.com/mboyr4z)
- LinkedIn: [Muhammet Boyraz](https://www.linkedin.com/in/muhammet-boyraz-6852b020b/)
- Mail: mmuhammetboyraz@gmail.com
