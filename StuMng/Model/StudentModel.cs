using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StuMng.Model
{
    public  class StudentModel
    {
        public string Num { get; set; }
        public string Name { get; set; }
        public string StuNum { get; set; }
        public string Gender { get; set; }
        public string Enrollment { get; set; }

        public string ZhuanYe { get; set; }



          
        public int Age { get; set; }


        public StudentModel()
        { }

        public StudentModel(string num,string name,string stuNum,string gender,int age,string enrollment,string zhuan)
        {
            Num = num;
            Name = name;
            StuNum = stuNum;
            Gender = gender;
            Enrollment = enrollment;
            ZhuanYe = zhuan;
            Age = age;
        }
    }
}
