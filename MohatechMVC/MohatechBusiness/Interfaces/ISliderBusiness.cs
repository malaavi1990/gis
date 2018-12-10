using System.Collections.Generic;
using MohatechDomain;

namespace MohatechBusiness.Interfaces
{
    public interface ISliderBusiness
    {
        IEnumerable<Slider> Get();
        Slider GetById(int id);
        void Insert(Slider slider);
        void Update(Slider slider);
        void Delete(int id);
        void Save();
    }
}
