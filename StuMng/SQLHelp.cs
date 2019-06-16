using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;

namespace StuMng
{
    public class SQLHelp
    {
        string constr = ConfigurationManager.ConnectionStrings["1"].ToString();

        /// <summary>
        ///测试连接
        /// </summary>
        /// <returns></returns>
        public bool ConnectSql()
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                if(con.State==System.Data.ConnectionState.Open)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// 获取记录行数
        /// </summary>
        /// <param name="sqlstr"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>

        public int GetCount(string sqlstr,SqlParameter [] parameters)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    con.Open();
                    if (con.State == System.Data.ConnectionState.Open)
                    {
                        SqlCommand cmd = new SqlCommand();
                        PrepareCommand(cmd, con, null, sqlstr, parameters);
                        string rows=  cmd.ExecuteScalar().ToString();
                        cmd.Parameters.Clear();
                        return int.Parse( rows);
                    }
                    else
                    {
                        return -1;
                    }
                }
            }

            catch (Exception ex)
            {
                //return -1;
                throw new Exception(ex.Message);
                
            }            
}

        /// <summary>
        /// 获取数据表
        /// </summary>
        /// <param name="sqlser"></param>
        /// <param name="sqlParameters"></param>
        /// <returns></returns>
        public DataTable GetDataTable(string sqlser,SqlParameter[] sqlParameters)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    con.Open();
                    if(con.State==ConnectionState.Open)
                    {
                        SqlCommand command = new SqlCommand(sqlser, con);
                        SqlDataAdapter da = new SqlDataAdapter(command);
                        DataSet ds = new DataSet();
                         da.Fill(ds);
                        DataTable dt = ds.Tables[0];
                        return dt;
;                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="sqlstr"></param>
        /// <param name="sqlParameters"></param>
        /// <returns></returns>
        public int InsertData(string sqlstr,SqlParameter[] sqlParameters)
        {
            int a = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    con.Open();
                    if(con.State == ConnectionState.Open)
                    {
                        SqlCommand command = new SqlCommand();
                        PrepareCommand(command, con, null, sqlstr, sqlParameters);
                        return a = command.ExecuteNonQuery();
                    }
                    else
                    {
                        return -1;
                    }

                }

            }
            catch(Exception ex)
            {
                //return -1;
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 初始化SqlCommand
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        /// <param name="cmdText"></param>
        /// <param name="cmdParms"></param>
        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, string cmdText, SqlParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = cmdText;

            if (trans != null)
                cmd.Transaction = trans;

            if (cmdParms == null)
                return;
            foreach (SqlParameter parameter in cmdParms)
            {
                if ((parameter.Direction == ParameterDirection.InputOutput ||
                     parameter.Direction == ParameterDirection.Input) &&
                    (parameter.Value == null))
                {
                    parameter.Value = DBNull.Value;
                }
                cmd.Parameters.Add(parameter);
            }
        }
    }
}
