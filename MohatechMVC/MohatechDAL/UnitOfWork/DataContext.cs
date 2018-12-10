using MohatechDomain;
using System.Data.Entity;
using System.Diagnostics;

namespace MohatechDAL.UnitOfWork
{
    public class DataContext : DbContext, IDataContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

        void IDataContext.OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new System.NotImplementedException();
        }

        public DbSet<Setting> Settings { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Slider> Slider { get; set; }
        public DbSet<News> News { get ; set; }
    }
}
