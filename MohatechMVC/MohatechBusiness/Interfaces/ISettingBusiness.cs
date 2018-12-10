using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MohatechDomain;

namespace MohatechBusiness.Interfaces
{
    public interface ISettingBusiness
    {
        Setting Get();
        void Update(Setting setting);
        void Save();
    }
}
