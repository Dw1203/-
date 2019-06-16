using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StuMng.Model
{
    public  class MenuModel
    {
        public int MenuCode { get; set; }
        public int MenuPathCode { get; set; }
        public string MenuName { get; set; }

        public MenuModel(int Code,int PathCode,string Name)
        {
            MenuCode = Code;
            MenuPathCode = PathCode;
            MenuName = Name;
        }
    }
}
