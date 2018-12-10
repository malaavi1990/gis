using MohatechDomain;
using System.Collections.Generic;

namespace MohatechBusiness.Interfaces
{
    public interface IRoleBusiness
    {
        IEnumerable<Role> Get();
        Role GetById(int id);
        bool CheckRoleName(string roleName);
        void Insert(Role role);
        void Update(Role role);
        void Delete(Role role);
        void Save();

    }
}
