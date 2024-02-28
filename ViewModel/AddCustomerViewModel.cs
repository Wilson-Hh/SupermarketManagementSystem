using GalaSoft.MvvmLight.Command;
using SupermarketManagementSystem.Entity;
using SupermarketManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SupermarketManagementSystem.ViewModel
{
    public class AddCustomerViewModel:ViewModelBase2
    {
        private CustomerProvider customerProvider = new CustomerProvider();
        private customer customer;
        public customer Customer
        {
            get { return customer; }
            set { customer = value; RaisePropertyChanged(); }
        }




        public RelayCommand<Window> LoadedCommand
        {
            get
            {
                return new RelayCommand<Window>((view) =>
                {
                    Customer = new customer();
                });
            }
        }

        public RelayCommand<Window> AddCommand
        {
            get
            {
                return new RelayCommand<Window>((view) =>
                {
                    if (string.IsNullOrEmpty(Customer.Name))
                    {
                        MessageBox.Show("姓名不能为空");
                        return;
                    }
                    if (string.IsNullOrEmpty(Customer.Password))
                    {
                        MessageBox.Show("密码不能为空");
                        return;
                    }
                    if (string.IsNullOrEmpty(Customer.TelePhone))
                    {
                        MessageBox.Show("电话不能为空");
                        return;
                    }
                    if (string.IsNullOrEmpty(Customer.Address))
                    {
                        MessageBox.Show("地址不能为空!");
                        return;
                    }
                    customer.InsertDate = DateTime.Now;
                    int count = customerProvider.Insert(customer);
                    if (count > 0)
                    {
                        MessageBox.Show("操作成功!");
                    }
                    view.DialogResult = true;
                    view.Close();
                });
            }
        }
        public RelayCommand<Window> ExiteCommand
        {
            get
            {
                return new RelayCommand<Window>((view) =>
                {
                    view.Close();
                });
            }
        }
    }
}
