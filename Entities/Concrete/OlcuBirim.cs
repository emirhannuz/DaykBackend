using Core.Entites.Abstract;

namespace Entities.Concrete
{
    public class OlcuBirim : IEntity
    {
        public int Id { get; set; }
        public string OlcuAdi { get; set; }

    }
}
