using System.Data.Entity;
using MohatechDAL.Interfaces;
using MohatechDAL.UnitOfWork;
using MohatechDomain;

namespace MohatechDAL.Classes
{
    public class SoftwareDal : GenericDal<Software>, ISoftwareDal
    {
        private readonly DataContext _context;
        private readonly DbSet<Software> _software;
        public SoftwareDal(DataContext context) : base(context)
        {
            _context = context;
            _software = context.Set<Software>();
        }
    }
}
