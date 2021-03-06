using AutoMapper;
using Digigarage.BusinessEntities;
using Digigarage.Data.Models;
using Digigarage.Data.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digigarage.Data.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly DigiGarageEntities _dbContext;
        public PaymentRepository()
        {
            _dbContext = new DigiGarageEntities();
        }

        public IEnumerable<PaymentViewModel> GetAllPayment()
        {
            IEnumerable<Payment> Payment = _dbContext.Payments;
            IEnumerable<PaymentViewModel> PaymentsEntities =
                Mapper.Map<IEnumerable<PaymentViewModel>>(Payment);
            return PaymentsEntities;
        }

        public PaymentViewModel GetPayment(int? Id)
        {
            int bookingId = (int)Id;
            Payment payment = _dbContext.Payments.Where(a => a.BookingId == bookingId).FirstOrDefault();
            PaymentViewModel paymententities = Mapper.Map<PaymentViewModel>(payment);
            return paymententities;
        }

        public string updatePayment(PaymentViewModel payment)
        {
            if (payment != null)
            {
                Payment entity = _dbContext.Payments.Find(payment.PaymentId);
                Mapper.Map(payment, entity);
                entity.Date = DateTime.Now;
                _dbContext.Entry(entity).State = EntityState.Modified;
                _dbContext.SaveChanges();
                Booking booking = _dbContext.Bookings.Find(entity.BookingId);
                booking.Status = 4;
                _dbContext.Entry(booking).State = EntityState.Modified;
                _dbContext.SaveChanges();
                return "Payment updated";
            }
            return "Model is null";
        }
    }
}
