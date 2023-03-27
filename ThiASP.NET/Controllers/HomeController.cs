using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThiASP.NET.Models;

namespace ThiASP.NET.Controllers
{
    public class HomeController : Controller
    {
        SHOPEntities db = new SHOPEntities();

        public ActionResult Index()
        {
            HomeModel obj = new HomeModel();
            obj.ListSanpham = db.SanPham.ToList();
            obj.ListDM = db.DanhMucSP.ToList();
            return View(obj);
        }

    }
}