using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MultiShop.Discount.Entities;
using System.Data;

namespace MultiShop.Discount.Context
{
    public class DapperContext:DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public DapperContext(IConfiguration configuration)
        {
            _connectionString=configuration.GetConnectionString("DefaultConnection");
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-DUEUI74;initial Catalog=MultiShopDiscountDB;Integrated Security=True;TrustServerCertificate=True;");
        }
        public DbSet<Coupon> Coupons { get; set; }
        
        public IDbConnection CreateConnection()=> new SqlConnection(_connectionString);
    }
}
