using System.Data.Entity;
using MohatechDAL.Interfaces;
using MohatechDAL.UnitOfWork;
using MohatechDomain;

namespace MohatechDAL.Classes
{
    public class ProductCategoryDal : GenericDal<ProductCategory>, IProductCategoryDal
    {
        private readonly DataContext _context;
        private readonly DbSet<ProductCategory> _productCategories;
        public ProductCategoryDal(DataContext context) : base(context)
        {
            _context = context;
            _productCategories = context.Set<ProductCategory>();
        }
    }
}
