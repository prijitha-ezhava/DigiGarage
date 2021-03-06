using Digigarage.Business.Interface;
using Digigarage.BusinessEntities;
using Digigarage.Data.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digigarage.Business
{
    public class PaymentManager : IPaymentManager
    {
        private readonly IPaymentRepository _PaymentRepository;

        public PaymentManager(IPaymentRepository PaymentRepository)
        {
            _PaymentRepository = PaymentRepository;
        }

        public IEnumerable<PaymentViewModel> GetAllPayment()
        {
            return _PaymentRepository.GetAllPayment();
        }

        public PaymentViewModel GetPayment(int? Id)
        {
            return _PaymentRepository.GetPayment(Id);
        }

        public string updatePayment(PaymentViewModel Payment)
        {
            return _PaymentRepository.updatePayment(Payment);
        }
    }
}
