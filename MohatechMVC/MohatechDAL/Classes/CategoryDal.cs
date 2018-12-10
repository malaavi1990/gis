using System.Data.Entity;
using MohatechDAL.Interfaces;
using MohatechDAL.UnitOfWork;
using MohatechDomain;

namespace MohatechDAL.Classes
{
    public class CategoryDal : GenericDal<Category>, ICategoryDal
    {
        private readonly DataContext _context;
        private readonly DbSet<Category> _categories;
        public CategoryDal(DataContext context) : base(context)
        {
            _context = context;
            _categories = context.Set<Category>();
        }
    }
}
