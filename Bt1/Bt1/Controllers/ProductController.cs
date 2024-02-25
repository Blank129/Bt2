using DataAccess.ProductNetFramework.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bt1.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListPartialView(GetProductRequestData requestData)
        {
            var list = new List<Product>();
            try
            {
                list = new DataAccess.ProductNetFramework.DAOimpl.ProductDAOimpl().GetProduct(requestData);
            }
            catch (Exception ex)
            {

                throw;
            }
            return PartialView(list);
        }
        [HttpPost]
        public JsonResult ProductDelete(ProductDeleteRequestData requestData)
        {
            var returnData = new ReturnData();
            try
            {
                var rs = new DataAccess.ProductNetFramework.DAOimpl.ProductDAOimpl().ProductDelete(requestData);
                return Json(rs, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                returnData.returnCode = -999;
                returnData.returnMessage = "Hệ thống đang bận";
                return Json(returnData, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetProductbyId(int? id)
        {
            var model = new Product();
            try
            {
                if(id != null)
                {
                    model = new DataAccess.ProductNetFramework.DAOimpl.ProductDAOimpl().GetProductById(Convert.ToInt32(id));
                }
                
            }
            catch (Exception ex)
            {

                throw;
            }
            return View(model);
        }

        public JsonResult ProductInsertUpdate(Product product)
        {
            var returnData = new ReturnData();
            try
            {
                var rs = new DataAccess.ProductNetFramework.DAOimpl.ProductDAOimpl().ProductInsertUdpate(product);
                return Json(rs, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                returnData.returnCode = -999;
                returnData.returnMessage = "Hệ thống đang bận";
                return Json(returnData, JsonRequestBehavior.AllowGet);
            }
        }


    }
}