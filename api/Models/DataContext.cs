using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder options) { }

        //
        public DbSet<FoodModel> Foods { get; set; }
        public DbSet<OrderDetailModel> OrderDetails { get; set; }
        public DbSet<OrderModel> Orders { get; set; }
        public DbSet<CustomerModel> Customers { get; set; }
        public DbSet<UserModel> Users { get; set; }
    }
}
