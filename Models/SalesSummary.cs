using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SequelDashboardWeb.Models
{
    public class SalesSummary
    {
        public string Warehouse { get; set; }

        public string NotProcessed { get; set; }
        public string Hold { get; set; }

        public string Failed { get; set; }

        public string AwaitingStock { get; set; }

        public string ReadyToShip { get; set; }

        public string Shipped { get; set; }

        public string Cancelled { get; set; }

        public string Total { get; set; }
    }
}
