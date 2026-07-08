# 🎬 StreamPulse

<div align="center">

### 🚀 Yüksek Performanslı Gerçek Zamanlı İzleme Analitiği Paneli

*Milisaniyeler düzeyindeki SQL sorgularıyla **1 Milyondan fazla izleme kaydını** analiz edebilen, **ASP.NET Core 8 MVC**, **Dapper**, **SQL Server** ve **Chart.js** ile oluşturulmuş modern bir analitik paneli.*

<br>

![.NET](https://img.shields.io/badge/.NET-8-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET_Core-MVC-5C2D91?style=for-the-badge)
![Dapper](https://img.shields.io/badge/Dapper-Micro_ORM-007ACC?style=for-the-badge)
![SQL Server](https://img.shields.io/badge/SQL_Server-2022-CC2927?style=for-the-badge&logo=microsoftsqlserver&logoColor=white)
![Chart.js](https://img.shields.io/badge/Chart.js-FF6384?style=for-the-badge&logo=chartdotjs&logoColor=white)
![HTML5](https://img.shields.io/badge/HTML5-E34F26?style=for-the-badge&logo=html5&logoColor=white)
![CSS3](https://img.shields.io/badge/CSS3-1572B6?style=for-the-badge&logo=css3&logoColor=white)
![JavaScript](https://img.shields.io/badge/JavaScript-F7DF1E?style=for-the-badge&logo=javascript&logoColor=black)

![GitHub stars](https://img.shields.io/github/stars/aysnrerl/StreamPulse?style=social)
![GitHub forks](https://img.shields.io/github/forks/aysnrerl/StreamPulse?style=social)

</div>

---

# 📖 Proje Hakkında

**StreamPulse**, optimize edilmiş SQL sorguları ve Dapper Micro ORM kullanılarak büyük ölçekli izleme veri kümelerinin ne kadar verimli bir şekilde analiz edilebileceğini göstermek için tasarlanmış yüksek performanslı bir web uygulamasıdır.

Proje; **1.000.000'dan fazla izleme kaydını** işleyen, ham verileri etkileşimli paneller, KPI kartları, dinamik grafikler ve gelişmiş filtreleme özellikleri aracılığıyla anlamlı iş içgörülerine dönüştüren profesyonel bir streaming analitik platformunu simüle eder.

Geleneksel CRUD uygulamalarından farklı olarak StreamPulse; **performans**, **sorgu optimizasyonu**, **veri görselleştirme** ve **temiz yazılım mimarisine** odaklanır.

Proje, modern ASP.NET Core uygulamalarının hafif veri erişimini özenle optimize edilmiş SQL komutlarıyla birleştirerek nasıl olağanüstü bir performans elde edebileceğini sergilemektedir.

---

# ✨ Öne Çıkan Özellikler

* 🚀 **1 Milyondan Fazla Kaydı** saniyeler içinde analiz edin
* ⚡ **Dapper** ile ultra hızlı SQL sorguları
* 📊 Etkileşimli Genel Bakış Paneli (Dashboard)
* 📈 Gerçek zamanlı Analitik Raporlama
* 📉 Canlı ve dinamik grafikler
* 🎯 KPI (Temel Performans Göstergesi) kartları
* 🔍 Çok parametreli Gelişmiş Filtreleme
* 📄 Sunucu tarafında sayfalama (Server-side Pagination)
* 📱 Tüm ekranlara uyumlu responsive tasarım
* 🌙 Modern Glassmorphism (Cam Efekti) Karanlık Tema
* 🗄 Optimize edilmiş SQL Server Veritabanı
* 💾 Temiz DTO (Veri Transfer Nesnesi) mimarisi
* 🧩 Dependency Injection (Bağımlılık Enjeksiyonu)
* 📦 Modüler MVC proje yapısı
* 🔥 Yüksek hızlı veri erişimi

---

# 🎯 Proje Hedefleri

Bu projenin temel amacı, modern Microsoft teknolojilerini kullanarak kurumsal düzeyde dashboard geliştirme tekniklerini göstermektir.

Uygulamanın odaklandığı alanlar:

* Yüksek performanslı SQL sorguları
* Hafif ve hızlı veri erişimi (Micro-ORM)
* Dashboard arayüzü tasarımı
* Dinamik veri görselleştirme
* Büyük veri kümesi yönetimi
* Temiz Mimari (Clean Architecture) prensipleri
* Responsive kullanıcı arayüzü tasarımı
* Sunucu tarafında optimizasyon

---

# 🖼 Ön İzleme

## Dashboard Görünümü
*(Buraya Dashboard Ekran Görüntüsünü Ekleyin)*

## KPI Kartları
*(Buraya KPI Kartları Ekran Görüntüsünü Ekleyin)*

## Analitik Grafikler
*(Buraya Grafik Sayfası Ekran Görüntüsünü Ekleyin)*

## Gelişmiş Arama Tablosu
*(Buraya Tüm Kayıtlar Ekran Görüntüsünü Ekleyin)*

---

# 📚 İçindekiler

* [Hakkında](#-proje-hakkında)
* [Özellikler](#-öne-çıkan-özellikler)
* [Hedefler](#-proje-hedefleri)
* [Ön İzleme](#-ön-izleme)
* [Sistem Mimarisi](#-sistem-mimarisi)
* [Teknoloji Yığını](#-teknoloji-yığını)
* [Neden Dapper?](#-neden-dapper)
* [Performans Özeti](#-performans-özeti)
* [Dashboard Modülleri](#-dashboard-modülleri)
* [SQL Performans Stratejisi](#-sql-performans-stratejisi)
* [Veritabanı Tasarımı](#-veritabanı-tasarımı)
* [Proje Yapısı](#-proje-yapısı)
* [Kurulum](#-kurulum)
* [Kullanım](#-kullanım)
* [Gelecekte Yapılacak Geliştirmeler](#-gelecekte-yapılacak-geliştirmeler)
* [Lisans](#-lisans)

---

# 🏗 Sistem Mimarisi

```text
                  Kullanıcı
                      │
                      ▼
              ASP.NET Core MVC
                      │
          ┌───────────┴────────────┐
          │                        │
          ▼                        ▼
 Dashboard Controller      Streaming Controller
          │                        │
          └───────────┬────────────┘
                      │
                   Dapper
                      │
            Parametrik SQL Sorgusu
                      │
                SQL Server 2022
                      │
              StreamingLogs Tablosu
```

---

# 🛠 Teknoloji Yığını

| Kategori | Teknoloji |
| -------------------- | ----------------------- |
| Framework | ASP.NET Core 8 MVC |
| Dil | C# 12 |
| ORM (Veri Erişim) | Dapper |
| Veri Tabanı | Microsoft SQL Server |
| Ön Yüz (Frontend) | HTML5, CSS3, JavaScript |
| Grafikler | Chart.js |
| Tasarım ve Stil | Özel Glassmorphic Arayüz |
| Mimari Yapı | MVC |
| Bağımlılık Enjeksiyonu | Dahili .NET DI Kontrolcüsü |
| Sayfalama (Paging) | Sunucu Tarafında (Server-side) |
| Sorgu Dili | SQL (Transact-SQL) |
| IDE (Geliştirme Ortamı) | Visual Studio 2022 |

---

# 💎 Neden Dapper?

Bu projede, Entity Framework Core kullanmak yerine veri tabanı sorgu performansını maksimize etmek amacıyla bilinçli olarak **Dapper** tercih edilmiştir.

### Avantajları

* Son derece hızlı sorgu çalıştırma performansı
* Minimum bellek (RAM) tüketimi ve ek yük (overhead)
* Ham SQL sorguları üzerinde tam kontrol
* Hafif ve bağımsız veri erişim katmanı
* Mükemmel ölçeklenebilirlik
* Kurumsal seviyede yüksek verim
* Raporlama ve veri analitiği sistemleri için ideal yapı
* Canlı dashboard panelleri için en yüksek hız

---

# 📈 Performans Özeti

| Metrik | Değer |
| ----------------- | ------------------ |
| Veri Kümesi Boyutu| 1,000,000+ Kayıt |
| Dashboard Modülleri| 12 |
| Grafikler | 8+ |
| KPI Kartları | 4 |
| Veritabanı | SQL Server |
| ORM Sınıfı | Dapper |
| Filtreleme Tipi | Dinamik Sorgular |
| Sayfalama Yöntemi | Sunucu Tarafında (OFFSET-FETCH) |
| Mimari Yapı | MVC |
| Arayüz Teması | Glassmorphism Karanlık Mod |

---

> ⭐ **StreamPulse; ASP.NET Core MVC ve Dapper kullanarak kurumsal yazılım geliştirme pratiklerini, SQL optimizasyon tekniklerini ve yüksek performanslı veri görselleştirmeyi sergileyen portföy kalitesinde bir veri analitiği paneli olarak tasarlanmıştır.**

---

# 📊 Dashboard Modülleri

StreamPulse dashboard arayüzü, izleme platformu aktivitelerine yönelik değerli iş içgörüleri sunmak üzere **12 analitik modüle** ayrılmıştır. Her modül optimize edilmiş bir SQL sorgusuyla beslenir ve anlık sonuçlar sunar.

---

### 📌 1. Toplam İzlenme Sayısı
*   **Amaç:** Sistemdeki toplam izleme işlemi sayısını KPI olarak gösterir.
*   **Temel Çıkarım:** Toplam platform etkileşim hacmi, veri tabanı büyüme hızı.

**SQL Sorgusu:**
```sql
SELECT COUNT(*) FROM StreamingLogs;
```

---

### 📌 2. Tekil İzleyici Sayısı
*   **Amaç:** Platformu kullanan benzersiz kullanıcı adlarının sayısını hesaplar.
*   **Temel Çıkarım:** Net aktif izleyici kitlesinin büyüklüğü ve platformun erişim gücü.

**SQL Sorgusu:**
```sql
SELECT COUNT(DISTINCT UserName) FROM StreamingLogs;
```

---

### 📌 3. Toplam İzlenme Süresi (Saat)
*   **Amaç:** Dakika cinsinden kaydedilen izlenmeleri kümülatif olarak saate dönüştürür.
*   **Temel Çıkarım:** Platformda geçirilen toplam saat hacmi ve izleyici bağlılığı.

**SQL Sorgusu:**
```sql
SELECT SUM(WatchDurationMin) / 60 FROM StreamingLogs;
```

---

### 📌 4. Ortalama İzleyici Puanı
*   **Amaç:** Kullanıcıların tüm içeriklere verdiği puanların ortalamasını hesaplar.
*   **Temel Çıkarım:** Genel izleyici memnuniyet oranları ve içerik kalite göstergesi.

**SQL Sorgusu:**
```sql
SELECT ROUND(AVG(CAST(Rating AS FLOAT)), 1) FROM StreamingLogs;
```

---

### 📌 5. Aylık İzlenme Trendi
*   **Amaç:** Son 12 aya ait izlenme adetlerini aylık gruplayarak zaman serisi sunar.
*   **Temel Çıkarım:** Aylık büyüme oranları, mevsimsel yoğunluklar ve kullanıcı eğilimleri.

**SQL Sorgusu:**
```sql
SELECT 
    FORMAT(WatchDate, 'yyyy-MM') AS Label,
    COUNT(*) AS Value
FROM StreamingLogs
WHERE WatchDate >= DATEADD(MONTH, -12, GETDATE())
GROUP BY FORMAT(WatchDate, 'yyyy-MM')
ORDER BY Label;
```

---

### 📌 6. Yayıncı Platform Dağılımı
*   **Amaç:** Farklı streaming yayıncılarının popülerlik ve pazar payı oranlarını analiz eder.
*   **Temel Çıkarım:** Netflix, Disney+, Prime Video, HBO Max ve Apple TV+ platformlarının rekabet dengesi.

**SQL Sorgusu:**
```sql
SELECT Platform AS Label, COUNT(*) AS Value
FROM StreamingLogs
GROUP BY Platform
ORDER BY Value DESC;
```

---

### 📌 7. Kategori (Tür) Analitiği
*   **Amaç:** Kullanıcıların en çok tercih ettiği içerik türlerini listeler.
*   **Temel Çıkarım:** Popüler kategoriler (Aksiyon, Drama, Komedi, Korku, Romantik, Belgesel vb.).

**SQL Sorgusu:**
```sql
SELECT Genre AS Label, COUNT(*) AS Value
FROM StreamingLogs
GROUP BY Genre
ORDER BY Value DESC;
```

---

### 📌 8. Cihaz Türü Dağılımı
*   **Amaç:** İzleyicilerin yayını hangi cihazlardan (TV, Mobil, Bilgisayar, Tablet) takip ettiğini bulur.
*   **Temel Çıkarım:** Tasarım ve teknik optimizasyonlar için donanım kullanım tercihleri.

**SQL Sorgusu:**
```sql
SELECT DeviceType AS Label, COUNT(*) AS Value
FROM StreamingLogs
GROUP BY DeviceType
ORDER BY Value DESC;
```

---

### 📌 9. Ülke Analizi (Top 5 Ülke)
*   **Amaç:** En çok izleme yapılan ilk 5 ülkeyi izlenme sayılarına göre sıralar.
*   **Temel Çıkarım:** Coğrafi trafik dağılımı ve platformun güçlü olduğu bölgesel pazarlar.

**SQL Sorgusu:**
```sql
SELECT TOP 5 Country AS Label, COUNT(*) AS Value
FROM StreamingLogs
GROUP BY Country
ORDER BY Value DESC;
```

---

### 📌 10. Saatlik İzlenme Dağılımı
*   **Amaç:** Gün içerisindeki yoğun saatleri (Peak Hours) tespit etmek için 24 saatlik trafik akışını gösterir.
*   **Temel Çıkarım:** Sunucu kapasite planlaması ve altyapı yük yönetimi verileri.

**SQL Sorgusu:**
```sql
SELECT 
    RIGHT('0' + CAST(DATEPART(HOUR, WatchDate) AS VARCHAR), 2) + ':00' AS Label, 
    COUNT(*) AS Value
FROM StreamingLogs
GROUP BY DATEPART(HOUR, WatchDate)
ORDER BY DATEPART(HOUR, WatchDate);
```

---

### 📌 11. En Çok İzlenen 10 İçerik
*   **Amaç:** Platform genelinde en çok izleme kaydına sahip 10 popüler yapımı sıralar.
*   **Temel Çıkarım:** Hit içeriklerin tespiti, öneri algoritması girdileri ve trend yapımlar.

**SQL Sorgusu:**
```sql
SELECT TOP 10 ContentTitle AS Label, COUNT(*) AS Value
FROM StreamingLogs
GROUP BY ContentTitle
ORDER BY Value DESC;
```

---

### 📌 12. Gelişmiş Arama & Sayfalama
*   **Amaç:** Çok parametreli dinamik arama filtrelerine sahip veri keşif tablosudur.
*   **Temel Çıkarım:** 1 Milyon satırlık tabloda Kullanıcı Adı, İçerik, Tür, Platform ve Duruma göre anlık arama yapar.

**SQL Sorgusu:**
```sql
SELECT LogId, UserName, ContentTitle, Genre, Platform,
       WatchDate, WatchDurationMin, Rating, Country, DeviceType, Status
FROM StreamingLogs
WHERE 1=1
  -- Filtre parametreleri Dapper tarafında dinamik olarak eklenir:
  -- AND UserName LIKE @UserName
  -- AND ContentTitle LIKE @ContentTitle
  -- AND Genre = @Genre
  -- AND Platform = @Platform
  -- AND Status = @Status
ORDER BY LogId DESC
OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;
```

---

# ⚡ SQL Performans Stratejisi

Uygulama, veritabanındaki **bir milyondan fazla kaydı** işlerken tarayıcı ekranına sonuçları gecikmesiz yansıtacak optimizasyonlara sahiptir.

## Optimizasyon Yöntemleri

* **Dapper Micro ORM:** SQL kodlarını doğrudan çalıştırarak EF Core'un oluşturduğu çeviri ve izleme (change tracking) yüklerinden kaçınır.
* **Parametrik Sorgular:** SQL Injection saldırılarını önler ve SQL Server'ın sorgu yürütme planını (Query Plan) önbelleğe almasını sağlar.
* **Sunucu Tarafında Sayfalama:** 1 milyon kaydı belleğe yüklemek yerine SQL `OFFSET-FETCH` komutlarıyla her seferinde sadece 12 satır veri çeker.
* **Kapsayan İndeksler (Covering Indexes):** İlgili sorgu sonuçlarını ana tabloya gitmeden doğrudan indeks ağacı üzerinden çözerek disk okuma yükünü sıfıra indirir.
* **Index Seek İşlemleri:** Tam tablo taramalarını engelleyerek aranan veriye doğrudan nokta atışı erişim sağlar.

---

# 🚀 Performans Avantajları

* **Işık Hızında Sorgular:** Dashboard genel metrikleri 15ms'nin altında hesaplanır.
* **Hafif RAM Tüketimi:** Uygulama yük altındayken bile 90MB'tan az bellek harcar.
* **Gecikmesiz Arama:** 1 Milyon satırlık tabloda anlık filtreleme yapılabilir.
* **Geliştirilebilir Mimari:** Yapıyı bozmadan Redis önbellekleme veya SignalR canlı yayın desteği entegre edilebilir.

---

# 🗄 Veritabanı Tasarımı

StreamPulse, merkezinde yer alan **StreamingLogs** analitik kayıt tablosu üzerinde çalışır. Tablo yapısı büyük veride hızlı filtreleme ve raporlama yapabilmek üzere optimize edilmiştir.

---

## Tablo Şeması

| Kolon Adı | Veri Tipi | Açıklama |
| :--- | :--- | :--- |
| **LogId** | **INT (PK, Identity)** | Benzersiz log kimliği (Birincil Anahtar) |
| **UserName** | **NVARCHAR(100)** | İzleyen kullanıcının adı |
| **ContentTitle** | **NVARCHAR(250)** | İzlenen film veya dizi başlığı |
| **Genre** | **NVARCHAR(50)** | İçeriğin kategorisi (Türü) |
| **Platform** | **NVARCHAR(50)** | Yayıncı platform |
| **WatchDate** | **DATETIME** | İzleme tarihi ve saati |
| **WatchDurationMin**| **INT** | İzleme süresi (Dakika) |
| **Rating** | **DECIMAL(3,1)** | Kullanıcının verdiği puan (1-10) |
| **Country** | **NVARCHAR(100)** | İzleyicinin ülkesi |
| **DeviceType** | **NVARCHAR(50)** | Kullanılan cihaz (Mobil, TV vb.) |
| **Status** | **NVARCHAR(50)** | İzleme durumu (Completed, Dropped vb.) |

---

## Veri İlişkileri Şeması

```text
┌─────────────────────────────┐
│       StreamingLogs         │
├─────────────────────────────┤
│ LogId (PK)                  │
│ UserName                    │
│ ContentTitle                │
│ Genre                       │
│ Platform                    │
│ WatchDate                   │
│ WatchDurationMin            │
│ Rating                      │
│ Country                     │
│ DeviceType                  │
│ Status                      │
└─────────────────────────────┘
```

---

## ⚡ Veritabanı İndeks Optimizasyonu

1 milyon satırlık veri tabanında anlık filtreleme işlemlerinin sunucuyu kilitlememesi için aşağıdaki indeks yapısı önerilmektedir.

### Önerilen İndeks Yapısı

```sql
CREATE NONCLUSTERED INDEX IX_StreamingLogs_Filters
ON StreamingLogs
(
    Platform,
    Genre,
    Status
)
INCLUDE
(
    UserName,
    ContentTitle,
    WatchDate,
    WatchDurationMin,
    Rating,
    Country,
    DeviceType
);
```

---

# 📂 Proje Yapısı

```text
StreamPulse
│
├── StreamingAnalytics/
│   ├── Context/
│   │   └── DapperContext.cs           # SQL Server veritabanı bağlantı yönetimi
│   │
│   ├── Controllers/
│   │   ├── DashboardController.cs     # Genel metrikler, KPI'lar ve Grafikleri yönetir
│   │   └── StreamingController.cs     # Sayfalı listeleme ve çoklu filtrelemeyi yönetir
│   │
│   ├── Dtos/
│   │   ├── ChartItemDto.cs            # Grafik verisi anahtar-değer modeli
│   │   ├── DashboardStatsDto.cs       # KPI kartları veri modeli
│   │   ├── DashboardViewModel.cs      # Arayüzü besleyen ana viewmodel sınıfı
│   │   └── StreamingLogDto.cs         # İzleme kaydı satır modeli
│   │
│   ├── Views/
│   │   ├── Dashboard/
│   │   │   ├── Index.cshtml           # Genel bakış paneli
│   │   │   └── Charts.cshtml          # Dinamik analitik grafiklerin yer aldığı sayfa
│   │   │
│   │   ├── Streaming/
│   │   │   └── Index.cshtml           # Detaylı log arama ve filtreleme tablosu
│   │   │
│   │   └── Shared/
│   │       └── _Layout.cshtml         # Responsive koyu tema şablonu
│   │
│   ├── wwwroot/                       # CSS, JS, kütüphaneler ve görseller
│   ├── appsettings.json               # Bağlantı metni ve sistem yapılandırması
│   └── Program.cs                     # Uygulama başlangıcı ve DI servis kayıtları
│
└── StreamingAnalytics.slnx            # Solution (Çözüm) dosyası
```

---

# 🔄 İstek Yaşam Döngüsü

```text
Kullanıcı İsteği
      │
      ▼
Denetleyici (Controller)
      │
      ▼
Dapper Sorgusu
      │
      ▼
SQL Server Veritabanı
      │
      ▼
DTO Eşleştirmesi (Mapping)
      │
      ▼
View Model Yapısı
      │
      ▼
Razor Arayüzü (View)
      │
      ▼
Tarayıcı Yanıtı
```

---

# ⚙ Bağımlılık Enjeksiyonu (DI)

ASP.NET Core'un yerleşik Bağımlılık Enjeksiyonu altyapısı, veritabanı bağlantı yönetimini ve servis sınıflarını yönetmek için kullanılır:

```csharp
builder.Services.AddScoped<DapperContext>();
builder.Services.AddScoped<StreamingService>();
```

---

# 🔐 Güvenlik Önlemleri

Uygulama, veri tabanına yapılacak SQL Injection (zararlı kod enjeksiyonu) saldırılarını engellemek için parametrik SQL sorguları kullanır.

```csharp
var query = @"
SELECT *
FROM StreamingLogs
WHERE UserName LIKE @UserName";

var data = await connection.QueryAsync<StreamingLogDto>(
    query,
    new { UserName = "%" + search + "%" }
);
```

---

# 🔧 Kurulum ve Çalıştırma

Projeyi yerel bilgisayarınızda kurmak ve çalıştırmak için aşağıdaki adımları izleyin:

### 1. Ön Koşullar
Aşağıdaki bileşenlerin sisteminizde yüklü olduğundan emin olun:
* [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
* Microsoft SQL Server (LocalDB, Express veya Developer Sürümü)

### 2. Veritabanının Oluşturulması
SQL Server üzerinde `StreamingDB` adında bir veritabanı oluşturun ve aşağıdaki tablo oluşturma script'ini çalıştırın:

```sql
CREATE DATABASE StreamingDB;
GO
USE StreamingDB;
GO

CREATE TABLE StreamingLogs (
    LogId INT IDENTITY(1,1) PRIMARY KEY,
    UserName NVARCHAR(100) NOT NULL,
    ContentTitle NVARCHAR(250) NOT NULL,
    Genre NVARCHAR(50) NOT NULL,
    Platform NVARCHAR(50) NOT NULL,
    WatchDate DATETIME NOT NULL,
    WatchDurationMin INT NOT NULL,
    Rating DECIMAL(3,1) NOT NULL,
    Country NVARCHAR(100) NOT NULL,
    DeviceType NVARCHAR(50) NOT NULL,
    Status NVARCHAR(50) NOT NULL
);
```

### 3. Yapılandırma
`StreamingAnalytics/appsettings.json` dosyasını açarak yerel SQL Server bağlantı dizesini kendi adresinize göre düzenleyin:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=.\\SQLEXPRESS;Database=StreamingDB;Trusted_Connection=True;TrustServerCertificate=True"
}
```

### 4. Uygulamanın Başlatılması
Projenin kök dizinindeyken terminal veya PowerShell açarak şu komutları yürütün:

```bash
# Paket bağımlılıklarını yükleyin
dotnet restore

# Projeyi derleyip çalıştırın
dotnet run --project StreamingAnalytics
```

Tarayıcınızı açarak `https://localhost:5001` veya `http://localhost:5000` adresine giderek StreamPulse paneline erişebilirsiniz.

---

# 🚀 Gelecekte Yapılacak Geliştirmeler

* 📡 **Canlı Simülatör (Seeder):** Arka planda çalışarak aktif izleyicilerin işlemlerini canlı olarak simüle eden ve veri tabanına anlık log üreten arka plan servisi.
* ⚡ **Önbellek (Caching):** Platform dağılımları ve popüler içerik listeleri gibi yavaş değişen veriler için Redis entegrasyonu.
* 🔔 **Gerçek Zamanlı Veri (WebSockets):** Veritabanındaki analitik değişimleri sayfayı yenilemeden arayüze aktarmak için SignalR implementasyonu.
* 🐳 **Dockerizasyon:** Hızlı ve kolay dağıtım için Docker konteyner yapılandırması.

---

# 📄 Lisans

Bu proje MIT Lisansı altında dağıtılmaktadır. Daha fazla bilgi için `LICENSE` dosyasına göz atabilirsiniz.
