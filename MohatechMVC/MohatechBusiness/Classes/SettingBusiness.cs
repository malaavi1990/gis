using System;
using MohatechBusiness.Interfaces;
using MohatechDAL.UnitOfWork;
using MohatechDomain;

namespace MohatechBusiness.Classes
{
    public class SettingBusiness : ISettingBusiness
    {
        private readonly UnitOfWork _uow = new UnitOfWork();

        public Setting Get()
        {
            try
            {
                return _uow.SettingDal.Get();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Update(Setting setting)
        {
            try
            {
                _uow.SettingDal.Update(setting);
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
