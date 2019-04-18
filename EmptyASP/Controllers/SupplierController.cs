using EmptyASP.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmptyASP.Controllers
{
    public class SupplierController : Controller
    {
        MyContext myContext = new MyContext();

        // GET: Supplier
        public ActionResult Index()
        {
            return View(myContext.Suppliers.Where(x => x.IsDelete == false).ToList());
        }

        // GET: Supplier/Details/5
        public ActionResult Details(int id)
        {
            return View(myContext.Suppliers.Find(id));
        }

        // GET: Supplier/Create
        public ActionResult Create()
        {            
            return View();
        }

        // POST: Supplier/Create
        [HttpPost]
        public ActionResult Create(Supplier modelSupplier)
        {
            if (String.IsNullOrWhiteSpace(modelSupplier.Name))
            {
                ModelState.AddModelError("Name", "Name is empty");                
                return View();
            }
            else
            {
                // TODO: Add insert logic here
                myContext.Suppliers.Add(modelSupplier);
                myContext.SaveChanges();
                TempData["message"] = "New Supplier Data added";
                return RedirectToAction("Index");
            }            
        }

        // GET: Supplier/Edit/5
        public ActionResult Edit(int id)
        {
            return View(myContext.Suppliers.Find(id));
        }

        // POST: Supplier/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Supplier suppliers)
        {
            if (String.IsNullOrWhiteSpace(suppliers.Name))
            {
                ModelState.AddModelError("Name", "Name is empty");
                return View();
            }
            else
            {
                // TODO: Add edit logic here
                var get = myContext.Suppliers.Find(id);
                get.Name = suppliers.Name;
                myContext.Entry(get).State = EntityState.Modified;
                myContext.SaveChanges();
                TempData["message"] = "Supplier "+id+" has been updated";
                return RedirectToAction("Index");
            }            
        }

        // GET: Supplier/Delete/5
        public ActionResult Delete(int id)
        {
            return View(myContext.Suppliers.Find(id));
        }

        // POST: Supplier/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Supplier suppliers)
        {
            // TODO: Add delete logic here
            var get = myContext.Suppliers.Find(id);
            get.IsDelete = true;
            myContext.Entry(get).State = EntityState.Modified;
            myContext.SaveChanges();
            TempData["message"] = "Supplier " + id + " has been deleted";
            return RedirectToAction("Index");            
        }
    }
}