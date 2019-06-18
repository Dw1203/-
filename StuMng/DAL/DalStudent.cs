using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StuMng.Model;

namespace StuMng.DAL
{
    public class DalStudent
    {
        SQLHelp SQLHelp = new SQLHelp();

        /// <summary>
        /// 加载数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetStuData()
        {
            string sqlstr = "select a.Num ,a.Name as 姓名,a.StuNum as 学号,a.Gender as 性别,a.Age as 年龄,a.Enrollment as 入校时间,b.Title as 专业 from Student as a ,Professional as b  where a.ZhuanYe= b.Num";
            try
            {
                DataTable dt = SQLHelp.GetDataTable(sqlstr, null);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool InsertStu(StudentModel model)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Insert into Student ");
                sb.Append("Values (@Name,@StuNum,@Gender,@Age,@ZhuanYe,@Enrollment)");
                SqlParameter[] parameter =
                {
                new SqlParameter("@Name",SqlDbType.VarChar,20),
                new SqlParameter ("@StuNum",SqlDbType.VarChar,10),
                new SqlParameter("@Gender",SqlDbType.Bit),
                new SqlParameter("@Age",SqlDbType.Int,2),
                new SqlParameter("@ZhuanYe",SqlDbType.VarChar,20),
                new SqlParameter("@Enrollment",SqlDbType.Date)
                };
                parameter[0].Value = model.Name;
                parameter[1].Value = model.StuNum;
                parameter[2].Value = model.Gender=="男"?"true":"false";
                parameter[3].Value =model.Age;
                parameter[4].Value = model.ZhuanYe;
                parameter[5].Value = model.Enrollment;
                if (SQLHelp.InsertData(sb.ToString(), parameter) == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        
    }
}
