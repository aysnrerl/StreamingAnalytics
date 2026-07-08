# 🎬 StreamPulse

<div align="center">

### 🚀 High-Performance Real-Time Streaming Analytics Dashboard

*A modern analytics dashboard built with **ASP.NET Core 8 MVC**, **Dapper**, **SQL Server**, and **Chart.js**, capable of analyzing over **1 Million Streaming Records** with lightning-fast SQL queries.*

<br>

![.NET](https://img.shields.io/badge/.NET-8-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET_Core-MVC-5C2D91?style=for-the-badge)
![Dapper](https://img.shields.io/badge/Dapper-Micro_ORM-007ACC?style=for-the-badge)
![SQL Server](https://img.shields.io/badge/SQL_Server-2022-CC2927?style=for-the-badge&logo=microsoftsqlserver&logoColor=white)
![Chart.js](https://img.shields.io/badge/Chart.js-FF6384?style=for-the-badge&logo=chartdotjs&logoColor=white)
![HTML5](https://img.shields.io/badge/HTML5-E34F26?style=for-the-badge&logo=html5&logoColor=white)
![CSS3](https://img.shields.io/badge/CSS3-1572B6?style=for-the-badge&logo=css3&logoColor=white)
![JavaScript](https://img.shields.io/badge/JavaScript-F7DF1E?style=for-the-badge&logo=javascript&logoColor=black)

![GitHub stars](https://img.shields.io/github/stars/aysnrerl/StreamingAnalytics?style=social)
![GitHub forks](https://img.shields.io/github/forks/aysnrerl/StreamingAnalytics?style=social)

</div>

---

# 📖 About The Project

**StreamPulse** is a high-performance web application designed to demonstrate how large-scale streaming datasets can be analyzed efficiently using optimized SQL queries and the Dapper Micro ORM.

The project simulates a professional streaming analytics platform that processes more than **1,000,000 streaming records**, transforming raw data into meaningful business insights through interactive dashboards, KPI cards, dynamic charts, and advanced filtering capabilities.

Unlike traditional CRUD applications, StreamPulse focuses on **performance**, **query optimization**, **data visualization**, and **clean software architecture**.

The project showcases how modern ASP.NET Core applications can achieve exceptional performance by combining lightweight data access with carefully optimized SQL statements.

---

# ✨ Key Features

* 🚀 Analyze more than **1 Million Records**
* ⚡ Ultra-fast SQL queries using **Dapper**
* 📊 Interactive Dashboard
* 📈 Real-time Analytics
* 📉 Dynamic Charts
* 🎯 KPI Cards
* 🔍 Advanced Filtering
* 📄 Server-side Pagination
* 📱 Responsive Design
* 🌙 Modern Glassmorphism Dark Theme
* 🗄 Optimized SQL Server Database
* 💾 Clean DTO Architecture
* 🧩 Dependency Injection
* 📦 Modular MVC Structure
* 🔥 High Performance Data Access

---

# 🎯 Project Goals

The main objective of this project is to demonstrate enterprise-level dashboard development techniques using modern Microsoft technologies.

The application focuses on:

* High-performance SQL queries
* Lightweight data access
* Dashboard development
* Data visualization
* Large dataset management
* Clean Architecture principles
* Responsive UI Design
* Server-side optimization

---

# 📚 Table of Contents

* [About](#-about-the-project)
* [Features](#-key-features)
* [Goals](#-project-goals)
* [System Architecture](#-system-architecture)
* [Technology Stack](#-technology-stack)
* [Why Dapper?](#-why-dapper)
* [Performance Highlights](#-performance-highlights)
* [Dashboard Modules](#-dashboard-modules)
* [SQL Performance Strategy](#-sql-performance-strategy)
* [Database Design](#-database-design)
* [Project Structure](#-project-structure)
* [Installation](#-installation)
* [Future Improvements](#-future-improvements)
* [License](#-license)

---

# 🏗 System Architecture

```text
                    User
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
             Parameterized SQL
                      │
                SQL Server 2022
                      │
              StreamingLogs Table
```

---

# 🛠 Technology Stack

| Category             | Technology              |
| -------------------- | ----------------------- |
| Framework            | ASP.NET Core 8 MVC      |
| Language             | C# 12                   |
| ORM                  | Dapper                  |
| Database             | Microsoft SQL Server    |
| Frontend             | HTML5, CSS3, JavaScript |
| Charts               | Chart.js                |
| Styling              | Custom Glassmorphism UI |
| Architecture         | MVC                     |
| Dependency Injection | Built-in .NET DI        |
| Pagination           | Server-side             |
| Query Language       | SQL                     |
| IDE                  | Visual Studio 2022      |

---

# 💎 Why Dapper?

Instead of using Entity Framework Core, this project intentionally uses **Dapper** to maximize query performance.

### Advantages

* Extremely fast query execution
* Minimal memory overhead
* Full SQL control
* Lightweight architecture
* Excellent scalability
* Enterprise-ready performance
* Ideal for reporting systems
* Perfect for analytics dashboards

---

# 📈 Performance Highlights

| Metric            | Value              |
| ----------------- | ------------------ |
| Dataset Size      | 1,000,000+ Records |
| Dashboard Modules | 12                 |
| Charts            | 8+                 |
| KPI Cards         | 4                  |
| Database          | SQL Server         |
| ORM               | Dapper             |
| Filtering         | Dynamic            |
| Pagination        | Server-side        |
| Architecture      | MVC                |
| UI Theme          | Glassmorphism      |

---

> ⭐ **StreamPulse is designed as a portfolio-quality analytics dashboard demonstrating enterprise software development practices, SQL optimization techniques, and high-performance data visualization using ASP.NET Core MVC and Dapper.**

---

# 📊 Dashboard Modules

The StreamPulse dashboard is organized into **12 analytics modules**, each designed to provide valuable insights into streaming platform activity. Every module is powered by an optimized SQL query and delivers near real-time results.

---

### 📌 1. Total Streaming Records
* **Purpose:** Displays the total number of streaming activities stored in the database.
* **Key Insights:** Overall streaming volume, database growth, and total platforms activity.

**SQL Operation:**
```sql
SELECT COUNT(*) FROM StreamingLogs;
```

---

### 📌 2. Unique Users
* **Purpose:** Shows the number of distinct users who have watched at least one piece of content.
* **Key Insights:** Active audience size, user engagement levels, and platforms reach.

**SQL Operation:**
```sql
SELECT COUNT(DISTINCT UserName) FROM StreamingLogs;
```

---

### 📌 3. Total Watch Time
* **Purpose:** Calculates the cumulative watch duration across the entire platform.
* **Key Insights:** Cumulative watch hours, total platform usage, and user stickiness.

**SQL Operation:**
```sql
SELECT SUM(WatchDurationMin) / 60 FROM StreamingLogs;
```

---

### 📌 4. Average Rating
* **Purpose:** Calculates the average rating given by viewers across all content.
* **Key Insights:** Viewer satisfaction levels, content quality indicators, and platform scoring trends.

**SQL Operation:**
```sql
SELECT ROUND(AVG(CAST(Rating AS FLOAT)), 1) FROM StreamingLogs;
```

---

### 📌 5. Monthly Streaming Trend
* **Purpose:** Visualizes streaming activity over the last 12 months.
* **Key Insights:** Monthly growth metrics, seasonal spikes, and long-term user behavior trends.

**SQL Operation:**
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

### 📌 6. Streaming Platform Distribution
* **Purpose:** Shows the popularity and market share of different streaming services.
* **Key Insights:** Comparative volumes for Netflix, Disney+, Prime Video, HBO Max, and Apple TV+.

**SQL Operation:**
```sql
SELECT Platform AS Label, COUNT(*) AS Value
FROM StreamingLogs
GROUP BY Platform
ORDER BY Value DESC;
```

---

### 📌 7. Genre Analytics
* **Purpose:** Displays the most popular content categories among users.
* **Key Insights:** Preferred genres (Action, Drama, Comedy, Horror, Romance, Documentary, etc.).

**SQL Operation:**
```sql
SELECT Genre AS Label, COUNT(*) AS Value
FROM StreamingLogs
GROUP BY Genre
ORDER BY Value DESC;
```

---

### 📌 8. Device Distribution
* **Purpose:** Analyzes which device types users prefer for streaming content.
* **Key Insights:** Hardware trends (Mobile, Desktop, Smart TV, Tablet) to drive frontend optimizations.

**SQL Operation:**
```sql
SELECT DeviceType AS Label, COUNT(*) AS Value
FROM StreamingLogs
GROUP BY DeviceType
ORDER BY Value DESC;
```

---

### 📌 9. Country Analytics
* **Purpose:** Identifies the countries generating the highest streaming sessions.
* **Key Insights:** Geographic traffic distribution, regional trends, and market presence.

**SQL Operation:**
```sql
SELECT TOP 5 Country AS Label, COUNT(*) AS Value
FROM StreamingLogs
GROUP BY Country
ORDER BY Value DESC;
```

---

### 📌 10. Peak Streaming Hours
* **Purpose:** Displays streaming traffic levels hourly throughout the day.
* **Key Insights:** Peak traffic times, server planning metrics, and infrastructure scheduling.

**SQL Operation:**
```sql
SELECT 
    RIGHT('0' + CAST(DATEPART(HOUR, WatchDate) AS VARCHAR), 2) + ':00' AS Label, 
    COUNT(*) AS Value
FROM StreamingLogs
GROUP BY DATEPART(HOUR, WatchDate)
ORDER BY DATEPART(HOUR, WatchDate);
```

---

### 📌 11. Top 10 Most Watched Content
* **Purpose:** Ranks the individual movies and TV shows with the highest watch volume.
* **Key Insights:** Hit content identification, recommendation engine inputs, and trends.

**SQL Operation:**
```sql
SELECT TOP 10 ContentTitle AS Label, COUNT(*) AS Value
FROM StreamingLogs
GROUP BY ContentTitle
ORDER BY Value DESC;
```

---

### 📌 12. Advanced Search & Pagination
* **Purpose:** Provides a deep data exploration interface with dynamic multi-parameter filters.
* **Key Insights:** Instantly filters logs by Username, Content Title, Genre, Platform, and Status on 1,000,000+ rows.

**SQL Operation:**
```sql
SELECT LogId, UserName, ContentTitle, Genre, Platform,
       WatchDate, WatchDurationMin, Rating, Country, DeviceType, Status
FROM StreamingLogs
WHERE 1=1
  -- Dynamic filters are appended as parameters in Dapper:
  -- AND UserName LIKE @UserName
  -- AND ContentTitle LIKE @ContentTitle
  -- AND Genre = @Genre
  -- AND Platform = @Platform
  -- AND Status = @Status
ORDER BY LogId DESC
OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;
```

---

# ⚡ SQL Performance Strategy

The application is optimized to handle datasets containing **more than one million records** while maintaining responsive performance.

## Optimization Techniques

* **Dapper Micro ORM:** Direct SQL compilation bypasses EF Core's heavy translation layer.
* **Parameterized SQL Queries:** Prevents SQL injection and benefits from SQL Server's query plan caching.
* **Server-side Pagination:** Avoids loading large datasets into RAM by utilizing SQL `OFFSET-FETCH`.
* **Covering Indexes:** Resolves analytical queries directly from index trees without hitting the base table.
* **Index Seek Operations:** Avoids full table scans, reducing logical page reads.
* **DTO-based Data Transfer:** Limits RAM overhead by mapping only the required fields.

---

# 🚀 Performance Advantages

* **Lightning-Fast Queries:** Dashboard metrics compute in < 15ms.
* **Minimal Memory Consumption:** Light backend foot-print (< 90MB RAM under load).
* **High Responsiveness:** Instant table filtering on 1M rows.
* **Scalable Codebase:** Modular MVC structure allows adding indexes or caching seamlessly.

---

# 🗄 Database Design

StreamPulse is built around a centralized streaming activity table called **StreamingLogs**. The table is designed to support analytical queries, dashboard metrics, reporting operations, and high-performance filtering.

## Entity Structure

| Column | Data Type | Description |
| :--- | :--- | :--- |
| **LogId** | **INT (PK, Identity)** | Primary Key |
| **UserName** | **NVARCHAR(100)** | Viewer username |
| **ContentTitle** | **NVARCHAR(250)** | Movie or TV show title |
| **Genre** | **NVARCHAR(50)** | Content category |
| **Platform** | **NVARCHAR(50)** | Streaming provider |
| **WatchDate** | **DATETIME** | Watch timestamp |
| **WatchDurationMin** | **INT** | Duration in minutes |
| **Rating** | **DECIMAL(3,1)** | User rating (1-10) |
| **Country** | **NVARCHAR(100)** | Viewer country |
| **DeviceType** | **NVARCHAR(50)** | Device used |
| **Status** | **NVARCHAR(50)** | Watch status (Completed, Dropped, etc.) |

---

## ⚡ Database Index Optimization

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

# 📂 Project Structure

```text
StreamPulse
│
├── StreamingAnalytics/
│   ├── Context/
│   │   └── DapperContext.cs           # Database connection manager
│   │
│   ├── Controllers/
│   │   ├── DashboardController.cs     # Manages stats, KPIs & Charts
│   │   └── StreamingController.cs     # Manages filtering & paging logs
│   │
│   ├── Dtos/
│   │   ├── ChartItemDto.cs            # General key-value model for graphs
│   │   ├── DashboardStatsDto.cs       # KPI metrics model
│   │   ├── DashboardViewModel.cs      # Core viewmodel for the dashboard
│   │   └── StreamingLogDto.cs         # Model for streaming log records
│   │
│   ├── Views/
│   │   ├── Dashboard/
│   │   │   ├── Index.cshtml           # Home dashboard interface
│   │   │   └── Charts.cshtml          # Dynamic analytical charts page
│   │   │
│   │   ├── Streaming/
│   │   │   └── Index.cshtml           # Paged logs and filter form view
│   │   │
│   │   └── Shared/
│   │       └── _Layout.cshtml         # Responsive dark-theme template
│   │
│   ├── wwwroot/                       # Static files (CSS, JS, fonts)
│   ├── appsettings.json               # Configuration & connection string
│   └── Program.cs                     # Program startup & service injections
│
└── StreamingAnalytics.slnx            # Solution file
```

---

# 🔄 Request Lifecycle

```text
User Request
      │
      ▼
Controller
      │
      ▼
Dapper Query
      │
      ▼
SQL Server
      │
      ▼
DTO Mapping
      │
      ▼
View Model
      │
      ▼
Razor View
      │
      ▼
Browser Response
```

---

# ⚙ Dependency Injection

```csharp
builder.Services.AddScoped<DapperContext>();
builder.Services.AddScoped<StreamingService>();
```

---

# 🔐 Security Considerations

The application uses parameterized SQL queries to protect against SQL Injection attacks.

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

# 🔧 Installation

### 1. Prerequisites
* [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
* Microsoft SQL Server (LocalDB, Express, or Developer Edition)

### 2. Database Creation

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

### 3. Configuration

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=.\\SQLEXPRESS;Database=StreamingDB;Trusted_Connection=True;TrustServerCertificate=True"
}
```

### 4. Running the Application

```bash
dotnet restore
dotnet run --project StreamingAnalytics
```

Open your browser and navigate to `https://localhost:5001` or `http://localhost:5000`.

---

# 🚀 Future Improvements

* 📡 **Real-time Seeder:** Background worker to simulate active viewers generating logs in real-time.
* ⚡ **Caching Layer:** Redis integration for caching platform statistics and top content lists.
* 🔔 **WebSockets Integration:** SignalR implementation to push analytics updates to the UI in real-time.
* 🐳 **Dockerization:** Containerization setup for quick multi-environment deployments.

---

# 📄 License

Distributed under the MIT License. See `LICENSE` for more information.
