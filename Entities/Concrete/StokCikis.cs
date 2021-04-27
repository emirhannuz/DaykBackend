using Core.Entites.Abstract;

namespace Entities.Concrete
{
    public class StokCikis : IEntity
    {
        public int Id { get; set; }
        public int AfetzedeId { get; set; }
        public int UrunId { get; set; }
        public int Adet { get; set; }
    }
}
