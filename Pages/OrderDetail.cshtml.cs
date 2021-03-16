using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SequelDashboardWeb.Data;
using SequelDashboardWeb.Models;

namespace SequelDashboardWeb.Pages
{
    public class OrderDetailModel : PageModel
    {
        public List<SalesOrder> SalesOrders = new List<SalesOrder>();
        private readonly ISalesData _salesData;

        public OrderDetailModel(ISalesData salesData)
        {
            _salesData = salesData;
        }

        public async Task OnGetAsync(string warehouse, string status)
        {
            SalesOrders = await _salesData.GetOrderDetailByStatus(warehouse, status);
        }
    }
}
