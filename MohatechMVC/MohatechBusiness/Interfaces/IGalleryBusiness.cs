using System.Collections.Generic;
using MohatechDomain;

namespace MohatechBusiness.Interfaces
{
    public interface IGalleryBusiness
    {
        IEnumerable<Gallery> Get();
        IEnumerable<Gallery> GetByProductId(int id);
        Gallery GetById(int Id);
        void Insert(Gallery gallery);
        void Update(Gallery gallery);
        void Delete(int id);
        void Save();
    }
}
