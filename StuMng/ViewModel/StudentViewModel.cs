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

        public DelegateCommand SearchCmd { get; set; }

        public DelegateCommand UpdateCmd { get; set; }

        private List<StudentModel> students;
        private string searchkey;

        public string Searchkey
        {
            get { return searchkey; }
            set { searchkey = value; }
        }

        public DelegateCommand RefreshCmd { get; set; }
        DAL.DalStudent dalStudent = new DAL.DalStudent();   
        //List<StudentModel> studentModels = new List<StudentModel>();
        public List<StudentModel> liststudents;
        public List<StudentModel> Liststudents
        { get { return liststudents; }
            set { liststudents = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Liststudents")); }
        }
       
        /// <summary>
        /// 初始化构造函数
        /// </summary>       

        public StudentViewModel()
        {
            LoadStudent();
            CreateCmd = new DelegateCommand(OpenCreate);          
            RefreshCmd = new DelegateCommand(Refresh);
            SearchCmd = new DelegateCommand(Search);
            UpdateCmd = new DelegateCommand(OpenUpdate);
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
           
            foreach (DataRow item in dt.Rows)
            {
                studentModel = new StudentModel(item["Num"].ToString(),item["姓名"].ToString(), item["学号"].ToString(), bool.Parse(item["性别"].ToString()) ? "男" : "女",
                    int.Parse(item["年龄"].ToString()), item["入校时间"].ToString(), item["专业"].ToString());
                list.Add(studentModel);
            }
            students = list;
            Liststudents = null;
            Liststudents = list;
        }

        /// <summary>
        /// 打开创建页
        /// </summary>
        private void OpenCreate()        {
          
            WindowManager.Show("CreatStu", null);            
        }

        private void OpenUpdate()
        {
            WindowManager.Show("Update", null);
        }

        private void Search()
        {
            List<StudentModel> list =students.Where(s => s.Name.Contains(Searchkey)).ToList();
            Liststudents = null;
            Liststudents = list;
        }           

        private void Refresh()
        {
            LoadStudent();
        }
        
     
    }
}
