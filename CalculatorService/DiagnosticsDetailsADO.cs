using CalculatorApp.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CalculatorApp.Core
{
    public class DiagnosticsDetailsADO : IDiagnosticsDetialsADO
    {
        private string connectionstr { get; set; }

        public DiagnosticsDetailsADO(string _constr)
        {
            connectionstr = _constr;
        }

        public void StoreOutputToDB(string firstParameter, string secondParameter, string Operation, string result, string processedIn)
        {
            SqlConnection con = new SqlConnection(connectionstr);
            con.Open();
            SqlCommand cmd = new SqlCommand("InsertOperationalDetial");
            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("@FirstParameter", System.Data.SqlDbType.NVarChar).Value = firstParameter;
            cmd.Parameters.Add("@SecondParameter", System.Data.SqlDbType.NVarChar).Value = secondParameter;
            cmd.Parameters.Add("@OPerator", System.Data.SqlDbType.NVarChar).Value = Operation;
            cmd.Parameters.Add("@Result", System.Data.SqlDbType.NVarChar).Value = result;
            cmd.Parameters.Add("@ProcessedIn", System.Data.SqlDbType.NVarChar).Value = firstParameter;
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
