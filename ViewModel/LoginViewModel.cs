using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SupermarketManagementSystem.Entity;
using SupermarketManagementSystem.Enums;
using SupermarketManagementSystem.Model;
using SupermarketManagementSystem.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SupermarketManagementSystem.ViewModel
{

    public class LoginViewModel : ViewModelBase2
    {
       

        /// <summary> 
        /// 用户实体 
        /// </summary>
        private member member = new member();
        public member Member
        {
            get { return member; }
            set { member = value; RaisePropertyChanged(); }
        }

        #region commands
        /// <summary>
        /// 初始化
        /// </summary>
        public RelayCommand<UserControl> LoadedCommand
        {
            get
            {
                return new RelayCommand<UserControl>((view) =>
                {
#if DEBUG
                    Member.NameEx = "admin";
                    Member.PasswordEx = "admin";
#endif
                });
            }
        }
        /// <summary>
        /// 用户登录
        /// </summary>
        public RelayCommand<LoginView> LoginCommand
        {
            get
            {
                return new RelayCommand<LoginView>((view) =>
                {
                    if (string.IsNullOrEmpty(member.Name) || string.IsNullOrEmpty(member.Password))
                    {
                        return;
                    }
                    if(AppData.UserType== CurrentUserType.管理员)
                    {
                        var list = MemberProvider.Current.GetAll();
                        var model = list.FirstOrDefault(t =>
                        t.Name == member.Name && t.Password == member.Password);
                        if (model != null)
                        {
                            AppData.CurrenUser = model;
                            //进入管理员的主窗体
                            new MainWindow().Show();
                            view.Close();
                        }
                        else
                        {
                            MessageBox.Show("用户名字或者密码错误");
                        }
                    }
                    else
                    {
                        var list = CustomerProvider.Current.GetAll();
                        var model = list.FirstOrDefault(t => 
                        t.Name == member.Name && t.Password == member.Password);
                        if (model != null)
                        {
                            AppData.CurrentCustomer = model;
                            new CustomerWindow().Show();
                            view.Close();
                        }
                        else
                        {
                            MessageBox.Show("用户名或密码错误！");
                        }
                    }

                });
            }
        }

        public RelayCommand<LoginView> ExitCommand
        {
            get
            {
                return new RelayCommand<LoginView>((view) =>
                {
                    view.Close();
                });
            }
        }

        /// <summary>
        /// 切换用户
        /// </summary>
        public RelayCommand<RadioButton> CheckedCommand
        {
            get
            {
                return new RelayCommand<RadioButton>((button) =>
                {
                    if (button == null) return;
                    if (button is RadioButton radioButton)
                    {
                        if (radioButton.Tag == null) return;
                        if (Enum.TryParse(radioButton.Tag.ToString(), false, out CurrentUserType result))
                        {
                            AppData.UserType = result;
#if DEBUG
                            if (result == CurrentUserType.顾客)
                            {
                                member.NameEx = "xiang";
                                member.PasswordEx = "123";
                            }
                            else
                            {
                                member.NameEx = "admin";
                                
                            }
#endif
                        }
                    }
                });
            }
        }


        #endregion
    }
}
