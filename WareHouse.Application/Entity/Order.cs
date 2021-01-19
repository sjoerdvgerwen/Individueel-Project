using System;

namespace Warehouse.Application.Entity
{
    public class Order
    {
        
        public Guid ProductID { get; set; }
        public string ProductName { get; set; }
    }
}