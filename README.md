# 🎬 StreamPulse — Real-Time Streaming Analytics Dashboard

[![Framework](https://img.shields.io/badge/.NET-8.0_MVC-512BD4?logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![Database](https://img.shields.io/badge/MS_SQL_Server-2022-CC2927?logo=microsoft-sql-server&logoColor=white)](https://www.microsoft.com/sql-server)
[![ORM](https://img.shields.io/badge/ORM-Dapper-007ACC)](https://github.com/DapperLib/Dapper)
[![Visualisation](https://img.shields.io/badge/Charts-Chart.js-FF6384?logo=chartdotjs&logoColor=white)](https://www.chartjs.org/)
[![UI Style](https://img.shields.io/badge/UI-Glassmorphism_Dark_Mode-060813)](https://developer.mozilla.org/css)

**StreamPulse**, **1.000.000 (1 Milyon) canlı izleme kaydı** barındıran devasa bir veri kümesi üzerinde, milisaniyeler seviyesinde çalışan gerçek zamanlı bir analitik sorgu ve görselleştirme motorudur. 

ASP.NET Core 8.0 MVC mimarisi üzerine inşa edilen proje; veri erişim katmanında **Dapper (Micro-ORM)** kullanılarak ham SQL sorgularının performans sınırlarını zorlayacak şekilde tasarlanmıştır. Ön yüzde modern **CSS Glassmorphism (Cam Efekti) Karanlık Tema** tasarımı ve **Chart.js** ile dinamik grafikler sunmaktadır.

---

## 🚀 Öne Çıkan Özellikler

StreamPulse, performans ve analitik odaklı **12 Temel SQL Sorgusu** üzerine yapılandırılmıştır:

### 1. KPI Metrik Kartları (Genel Bakış)
*   **Sorgu 1 (Toplam İzlenme):** Sistemdeki toplam izleme işlemi sayısı.
*   **Sorgu 2 (Tekil İzleyici):** Platformu kullanan benzersiz kullanıcı sayısı.
*   **Sorgu 3 (İzlenme Saati):** Toplam izlenme dakikalarının saate dönüştürülmüş kümülatif değeri.
*   **Sorgu 4 (Ortalama Puan):** İçeriklere verilen puanların ağırlıklı ortalaması (10 üzerinden).

### 2. Grafiksel Dashboard Panelleri (Chart.js Entegrasyonu)
*   **Sorgu 5 (Aylık İzlenme Trendi):** Son 12 aya ait izlenme adetlerinin zaman serisi analizi (Bar Grafik).
*   **Sorgu 6 (Platform Dağılımı):** Netflix, Amazon Prime, Disney+, HBO Max, Apple TV+ platformlarının pazar payı oranları (Doughnut Grafik).
*   **Sorgu 7 (Tür Dağılımı):** Aksiyon, Drama, Bilim Kurgu vb. kategorilerin popülerlik dağılımı (Bar Grafik).
*   **Sorgu 8 (Cihaz Dağılımı):** Mobil, TV, Bilgisayar, Tablet kullanım oranları (Pie Grafik).
*   **Sorgu 9 (Coğrafi Ülke Analizi):** En çok izleme yapılan ilk 5 ülkenin karşılaştırması.
*   **Sorgu 10 (Saatlik İzlenme Trendi):** Günün hangi saatlerinde izlenme yoğunluğunun arttığını gösteren 24 saatlik analiz (Line Grafik).

### 3. Detaylı Listeleme ve Performanslı Arama
*   **Sorgu 11 (En Çok İzlenen 10 İçerik):** En popüler dizi/film başlıklarının listesi.
*   **Sorgu 12 (Son İzlemeler & Gelişmiş Paging):** 
    *   Kullanıcı adı, İçerik başlığı, Tür, Platform ve İzleme durumuna göre çoklu filtreleme.
    *   **1 Milyon satırlık** tabloda yüksek hızda çalışması için SQL `OFFSET-FETCH` mimarisiyle sayfalama (Paging).

---

## 🛠️ Teknoloji Yığını

| Bileşen | Kullanılan Teknoloji | Seçim Nedeni |
| :--- | :--- | :--- |
| **Framework** | **ASP.NET Core 8.0 MVC** | Modüler, güvenli ve kurumsal standartlarda MVC mimarisi. |
| **Veri Tabanı** | **MS SQL Server (Express)** | İlişkisel veri modeli ve büyük ölçekli sorgulamalar için güçlü indeksleme yeteneği. |
| **Veri Erişim (ORM)** | **Dapper (Micro-ORM)** | Entity Framework Core'a kıyasla ham SQL gücü ve sıfıra yakın overhead ile maksimum sorgu hızı. |
| **Veri Transferi** | **DTO (Data Transfer Object)** | Yalnızca ihtiyaç duyulan kolonların taşınmasıyla RAM ve network optimizasyonu. |
| **Görselleştirme** | **Chart.js** | Canvas tabanlı, responsive ve animasyonlu modern grafik kütüphanesi. |
| **Tasarım & Tema** | **Kişiselleştirilmiş Vanilla CSS** | Neon geçişler, derinlik hissi veren gölgelendirmeler (shadows), glassmorphism ve responsive tasarım. |

---

## 📂 Proje Yapısı

```text
StreamPulse/
│
├── StreamingAnalytics/
│   ├── Context/
│   │   └── DapperContext.cs           # SQL Server veritabanı bağlantı yönetimi
│   │
│   ├── Controllers/
│   │   ├── DashboardController.cs    # Grafik verilerini ve metrikleri yöneten denetleyici
│   │   └── StreamingController.cs    # Filtreleme ve sayfalı listelemeyi yöneten denetleyici
│   │
│   ├── Dtos/
│   │   ├── ChartItemDto.cs           # Grafik etiket-değer modeli
│   │   ├── DashboardStatsDto.cs      # KPI kartları veri modeli
│   │   ├── DashboardViewModel.cs     # Dashboard'a toplu veri taşıyan model
│   │   └── StreamingLogDto.cs        # Detaylı log satırı modeli
│   │
│   ├── Views/
│   │   ├── Dashboard/
│   │   │   ├── Index.cshtml          # Genel metrikler ve hızlı geçiş paneli
│   │   │   └── Charts.cshtml         # 8 farklı dinamik grafik ve tablo görünümü
│   │   │
│   │   ├── Streaming/
│   │   │   └── Index.cshtml          # Gelişmiş filtreleme ve sayfalı liste tablosu
│   │   │
│   │   └── Shared/
│   │       └── _Layout.cshtml        # Global tema, navbar ve responsive sidebar yapısı
│   │
│   ├── wwwroot/                      # CSS, JS ve kütüphane dosyaları
│   ├── appsettings.json              # Connection String tanımlamaları
│   └── Program.cs                    # DI (Dependency Injection) kayıtları ve uygulama başlangıcı
```

---

## ⚡ Veritabanı Yapısı & Performans Notları

### Tablo Şeması (`StreamingLogs`)
Uygulama, SQL Server üzerinde aşağıdaki şemaya sahip `StreamingLogs` tablosunu sorgular:

| Kolon Adı | Veri Tipi | Açıklama |
| :--- | :--- | :--- |
| **LogId** | `INT` (PK, Identity) | Benzersiz log kimliği |
| **UserName** | `NVARCHAR(100)` | İzleyen kullanıcının adı |
| **ContentTitle** | `NVARCHAR(250)` | İzlenen film/dizi başlığı |
| **Genre** | `NVARCHAR(50)` | İçeriğin türü (Kategori) |
| **Platform** | `NVARCHAR(50)` | Yayıncı platform |
| **WatchDate** | `DATETIME` | İzleme tarihi ve saati |
| **WatchDurationMin** | `INT` | İzleme süresi (Dakika) |
| **Rating** | `DECIMAL(3,1)` | Kullanıcının verdiği puan (1-10) |
| **Country** | `NVARCHAR(100)` | İzleyicinin ülkesi |
| **DeviceType** | `NVARCHAR(50)` | Kullanılan cihaz (Mobil, TV vb.) |
| **Status** | `NVARCHAR(50)` | İzleme durumu (Completed, Dropped vb.) |

### Performans Optimizasyonu
1 milyon veri satırında anlık filtreleme yaparken gecikmeyi önlemek için veritabanında şu indekslerin (`Indexes`) tanımlanması önerilir:
```sql
CREATE NONCLUSTERED INDEX IX_StreamingLogs_Filters 
ON StreamingLogs (Platform, Genre, Status)
INCLUDE (UserName, ContentTitle, WatchDate, WatchDurationMin, Rating, Country, DeviceType);
```

Arama ve sayfalama işlemlerinde SQL sunucusunu yormamak adına sorgularda `OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY` yapısı kullanılarak verilerin belleğe yalnızca ihtiyaç duyulan kadarı çekilmektedir.

---

## 🔧 Kurulum ve Çalıştırma

### 1. Ön Koşullar
*   [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) bilgisayarınızda kurulu olmalıdır.
*   Yerel bir **MS SQL Server** (LocalDB veya Express) çalışır durumda olmalıdır.

### 2. Veritabanı Bağlantısı
`StreamingAnalytics/appsettings.json` dosyasını açın ve kendi yerel SQL Server bağlantı adresinize göre `DefaultConnection` değerini düzenleyin:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=.\\SQLEXPRESS;Database=StreamingDB;Trusted_Connection=True;TrustServerCertificate=True"
}
```

### 3. Çalıştırma Komutları
Proje dizinine giderek terminal veya PowerShell üzerinden uygulamayı başlatın:

```bash
# Bağımlılıkları yükle
dotnet restore

# Uygulamayı çalıştır
dotnet run --project StreamingAnalytics
```

Tarayıcınızda açılan adreste (örneğin `https://localhost:5001` veya `http://localhost:5000`) StreamPulse Dashboard'u görüntüleyebilirsiniz.

---

## 🎨 Arayüz Tasarım Felsefesi
*   **Karanlık Tema:** Göz yormayan, sinematik his uyandıran `#060813` arka plan tonları.
*   **Glassmorphism:** Yarı saydam kart tasarımları, arka plan bulanıklaştırma (`backdrop-filter: blur`) efektleri.
*   **Neon Vurgular:** Mor (Violet), Mavi (Indigo) ve Turkuaz (Cyan) neon gradyanları ile modern bir siberpunk estetiği.
*   **Mikro Etkileşimler:** Butonlarda ve navigasyon kartlarında yumuşak hover animasyonları (`transition: all 0.25s cubic-bezier`).
