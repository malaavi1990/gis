using System;
using System.Collections.Generic;
using MohatechBusiness.Interfaces;
using MohatechDAL.UnitOfWork;
using MohatechDomain;

namespace MohatechBusiness.Classes
{
    public class ProductCategoryBusiness : IProductCategoryBusiness
    {
        private readonly UnitOfWork _uow = new UnitOfWork();

        public void Delete(ProductCategory productCategory)
        {
            try
            {
                _uow.ProductCategoryDal.Delete(productCategory);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public IEnumerable<ProductCategory> Get()
        {
            try
            {
                return _uow.ProductCategoryDal.Get();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public IEnumerable<ProductCategory> GetByProductId(int id)
        {
            try
            {
                return _uow.ProductCategoryDal.Get(p => p.ProductId == id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Insert(ProductCategory productCategory)
        {
            try
            {
                _uow.ProductCategoryDal.Insert(productCategory);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Save()
        {
            try
            {
                _uow.Save();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
