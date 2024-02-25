using DataAccess.ProductNetFramework.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bt1.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ListShoppingCart(GetProductRequestData requestData)
        {
            var list = new List<ShoppingCart>();
            try
            {
                var cookie = Request.Cookies["MyShoppingCart"] != null ? Request.Cookies["MyShoppingCart"].Value : string.Empty;
                if (cookie != null && !string.IsNullOrEmpty(cookie))
                {
                    list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ShoppingCart>>(HttpUtility.UrlDecode(cookie));
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return PartialView(list);
        }

        public JsonResult CreateOrder(OrderInsertRequestData requestData)
        {
            try
            {
                var list = new List<ShoppingCart>();
                var cookie = Request.Cookies["MyShoppingCart"] != null ? Request.Cookies["MyShoppingCart"].Value : string.Empty;
                if (cookie != null && !string.IsNullOrEmpty(cookie))
                {
                    list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ShoppingCart>>(HttpUtility.UrlDecode(cookie));
                }
                //Kiểm tra xem số lg của từng mặt hàng còn ko

                //Tạo đơn hàng (giỏ hàng + giữ liệu khách hàng)
                var ma_dh = CreateOrder(requestData, list);


                //Tạo chi tiết đơn hàng
                var list_orderDetail = new List<OrderDetail>();
                foreach(var item in list)
                {
                    list_orderDetail.Add(new OrderDetail()
                    {
                        Ma_DonHang = ma_dh,
                        ProductId = item.ProductID,
                        ProductName = item.ProductName,
                        Quantity = item.Quality
                    });
                }
                return Json(list_orderDetail, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private string CreateOrder(OrderInsertRequestData requestData, List<ShoppingCart> carts)
        {
            try
            {
                var totalAmount = 0;
                foreach(var item in carts)
                {
                    totalAmount += item.Price;
                }
                var cart = new Order();
                //Guid là id tự sinh tự động
                cart.Ma_DonHang = "DH_" + Guid.NewGuid().ToString();
                cart.TongTien = totalAmount;
                cart.TenKhachHang = requestData.CustomerName;

                return cart.Ma_DonHang;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}