using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ProductNetFramework.DTO
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
    }

    public class GetProductRequestData
    {
        public string name { get; set; }
    }
    public class ProductDeleteRequestData
    {
        public int Id { get; set; }
    }
    
}
