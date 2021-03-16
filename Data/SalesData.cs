using SequelDashboardWeb.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SequelDashboardWeb.Data
{
    public class SalesData: ISalesData
    {
        public List<SalesSummary> orders = new List<SalesSummary>();

        private readonly IHubData _data;

        public SalesData(IHubData data)
        {
            _data = data;
        }

        public async Task<List<SalesSummary>> GetSalesSummary()
        {
            List<SalesSummary> Result = new List<SalesSummary>();
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "ESP_Hub_UKDashboard";

                    using (SqlDataReader dr = await _data.OpenQuery(cmd))
                    {
                        while (dr.Read())
                        {
                            SalesSummary so = new SalesSummary();
                            so.Warehouse = dr["Warehouse"].ToString();
                            so.NotProcessed = dr["NotProcessed"].ToString();
                            so.Hold = dr["Hold"].ToString();
                            so.Failed = dr["Failed"].ToString();
                            so.AwaitingStock = dr["AwaitingStock"].ToString();
                            so.ReadyToShip = dr["ReadyToShip"].ToString();
                            so.Shipped = dr["Shipped"].ToString();
                            so.Cancelled = dr["Cancelled"].ToString();
                            so.Total = dr["Total"].ToString();

                            Result.Add(so);
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Result;
        }

        public async Task<List<SalesOrder>> GetOrderDetailByStatus(string warehouse, string status)
        {
            List<SalesOrder> Result = new List<SalesOrder>();
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "ESP_Hub_OrderDetailsByStatus";
                    cmd.Parameters.Add("warehouse", SqlDbType.VarChar).Value = warehouse;
                    cmd.Parameters.Add("status", SqlDbType.VarChar).Value = status;

                    using (SqlDataReader dr = await _data.OpenQuery(cmd))
                    {
                        while (dr.Read())
                        {
                            SalesOrder so = new SalesOrder();
                            so.OrderRef = dr["ref"].ToString();
                            so.CustomerRef = dr["PurchaseOrder"].ToString();
                            so.OrderDate = Convert.ToDateTime(dr["date"].ToString());
                            so.OrderStatus = dr["Status"].ToString();
                            so.TrackingNumber = dr["TrackingNum"].ToString();
                            so.CustomerName = dr["CardHolder"].ToString();
                            so.ShippedDate = dr["ShippedDate"].ToString();

                            Result.Add(so);
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Result;
        }

    }
}
