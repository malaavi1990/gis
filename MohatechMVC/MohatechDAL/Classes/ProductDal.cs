using System.Data.Entity;
using MohatechDAL.Interfaces;
using MohatechDAL.UnitOfWork;
using MohatechDomain;

namespace MohatechDAL.Classes
{
    public class ProductDal : GenericDal<Product>, IProductDal
    {
        private readonly DataContext _context;
        private readonly DbSet<Product> _products;
        public ProductDal(DataContext context) : base(context)
        {
            _context = context;
            _products = context.Set<Product>();
        }
    }
}
