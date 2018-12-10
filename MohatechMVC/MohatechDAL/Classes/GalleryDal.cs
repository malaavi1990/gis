using MohatechDomain;
using System.Data.Entity;
using MohatechDAL.Interfaces;
using MohatechDAL.UnitOfWork;

namespace MohatechDAL.Classes
{
    public class GalleryDal : GenericDal<Gallery>, IGalleryDal
    {
        private readonly DataContext _context;
        private readonly DbSet<Gallery> _galleries;
        public GalleryDal(DataContext context) : base(context)
        {
            _context = context;
            _galleries = context.Set<Gallery>();
        }
    }
}
