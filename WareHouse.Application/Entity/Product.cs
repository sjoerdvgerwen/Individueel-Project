using System;
using System.Collections.Generic;
using System.Text;

namespace Warehouse.Application.Entity
{
    public class Product
    {
        public Guid ProductID { get; set; }
        public string ProductName { get; set; }

        public string ProductDescription { get; set; }

        public int ProductQuantity { get; set; }

        public int AddQuantity { get; set; }
        public int ReduceQuantity { get; set; }
    }
}
