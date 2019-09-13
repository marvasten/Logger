using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger.Enums;

namespace Logger.Logs
{
    public class DatabaseLogger : AbstractLogger
    {
        public override void AddLog(LogLevel level, string message)
        {
            string connectionString = Environment.GetEnvironmentVariable("ConnectionString", EnvironmentVariableTarget.User);
            if (string.IsNullOrEmpty(connectionString)) {
                throw new ApplicationException("Missing configuration: Connection String");
            }

            SqlConnection cnx = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("usp_AddLog", cnx);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("@pLevel", SqlDbType.NVarChar, 50).Value = level.ToString();
            cmd.Parameters.Add("@pMessage", SqlDbType.NVarChar, -1).Value = message;
            try
            {
                cnx.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cnx.Close();
            }
        }
    }
}
