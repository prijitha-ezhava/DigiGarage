using Digigarage.Data;
using Digigarage.Data.Repository;
using Digigarage.Data.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Extension;

namespace Digigarage.Business.RepositoryHelper
{
    public class RepositoryHelper : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<ICustomerRepository, CustomerRepository>();
            Container.RegisterType<IMechanicRepository, MechanicRepository>();
            Container.RegisterType<IVehicleRepository, VehicleRepository>();
            Container.RegisterType<ILoginRepository, LoginRepository>();
            Container.RegisterType<IServiceRepository, ServiceRepository>();
            Container.RegisterType<IBookingRepository, BookingRepository>();
            Container.RegisterType<IDepartmentRepostitory, DepartmentRepostitory>();
            Container.RegisterType<IBookingHistoryRepository, BookingHistoryRepository>();
            Container.RegisterType<IPaymentRepository, PaymentRepository>();
        }
    }
}
