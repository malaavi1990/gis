using MohatechDAL.Interfaces;
using MohatechDAL.UnitOfWork;
using MohatechDomain;
using System.Data.Entity;
using System.Linq;

namespace MohatechDAL.Classes
{
    public class UserDal : GenericDal<User>, IUserDal
    {
        private readonly DataContext _context;
        private readonly DbSet<User> _users;
        public UserDal(DataContext context) : base(context)
        {
            _context = context;
            _users = context.Set<User>();
        }

        public User GetByEmail(string email)
        {
            return _users.SingleOrDefault(u => u.Email == email);
        }

        public User GetByActiveCode(string id)
        {
            return _users.SingleOrDefault(u => u.ActiveCode == id);
        }

        public string[] GetRoleByEmail(string email)
        {
            return _users.Where(u => u.Email == email).Select(u => u.Role.RoleName).ToArray();
        }

        public User GetByUserName(string userName)
        {
            return _users.SingleOrDefault(u => u.UserName == userName);
        }
    }
}
