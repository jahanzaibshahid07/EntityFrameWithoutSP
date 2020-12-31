using DatabaseFirstApproach.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DatabaseFirstApproach.Controllers
{
    public class ProductController : Controller
    {
        DataContext db = new DataContext();

        // GET: Product
        public ActionResult Index()
        {
            var data = db.products.SqlQuery("select * from products").ToList();
            return View(data);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            var data = db.products.SqlQuery("select * from products where ProductId = @p0", id).SingleOrDefault();
            return View(data);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Products collection)
        {
            try
            {
                // TODO: Add insert logic here
                List<object> list = new List<object>();
                list.Add(collection.ProductName);
                list.Add(collection.SerialNumber);
                list.Add(collection.Company);
                
                object[] objectitems = list.ToArray();

                int output = db.Database.ExecuteSqlCommand("insert into products(ProductName,SerialNumber,Company) values(@p0,@p1,@p2)", objectitems);

                if (output > 0)
                {
                    ViewBag.msg = "Insert successfully";
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            var data = db.products.SqlQuery("select * from products where ProductId = @p0", id).SingleOrDefault();
            return View(data);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Products collection)
        {
            try
            {
                List<object> list = new List<object>();
                list.Add(collection.ProductName);
                list.Add(collection.SerialNumber);
                list.Add(collection.Company);
                list.Add(collection.ProductId);

                object[] objectitems = list.ToArray();
         
                int output = db.Database.ExecuteSqlCommand("update products set productname = @p0, serialnumber=@p1, company = @p2 where productid = @p3", objectitems);
                
                if (output > 0)
                {
                    ViewBag.msg = "Update successfully";
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            var data = db.products.SqlQuery("select * from products where ProductId = @p0", id).SingleOrDefault();
            return View(data);
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Products collection)
        {
            try
            {
                // TODO: Add delete logic here
                int output = db.Database.ExecuteSqlCommand("delete from products where productid = @p0", id);

                if (output > 0)
                {
                    ViewBag.msg = "Delete successfully";
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
