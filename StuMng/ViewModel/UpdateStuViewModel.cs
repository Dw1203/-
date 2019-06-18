using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StuMng.Model;

namespace StuMng.ViewModel
{
    public class UpdateStuViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        public UpdateStuViewModel()
        {

            
        }

        private int proSelectIndex=0;
        public int ProSelectIndex
        {
            get { return proSelectIndex; }
            set { proSelectIndex = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ProSelectIndex"));
            }
        }

        private int genSelectIndex=1;

        public int GenSelectIndex
        {
            get { return genSelectIndex; }
            set { genSelectIndex = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("GenSelectIndex"));
            }
        }

        private StudentModel student;

        public StudentModel Student
        {
            get { return student; }
            set { student = value; }
        }


    }
}
