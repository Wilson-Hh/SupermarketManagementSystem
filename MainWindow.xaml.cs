﻿using SupermarketManagementSystem.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SupermarketManagementSystem
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        // 页面切换
        private void IndexView_Checked(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton radioButton)
            {
                if (string.IsNullOrEmpty(radioButton.Name))
                {
                    return;
                }
                //第一种导航
                //switch (radioButton.Name)
                //{

                //    case "IndexView":container.Content = new IndexView();break;
                //    case "OrderView":container.Content = new OrderView();break;
                //    case "CustomerView":container.Content = new CustomerView();break;
                //    case "GoodsView":container.Content = new GoodsView();break;
                //    case "SupplierView":container.Content = new SupplierView();break;
                //    case "InstorageView":container.Content = new InstorageView();break;
                //    case "OutStorageView":container.Content = new OutStorageView();break;
                //    case "OrderDetailView":container.Content = new OrderDetailView();break;
                //    case "MemberView":container.Content = new MemberView();break;
                //    case "SettingView":container.Content = new SettingView();break;


                //    default:
                //        break;
                //}

                //第二种 反射
                container.Content = Activator.CreateInstance(Type.GetType("SupermarketManagementSystem.View." + radioButton.Name));
            }
        }
    }
}
