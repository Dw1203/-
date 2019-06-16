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
                gender = value;
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

        public CreateStuViewModel()
        {
            CreateCmd = new DelegateCommand<Window>(create);
            student = new StudentViewModel();
        }

        private void create(Window win)
        {
            
            StudentModel studentModel = new StudentModel(Name, StuNum, Gender,int.Parse(Age), Enrollment, Zhuanye);
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
    }
}
