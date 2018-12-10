using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MohatechDAL.Interfaces;

namespace MohatechDAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        ISettingDal SettingDal { get; }
        IRoleDal RoleDal { get; }
        IUserDal UserDal { get; }
        IProductDal ProductDal { get; }
        IGalleryDal GalleryDal { get; }
        ICategoryDal CategoryDal { get; }
        IProductCategoryDal ProductCategoryDal { get; }
        ITagDal TagDal { get; }
        ISliderDal SliderDal { get; }
        INewsDal NewsDal { get; }
        void Save();
        void Dispose();
    }
}
