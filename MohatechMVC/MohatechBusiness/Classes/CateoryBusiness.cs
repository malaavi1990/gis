using System;
using System.Collections.Generic;
using MohatechBusiness.Interfaces;
using MohatechDAL.UnitOfWork;
using MohatechDomain;

namespace MohatechBusiness.Classes
{
    public class CateoryBusiness : ICategoryBusiness
    {
        private readonly UnitOfWork _uow = new UnitOfWork();

        public IEnumerable<Category> Get()
        {
            try
            {
                return _uow.CategoryDal.Get();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Category GetById(int Id)
        {
            try
            {
                return _uow.CategoryDal.GetById(Id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Insert(Category category)
        {
            try
            {
                _uow.CategoryDal.Insert(category);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Update(Category category)
        {
            try
            {
                _uow.CategoryDal.Update(category);
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
                _uow.CategoryDal.Delete(id);
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
