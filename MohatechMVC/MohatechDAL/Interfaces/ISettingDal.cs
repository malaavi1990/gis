using MohatechDomain;

namespace MohatechDAL.Interfaces
{
    public interface ISettingDal : IGenericDal<Setting>
    {
        Setting Get();
    }
}
