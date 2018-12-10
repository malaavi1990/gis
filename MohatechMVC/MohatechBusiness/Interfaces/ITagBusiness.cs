using System.Collections.Generic;
using MohatechDomain;

namespace MohatechBusiness.Interfaces
{
    public interface ITagBusiness
    {
        IEnumerable<Tag> Get();
        Tag GetById(int Id);
        IEnumerable<Tag> GetByProductId(int id);
        void Insert(Tag tag);
        void Update(Tag tag);
        void Delete(int id);
        void Save();
    }
}
