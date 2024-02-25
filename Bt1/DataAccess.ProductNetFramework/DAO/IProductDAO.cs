using DataAccess.ProductNetFramework.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ProductNetFramework.DAO
{
    public interface IProductDAO
    {
        List<Product> GetProduct(GetProductRequestData requestData);
        Product GetProductById(int Id);
        ReturnData ProductInsertUdpate(Product product);
        ReturnData ProductDelete(ProductDeleteRequestData requestData);


    }
}
