using Core.Entites.Abstract;
using System;

namespace Entities.Concrete
{
    public class AfetzedeFotograf : IEntity
    {
        public int Id { get; set; }
        public int AfetzedeId { get; set; }
        public string FotografYolu { get; set; }
        public DateTime EklemeTarihi { get; set; }
    }
}
