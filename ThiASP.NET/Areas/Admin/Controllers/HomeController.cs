using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ThiASP.NET.Models;

namespace ThiASP.NET.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home

        public bool Kiemtraphanquyen()
        {
            SHOPEntities db = new SHOPEntities();
            Account ac = new Account();
            var cout = db.PhanQuyen.Count(m => m.idNhanvien == ac.AccountID & m.idChucnang == 1);
            if (cout == 1)
            {
                return true;
            }
            else
            {
                return false;
            }

            //muon su dung phan quyen
            //if(Kiemtraphanquyen ==false)
             //   return...

        }
        public ActionResult Index()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                return View();

            }
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string user , string password)
        {
            SHOPEntities db = new SHOPEntities();
            int demtaikhoan = db.Account.Count(m => m.TaiKhoan.ToLower() == user.ToLower() && m.MatKhau == password);

            if(demtaikhoan ==1)
            {
                Session["user"] = user;
                return RedirectToAction("Index");
            }
            else
            {
                TempData["error"] = "Tài khoản mật khẩu chưa đúng";
                return View();
            }
        }
        public ActionResult Logout()
        {
            Session.Remove("user");
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Account _user)
        {
            SHOPEntities db = new SHOPEntities();

            if (ModelState.IsValid)
            {
                var check = db.Account.FirstOrDefault(s => s.TaiKhoan == _user.TaiKhoan);
                if (check == null)
                {
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.Account.Add(_user);
                    db.SaveChanges();
                    return RedirectToAction("Register");
                }
                else
                {
                    ViewBag.error = "Nhap lai !!!";
                    return View();
                }
            }
            return View();
        }

    }
}