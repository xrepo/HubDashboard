using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SequelDashboardWeb.Data
{
    public interface IHubData
    {
        Task<SqlDataReader> OpenQuery(SqlCommand _cmd);

        Task RunQuery(SqlCommand _cmd);

    }
}
