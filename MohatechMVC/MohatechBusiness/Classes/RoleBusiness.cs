using MohatechBusiness.Interfaces;
using MohatechDAL.UnitOfWork;
using MohatechDomain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MohatechBusiness.Classes
{
    public class RoleBusiness : IRoleBusiness
    {
        private readonly UnitOfWork _uow = new UnitOfWork();

        public IEnumerable<Role> Get()
        {
            try
            {
                return _uow.RoleDal.Get().ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Role GetById(int id)
        {
            try
            {
                return _uow.RoleDal.GetById(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public bool CheckRoleName(string roleName)
        {
            try
            {
                var checkRole = _uow.RoleDal.Get(u => u.RoleName == roleName);
                if (checkRole.Count() != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Insert(Role role)
        {
            try
            {
                _uow.RoleDal.Insert(role);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Update(Role role)
        {
            try
            {
                _uow.RoleDal.Update(role);
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

        public void Delete(Role role)
        {
            try
            {
                _uow.RoleDal.Delete(role);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
