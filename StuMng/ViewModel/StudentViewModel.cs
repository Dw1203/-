using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StuMng.Model;
using System.Data;
using Microsoft.Practices.Prism.Commands;
using StuMng.View;
using StuMng.Common;
using StuMng.ViewModel;

namespace StuMng.ViewModel
{
    public class StudentViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
       
        public DelegateCommand CreateCmd { get; set; }
        public DelegateCommand SaveCreate { get; set; }
        DAL.DalStudent dalStudent = new DAL.DalStudent();
        //List<StudentModel> studentModels = new List<StudentModel>();
        public List<StudentModel> liststudents;
        public List<StudentModel> Liststudents
        { get { return liststudents; }
            set { liststudents = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Liststudents")); }
        }
        public DataTable tableStu { get; set; }
        /// <summary>
        /// 初始化构造函数
        /// </summary>       

        public StudentViewModel()
        {
            LoadStudent();
            CreateCmd = new DelegateCommand(OpenCreate);
            SaveCreate = new DelegateCommand(saveCreate);
            
        }
        /// <summary>
        /// 学生对象
        /// </summary>
        private StudentModel studentModel;
        public StudentModel StudentModel
        {
            get { return studentModel; }
            set
            {
                studentModel = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("StudentModel"));
            }
        }

        /// <summary>
        /// 加载学生信息
        /// </summary>
        public void LoadStudent()
        {
            List<StudentModel> list=new List<StudentModel>();
            DataTable dt = dalStudent.GetStuData();
            dt.Columns["Name"].ColumnName = "姓名";
            foreach (DataRow item in dt.Rows)
            {
                studentModel = new StudentModel(item["姓名"].ToString(), item["StuNum"].ToString(), bool.Parse(item["Gender"].ToString()) ? "男" : "女",
                    int.Parse(item["Age"].ToString()), item["Enrollment"].ToString(), item["ZhuanYe"].ToString());
                list.Add(studentModel);
            }
            Liststudents = null;
            Liststudents = list;
        }

        /// <summary>
        /// 打开创建页
        /// </summary>
        private void OpenCreate()
        {
            LoadStudent();
            WindowManager.Show("CreatStu", null);            
        }

        private void saveCreate()
        {
            string s = studentModel.Name;

        }


        
    }
}
