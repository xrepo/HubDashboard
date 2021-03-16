using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SequelDashboardWeb.Data
{
    public class HubData : IHubData
    {
        private string _dbConnectionString;

        public HubData(string dbConnectionString)
        {
            _dbConnectionString = dbConnectionString;
        }

        public async Task<SqlDataReader> OpenQuery(SqlCommand _cmd)
        {
            SqlDataReader dr = null;
            SqlConnection conn = new SqlConnection(_dbConnectionString);
            SqlCommand cmd = new SqlCommand();

            try
            {
                {
                    {
                        conn.Open();

                        cmd.CommandText = _cmd.CommandText;
                        cmd.CommandType = _cmd.CommandType;
                        cmd.CommandTimeout = 7200;

                        cmd.Connection = conn;

                        foreach (SqlParameter pr in _cmd.Parameters)
                        {
                            cmd.Parameters.Add(pr.ParameterName, pr.SqlDbType).Value = pr.Value;
                        }

                        dr = await cmd.ExecuteReaderAsync(CommandBehavior.CloseConnection);

                    }

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dr;

        }

        public async Task RunQuery(SqlCommand _cmd)
        {

            try
            {
                using (SqlConnection conn = new SqlConnection(_dbConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        conn.Open();

                        cmd.CommandText = _cmd.CommandText;
                        cmd.CommandType = _cmd.CommandType;
                        cmd.CommandTimeout = 3600;

                        cmd.Connection = conn;

                        foreach (SqlParameter pr in _cmd.Parameters)
                        {
                            cmd.Parameters.Add(pr.ParameterName, pr.SqlDbType).Value = pr.Value;
                        }

                        await cmd.ExecuteNonQueryAsync();

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }

        }

    }
}
