using MohatechDAL.Classes;
using MohatechDAL.Interfaces;
using System;

namespace MohatechDAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DataContext _context = new DataContext();

        private ISettingDal _settingDal;
        public ISettingDal SettingDal
        {
            get
            {
                if (_settingDal == null)
                {
                    _settingDal = new SettingDal(_context);
                }

                return _settingDal;
            }
        }

        private IRoleDal _roleDal;
        public IRoleDal RoleDal
        {
            get
            {
                if (_roleDal == null)
                {
                    _roleDal = new RoleDal(_context);
                }

                return _roleDal;
            }
        }

        private IUserDal _userDal;
        public IUserDal UserDal
        {
            get
            {
                if (_userDal == null)
                {
                    _userDal = new UserDal(_context);
                }

                return _userDal;
            }
        }

        private IProductDal _productDal;
        public IProductDal ProductDal
        {
            get
            {
                if (_productDal == null)
                {
                    _productDal = new ProductDal(_context);
                }

                return _productDal;
            }
        }

        private IGalleryDal _galleryDal;
        public IGalleryDal GalleryDal
        {
            get
            {
                if (_galleryDal == null)
                {
                    _galleryDal = new GalleryDal(_context);
                }

                return _galleryDal;
            }
        }

        private ICategoryDal _categoryDal;
        public ICategoryDal CategoryDal
        {
            get
            {
                if (_categoryDal == null)
                {
                    _categoryDal = new CategoryDal(_context);
                }

                return _categoryDal;
            }
        }

        private ITagDal _tagDal;
        public ITagDal TagDal
        {
            get
            {
                if (_tagDal == null)
                {
                    _tagDal = new TagDal(_context);
                }

                return _tagDal;
            }
        }

        private IProductCategoryDal _productCategoryDal;
        public IProductCategoryDal ProductCategoryDal
        {
            get
            {
                if (_productCategoryDal==null)
                {
                    _productCategoryDal=new ProductCategoryDal(_context);
                }

                return _productCategoryDal;
            }
        }

        private ISliderDal _sliderDal;
        public ISliderDal SliderDal
        {
            get
            {
                if (_sliderDal == null)
                {
                    _sliderDal = new SliderDal(_context);
                }

                return _sliderDal;
            }
        }

        private INewsDal _newsDal;
        public INewsDal NewsDal
        {
            get
            {
                if (_newsDal == null)
                {
                    _newsDal = new NewsDal(_context);
                }

                return _newsDal;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
