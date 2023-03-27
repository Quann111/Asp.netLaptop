using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThiASP.NET.Models;

namespace ThiASP.NET.Controllers
{
    public class AccoutController : Controller
    {
        // GET: Accout
        public ActionResult Danhsach()
        {
            SHOPEntities db = new SHOPEntities();

            return View(db.Account.ToList());
        }
        public ActionResult Them()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Them(Account model)
        {
            if (string.IsNullOrEmpty(model.TaiKhoan) == true)
            {
                ModelState.AddModelError("", "Thieu thong tin");
                return View(model);
            }
            SHOPEntities db = new SHOPEntities();
            try
            {
                db.Account.Add(model);
                db.SaveChanges();
                return RedirectToAction("Danhsach");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model);

            }

        }


        public ActionResult Update(int id)
        {
            SHOPEntities db = new SHOPEntities();
            var model = db.Account.Find(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Update(Account model)
        {
            if (string.IsNullOrEmpty(model.TaiKhoan) == true)
            {
                ModelState.AddModelError("", "Thieu thong tin");
                return View(model);
            }
            SHOPEntities db = new SHOPEntities();
            var updatemodel = db.Account.Find(model.AccountID);

            try
            {
                updatemodel.TaiKhoan = model.TaiKhoan;
                db.SaveChanges();
                return RedirectToAction("Update");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model);

            }
        }
        public ActionResult Xoa(int id)
        {
            SHOPEntities db = new SHOPEntities();
            var model = db.Account.Find(id);
            db.Account.Remove(model);
            db.SaveChanges();
            return RedirectToAction("Danhsach");

        }
    }
}