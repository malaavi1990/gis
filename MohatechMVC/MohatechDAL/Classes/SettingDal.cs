using System;
using System.Data.Entity;
using System.Linq;
using MohatechDAL.Interfaces;
using MohatechDAL.UnitOfWork;
using MohatechDomain;

namespace MohatechDAL.Classes
{
    public class SettingDal : GenericDal<Setting>, ISettingDal
    {
        private readonly DataContext _context;
        private readonly DbSet<Setting> _settings;
        public SettingDal(DataContext context) : base(context)
        {
            _context = context;
            _settings = context.Set<Setting>();
        }

        public Setting Get()
        {
            return _settings.Single(s => s.SettingId == 1);
        }
    }
}
