using MohatechDomain;

namespace MohatechDAL.Interfaces
{
    public interface IUserDal : IGenericDal<User>
    {
        User GetByEmail(string email);
        User GetByActiveCode(string id);
        string[] GetRoleByEmail(string email);
        User GetByUserName(string userName);
    }
}
