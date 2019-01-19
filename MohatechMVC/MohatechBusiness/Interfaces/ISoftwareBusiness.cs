using System.Collections.Generic;
using MohatechDomain;

namespace MohatechBusiness.Interfaces
{
    public interface ISoftwareBusiness
    {
        IEnumerable<Software> Get();
        Software GetById(int id);
        void Insert(Software software);
        void Update(Software software);
        void Delete(int id);
        void Save();
    }
}
