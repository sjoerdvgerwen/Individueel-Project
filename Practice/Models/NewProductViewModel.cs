using System;

namespace Warehouse.Webapp.Models
{
    public class NewProductViewModel
    {
        public Guid ProductID { get; set; }
        
        public string ProductName { get; set; }
        
        public string ProductDescription { get; set; }
        
        public int ProductQuantity { get; set; }
        
        public string BarcodeId { get; set; }
    }
}