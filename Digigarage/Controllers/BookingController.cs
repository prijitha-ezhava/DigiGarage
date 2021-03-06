using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Digigarage.Business.Interface;
using Digigarage.BusinessEntities;

namespace Digigarage.Controllers
{
    [Authorize(Roles = "Admin")]
    public class BookingController : Controller
    {
       
        private readonly IBookingManager _bookingManager;
        private readonly IServiceManager _serviceManager;
        private readonly IVehicleManager _vehicleManager;
        private readonly IPaymentManager _paymentManager;

        public BookingController(IBookingManager bookingManager, IPaymentManager paymentManager, IServiceManager serviceManager, IVehicleManager vehicleManager)
        {
            _bookingManager = bookingManager;
            _serviceManager = serviceManager;
            _vehicleManager = vehicleManager;
            _paymentManager = paymentManager;
        }
        // GET: Booking
        // GET: Dealers
        public ActionResult Index()
        {
            IEnumerable<BookingViewModel> booking =_bookingManager.GetAllBooking().Reverse();
            return View(booking.ToList());
        }

        

        // GET: Booking/Create
        public ActionResult Create()
        {
            ViewBag.VehicleId = new SelectList(_vehicleManager.GetAllVehicle(), "VehicleId", "LicencePlate" );
            ViewBag.ServiceId = new SelectList(_serviceManager.GetAllService(), "ServiceId", "ServiceName");
            return View();
        }

        // POST: Booking/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookingViewModel booking)
        {
            try
            {
                if (ModelState.IsValid)
                { 
                    string add = _bookingManager.CreateBooking(booking);
                    if (add == "Exist")
                    {
                        ViewBag.VehicleId = new SelectList(_vehicleManager.GetAllVehicle(), "VehicleId", "LicencePlate");
                        ViewBag.ServiceId = new SelectList(_serviceManager.GetAllService(), "ServiceId", "ServiceName");
                        ModelState.AddModelError("", "Booking already register");
                        return View(booking);
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            ViewBag.VehicleId = new SelectList(_vehicleManager.GetAllVehicle(), "VehicleId", "LicencePlate");
            ViewBag.ServiceId = new SelectList(_serviceManager.GetAllService(), "ServiceId", "ServiceName");
            return View(booking);
        }

        // GET: Booking/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingViewModel booking = _bookingManager.GetBooking(id);
            ViewBag.VehicleId = new SelectList(_vehicleManager.GetAllVehicle().Where(a => a.VehicleId == booking.VehicleId), "VehicleId", "LicencePlate", selectedValue: booking.VehicleId);
            ViewBag.ServiceId = new SelectList(_serviceManager.GetAllService().Where(a => a.ServiceId == booking.ServiceId), "ServiceId", "ServiceName", selectedValue: booking.ServiceId);
            ViewBag.Status = new SelectList(_serviceManager.GetAllServiceStatus(), "Id", "Status", selectedValue: booking.Status);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // POST: Booking/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BookingViewModel booking)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string update = _bookingManager.UpdateBooking(booking);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            ViewBag.VehicleId = new SelectList(_vehicleManager.GetAllVehicle().Where(a=> a.VehicleId == booking.VehicleId), "VehicleId", "LicencePlate", selectedValue: booking.VehicleId);
            ViewBag.ServiceId = new SelectList(_serviceManager.GetAllService().Where(a => a.ServiceId == booking.ServiceId), "ServiceId", "ServiceName", selectedValue: booking.ServiceId);
            ViewBag.Status = new SelectList(_serviceManager.GetAllServiceStatus(), "Id", "Status", selectedValue: booking.Status);
            return View(booking);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingViewModel booking = _bookingManager.GetBooking(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // GET: Booking/Delete/5
        public ActionResult Delete(int id)
        {
            
            BookingViewModel booking = _bookingManager.GetBooking(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // POST: Booking/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            string delete = _bookingManager.DeleteBooking(id);
            return RedirectToAction("Index");
        }

        public ActionResult BillGenerate(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentViewModel payment = _paymentManager.GetPayment(id);
            ViewBag.VehicleId = new SelectList(_vehicleManager.GetAllVehicle().Where(a => a.VehicleId == payment.VehicleId), "VehicleId", "LicencePlate", selectedValue: payment.VehicleId);
            ViewBag.ServiceId = new SelectList(_serviceManager.GetAllService().Where(a => a.ServiceId == payment.ServiceId), "ServiceId", "ServiceName", selectedValue: payment.ServiceId);
            if (payment == null)
            {
                return HttpNotFound();
            }
            return View(payment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BillGenerate(PaymentViewModel payment)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string update = _paymentManager.updatePayment(payment);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            ViewBag.VehicleId = new SelectList(_vehicleManager.GetAllVehicle().Where(a => a.VehicleId == payment.VehicleId), "VehicleId", "LicencePlate", selectedValue: payment.VehicleId);
            ViewBag.ServiceId = new SelectList(_serviceManager.GetAllService().Where(a => a.ServiceId == payment.ServiceId), "ServiceId", "ServiceName", selectedValue: payment.ServiceId);
            return View(payment);
        }
    }
}
