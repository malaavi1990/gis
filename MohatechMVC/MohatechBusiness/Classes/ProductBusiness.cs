using System;
using System.Collections.Generic;
using MohatechBusiness.Interfaces;
using MohatechDAL.UnitOfWork;
using MohatechDomain;

namespace MohatechBusiness.Classes
{
    public class ProductBusiness : IProductBusiness
    {
        private readonly UnitOfWork _uow = new UnitOfWork();

        public IEnumerable<Product> Get()
        {
            try
            {
                return _uow.ProductDal.Get();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Product GetById(int Id)
        {
            try
            {
                return _uow.ProductDal.GetById(Id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Insert(Product product)
        {
            try
            {
                _uow.ProductDal.Insert(product);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Update(Product product)
        {
            try
            {
                _uow.ProductDal.Update(product);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Delete(int id)
        {
            try
            {
                _uow.ProductDal.Delete(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Save()
        {
            _uow.Save();
        }

    }
}
