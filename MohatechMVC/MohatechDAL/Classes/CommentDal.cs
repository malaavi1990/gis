using System.Data.Entity;
using MohatechDAL.Interfaces;
using MohatechDAL.UnitOfWork;
using MohatechDomain;

namespace MohatechDAL.Classes
{
    public class CommentDal : GenericDal<Comment>, ICommentDal
    {
        private readonly DataContext _context;
        private readonly DbSet<Comment> _comment;
        public CommentDal(DataContext context) : base(context)
        {
            _context = context;
            _comment = context.Set<Comment>();
        }
    }
}
