using Core.Entites.Abstract;

namespace Entities.Concrete
{
    public class Urun : IEntity
    {
        public int Id { get; set; }
        public string UrunAdi { get; set; }
        public int TurId { get; set; }
        public int OlcuBirimId { get; set; }

    }
}
