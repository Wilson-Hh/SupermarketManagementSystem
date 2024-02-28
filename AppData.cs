using GalaSoft.MvvmLight;
using SupermarketManagementSystem.Entity;
using SupermarketManagementSystem.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SupermarketManagementSystem
{
    public class AppData : ObservableObject
    {
        /// <summary>
        /// 单例模式
        /// </summary>
        public static AppData Instance { get; set; } = new Lazy<AppData>(() => new AppData()).Value;
        /// <summary>
        /// 当前登录的用户
        /// </summary>
        public member CurrenUser { get; set; } = new member();

        public string Title => "XX超市";
        public string FullTitle => Title + "管理系统";
        /// <summary>
        /// 当前登录的顾客
        /// </summary>
        public customer CurrentCustomer { get; set; } = new customer();

        /// <summary>
        /// 背景颜色
        /// </summary>
        public SolidColorBrush Background => new SolidColorBrush(Color.FromRgb(41, 55, 82));

        /// <summary>
        /// 前景颜色
        /// </summary>
        public SolidColorBrush Foreground => new SolidColorBrush(Color.FromRgb(255, 255, 255));

        /// <summary>
        /// 用户类别
        /// </summary>
        private CurrentUserType userType = CurrentUserType.管理员;

        public CurrentUserType UserType
        {
            get { return userType; }
            set { userType = value; RaisePropertyChanged(); }
        }

    }
    
}
