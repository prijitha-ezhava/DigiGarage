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
    public class MechanicsController : Controller
    {
        private readonly IMechanicManager _mechanicManager;
        private readonly IDepartmentManager _departmentManager;
        public MechanicsController(IMechanicManager mechanicManager, IDepartmentManager departmentManager)
        {
            _mechanicManager = mechanicManager;
            _departmentManager = departmentManager;
        }
        // GET: Mechanic
        public ActionResult Index()
        {
            IEnumerable<MechanicViewModel> mechanic = _mechanicManager.GetAllMechanic().Reverse();
            return View(mechanic);
        }

        // GET: Customers/Details/5
        public ActionResult Details(int id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            MechanicViewModel mechanic = _mechanicManager.GetMechanic(id);
            if (mechanic == null)
            {
                return HttpNotFound();
            }
            return View(mechanic);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            ViewBag.DeptId = new SelectList(_departmentManager.GetAllDepartment(), "DeptId", "Department1");
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MechanicViewModel mechanic)
        {
            if (ModelState.IsValid)
            {
                string add = _mechanicManager.CreateMechanic(mechanic);
                return RedirectToAction("Index");
            }
            ViewBag.DeptId = new SelectList(_departmentManager.GetAllDepartment(), "DeptId", "Department1");
            return View(mechanic);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            MechanicViewModel mechanic = _mechanicManager.GetMechanic(id);
            if (mechanic == null)
            {
                return HttpNotFound();
            }
            ViewBag.DeptId = new SelectList(_departmentManager.GetAllDepartment(), "DeptId", "Department1");
            return View(mechanic);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MechanicViewModel mechanic)
        {
            if (ModelState.IsValid)
            {
                string update = _mechanicManager.UpdateMechanic(mechanic);
                return RedirectToAction("Index");
            }
            ViewBag.DeptId = new SelectList(_departmentManager.GetAllDepartment(), "DeptId", "Department1");
            return View(mechanic);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            MechanicViewModel mechanic = _mechanicManager.GetMechanic(id);
            if (mechanic == null)
            {
                return HttpNotFound();
            }
            return View(mechanic);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            string delete = _mechanicManager.DeleteMechanic(id);
            return RedirectToAction("Index");
        }


    }
}
