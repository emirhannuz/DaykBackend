using Core.Entites.Abstract;
using Entities.Concrete;

namespace Entities.DTOs
{
    public class AfetzedeDetayDto : IDto
    {
        public Afetzede Afetzede { get; set; }
        public AfetzedeFotograf? AfetzedeFotograf { get; set; }
    }
}
