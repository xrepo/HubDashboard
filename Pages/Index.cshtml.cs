using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using SequelDashboardWeb.Data;
using SequelDashboardWeb.Models;

namespace SequelDashboardWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public List<SalesSummary> Sales = new List<SalesSummary>();

        private readonly ISalesData _salesdata;

        public IndexModel(ILogger<IndexModel> logger, ISalesData salesdata)
        {
            _logger = logger;
            _salesdata = salesdata;
        }

        public async Task OnGetAsync()
        {
            Sales = await _salesdata.GetSalesSummary();
        }

    }
}
