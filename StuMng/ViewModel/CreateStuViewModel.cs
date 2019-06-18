using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StuMng.Model;
using System.Threading.Tasks;
using System.ComponentModel;
using Microsoft.Practices.Prism.Commands;
using StuMng.DAL;
using StuMng.ViewModel;
using System.Windows;
using StuMng.Common;

namespace StuMng.ViewModel
{

    
    public class CreateStuViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public  DelegateCommand<Window> CreateCmd{ get; set; }
        private StudentViewModel student { get; set;}
        DalStudent dal = new DalStudent();
        DalProfessional dalp = new DalProfessional();


        private string name;                                             
        public string Name
        {
            get { return name; }
            set { name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name")); }
        }

        private string stuNum;                                               
        public string StuNum
        {
            get { return stuNum; }
            set
            {
                stuNum = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("StuNum"));
            }
        }

        private string gender;                                             
        public string Gender
        {
            get { return gender; }
            set
            {
                if(GenSelectIndex==0)
                gender = "男";
                else
                    gender = "女";
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Gender"));
            }
        }

        private string age;                                          
        public string Age
        {
            get { return age; }
            set
            {
                age = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Age"));
            }
        }

        private string zhuanye;                                          
        public string Zhuanye
        {
            get { return zhuanye; }              

            set
            {
                zhuanye = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Zhuanye"));
            }
        }

        private string enrolment;                                      
        public string Enrollment
        {
            get { return enrolment; }
            set
            {
                enrolment = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Enrollment"));
            }
        }


        private int proSelectIndex=0;

        public int ProSelectIndex
        {
            get { return proSelectIndex; }
            set { proSelectIndex = value; }
        }

        private int genSelectIndex=0;

        public int GenSelectIndex
        {
            get { return genSelectIndex=0; }
            set { genSelectIndex = value; }
        }


        private List<ProfessionalModel> professionalModels;

        public List<ProfessionalModel> ProfessionalModels
        {
            get { return professionalModels; }
            set { professionalModels = value; }
        }


        public CreateStuViewModel()
        {
            CreateCmd = new DelegateCommand<Window>(create);
            student = new StudentViewModel();
            LoadList();
        }

        private void LoadList()
        {
            List<ProfessionalModel> list = new List<ProfessionalModel>();
            list=  dalp.GetProfessionals();
            ProfessionalModels = list;
        }
        private void create(Window win)
        {
            Convert();
            StudentModel studentModel = new StudentModel("",Name, StuNum, Gender,int.Parse(Age), Enrollment, Zhuanye);
            try
            {
                
                if(dal.InsertStu(studentModel))
                {
                    if(win!=null)
                    {
                        win.Close();
                    }
                }
                student.LoadStudent();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Convert()
        {
            switch (GenSelectIndex)
            {
                case 0:
                    Gender = "男";
                    break;
                case 1:
                    Gender = "女";
                    break;
                default:
                    Gender = "男";
                    break;
            }
            switch (ProSelectIndex)
            {

                case 0:
                    Zhuanye= "001";
                    break;
                case 1:
                    Zhuanye = "002";
                    break;
               case 2:
                    Zhuanye = "003";
                    break;
                default:
                    Zhuanye = "001";
                    break;
            }
        }
    }
}
