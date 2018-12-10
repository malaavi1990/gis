using System.Data.Entity;
using MohatechDAL.Interfaces;
using MohatechDAL.UnitOfWork;
using MohatechDomain;

namespace MohatechDAL.Classes
{
    public class SliderDal : GenericDal<Slider>, ISliderDal
    {
        private readonly DataContext _context;
        private readonly DbSet<Slider> _sliders;

        public SliderDal(DataContext context) : base(context)
        {
            _context = context;
            _sliders = context.Set<Slider>();
        }
    }
}
