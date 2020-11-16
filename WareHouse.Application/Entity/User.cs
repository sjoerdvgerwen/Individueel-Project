using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Warehouse.Application.Entity
{
    public class User
    {
        public Guid UserID { get; set; }

        public string UserName { get; set; }

        public string Password{ get; set; }
    }
}
