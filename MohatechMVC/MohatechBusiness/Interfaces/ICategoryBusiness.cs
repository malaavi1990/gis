using System.Collections.Generic;
using MohatechDomain;

namespace MohatechBusiness.Interfaces
{
    public interface ICategoryBusiness
    {
        IEnumerable<Category> Get();
        Category GetById(int Id);
        void Insert(Category category);
        void Update(Category category);
        void Delete(int id);
        void Save();
    }
}
