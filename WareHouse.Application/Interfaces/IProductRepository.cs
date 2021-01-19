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

        Product AddQuantity(Product product);

        Product ReduceQuantity(Product product);

        DeleteProduct Delete(Guid productID);

        Product GetProductDetails(Guid product);

        void AddBarcodeQuantity(string barcodeId);

        void DecreaseBarcodeQuantity(string barcodeId);
        
        Product GetProductByBarcode(string newBarcodeId);
    }
}
