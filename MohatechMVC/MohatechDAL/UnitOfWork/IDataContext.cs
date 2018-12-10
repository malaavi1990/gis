using MohatechDomain;
using System.Data.Entity;

namespace MohatechDAL.UnitOfWork
{
    public interface IDataContext
    {
        void OnModelCreating(DbModelBuilder modelBuilder);

         DbSet<Setting> Settings { get; set; }
         DbSet<Role> Roles { get; set; }
         DbSet<User> Users { get; set; }
         DbSet<Product> Products { get; set; }
         DbSet<Category> Categories { get; set; }
         DbSet<Gallery> Galleries { get; set; }
         DbSet<Tag> Tags { get; set; }
         DbSet<Slider> Slider { get; set; }
         DbSet<News> News { get; set; }
    }
}
