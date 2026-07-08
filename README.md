# 🎬 StreamPulse — Real-Time Streaming Analytics Dashboard

[![Framework](https://img.shields.io/badge/.NET-8.0_MVC-512BD4?logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![Database](https://img.shields.io/badge/MS_SQL_Server-2022-CC2927?logo=microsoft-sql-server&logoColor=white)](https://www.microsoft.com/sql-server)
[![ORM](https://img.shields.io/badge/ORM-Dapper-007ACC)](https://github.com/DapperLib/Dapper)
[![Visualisation](https://img.shields.io/badge/Charts-Chart.js-FF6384?logo=chartdotjs&logoColor=white)](https://www.chartjs.org/)
[![UI Style](https://img.shields.io/badge/UI-Glassmorphism_Dark_Mode-060813)](https://developer.mozilla.org/css)

**StreamPulse**, **1.000.000 (1 Milyon) canlı izleme kaydı** barındıran devasa bir veri kümesi üzerinde, milisaniyeler seviyesinde çalışan gerçek zamanlı bir analitik sorgu ve görselleştirme motorudur. 

ASP.NET Core 8.0 MVC mimarisi üzerine inşa edilen proje; veri erişim katmanında **Dapper (Micro-ORM)** kullanılarak ham SQL sorgularının performans sınırlarını zorlayacak şekilde tasarlanmıştır. Ön yüzde modern **CSS Glassmorphism (Cam Efekti) Karanlık Tema** tasarımı ve **Chart.js** ile dinamik grafikler sunmaktadır.

---

## 🖥️ 12 Temel Sayfa, Arayüz Paneli ve SQL Sorgu Detayları

StreamPulse üzerindeki her bir analitik bölüm, kendine ait bir arayüz görünümüne (Section/Page) ve optimize edilmiş bir SQL sorgusuna sahiptir. Aşağıda bu 12 yapının işlevleri, ekran tasarımları ve sorgu detayları tek tek açıklanmıştır:

<img width="1920" height="881" alt="Image" src="https://github.com/user-attachments/assets/0d19a45f-1628-4baf-bf84-e57bf407ce59" />

### 1. Sayfa: Toplam İzlenme Metrik Kartı
<img width="344" height="215" alt="Image" src="https://github.com/user-attachments/assets/fb8dbfc0-1966-4e61-95a8-029a2c066d86" />

*   **Arayüz Tanımı:** Dashboard'un en üstünde yer alan mor neon renkli ilk KPI kartıdır. Sistemde kayıtlı toplam etkileşim hacmini gösterir.
*   **Sorgunun Amacı:** Veritabanındaki `StreamingLogs` tablosunda bulunan toplam satır sayısını milisaniyeler içinde çekmek.
*   **SQL Sorgusu:**
    ```sql
    SELECT COUNT(*) FROM StreamingLogs;
    ```
*   **Sorgu Açıklaması:** `COUNT(*)` fonksiyonu tabloda bulunan tüm kayıtları sayar. Birincil anahtar (Primary Key - LogId) üzerinden tarama yaparak en hızlı şekilde sonucu döndürür.

---

### 2. Sayfa: Tekil İzleyici Metrik Kartı
<img width="343" height="192" alt="Image" src="https://github.com/user-attachments/assets/ddaac337-6cf9-4bdf-b1c3-aa9d583f9ad2" />

*   **Arayüz Tanımı:** Dashboard üstündeki yeşil renkli ikinci KPI kartıdır. Platformu aktif olarak kullanan benzersiz kullanıcı kitlesinin büyüklüğünü temsil eder.
*   **Sorgunun Amacı:** Aynı kullanıcının yaptığı mükerrer izlemeleri eleyerek net kullanıcı sayısını bulmak.
*   **SQL Sorgusu:**
    ```sql
    SELECT COUNT(DISTINCT UserName) FROM StreamingLogs;
    ```
*   **Sorgu Açıklaması:** `DISTINCT UserName` ifadesi, kullanıcı adlarını tekilleştirir. `COUNT` ise bu tekil listenin eleman sayısını verir. 1 milyon kayıt arasında hızlı çalışması için `UserName` kolonu üzerinde indeksleme olması performansı doğrudan artırır.

---

### 3. Sayfa: İzlenme Saati Metrik Kartı
<img width="349" height="208" alt="Image" src="https://github.com/user-attachments/assets/7dd63eaa-e8a6-4fed-b16a-2e3ee7f5b354" />

*   **Arayüz Tanımı:** Dashboard üzerindeki sarı renkli üçüncü KPI kartıdır. Kullanıcıların platformda geçirdiği toplam süreyi saat cinsinden gösterir.
*   **Sorgunun Amacı:** Dakika bazlı tutulan tüm izleme sürelerini toplayıp saate çevirerek kümülatif izlenme hacmini hesaplamak.
*   **SQL Sorgusu:**
    ```sql
    SELECT SUM(WatchDurationMin) / 60 FROM StreamingLogs;
    ```
*   **Sorgu Açıklaması:** `SUM(WatchDurationMin)` fonksiyonu tablodaki tüm satırların izlenme sürelerini toplar. Elde edilen değer `60`'a bölünerek dakika cinsinden toplam süre, tam saat değerine dönüştürülür.

---

### 4. Sayfa: Ortalama Puan Metrik Kartı
<img width="348" height="221" alt="Image" src="https://github.com/user-attachments/assets/ece56225-9aa8-4eae-8bc3-6463f64bf10c" />

*   **Arayüz Tanımı:** Dashboard üzerindeki kırmızı renkli dördüncü KPI kartıdır. Platformdaki içeriklerin genel izleyici memnuniyetini (10 üzerinden) yansıtır.
*   **Sorgunun Amacı:** Kullanıcıların verdiği tüm puanların aritmetik ortalamasını bulmak ve virgülden sonra tek hane olarak yuvarlamak.
*   **SQL Sorgusu:**
    ```sql
    SELECT ROUND(AVG(CAST(Rating AS FLOAT)), 1) FROM StreamingLogs;
    ```
*   **Sorgu Açıklaması:** `CAST(Rating AS FLOAT)` ile tam sayı olan puanlar ondalıklı sayıya dönüştürülür. `AVG` ile ortalama alınır ve `ROUND(..., 1)` fonksiyonuyla virgülden sonra tek basamağa yuvarlanarak (örn: 7.4) temiz bir çıktı elde edilir.

---

### 5. Sayfa: Aylık İzlenme Trendi Analiz Paneli
<img width="1911" height="880" alt="Image" src="https://github.com/user-attachments/assets/f6f16fc1-564b-4cef-a302-508551b307db" />

*   **Arayüz Tanımı:** Yan menüden veya dashboard'dan erişilebilen, zaman serisi analizini sunan geniş bar grafik ekranıdır.
*   **Sorgunun Amacı:** Son 12 ayın izlenme sayılarını ay bazında gruplayarak mevsimsel trendleri ve büyüme oranlarını gözlemlemek.
*   **SQL Sorgusu:**
    ```sql
    SELECT 
        FORMAT(WatchDate, 'yyyy-MM') AS Label,
        COUNT(*) AS Value
    FROM StreamingLogs
    WHERE WatchDate >= DATEADD(MONTH, -12, GETDATE())
    GROUP BY FORMAT(WatchDate, 'yyyy-MM')
    ORDER BY Label;
    ```
*   **Sorgu Açıklaması:** 
    *   `WHERE WatchDate >= DATEADD(MONTH, -12, GETDATE())` filtresi ile sadece son 1 yıla ait veriler alınır.
    *   `FORMAT(WatchDate, 'yyyy-MM')` fonksiyonu tarih bilgisini yıl-ay (Örn: 2026-06) formatına çevirir.
    *   `GROUP BY` ile bu formatlı tarihlere göre gruplama yapılarak her ayın izlenme adeti (`COUNT(*)`) hesaplanır.

---

### 6. Sayfa: Platform Dağılımı Analiz Paneli
<img width="1916" height="879" alt="Image" src="https://github.com/user-attachments/assets/dfbc8da9-8e23-430f-b134-7299e2748839" />

*   **Arayüz Tanımı:** Platformların pazar paylarını dinamik bir Doughnut (Simit) grafik ve sağ tarafında yüzde oranlarını içeren şık bir veri tablosuyla sunan sayfadır.
*   **Sorgunun Amacı:** İzleyicilerin hangi yayın platformlarında (Netflix, Prime, Disney+ vb.) yoğunlaştığını analiz etmek.
*   **SQL Sorgusu:**
    ```sql
    SELECT Platform AS Label, COUNT(*) AS Value
    FROM StreamingLogs
    GROUP BY Platform
    ORDER BY Value DESC;
    ```
*   **Sorgu Açıklaması:** `Platform` kolonuna göre gruplama yapılarak her bir platform için toplam kayıt sayısı hesaplanır. `ORDER BY Value DESC` ifadesiyle pazar payı en yüksek olan platform en üstte gösterilir.

---

### 7. Sayfa: Tür Dağılımı Analiz Paneli
<img width="1906" height="879" alt="Image" src="https://github.com/user-attachments/assets/6462c6a7-80b1-4dbb-a3fa-8642af1581df" />

*   **Arayüz Tanımı:** Kategori bazında popülerliği gösteren yatay çubuk (Bar) grafik arayüzüdür.
*   **Sorgunun Amacı:** En çok tercih edilen içerik türlerini (Aksiyon, Drama, Komedi vb.) tespit etmek.
*   **SQL Sorgusu:**
    ```sql
    SELECT Genre AS Label, COUNT(*) AS Value
    FROM StreamingLogs
    GROUP BY Genre
    ORDER BY Value DESC;
    ```
*   **Sorgu Açıklaması:** `Genre` (Tür) bilgisine göre gruplama yapılarak her türün izlenme frekansı bulunur. Grafik çizimi için veriler en yüksekten en düşüğe göre sıralanır.

---

### 8. Sayfa: Cihaz Dağılımı Analiz Paneli
<img width="1914" height="878" alt="Image" src="https://github.com/user-attachments/assets/be97a95e-13a8-41bb-9877-3a6c0e0186c0" />

*   **Arayüz Tanımı:** İzleyicilerin kullandığı donanımları (Mobile, Smart TV, PC, Tablet) gösteren dairesel (Pie) grafik ekranıdır.
*   **Sorgunun Amacı:** Platformun teknik optimizasyon ihtiyaçlarını (mobil veya TV odaklı geliştirme) belirlemek amacıyla cihaz kullanım oranlarını saptamak.
*   **SQL Sorgusu:**
    ```sql
    SELECT DeviceType AS Label, COUNT(*) AS Value
    FROM StreamingLogs
    GROUP BY DeviceType
    ORDER BY Value DESC;
    ```
*   **Sorgu Açıklaması:** `DeviceType` kolonu üzerinden gruplama ve sayma işlemi yapılarak cihaz kırılımları elde edilir.

---

### 9. Sayfa: Ülke Analizi Paneli
<img width="1916" height="879" alt="Image" src="https://github.com/user-attachments/assets/4c302c5b-e98b-4fa5-a26e-cb8ffc8bc2e3" />

*   **Arayüz Tanımı:** Platformun coğrafi olarak en aktif olduğu 5 ülkeyi sıralayan bar grafik ve mini sıralama listesidir.
*   **Sorgunun Amacı:** Küresel pazardaki en güçlü 5 ülkeyi izlenme sayılarına göre bulmak.
*   **SQL Sorgusu:**
    ```sql
    SELECT TOP 5 Country AS Label, COUNT(*) AS Value
    FROM StreamingLogs
    GROUP BY Country
    ORDER BY Value DESC;
    ```
*   **Sorgu Açıklaması:** `GROUP BY Country` ile tüm ülkeler gruplanır ve izlenme sayılarına göre sıralanır. `TOP 5` ifadesiyle sadece en yüksek izlenmeye sahip ilk 5 ülke çekilerek gereksiz veri transferi önlenir.

---

### 10. Sayfa: Saatlik İzlenme Dağıl Paneli
<img width="1907" height="874" alt="Image" src="https://github.com/user-attachments/assets/47c762e0-c659-40ae-9084-be300e7bbabc" />

*   **Arayüz Tanımı:** Günün 24 saatini yatay eksende gösteren, trafik yoğunluğunu ve zirve saatleri (Peak Hours) gösteren neon çizgi (Line) grafiğidir.
*   **Sorgunun Amacı:** Kullanıcıların günün hangi saatlerinde izleme yaptığını saptayarak sunucu yük yönetimi için veri sağlamak.
*   **SQL Sorgusu:**
    ```sql
    SELECT 
        RIGHT('0' + CAST(DATEPART(HOUR, WatchDate) AS VARCHAR), 2) + ':00' AS Label, 
        COUNT(*) AS Value
    FROM StreamingLogs
    GROUP BY DATEPART(HOUR, WatchDate)
    ORDER BY DATEPART(HOUR, WatchDate);
    ```
*   **Sorgu Açıklaması:** 
    *   `DATEPART(HOUR, WatchDate)` fonksiyonu, her kaydın izlenme tarihinden sadece saat dilimini (0-23) ayıklar.
    *   `CAST(... AS VARCHAR)` ve `RIGHT('0' + ..., 2)` işlemleri, tek haneli saatlerin başına sıfır ekleyerek standart bir saat formatı (Örn: 09:00, 15:00) oluşturur.
    *   Elde edilen saat dilimlerine göre gruplama ve sıralama yapılarak 24 saatlik izlenme akışı oluşturulur.

---

### 11. Sayfa: En Çok İzlenen 10 İçerik Paneli
<img width="1914" height="873" alt="Image" src="https://github.com/user-attachments/assets/18e1b828-bdc7-47dd-bf50-39b37f22c12b" />

*   **Arayüz Tanımı:** Platformda en yüksek izlenme sayısına ulaşan lider film ve dizileri sıralayan altın madalyon ikonlu özel bir sıralama tablosudur.
*   **Sorgunun Amacı:** Platformun en popüler 10 yapımını anlık olarak listelemek.
*   **SQL Sorgusu:**
    ```sql
    SELECT TOP 10 ContentTitle AS Label, COUNT(*) AS Value
    FROM StreamingLogs
    GROUP BY ContentTitle
    ORDER BY Value DESC;
    ```
*   **Sorgu Açıklaması:** İçerik başlıklarına (`ContentTitle`) göre gruplama yapılır, her başlığın izlenme adeti sayılır ve en yüksekten düşüğe doğru sıralanarak ilk 10 kayıt (`TOP 10`) çekilir.

---

### 12. Sayfa: Son İzlemeler & Tüm Kayıtlar Arama Motoru
<img width="1915" height="873" alt="Image" src="https://github.com/user-attachments/assets/008fb14c-3f4d-4ca7-a7e2-ba1d7f3b499b" />

*   **Arayüz Tanımı:** 5 farklı dinamik arama filtresine (Kullanıcı Adı, İçerik, Tür, Platform, İzleme Durumu) ve sayfa başına 12 kayıt getiren modern bir listeleme tablosuna sahip en kapsamlı arama sayfasıdır.
*   **Sorgunun Amacı:** 1 Milyon satırlık devasa tabloda filtre kriterlerine uyan kayıtları sunucuyu yormadan sayfalayarak getirmek.
<img width="1911" height="876" alt="Image" src="https://github.com/user-attachments/assets/098789ff-ca3f-4150-9d1b-e894f8a92cb5" />
*   
*   **SQL Sorgusu (Dinamik Paging):**
    ```sql
    SELECT LogId, UserName, ContentTitle, Genre, Platform,
           WatchDate, WatchDurationMin, Rating, Country, DeviceType, Status
    FROM StreamingLogs
    WHERE 1=1
      -- C# / Dapper tarafında filtre girildiyse dinamik eklenir:
      AND UserName LIKE @UserName
      AND ContentTitle LIKE @ContentTitle
      AND Genre = @Genre
      AND Platform = @Platform
      AND Status = @Status
    ORDER BY LogId DESC
    OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;
    ```
*   **Sorgu Açıklaması:** 
    *   `WHERE 1=1` ifadesi, dinamik olarak eklenecek `AND` filtrelerinin SQL sözdizimini (syntax) bozmasını engeller.
    *   `OFFSET @Offset ROWS` ifadesi, belirtilen sayı kadar satırı atlar (Örn: 3. sayfa için ilk 24 satır atlanır).
    *   `FETCH NEXT @PageSize ROWS ONLY` ifadesi, sadece belirtilen sayfa boyutu (bu projede 12) kadar kayıt çeker. Bu sayede 1 milyon satırlık veritabanından her seferinde sadece 12 kayıt çekilerek inanılmaz bir hız kazanılır.

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
