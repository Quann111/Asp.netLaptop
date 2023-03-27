using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThiASP.NET.Models;

namespace ThiASP.NET.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Categories
        public ActionResult Index()
        {
            SHOPEntities db = new SHOPEntities();
            List<DanhMucSP> lst = db.DanhMucSP.ToList();
            return View(lst);
        }
        // GET: Add Category
        public ActionResult Add()
        {
            return View();
        }
        // POST : Add to db
        [HttpPost]
        public ActionResult Add(DanhMucSP obj)
        {
            SHOPEntities db = new SHOPEntities();
            try
            {
                var fileImage = Request.Files["fileImage"];
                if (fileImage != null && fileImage.ContentLength > 0)
                {
                    string[] f_name = fileImage.FileName.Split('.');
                    string file_name = DateTime.Now.ToString("yyyyMMddhhmmssffff") + "." + f_name[f_name.Length - 1];
                    string path = Server.MapPath("~/images/logo/" + file_name);
                    fileImage.SaveAs(path);
                    obj.AnhDM = "/images/logo/" + file_name;
                }
                db.DanhMucSP.Add(obj);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {

            }
            return View();
        }
        public ActionResult Edit(long? ID)
        {
            SHOPEntities db = new SHOPEntities();
            if (ID == null || ID == 0)
            {
                return HttpNotFound();
            }
            DanhMucSP data = db.DanhMucSP.Find(ID);
            if (data == null)
            {
                return HttpNotFound();
            }
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(DanhMucSP obj)
        {
            try
            {
                var fileImage = Request.Files["fileImage"];
                if (fileImage != null && fileImage.ContentLength > 0)
                {
                    string[] f_name = fileImage.FileName.Split('.');
                    string file_name = DateTime.Now.ToString("yyyyMMddhhmmssffff") + "." + f_name[f_name.Length - 1];
                    string path = Server.MapPath("~/images/logo/" + file_name);
                    fileImage.SaveAs(path);
                    obj.AnhDM = "/images/logo/" + file_name;
                }

                SHOPEntities db = new SHOPEntities();
                DanhMucSP data = db.DanhMucSP.Find(obj.MaDM);
                if (data != null)
                {
                    data.TenDM = obj.TenDM;
                    data.MoTaDM = obj.MoTaDM;
                }
                db.SaveChanges();
            }
            catch
            {

            }
            return RedirectToAction("Index");
        }


        //public ActionResult Delete(long ID)
        //{
        //    if (ID == null || ID == 0)
        //    {
        //        return HttpNotFound();
        //    }
        //    SHOPEntities db = new SHOPEntities();
        //    DanhMucSP product = db.DanhMucSP.Find(ID);
        //    if (product == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(product);
        //}
        public ActionResult Delete(long ID)
        {
            SHOPEntities db = new SHOPEntities();
            DanhMucSP product = db.DanhMucSP.Find(ID);
            db.DanhMucSP.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}