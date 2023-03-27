using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThiASP.NET.Models;

namespace ThiASP.NET.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index(long? Category)
        {
            SHOPEntities db = new SHOPEntities();
            ViewBag.Category = new SelectList(db.DanhMucSP, "MaDM", "TenDM");
            List<SanPham> list;
            if (Category == null)
            {
                list = db.SanPham.ToList();
            }
            else
            {
                list = db.SanPham.Where(x => x.MaDM == Category).ToList();
            }
            return View(list);
        }
        [HttpGet]
        public ActionResult Add()
        {
            SHOPEntities db = new SHOPEntities();
            ViewBag.Category = new SelectList(db.DanhMucSP, "MaDM", "TenDM");
            return View();
        }
        [HttpPost]
        public ActionResult Add(SanPham obj)
        {
            SHOPEntities db = new SHOPEntities();
            try
            {
                var fileImage = Request.Files["fileImage"];
                if (fileImage != null && fileImage.ContentLength > 0)
                {
                    string[] f_name = fileImage.FileName.Split('.');
                    string file_name = DateTime.Now.ToString("yyyyMMddhhmmssffff") + "." + f_name[f_name.Length - 1];
                    string path = Server.MapPath("~/images/laptop/" + file_name);
                    fileImage.SaveAs(path);
                    obj.AnhSP = "/images/laptop/" + file_name;
                }
                db.SanPham.Add(obj);
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

            ViewBag.Category = new SelectList(db.DanhMucSP, "MaDM", "TenDM");

            if (ID == null || ID == 0)
            {
                return HttpNotFound();
            }
            SanPham data = db.SanPham.Find(ID);
            if (data == null)
            {
                return HttpNotFound();
            }
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(SanPham obj)
        {
            try
            {
                var fileImage = Request.Files["fileImage"];
                if (fileImage != null && fileImage.ContentLength > 0)
                {
                    string[] f_name = fileImage.FileName.Split('.');
                    string file_name = DateTime.Now.ToString("yyyyMMddhhmmssffff") + "." + f_name[f_name.Length - 1];
                    string path = Server.MapPath("~/images/laptop/" + file_name);
                    fileImage.SaveAs(path);
                    obj.AnhSP = "/images/laptop/" + file_name;
                }

                SHOPEntities db = new SHOPEntities();
                SanPham data = db.SanPham.Find(obj.MaSP);
                if (data != null)
                {
                    data.TenSP = obj.TenSP;
                    data.GiaSP = obj.GiaSP;
                    data.AnhSP = obj.AnhSP;
                    data.TrangThai = obj.TrangThai;
                    data.BestSeller = obj.BestSeller;
                    data.CreateDate = obj.CreateDate;
                    data.MotaSP = obj.MotaSP;
                }
                db.SaveChanges();
            }
            catch
            {

            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(long ID)
        {
            SHOPEntities db = new SHOPEntities();
            SanPham product = db.SanPham.Find(ID);
            db.SanPham.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}