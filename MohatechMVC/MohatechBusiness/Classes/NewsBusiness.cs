using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MohatechBusiness.Interfaces;
using MohatechDAL.UnitOfWork;
using MohatechDomain;

namespace MohatechBusiness.Classes
{
    public class NewsBusiness : INewsBusiness
    {
        private readonly UnitOfWork _uow=new UnitOfWork();
        public IEnumerable<News> Get()
        {
            try
            {
                return _uow.NewsDal.Get();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public News GetById(int id)
        {
            try
            {
                return _uow.NewsDal.GetById(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Insert(News news)
        {
            try
            {
                _uow.NewsDal.Insert(news);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Update(News news)
        {
            try
            {
                _uow.NewsDal.Update(news);
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
                _uow.NewsDal.Delete(id);
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
