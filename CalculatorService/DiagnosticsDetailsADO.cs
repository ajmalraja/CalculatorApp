using CalculatorApp.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CalculatorApp.Core
{   /// <summary>
    /// Diagnostic details to store the inputs and result in the database using ADO.Net
    /// </summary>
    public class DiagnosticsDetailsADO : IDiagnosticsDetialsADO
    {
        private string connectionstr { get; set; }

        public DiagnosticsDetailsADO(string _constr)
        {
            connectionstr = _constr;
        }
        /// <summary>
        /// This use InsertOperationalDetial stored procedure to insert database to the table
        /// </summary>
        /// <param name="firstParameter"></param>
        /// <param name="secondParameter"></param>
        /// <param name="Operation"></param>
        /// <param name="result"></param>
        /// <param name="processedIn"></param>
        public void StoreOutputToDB(string firstParameter, string secondParameter, string Operation, string result, string processedIn)
        {
            try
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
            }catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
