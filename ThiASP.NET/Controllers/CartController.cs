using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThiASP.NET.Models;

namespace ThiASP.NET.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            List<Cart> lstCart = (List<Cart>)Session["lstCart"];
            if (lstCart == null)
            {
                lstCart = new List<Cart>();
            }
            return View(lstCart);
        }
        public ActionResult AddToCart(long productID)
        {
            // Xác định sản phẩm sẽ được thêm vào giỏ hàng
            List<Cart> lstCart = (List<Cart>)Session["lstCart"];
            if (lstCart == null)
            {
                lstCart = new List<Cart>();
            }
            Cart obj = lstCart.FirstOrDefault(x => x.productID == productID);
            if (obj != null)
            {
                obj.quantity++;
            }
            else
            {
                SHOPEntities db = new SHOPEntities();
                obj = new Cart();
                obj.productID = productID;
                obj.productDetail = db.SanPham.First(x => x.MaSP == productID);
                obj.quantity = 1;
                lstCart.Add(obj);
            }
            Session["lstCart"] = lstCart;

            return RedirectToAction("Index");
        }
    }
}