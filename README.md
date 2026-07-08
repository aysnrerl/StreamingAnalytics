🎬 StreamPulse — Real-Time Streaming Analytics Dashboard
FrameworkDatabaseORMVisualisationUI Style

StreamPulse, 1.000.000 (1 Milyon) canlı izleme kaydı barındıran devasa bir veri kümesi üzerinde, milisaniyeler seviyesinde çalışan gerçek zamanlı bir analitik sorgu ve görselleştirme motorudur.

ASP.NET Core 8.0 MVC mimarisi üzerine inşa edilen proje; veri erişim katmanında Dapper (Micro-ORM) kullanılarak ham SQL sorgularının performans sınırlarını zorlayacak şekilde tasarlanmıştır. Ön yüzde modern CSS Glassmorphism (Cam Efekti) Karanlık Tema tasarımı ve Chart.js ile dinamik grafikler sunmaktadır.

🖥️ 12 Temel Sayfa, Arayüz Paneli ve SQL Sorgu Detayları
StreamPulse üzerindeki her bir analitik bölüm, kendine ait bir arayüz görünümüne (Section/Page) ve optimize edilmiş bir SQL sorgusuna sahiptir. Aşağıda bu 12 yapının işlevleri, ekran tasarımları ve sorgu detayları tek tek açıklanmıştır:

1. Sayfa: Toplam İzlenme Metrik Kartı
Arayüz Tanımı: Dashboard'un en üstünde yer alan mor neon renkli ilk KPI kartıdır. Sistemde kayıtlı toplam etkileşim hacmini gösterir.
Sorgunun Amacı: Veritabanındaki StreamingLogs tablosunda bulunan toplam satır sayısını milisaniyeler içinde çekmek.
SQL Sorgusu:
sql

SELECT COUNT(*) FROM StreamingLogs;
Sorgu Açıklaması: COUNT(*) fonksiyonu tabloda bulunan tüm kayıtları sayar. Birincil anahtar (Primary Key - LogId) üzerinden tarama yaparak en hızlı şekilde sonucu döndürür.
2. Sayfa: Tekil İzleyici Metrik Kartı
Arayüz Tanımı: Dashboard üstündeki yeşil renkli ikinci KPI kartıdır. Platformu aktif olarak kullanan benzersiz kullanıcı kitlesinin büyüklüğünü temsil eder.
Sorgunun Amacı: Aynı kullanıcının yaptığı mükerrer izlemeleri eleyerek net kullanıcı sayısını bulmak.
SQL Sorgusu:
sql

SELECT COUNT(DISTINCT UserName) FROM StreamingLogs;
Sorgu Açıklaması: DISTINCT UserName ifadesi, kullanıcı adlarını tekilleştirir. COUNT ise bu tekil listenin eleman sayısını verir. 1 milyon kayıt arasında hızlı çalışması için UserName kolonu üzerinde indeksleme olması performansı doğrudan artırır.
3. Sayfa: İzlenme Saati Metrik Kartı
Arayüz Tanımı: Dashboard üzerindeki sarı renkli üçüncü KPI kartıdır. Kullanıcıların platformda geçirdiği toplam süreyi saat cinsinden gösterir.
Sorgunun Amacı: Dakika bazlı tutulan tüm izleme sürelerini toplayıp saate çevirerek kümülatif izlenme hacmini hesaplamak.
SQL Sorgusu:
sql

SELECT SUM(WatchDurationMin) / 60 FROM StreamingLogs;
Sorgu Açıklaması: SUM(WatchDurationMin) fonksiyonu tablodaki tüm satırların izlenme sürelerini toplar. Elde edilen değer 60'a bölünerek dakika cinsinden toplam süre, tam saat değerine dönüştürülür.
4. Sayfa: Ortalama Puan Metrik Kartı
Arayüz Tanımı: Dashboard üzerindeki kırmızı renkli dördüncü KPI kartıdır. Platformdaki içeriklerin genel izleyici memnuniyetini (10 üzerinden) yansıtır.
Sorgunun Amacı: Kullanıcıların verdiği tüm puanların aritmetik ortalamasını bulmak ve virgülden sonra tek hane olarak yuvarlamak.
SQL Sorgusu:
sql

SELECT ROUND(AVG(CAST(Rating AS FLOAT)), 1) FROM StreamingLogs;
Sorgu Açıklaması: CAST(Rating AS FLOAT) ile tam sayı olan puanlar ondalıklı sayıya dönüştürülür. AVG ile ortalama alınır ve ROUND(..., 1) fonksiyonuyla virgülden sonra tek basamağa yuvarlanarak (örn: 7.4) temiz bir çıktı elde edilir.
5. Sayfa: Aylık İzlenme Trendi Analiz Paneli
Arayüz Tanımı: Yan menüden veya dashboard'dan erişilebilen, zaman serisi analizini sunan geniş bar grafik ekranıdır.
Sorgunun Amacı: Son 12 ayın izlenme sayılarını ay bazında gruplayarak mevsimsel trendleri ve büyüme oranlarını gözlemlemek.
SQL Sorgusu:
sql

SELECT 
    FORMAT(WatchDate, 'yyyy-MM') AS Label,
    COUNT(*) AS Value
FROM StreamingLogs
WHERE WatchDate >= DATEADD(MONTH, -12, GETDATE())
GROUP BY FORMAT(WatchDate, 'yyyy-MM')
ORDER BY Label;
Sorgu Açıklaması:
WHERE WatchDate >= DATEADD(MONTH, -12, GETDATE()) filtresi ile sadece son 1 yıla ait veriler alınır.
FORMAT(WatchDate, 'yyyy-MM') fonksiyonu tarih bilgisini yıl-ay (Örn: 2026-06) formatına çevirir.
GROUP BY ile bu formatlı tarihlere göre gruplama yapılarak her ayın izlenme adeti (COUNT(*)) hesaplanır.
6. Sayfa: Platform Dağılımı Analiz Paneli
Arayüz Tanımı: Platformların pazar paylarını dinamik bir Doughnut (Simit) grafik ve sağ tarafında yüzde oranlarını içeren şık bir veri tablosuyla sunan sayfadır.
Sorgunun Amacı: İzleyicilerin hangi yayın platformlarında (Netflix, Prime, Disney+ vb.) yoğunlaştığını analiz etmek.
SQL Sorgusu:
sql

SELECT Platform AS Label, COUNT(*) AS Value
FROM StreamingLogs
GROUP BY Platform
ORDER BY Value DESC;
Sorgu Açıklaması: Platform kolonuna göre gruplama yapılarak her bir platform için toplam kayıt sayısı hesaplanır. ORDER BY Value DESC ifadesiyle pazar payı en yüksek olan platform en üstte gösterilir.
7. Sayfa: Tür Dağılımı Analiz Paneli
Arayüz Tanımı: Kategori bazında popülerliği gösteren yatay çubuk (Bar) grafik arayüzüdür.
Sorgunun Amacı: En çok tercih edilen içerik türlerini (Aksiyon, Drama, Komedi vb.) tespit etmek.
SQL Sorgusu:
sql

SELECT Genre AS Label, COUNT(*) AS Value
FROM StreamingLogs
GROUP BY Genre
ORDER BY Value DESC;
Sorgu Açıklaması: Genre (Tür) bilgisine göre gruplama yapılarak her türün izlenme frekansı bulunur. Grafik çizimi için veriler en yüksekten en düşüğe göre sıralanır.
8. Sayfa: Cihaz Dağılımı Analiz Paneli
Arayüz Tanımı: İzleyicilerin kullandığı donanımları (Mobile, Smart TV, PC, Tablet) gösteren dairesel (Pie) grafik ekranıdır.
Sorgunun Amacı: Platformun teknik optimizasyon ihtiyaçlarını (mobil veya TV odaklı geliştirme) belirlemek amacıyla cihaz kullanım oranlarını saptamak.
SQL Sorgusu:
sql

SELECT DeviceType AS Label, COUNT(*) AS Value
FROM StreamingLogs
GROUP BY DeviceType
ORDER BY Value DESC;
Sorgu Açıklaması: DeviceType kolonu üzerinden gruplama ve sayma işlemi yapılarak cihaz kırılımları elde edilir.
9. Sayfa: Ülke Analizi Paneli
Arayüz Tanımı: Platformun coğrafi olarak en aktif olduğu 5 ülkeyi sıralayan bar grafik ve mini sıralama listesidir.
Sorgunun Amacı: Küresel pazardaki en güçlü 5 ülkeyi izlenme sayılarına göre bulmak.
SQL Sorgusu:
sql

SELECT TOP 5 Country AS Label, COUNT(*) AS Value
FROM StreamingLogs
GROUP BY Country
ORDER BY Value DESC;
Sorgu Açıklaması: GROUP BY Country ile tüm ülkeler gruplanır ve izlenme sayılarına göre sıralanır. TOP 5 ifadesiyle sadece en yüksek izlenmeye sahip ilk 5 ülke çekilerek gereksiz veri transferi önlenir.
10. Sayfa: Saatlik İzlenme Dağılım Paneli
Arayüz Tanımı: Günün 24 saatini yatay eksende gösteren, trafik yoğunluğunu ve zirve saatleri (Peak Hours) gösteren neon çizgi (Line) grafiğidir.
Sorgunun Amacı: Kullanıcıların günün hangi saatlerinde izleme yaptığını saptayarak sunucu yük yönetimi için veri sağlamak.
SQL Sorgusu:
sql

SELECT 
    RIGHT('0' + CAST(DATEPART(HOUR, WatchDate) AS VARCHAR), 2) + ':00' AS Label, 
    COUNT(*) AS Value
FROM StreamingLogs
GROUP BY DATEPART(HOUR, WatchDate)
ORDER BY DATEPART(HOUR, WatchDate);
Sorgu Açıklaması:
DATEPART(HOUR, WatchDate) fonksiyonu, her kaydın izlenme tarihinden sadece saat dilimini (0-23) ayıklar.
CAST(... AS VARCHAR) ve RIGHT('0' + ..., 2) işlemleri, tek haneli saatlerin başına sıfır ekleyerek standart bir saat formatı (Örn: 09:00, 15:00) oluşturur.
Elde edilen saat dilimlerine göre gruplama ve sıralama yapılarak 24 saatlik izlenme akışı oluşturulur.
11. Sayfa: En Çok İzlenen 10 İçerik Paneli
Arayüz Tanımı: Platformda en yüksek izlenme sayısına ulaşan lider film ve dizileri sıralayan altın madalyon ikonlu özel bir sıralama tablosudur.
Sorgunun Amacı: Platformun en popüler 10 yapımını anlık olarak listelemek.
SQL Sorgusu:
sql

SELECT TOP 10 ContentTitle AS Label, COUNT(*) AS Value
FROM StreamingLogs
GROUP BY ContentTitle
ORDER BY Value DESC;
Sorgu Açıklaması: İçerik başlıklarına (ContentTitle) göre gruplama yapılır, her başlığın izlenme adeti sayılır ve en yüksekten düşüğe doğru sıralanarak ilk 10 kayıt (TOP 10) çekilir.
12. Sayfa: Son İzlemeler & Tüm Kayıtlar Arama Motoru
Arayüz Tanımı: 5 farklı dinamik arama filtresine (Kullanıcı Adı, İçerik, Tür, Platform, İzleme Durumu) ve sayfa başına 12 kayıt getiren modern bir listeleme tablosuna sahip en kapsamlı arama sayfasıdır.
Sorgunun Amacı: 1 Milyon satırlık devasa tabloda filtre kriterlerine uyan kayıtları sunucuyu yormadan sayfalayarak getirmek.
SQL Sorgusu (Dinamik Paging):
sql

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
Sorgu Açıklaması:
WHERE 1=1 ifadesi, dinamik olarak eklenecek AND filtrelerinin SQL sözdizimini (syntax) bozmasını engeller.
OFFSET @Offset ROWS ifadesi, belirtilen sayı kadar satırı atlar (Örn: 3. sayfa için ilk 24 satır atlanır).
FETCH NEXT @PageSize ROWS ONLY ifadesi, sadece belirtilen sayfa boyutu (bu projede 12) kadar kayıt çeker. Bu sayede 1 milyon satırlık veritabanından her seferinde sadece 12 kayıt çekilerek inanılmaz bir hız kazanılır.
🛠️ Teknoloji Yığını
Bileşen	Kullanılan Teknoloji	Seçim Nedeni
Framework	ASP.NET Core 8.0 MVC	Modüler, güvenli ve kurumsal standartlarda MVC mimarisi.
Veri Tabanı	MS SQL Server (Express)	İlişkisel veri modeli ve büyük ölçekli sorgulamalar için güçlü indeksleme yeteneği.
Veri Erişim (ORM)	Dapper (Micro-ORM)	Entity Framework Core'a kıyasla ham SQL gücü ve sıfıra yakın overhead ile maksimum sorgu hızı.
Veri Transferi	DTO (Data Transfer Object)	Yalnızca ihtiyaç duyulan kolonların taşınmasıyla RAM ve network optimizasyonu.
Görselleştirme	Chart.js	Canvas tabanlı, responsive ve animasyonlu modern grafik kütüphanesi.
Tasarım & Tema	Kişiselleştirilmiş Vanilla CSS	Neon geçişler, derinlik hissi veren gölgelendirmeler (shadows), glassmorphism ve responsive tasarım.
📂 Proje Yapısı
text

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
⚡ Veritabanı Yapısı & İndeks Optimizasyonu
Tablo Şeması (StreamingLogs)
Uygulama, SQL Server üzerinde aşağıdaki şemaya sahip StreamingLogs tablosunu sorgular:

Kolon Adı	Veri Tipi	Açıklama
LogId	INT (PK, Identity)	Benzersiz log kimliği
UserName	NVARCHAR(100)	İzleyen kullanıcının adı
ContentTitle	NVARCHAR(250)	İzlenen film/dizi başlığı
Genre	NVARCHAR(50)	İçeriğin türü (Kategori)
Platform	NVARCHAR(50)	Yayıncı platform
WatchDate	DATETIME	İzleme tarihi ve saati
WatchDurationMin	INT	İzleme süresi (Dakika)
Rating	DECIMAL(3,1)	Kullanıcının verdiği puan (1-10)
Country	NVARCHAR(100)	İzleyicinin ülkesi
DeviceType	NVARCHAR(50)	Kullanılan cihaz (Mobil, TV vb.)
Status	NVARCHAR(50)	İzleme durumu (Completed, Dropped vb.)
İndeks Optimizasyonu (Performans Sırrı)
1 milyon veri satırında anlık filtreleme yaparken gecikmeyi önlemek için veritabanında şu indekslerin (Indexes) tanımlanması önerilir:

sql

CREATE NONCLUSTERED INDEX IX_StreamingLogs_Filters 
ON StreamingLogs (Platform, Genre, Status)
INCLUDE (UserName, ContentTitle, WatchDate, WatchDurationMin, Rating, Country, DeviceType);
Bu indeks sayesinde, arama kriterlerine göre veriler tüm tablo taranmadan (Table Scan yerine Index Seek ile) milisaniyeler düzeyinde çekilir.

🔧 Kurulum ve Çalıştırma
1. Ön Koşullar
.NET 8.0 SDK bilgisayarınızda kurulu olmalıdır.
Yerel bir MS SQL Server (LocalDB veya Express) çalışır durumda olmalıdır.
2. Veritabanı Bağlantısı
StreamingAnalytics/appsettings.json dosyasını açın ve kendi yerel SQL Server bağlantı adresinize göre DefaultConnection değerini düzenleyin:

json

"ConnectionStrings": {
  "DefaultConnection": "Server=.\\SQLEXPRESS;Database=StreamingDB;Trusted_Connection=True;TrustServerCertificate=True"
}
3. Çalıştırma Komutları
Proje dizinine giderek terminal veya PowerShell üzerinden uygulamayı başlatın:

bash

# Bağımlılıkları yükle
dotnet restore
# Uygulamayı çalıştır
dotnet run --project StreamingAnalytics
Tarayıcınızda açılan adreste (örneğin https://localhost:5001 veya http://localhost:5000) StreamPulse Dashboard'u görüntüleyebilirsiniz.
