using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MohatechDomain;

namespace MohatechBusiness.Interfaces
{
    public interface ICommentBusiness
    {
        IEnumerable<Comment> Get();
        Comment GetById(int id);
        void Insert(Comment comment);
        void Update(Comment comment);
        void Delete(int id);
        void Save();
    }
}
