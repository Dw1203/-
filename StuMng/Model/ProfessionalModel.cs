using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StuMng.Model
{
    public  class ProfessionalModel
    {

        private string num;

        public string Number
        {
            get { return num; }
            set { num = value; }
        }

        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }


        public  ProfessionalModel(string num,string title)
        {
            Number = num;
            Title = title;
        }

    }
}
