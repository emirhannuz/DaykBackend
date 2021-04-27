using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfStokCikisOnayDal : EfEntityRepositoryBase<StokCikisOnay, DaykContext>, IStokCikisOnayDal
    {
    }
}
