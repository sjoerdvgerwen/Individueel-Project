using System;
using Warehouse.Application.Entity;

namespace Warehouse.Webapp.Models
{
    public class ProductDetailsViewModel
    {
        public ProductDetailsViewModel(Product product)
        {
            ProductID = product.ProductID;
            ProductName = product.ProductName;
            ProductDescription = product.ProductDescription;
            ProductQuantity = product.ProductQuantity;
        }
        public Guid ProductID { get; set; }
        
        public string ProductName { get; set; }
        
        public string ProductDescription { get; set; }
        
        public int ProductQuantity { get; set; }
        
    }
}