using StuMng.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StuMng.DAL
{
   public  class DalLogin
    {
        SQLHelp sql = new SQLHelp();
        public bool Validation(LoginModel loginModel)
        {
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append("select count(*) from myuser where username=@UserName and password=@Password and usertype=@Type");
                SqlParameter[] parameters =
                {
                    new SqlParameter("@UserName",System.Data.SqlDbType.VarChar,50),
                    new SqlParameter("@Password", System.Data.SqlDbType.VarChar, 50),
                    new SqlParameter("@Type", System.Data.SqlDbType.VarChar, 50),
                };
                parameters[0].Value = loginModel.UserName;
                parameters[1].Value = loginModel.PassWord;
                parameters[2].Value = loginModel.Type;
                int row= sql.GetCount(stringBuilder.ToString(), parameters);
                if(row==1)
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
                //return false;
                throw new Exception(ex.Message);               
            }
        }
    }
}
