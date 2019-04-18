using EmptyASP.Models;
using EmptyASP.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmptyASP.Controllers
{
    public class ItemController : Controller
    {
        MyContext myContext = new MyContext();

        // GET: Item
        public ActionResult Index()
        {
            return View(myContext.Items.Include("Suppliers").Where(x => x.IsDelete == false).ToList());
        }

        // GET: Item/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Item/Create
        public ActionResult Create()
        {
            //var list = myContext.Suppliers.Where(x => x.IsDelete == false).ToList();
            //List<SelectListItem> SupplierList = new List<SelectListItem>();
            //foreach(var addList in list)
            //{
            //    SupplierList.Add(new SelectListItem
            //    {
            //        Text = addList.Name,
            //        Value = addList.Id.ToString(),
            //        Selected = false
            //    });
            //}
            //ViewBag.Suppliers = SupplierList;
            ViewBag.Suppliers =  new SelectList(myContext.Suppliers.Where(x => x.IsDelete == false).ToList(), "Id", "Name", "0");
            return View();
        }

        // POST: Item/Create
        [HttpPost]
        public ActionResult Create(ItemVM itemVM)//int id, Item items)
        {
            //var supplier = myContext.Suppliers.Find(id);
            //items.Suppliers = supplier;
            if (ModelState.IsValid)
            {
                var supplier = myContext.Suppliers.Find(itemVM.Suppliers_Id);
                Item item = new Item()
                {
                    Name = itemVM.Name,
                    Price = itemVM.Price,
                    Stock = itemVM.Stock,
                    Suppliers = supplier
                };
                myContext.Items.Add(item);
                myContext.SaveChanges();
                TempData["message"] = "New Item Data added";                
            }
            return RedirectToAction("Index");
        }

        // GET: Item/Edit/5
        public ActionResult Edit(int id)
        {            
            var getItem = myContext.Items.Find(id);
            ItemVM itemVM = new ItemVM()
            {
                Id = getItem.Id,
                Name = getItem.Name,
                Price = getItem.Price,
                Stock = getItem.Stock,
                Suppliers_Id = getItem.Suppliers.Id
            };
            ViewBag.Suppliers = new SelectList(myContext.Suppliers.Where(x => x.IsDelete == false).ToList(), "Id", "Name", "0");
            return View(itemVM);
        }

        // POST: Item/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ItemVM itemVM)
        {
            var get = myContext.Items.Find(id);
            var supplier = myContext.Suppliers.Find(itemVM.Suppliers_Id);
            get.Name = itemVM.Name;
            get.Price = itemVM.Price;
            get.Stock = itemVM.Stock;
            get.Suppliers = supplier;
            myContext.Entry(get).State = EntityState.Modified;
            myContext.SaveChanges();
            TempData["message"] = "Item " + id + " has been updated";
            return RedirectToAction("Index");            
        }

        // GET: Item/Delete/5
        //public ActionResult Delete()
        //{
        //    return View();
        //}

        // POST: Item/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var get = myContext.Items.Find(id);
            get.IsDelete = true;
            myContext.Entry(get).State = EntityState.Modified;
            myContext.SaveChanges();
            TempData["message"] = "Item " + id + " has been deleted";
            return RedirectToAction("Index");            
        }
    }
}
