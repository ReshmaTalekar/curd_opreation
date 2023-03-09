using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Data.Entity;
using RBTalekar.Models;

namespace RBTalekar.Controllers
{
    public class HomeController : Controller
    {
      
           ServicesContext db = new Models.ServicesContext();

            public ActionResult Index()
            {
                var data = db.emp.ToList();
                return View(data);
            }

            public ActionResult Create()
            {
                ViewBag.Message = "Your application description page.";

                return View();
            }
            [HttpPost]
            public ActionResult Create(Models.Employee e)
            {
                if (ModelState.IsValid == true)
                {
                    db.emp.Add(e);
                    int a = db.SaveChanges();
                    if (a > 0)
                    {
                        ViewBag.CreateMessage = ("<script>alert('Data saved...')</script>");
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.CreateMessage = ("<script>alert('Data not saved...')</script>");
                    }
                }


                return View();
            }
            public ActionResult Edit(int id)
            {
                var row = db.emp.Where(model => model.Id == id).FirstOrDefault();
                return View(row);
            }

            [HttpPost]
            public ActionResult Edit(Models.Employee e)
            {
                db.Entry(e).State = EntityState.Modified;
                int a = db.SaveChanges();
                if (a > 0)
                {
                    // ViewBag.UpdateMessage = ("<script>alert('Data saved...')</script>");
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.UpdateMessage = ("<script>alert('Data not Modified...')</script>");
                }

                db.SaveChanges();
                return View();
            }

            [HttpPost]
            public ActionResult Delete(int id)
            {
                var row = db.emp.Where(model => model.Id == id).FirstOrDefault();
                return View(row);
            }


            public ActionResult Delete(Models.Employee e)
            {
                db.Entry(e).State = EntityState.Deleted;
                int a = db.SaveChanges();

                if (a > 0)
                {
                    ViewBag.DeleteMessage = ("<script>alert('Data delete succesfully...')</script>");
                    ModelState.Clear();
                    // return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.DeleteMessage = ("<script>alert('Data not delete succesfully...')</script>");
                }

                db.SaveChanges();
                return View();
            }


            [HttpPost]
            public ActionResult Details(int id)
            {
                var row = db.emp.Where(model => model.Id == id).FirstOrDefault();
                return View(row);
            }


            public ActionResult Details(Models.Employee e)
            {
                db.Entry(e).State = EntityState.Detached;
                int a = db.SaveChanges();

                if (a > 0)
                {
                    ViewBag.DetailsMessage = ("<script>alert('Data fetch succesfully...')</script>");
                    // ModelState.Clear();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.DetailsMessage = ("<script>alert('Data not fetch succesfully...')</script>");
                }

                db.SaveChanges();
                return View();
            }
        }
}