using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StuMng.Model
{
    public  class StudentModel
    {
        public string Name { get; set; }
        public string StuNum { get; set; }
        public string Gender { get; set; }
        public string Enrollment { get; set; }

        private string zhuanye;
        public string ZhuanYe
        {
            get
            {
                switch(zhuanye)
                {
                    case "001":
                        return  "计算机工程";
                    case "002":
                        return "学前教育";
                    case "003":
                        return "能机工程";                     
                    default:
                        return "计算机工程";
                      
                }
            }
            set
            {
                zhuanye = value;
            }
        } 

          
        public int Age { get; set; }


        public StudentModel()
        { }

        public StudentModel(string name,string stuNum,string gender,int age,string enrollment,string zhuanYe)
        {
            Name = name;
            StuNum = stuNum;
            Gender = gender;
            Enrollment = enrollment;
            ZhuanYe = zhuanYe;
            Age = age;
        }
    }
}
