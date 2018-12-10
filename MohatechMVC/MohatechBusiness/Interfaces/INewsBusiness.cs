using System.Collections.Generic;
using MohatechDomain;

namespace MohatechBusiness.Interfaces
{
    public interface INewsBusiness
    {
        IEnumerable<News> Get();
        News GetById(int id);
        void Insert(News news);
        void Update(News news);
        void Delete(int id);
        void Save();
    }
}
