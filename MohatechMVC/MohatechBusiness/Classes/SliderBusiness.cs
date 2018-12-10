using System;
using System.Collections.Generic;
using MohatechBusiness.Interfaces;
using MohatechDAL.UnitOfWork;
using MohatechDomain;

namespace MohatechBusiness.Classes
{
    public class SliderBusiness : ISliderBusiness
    {
        private readonly UnitOfWork _uow = new UnitOfWork();
        public IEnumerable<Slider> Get()
        {
            try
            {
                return _uow.SliderDal.Get();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Slider GetById(int id)
        {
            try
            {
                return _uow.SliderDal.GetById(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Insert(Slider slider)
        {
            try
            {
                _uow.SliderDal.Insert(slider);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public void Update(Slider slider)
        {
            try
            {
                _uow.SliderDal.Update(slider);
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
                _uow.SliderDal.Delete(id);
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
