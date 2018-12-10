using MohatechDAL.Interfaces;
using MohatechDAL.UnitOfWork;
using MohatechDomain;
using System.Data.Entity;

namespace MohatechDAL.Classes
{
    public class RoleDal : GenericDal<Role>, IRoleDal
    {
        private readonly DataContext _context;
        private readonly DbSet<Role> _roles;
        public RoleDal(DataContext context) : base(context)
        {
            _context = context;
            _roles = context.Set<Role>();
        }

    }
}
