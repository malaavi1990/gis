using System.Data.Entity;
using MohatechDAL.Interfaces;
using MohatechDAL.UnitOfWork;
using MohatechDomain;

namespace MohatechDAL.Classes
{
    public class TagDal : GenericDal<Tag>, ITagDal
    {
        private readonly DataContext _context;
        private readonly DbSet<Tag> _tags;
        public TagDal(DataContext context) : base(context)
        {
            _context = context;
            _tags = context.Set<Tag>();
        }
    }
}
