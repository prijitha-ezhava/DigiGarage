using Digigarage.Business;
using Digigarage.Business.Interface;
using Digigarage.Business.RepositoryHelper;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace Digigarage
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<ICustomerManager, CustomerManager>();
            container.RegisterType<IVehicleManager, VehicleManager>();
            container.RegisterType<IMechanicManager, MechanicManager>();
            container.RegisterType<IServiceManager, ServiceManager>();
            container.RegisterType<IBookingManager, BookingManager>();
            container.RegisterType<ILoginManager, LoginManager>();
            container.RegisterType<IDepartmentManager, DepartmentManager>();
            container.RegisterType<IBookingHistoryManager, BookingHistoryManager>();
            container.RegisterType<IPaymentManager, PaymentManager>();
            container.AddNewExtension<RepositoryHelper>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}