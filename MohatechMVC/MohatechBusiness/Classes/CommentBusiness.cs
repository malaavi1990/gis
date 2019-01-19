using System;
using System.Collections.Generic;
using MohatechBusiness.Interfaces;
using MohatechDAL.UnitOfWork;
using MohatechDomain;

namespace MohatechBusiness.Classes
{
    public class CommentBusiness : ICommentBusiness
    {
        private readonly IUnitOfWork _uow = new UnitOfWork();

        public IEnumerable<Comment> Get()
        {
            try
            {
                return _uow.CommentDal.Get();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Comment GetById(int id)
        {
            try
            {
                return _uow.CommentDal.GetById(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Insert(Comment comment)
        {
            try
            {
                _uow.CommentDal.Insert(comment);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Update(Comment comment)
        {
            try
            {
                _uow.CommentDal.Update(comment);
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
                _uow.CommentDal.Delete(id);
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
