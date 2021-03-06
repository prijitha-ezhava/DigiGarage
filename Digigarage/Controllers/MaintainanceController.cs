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
    
    public class MaintainanceController : Controller
    {
        private readonly IBookingManager _bookingManager;
        private readonly IServiceManager _serviceManager;
        private readonly IVehicleManager _vehicleManager;
        private readonly IBookingHistoryManager _bookingHistoryManager;
        private readonly IMechanicManager _mechanicManager;

        public MaintainanceController(IMechanicManager mechanicManager, IBookingHistoryManager bookingHistoryManager, IBookingManager bookingManager, IServiceManager serviceManager, IVehicleManager vehicleManager)
        {
            _bookingManager = bookingManager;
            _serviceManager = serviceManager;
            _vehicleManager = vehicleManager;
            _bookingHistoryManager = bookingHistoryManager;
            _mechanicManager = mechanicManager;
        }
        // GET: Washing
        [Authorize(Roles = "Maintainance")]
        public ActionResult Index()
        {
            IEnumerable<BookingViewModel> booking = _bookingManager.GetAllBooking().Where(a => a.DepartmentId == 3 && a.Status == 2).Reverse(); ;
            return View(booking.ToList());
        }
        [Authorize(Roles = "Admin")]
        public ActionResult AdminIndex()
        {
            IEnumerable<BookingViewModel> booking = _bookingManager.GetAllBooking().Where(a => a.DepartmentId == 3 && a.Status == 2).Reverse();
            return View(booking.ToList());
        }
        [Authorize(Roles = "Maintainance")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingHistoryViewModel booking = _bookingHistoryManager.GetBookingHistory(id);
            ViewBag.VehicleId = new SelectList(_vehicleManager.GetAllVehicle().Where(a => a.VehicleId == booking.VehicleId), "VehicleId", "LicencePlate", selectedValue: booking.VehicleId);
            ViewBag.ServiceId = new SelectList(_serviceManager.GetAllService().Where(a => a.ServiceId == booking.ServiceId), "ServiceId", "ServiceName", selectedValue: booking.ServiceId);
            ViewBag.MechanicId = new SelectList(_mechanicManager.GetMechanicOfMaintainance(), "MechanicId", "Name");
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
        public ActionResult Edit(BookingHistoryViewModel booking)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string update = _bookingHistoryManager.updateBookingHistory(booking);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            ViewBag.VehicleId = new SelectList(_vehicleManager.GetAllVehicle().Where(a => a.VehicleId == booking.VehicleId), "VehicleId", "LicencePlate", selectedValue: booking.VehicleId);
            ViewBag.ServiceId = new SelectList(_serviceManager.GetAllService().Where(a => a.ServiceId == booking.ServiceId), "ServiceId", "ServiceName", selectedValue: booking.ServiceId);
            ViewBag.MechanicId = new SelectList(_mechanicManager.GetMechanicOfWashing(), "MechanicId", "Name");
            return View(booking);

        }
        [Authorize(Roles = "Admin")]
        public ActionResult AdminEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingHistoryViewModel booking = _bookingHistoryManager.GetBookingHistory(id);
            ViewBag.VehicleId = new SelectList(_vehicleManager.GetAllVehicle().Where(a => a.VehicleId == booking.VehicleId), "VehicleId", "LicencePlate", selectedValue: booking.VehicleId);
            ViewBag.ServiceId = new SelectList(_serviceManager.GetAllService().Where(a => a.ServiceId == booking.ServiceId), "ServiceId", "ServiceName", selectedValue: booking.ServiceId);
            ViewBag.MechanicId = new SelectList(_mechanicManager.GetMechanicOfMaintainance(), "MechanicId", "Name");
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
        public ActionResult AdminEdit(BookingHistoryViewModel booking)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string update = _bookingHistoryManager.updateBookingHistory(booking);
                    return RedirectToAction("AdminIndex");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            ViewBag.VehicleId = new SelectList(_vehicleManager.GetAllVehicle().Where(a => a.VehicleId == booking.VehicleId), "VehicleId", "LicencePlate", selectedValue: booking.VehicleId);
            ViewBag.ServiceId = new SelectList(_serviceManager.GetAllService().Where(a => a.ServiceId == booking.ServiceId), "ServiceId", "ServiceName", selectedValue: booking.ServiceId);
            ViewBag.MechanicId = new SelectList(_mechanicManager.GetMechanicOfWashing(), "MechanicId", "Name");
            return View(booking);

        }
    }
}