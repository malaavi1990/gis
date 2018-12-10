using System;
using System.Collections.Generic;
using System.Linq;
using MohatechBusiness.Interfaces;
using MohatechDAL.UnitOfWork;
using MohatechDomain;

namespace MohatechBusiness.Classes
{
    public class TagBusiness : ITagBusiness
    {
        private readonly UnitOfWork _uow = new UnitOfWork();
        public IEnumerable<Tag> Get()
        {
            try
            {
                return _uow.TagDal.Get();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Tag GetById(int Id)
        {
            try
            {
                return _uow.TagDal.GetById(Id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Insert(Tag tag)
        {
            try
            {
                _uow.TagDal.Insert(tag);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Update(Tag tag)
        {
            try
            {
                _uow.TagDal.Update(tag);
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
                _uow.TagDal.Delete(id);
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

        public IEnumerable<Tag> GetByProductId(int id)
        {
            try
            {
                return _uow.TagDal.Get(t => t.ProductId == id);
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
