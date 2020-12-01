using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Application.Entity;

namespace Warehouse.Application.Interfaces
{
    public interface IProductRepository
    {
        Product AddProduct(Product product);

        List<Product> GetAllProducts();

        Product AddQuantity(Product Product);

        Product ReduceQuantity(Product product);

        Product GetProductDetails(Product product);

    }
}
