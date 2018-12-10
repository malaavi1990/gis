using MohatechDomain;
using System;
using System.Collections.Generic;

namespace MohatechBusiness.Interfaces
{
    public interface IUserBusiness : IDisposable
    {
        IEnumerable<User> Get();
        User GetById(int id);
        User GetByUserName(string userName);
        User GetByEmail(string email);
        User GetByActiveCode(string id);
        void Update(User user);
        void Insert(User user);
        string[] GetRoleByEmail(string email);
        void Delete(User user);
        void Save();
        void Dispose();
        bool CheckEmail(string email);
    }
}
