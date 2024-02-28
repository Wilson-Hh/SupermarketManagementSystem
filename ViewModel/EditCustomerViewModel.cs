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
    public class EditCustomerViewModel:ViewModelBase2
    {

        private CustomerProvider customerProvider = new CustomerProvider();
        private customer customer;
        public customer Customer
        {
            get { return customer; }
            set { customer = value; RaisePropertyChanged(); }
        }
        public RelayCommand<Window> OkCommand
        {
            get
            {
                return new RelayCommand<Window>((view) =>
                {
                    if (string.IsNullOrEmpty(Customer.Name))
                    {
                        MessageBox.Show("姓名不能为空!");
                        return;
                    }

                    if (string.IsNullOrEmpty(Customer.TelePhone))
                    {
                        MessageBox.Show("电话不能为空!");
                        return;
                    }

                    if (string.IsNullOrEmpty(Customer.Address))
                    {
                        MessageBox.Show("地址不能为空!");
                        return;
                    }

                    int count = customerProvider.Update(Customer);
                    if (count > 0)
                    {
                        MessageBox.Show("操作成功!");
                    }
                    view.DialogResult = true;
                    view.Close();
                });
            }
        }


        public RelayCommand<Window> ExitCommand
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

