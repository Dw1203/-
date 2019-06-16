using StuMng.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace StuMng.DAL
{
   public class DalMain
    {
        SQLHelp sql = new SQLHelp();

        public List<MenuModel> GetMenu(string sqlstr)
        {
            try
            {
                List<MenuModel> list = new List<MenuModel>();
                
                DataTable dt = sql.GetDataTable(sqlstr, null);
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new MenuModel(int.Parse(dr[0].ToString()), int.Parse(dr[2].ToString()), dr[3].ToString()));
                }
                return list;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
