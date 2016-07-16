using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleApplicationMVC.Models;
using static SimpleApplicationMVC.Models.Employer;
using System.Net;
using System.Data.Entity;

namespace SimpleApplicationMVC.Controllers
{
    public class EmployerController : Controller
    {
        EmployerDbModel db = new EmployerDbModel();
        // GET: Employer
        public ActionResult Index()
        {
            return View(db.Employers.ToList());
        }
        //ActionResult Create
        public ActionResult Create(int? id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employer model)
        {
            if (ModelState.IsValid)
            {
                db.Employers.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        ///ActionResult Detials
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                Employer model = db.Employers.Find(id);
                if (model == null)
                {
                    return HttpNotFound();
                }
                return View(model);
            }
        }
        /// <summary>
        /// ActioResult delete
        /// </summary>
        /// <returns>Delete</returns>
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                Employer model = db.Employers.Find(id);
                if (model == null)
                {
                    return HttpNotFound();
                }
                return View(model);
            }
        }
        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {
                Employer emp = db.Employers.Find(id);
                db.Employers.Remove(emp);
                db.SaveChanges();
                return RedirectToAction("Index");
            
        }
        //ActionResult Edit
        public ActionResult Edit(int?id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                Employer model = db.Employers.Find(id);
                if (model == null)
                {
                    return HttpNotFound();
                }
                return View(model);
            }
        }
        /// <summary>
        /// ActionResult Edit fields
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(Employer model)
        {
            if (ModelState.IsValid)
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        /// <summary>
        /// Close database connection after action
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

    }
}