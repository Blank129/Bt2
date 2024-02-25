using DataAccess.ProductNetFramework.DAO;
using DataAccess.ProductNetFramework.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ProductNetFramework.DAOimpl
{
    public class ProductDAOimpl : IProductDAO
    {
        public List<Product> GetProduct(GetProductRequestData requestData)
        {
            try
            {
                var list = InitialProduct();
                if (!string.IsNullOrEmpty(requestData.name))
                {
                    list = list.FindAll(s => s.Name.Contains(requestData.name) == requestData.name.Contains(requestData.name));
                }
                else
                {
                    list = InitialProduct();
                }
                return list;
                
                
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public Product GetProductById(int Id)
        {
            var list = InitialProduct();
            var product = list.Where(s => s.Id == Id).FirstOrDefault();
            return product;

        }

        public ReturnData ProductDelete(ProductDeleteRequestData requestData)
        {
            var returnData = new ReturnData();
            if(requestData== null || requestData.Id < 0)
            {
                returnData.returnCode = -1;
                returnData.returnMessage = "Dữ liệu đầu vào ko hợp lệ";
                return returnData;
            }

            var list = InitialProduct();
            var product = list.Where(s=> s.Id == requestData.Id).FirstOrDefault();
            if (product == null)
            {
                returnData.returnCode = -2;
                returnData.returnMessage = "Ko tìm thấy sản phẩm";
                return returnData;
            }

            var rs = list.Remove(product);
            returnData.returnCode = 1;
            returnData.returnMessage = "Xóa thành công";
            return returnData;
        }

        public ReturnData ProductInsertUdpate(Product product)
        {
            try
            {
                var returnData = new ReturnData();
                if (product == null || product.Id < 0)
                {
                    returnData.returnCode = -1;
                    returnData.returnMessage = "Dữ liệu đầu vào ko hợp lệ";
                    return returnData;
                }

                if (!MyShop.Common.Security.CheckXSSInput(product.Name))
                {
                    returnData.returnCode = -2;
                    returnData.returnMessage = "Dữ liệu đầu vào ko an toàn";
                    return returnData;
                }

                var list = InitialProduct();
                
                if(product.Id < 0)
                {
                    list.Add(product);
                    returnData.returnCode = 1;
                    returnData.returnMessage = "Thêm thành công";
                    return returnData;
                }

                else
                {
                    var productName = list.Where(s=>s.Id == product.Id).FirstOrDefault();
                    
                    if (product == null)
                    {
                        returnData.returnCode = -1;
                        returnData.returnMessage = "Ko tìm thấy sản phẩm";
                        return returnData;
                    }
                    productName.Name = product.Name;
                    returnData.returnCode = 1;
                    returnData.returnMessage = "Cập nhật sản phẩm thành công";
                    return returnData;
                }
            }
            catch (Exception ex)
            {

                throw;
            }


        }

        private List<Product> InitialProduct()
        {
            var list = new List<Product>();
            try
            {
                for(int i = 0; i < 10; i++)
                {
                    list.Add(new Product { Id = i + 1, Name = "Product" + i, Price = 10000 });
                }
                return list;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
