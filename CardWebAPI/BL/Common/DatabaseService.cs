using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CardWebAPI.BL.Common
{
    public class DatabaseService
    {
        public DataTable executeStoreProcedure(string procname, List<SqlParams> parameters)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-VAJNS2A;Initial Catalog=kokard_cms;User ID=sa;Password=12");
            DataTable dt = null;
            try
            {
                SqlCommand cmd = new SqlCommand(procname, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                foreach (var item in parameters)
                {
                    cmd.Parameters.Add(item.name, item.type).Value = item.value;
                }

                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                dt = new DataTable();
                dt.Load(reader);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }
    }
}
