using Ninject;
using System;
using System.Web.Mvc;
using MohatechBusiness.Classes;
using MohatechBusiness.Interfaces;
using System.Web.Routing;

namespace MohatechMVC.Controllers
{
    public class NinjectController : DefaultControllerFactory
    {
        private IKernel ninjectKernel;
        public NinjectController()
        {
            ninjectKernel = new StandardKernel();
            AddBinding();
        }

        void AddBinding()
        {
            ninjectKernel.Bind<IUserBusiness>().To<UserBusiness>();
            ninjectKernel.Bind<IRoleBusiness>().To<RoleBusiness>();
            ninjectKernel.Bind<IProductBusiness>().To<ProductBusiness>();
            ninjectKernel.Bind<ICategoryBusiness>().To<CateoryBusiness>();
            ninjectKernel.Bind<ISettingBusiness>().To<SettingBusiness>();
            ninjectKernel.Bind<IProductCategoryBusiness>().To<ProductCategoryBusiness>();
            ninjectKernel.Bind<ITagBusiness>().To<TagBusiness>();
            ninjectKernel.Bind<IGalleryBusiness>().To<GalleryBusiness>();
            ninjectKernel.Bind<ISliderBusiness>().To<SliderBusiness>();
            ninjectKernel.Bind<INewsBusiness>().To<NewsBusiness>();
            ninjectKernel.Bind<IBookBusiness>().To<BookBusiness>();
            ninjectKernel.Bind<ISoftwareBusiness>().To<SoftwareBusiness>();
            ninjectKernel.Bind<ICommentBusiness>().To<CommentBusiness>();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)ninjectKernel.Get(controllerType);
        }
    }
}