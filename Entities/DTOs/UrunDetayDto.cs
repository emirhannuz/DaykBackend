using Core.Entites.Abstract;
using Entities.Concrete;

namespace Entities.DTOs
{
    public class UrunDetayDto : IDto
    {
        public Urun Urun { get; set; }
        public Tur Tur { get; set; }
        public OlcuBirim OlcuBirim { get; set; }

    }
}
