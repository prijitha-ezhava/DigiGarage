using AutoMapper;
using Digigarage.Data.Models;
using Digigarage.BusinessEntities;

namespace Digigarage.Business.Automapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Booking, BookingViewModel>();
            CreateMap<BookingViewModel, Booking>();

            CreateMap<Customer, CustomerViewModel>();
            CreateMap<CustomerViewModel, Customer>();

            CreateMap<Department, DepartmentViewModel>();
            CreateMap<DepartmentViewModel, Department>();

            CreateMap<Login, LoginViewModel>();
            CreateMap<LoginViewModel, Login>();

            CreateMap<Mechanic, MechanicViewModel>();
            CreateMap<MechanicViewModel, Mechanic>();

            CreateMap<Payment, PaymentViewModel>();
            CreateMap<PaymentViewModel, Payment>();

            CreateMap<Service, ServiceViewModel>();
            CreateMap<ServiceViewModel, Service>();

            CreateMap<StatusOfBooking, StatusOfBookingViewModel>();
            CreateMap<StatusOfBookingViewModel, StatusOfBooking>();

            CreateMap<Vehicle, VehicleViewModel>();
            CreateMap<VehicleViewModel, Vehicle>();

            CreateMap<BookingHistory, BookingHistoryViewModel>();
            CreateMap<BookingHistoryViewModel, BookingHistory>();
        }
    }
}
