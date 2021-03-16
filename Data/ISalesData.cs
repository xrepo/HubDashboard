using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SequelDashboardWeb.Models;

namespace SequelDashboardWeb.Data
{
    public interface ISalesData
    {
        Task<List<SalesSummary>> GetSalesSummary();

        Task<List<SalesOrder>> GetOrderDetailByStatus(string warehouse, string status);
    }
}
