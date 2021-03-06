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
    public class VehiclesController : Controller
    {
       
        private readonly IVehicleManager _vehicleManager;
        private readonly ICustomerManager _customerManager;

        public VehiclesController(IVehicleManager vehicleManager, ICustomerManager customerManager)
        {
            _vehicleManager = vehicleManager;
            _customerManager = customerManager;
        }
        // GET: Vehicles
        // GET: Dealers
        public ActionResult Index()
        {
            IEnumerable<VehicleViewModel> dealer = _vehicleManager.GetAllVehicle().Reverse();
            return View(dealer.ToList());
        }

        // GET: Vehicles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleViewModel vehicle = _vehicleManager.GetVehicle(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // GET: Vehicles/Create
        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(_customerManager.GetAllCustomer(), "CustomerId", "Name");
            return View();
        }

        // POST: Vehicles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VehicleViewModel vehicle)
        {
            if (ModelState.IsValid)
            {
                string add = _vehicleManager.CreateVehicle(vehicle);
                if (add == "Exist")
                {
                    ModelState.AddModelError("", "Vehicle already register");
                    ViewBag.CustomerId = new SelectList(_customerManager.GetAllCustomer(), "CustomerId", "Name");
                    return View(vehicle);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            ViewBag.CustomerId = new SelectList(_customerManager.GetAllCustomer(), "CustomerId", "Name");
            return View(vehicle);
        }

        // GET: Vehicles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleViewModel vehicle = _vehicleManager.GetVehicle(id);
            ViewBag.CustomerId = new SelectList(_customerManager.GetAllCustomer(), "CustomerId", "Name",selectedValue: vehicle.CustomerId);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VehicleViewModel vehicle)
        {
            if (ModelState.IsValid)
            {
                string update = _vehicleManager.UpdateVehicle(vehicle);
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(_customerManager.GetAllCustomer(), "CustomerId", "Name", selectedValue: vehicle.CustomerId);
            return View(vehicle);
        }

        // GET: Vehicles/Delete/5
        public ActionResult Delete(int id)
        {
            
            VehicleViewModel vehicle = _vehicleManager.GetVehicle(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            string delete = _vehicleManager.DeleteVehicle(id);
            return RedirectToAction("Index");
        }
    }
}
