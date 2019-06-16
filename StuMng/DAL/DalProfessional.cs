using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StuMng.Model;
using System.Data;


namespace StuMng.DAL
{
   public  class DalProfessional
    {
        SQLHelp sQLHelp = new SQLHelp();
         public List<ProfessionalModel> GetProfessionals ()
        {
            string sqlstr = "select * from Professional";
            DataTable DT= sQLHelp.GetDataTable(sqlstr, null);
            List<ProfessionalModel> list = new List<ProfessionalModel>();
            foreach (DataRow item in DT.Rows)
            {
                list.Add(new ProfessionalModel(item["num"].ToString(), item["title"].ToString()));                
            }
            return list;
        }

    }
}
