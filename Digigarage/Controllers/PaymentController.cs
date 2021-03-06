using Digigarage.Business.Interface;
using Digigarage.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Digigarage.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IBookingManager _bookingManager;
        private readonly IServiceManager _serviceManager;
        private readonly IVehicleManager _vehicleManager;
        private readonly IPaymentManager _paymentManager;

        public PaymentController(IPaymentManager paymentManager, IBookingManager bookingManager, IServiceManager serviceManager, IVehicleManager vehicleManager)
        {
            _bookingManager = bookingManager;
            _serviceManager = serviceManager;
            _vehicleManager = vehicleManager;
            _paymentManager = paymentManager;
        }
        // GET: Washing
        public ActionResult Index()
        {
            IEnumerable<PaymentViewModel> payment = _paymentManager.GetAllPayment().Where(a => a.TotalAmount != null).Reverse();
            return View(payment.ToList());
        }

    }
}