using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SequelDashboardWeb.Models
{
    public class SalesOrder
    {
        public string OrderRef { get; set; }

        public DateTime OrderDate { get; set; }

        public string CustomerRef { get; set; }

        public string CustomerName { get; set; }

        public string OrderStatus { get; set; }

        public string TrackingNumber { get; set; }

        public string ShippedDate { get; set; }
    }
}
