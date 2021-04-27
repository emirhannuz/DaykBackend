using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Helpers.FileHelpers.Images;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.Jwt;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TurManager>().As<ITurService>().SingleInstance();
            builder.RegisterType<EfTurDal>().As<ITurDal>().SingleInstance();

            builder.RegisterType<UrunManager>().As<IUrunService>().SingleInstance();
            builder.RegisterType<EfUrunDal>().As<IUrunDal>().SingleInstance();

            builder.RegisterType<OlcuBirimManager>().As<IOlcuBirimService>().SingleInstance();
            builder.RegisterType<EfOlcuBirimDal>().As<IOlcuBirimDal>().SingleInstance();

            builder.RegisterType<AfetzedeManager>().As<IAfetzedeService>().SingleInstance();
            builder.RegisterType<EfAfetzedeDal>().As<IAfetzedeDal>().SingleInstance();

            builder.RegisterType<StokManager>().As<IStokService>().SingleInstance();
            builder.RegisterType<EfStokDal>().As<IStokDal>().SingleInstance();

            builder.RegisterType<StokCikisManager>().As<IStokCikisService>().SingleInstance();
            builder.RegisterType<EfStokCikisDal>().As<IStokCikisDal>().SingleInstance();
            
            builder.RegisterType<StokCikisOnayManager>().As<IStokCikisOnayService>().SingleInstance();
            builder.RegisterType<EfStokCikisOnayDal>().As<IStokCikisOnayDal>().SingleInstance();
            
            builder.RegisterType<StokCikisTeslimManager>().As<IStokCikisTeslimService>().SingleInstance();
            builder.RegisterType<EfStokCikisTeslimDal>().As<IStokCikisTeslimDal>().SingleInstance();

            builder.RegisterType<AfetzedeFotografManager>().As<IAfetzedeFotografService>().SingleInstance();
            builder.RegisterType<EfAfetzedeFotografDal>().As<IAfetzedeFotografDal>().SingleInstance();






            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();
            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();
            builder.RegisterType<ImageFileHelper>().As<IImageFileHelper>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
