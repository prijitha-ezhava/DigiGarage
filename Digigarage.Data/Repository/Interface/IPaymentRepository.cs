using Digigarage.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digigarage.Data.Repository.Interface
{
    public interface IPaymentRepository
    {
        PaymentViewModel GetPayment(int? Id);
        IEnumerable<PaymentViewModel> GetAllPayment();
        string updatePayment(PaymentViewModel payment);
    }
}
