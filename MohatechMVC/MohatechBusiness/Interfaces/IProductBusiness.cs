using System.Collections.Generic;
using MohatechDomain;

namespace MohatechBusiness.Interfaces
{
    public interface IProductBusiness
    {
        IEnumerable<Product> Get();
        Product GetById(int Id);
        void Insert(Product product);
        void Update(Product product);
        void Delete(int id);
        void Save();
    }
}
