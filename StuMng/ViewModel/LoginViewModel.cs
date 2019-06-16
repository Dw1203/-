using Microsoft.Practices.Prism.Commands;
using StuMng.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using StuMng.Common;

namespace StuMng.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public DelegateCommand<Window> LoginCmd { get; set; }
        public DelegateCommand<Window> CloseWinCmd { get; set; }

        LoginModel loginModel = new LoginModel();        

        public string VmUsername
        {
            get { return loginModel.UserName; }
            set
            {
                loginModel.UserName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("vmUsername"));
            }
        }

        public string VmPassWord
        {
            get { return loginModel.PassWord; }
            set
            {
                loginModel.PassWord = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("VmPassWord"));
            }
        }

        public bool vmType;
        public bool VmType
        {
            get { return vmType;
            }
            set
            {
                vmType = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("VmType"));
            }
        }

        public LoginViewModel()
        {
            LoginCmd = new DelegateCommand<Window>(val);
            CloseWinCmd = new DelegateCommand<Window>(CloseWin);
        }

      

        private void val(Window window)
        {
            DAL.DalLogin dalLogin = new DAL.DalLogin();
            if(loginModel.UserName.Length<=0)
            {
                MessageBox.Show("用户名不能为空");
                return;
            }
            if(loginModel.PassWord.Length<=0)
            {
                MessageBox.Show("密码不能为空");
                return;
            }
            try
            {                
                if(VmType)
                {
                    loginModel.Type = "0";
                }
                else
                {
                    loginModel.Type = "1";
                }
                if (dalLogin.Validation(loginModel))
                {
                    if (window != null)
                    {
                        window.Visibility=Visibility.Collapsed;
                    }
                    WindowManager.Show("MainWindow", null);
                   
                }
                else
                {
                    MessageBox.Show("登录失败");
                    VmUsername = "";
                    VmPassWord = "";
                }
            }
            catch(Exception EX)
            {
                MessageBox.Show(EX.Message);
            }
           
        }

        private void CloseWin(Window win)
        {
            if(win!=null)
            {
                win.Close();
            }
        }
    }
}
