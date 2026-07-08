using Microsoft.Data.SqlClient;
using System.Data;

namespace StreamingAnalytics.Context
{
    // 📌 NE YAPAR?
    // Bu sınıf, uygulamamızın SQL Server'a bağlanmasını sağlar.
    // Her Controller veya Service bu sınıfı kullanarak veritabanına ulaşır.

    public class DapperContext
    {
        private readonly string _connectionString;

        // appsettings.json'dan bağlantı stringini okur
        public DapperContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")!;
        }

        // Her sorgu çalıştırılacağında yeni bir bağlantı açar
        public IDbConnection CreateConnection()
            => new SqlConnection(_connectionString);
    }
}
