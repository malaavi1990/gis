using System;
using System.Collections.Generic;
using MohatechBusiness.Interfaces;
using MohatechDAL.UnitOfWork;
using MohatechDomain;

namespace MohatechBusiness.Classes
{
    public class GalleryBusiness : IGalleryBusiness
    {
        private readonly UnitOfWork _uow = new UnitOfWork();
        public IEnumerable<Gallery> Get()
        {
            try
            {
                return _uow.GalleryDal.Get();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Gallery GetById(int Id)
        {
            try
            {
                return _uow.GalleryDal.GetById(Id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Insert(Gallery gallery)
        {
            try
            {
                _uow.GalleryDal.Insert(gallery);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Update(Gallery gallery)
        {
            try
            {
                _uow.GalleryDal.Update(gallery);
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
                _uow.GalleryDal.Delete(id);
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

        public IEnumerable<Gallery> GetByProductId(int id)
        {
            try
            {
                return _uow.GalleryDal.Get(g => g.ProductId == id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
