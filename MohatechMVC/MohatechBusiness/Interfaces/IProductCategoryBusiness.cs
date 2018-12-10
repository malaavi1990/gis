using System.Collections.Generic;
using MohatechDomain;

namespace MohatechBusiness.Interfaces
{
    public interface IProductCategoryBusiness
    {
        IEnumerable<ProductCategory> Get();
        IEnumerable<ProductCategory> GetByProductId(int id);
        void Insert(ProductCategory productCategory);
        void Delete(ProductCategory productCategory);
        void Save();
    }
}
