using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.EmailSender;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<HouseManager>().As<IHouseService>().SingleInstance();
            builder.RegisterType<EfHouseDal>().As<IHouseDal>().SingleInstance();

            builder.RegisterType<ApartmentManager>().As<IApartmentService>().SingleInstance();
            builder.RegisterType<EfApartmentDal>().As<IApartmentDal>().SingleInstance();

            builder.RegisterType<AuthManager>().As<IAuthService>().SingleInstance();
            
            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();

            builder.RegisterType<ResidentManager>().As<IResidentService>().SingleInstance();
            
            builder.RegisterType<InvoiceManager>().As<IInvoiceService>().SingleInstance();
            builder.RegisterType<EfInvoiceDal>().As<IInvoiceDal>().SingleInstance();

            builder.RegisterType<InvoiceGenreManager>().As<IInvoiceGenreService>().SingleInstance();
            builder.RegisterType<EfInvoiceGenreDal>().As<IInvoiceGenreDal>().SingleInstance();

            builder.RegisterType<EmailSender>().As<IEmailSender>().SingleInstance();

            builder.RegisterType<OperationClaimManager>().As<IOperationClaimService>().SingleInstance();
            builder.RegisterType<EfOperationClaimDal>().As<IOperationClaimDal>().SingleInstance();
            builder.RegisterType<UserOperationClaimManager>().As<IUserOperationClaimService>().SingleInstance();
            builder.RegisterType<EfUserOperationClaimDal>().As<IUserOperationClaimDal>().SingleInstance();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                //  Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}