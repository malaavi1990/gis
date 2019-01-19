using System.Data.Entity;
using MohatechDAL.Interfaces;
using MohatechDAL.UnitOfWork;
using MohatechDomain;

namespace MohatechDAL.Classes
{
    public class BookDal : GenericDal<Book>, IBookDal
    {
        private readonly DataContext _context;
        private readonly DbSet<Book> _book;

        public BookDal(DataContext context) : base(context)
        {
            _context = context;
            _book = context.Set<Book>();
        }
    }
}
