using System;

namespace Warehouse.Webapp.Models
{
    public class ReduceProductViewModel
    {
        public Guid ProductID { get; set; }
        public int ReduceQuantity { get; set; }
    }
}