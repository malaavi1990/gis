using System.Data.Entity;
using MohatechDAL.Interfaces;
using MohatechDAL.UnitOfWork;
using MohatechDomain;

namespace MohatechDAL.Classes
{
    public class NewsDal : GenericDal<News>, INewsDal
    {
        private readonly DataContext _context;
        private readonly DbSet<News> _newses;

        public NewsDal(DataContext context):base(context)
        {
            _context = context;
            _newses = context.Set<News>();
        }
    }
}
