using CommonServiceLocator;
using GalaSoft.MvvmLight.Command;
using SupermarketManagementSystem.Entity;
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
    public class CustomerViweModel:ViewModelBase2
    {
        //private CustomerProvider customerProvider = new CustomerProvider();
        private List<customer> customerList = new List<customer>();
        public List<customer> CustomerList
        {
            get { return customerList; }
            set { customerList = value;  }
        }
        private customer customer;
        /// <summary>
        ///  当前选中的顾客实体
        /// </summary>
        public customer Customer
        {
            get { return customer; }
            set { customer = value; RaisePropertyChanged(); }
        }

        #region commands

        public RelayCommand<UserControl> LoadedCommand
        {
            get
            {
                return new RelayCommand<UserControl>((view) => 
                {
                    CustomerList = CustomerProvider.Current.GetAll();
                });
            }
        }
        /// <summary>
        /// 新增顾客
        /// </summary>
        public RelayCommand<UserControl> OpenAddViewCommand
        {
            get
            {
                return new RelayCommand<UserControl>((view) =>
                {
                    AddCustomerView addCustomerView = new AddCustomerView();
                    if (addCustomerView.ShowDialog().Value == true)
                    {
                        CustomerList = CustomerProvider.Current.GetAll();
                    }
                });
            }
        }
        /// <summary>
        /// 删除当前选中的顾客
        /// </summary>
        public RelayCommand<UserControl> DeleteCommand
        {
            get
            {
                return new RelayCommand<UserControl>((view) =>
                {
                    if (customer == null) return;
                    if (Dialog.Show())
                    {
                        var count = CustomerProvider.Current.Delete(customer);
                        if (count > 0)
                        {
                            MessageBox.Show("操作成功！");
                            CustomerList = CustomerProvider.Current.GetAll();
                        }
                    }
                });
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        public RelayCommand<UserControl> SaveCommand
        {
            get
            {
                return new RelayCommand<UserControl>((view) =>
                {
                    int count = CustomerProvider.Current.Save();
                    if (count > 0)
                    {
                        MessageBox.Show("保存成功");
                    }
                });
            }
        }

        /// <summary>
        /// 修改顾客
        /// </summary>
        public RelayCommand<UserControl> EditCommand
        {
            get
            {
                return new RelayCommand<UserControl>((view) =>
                {
                    if (Customer == null) return;
                    var vm = ServiceLocator.Current.GetInstance<EditCustomerViewModel>();
                    vm.Customer = Customer;
                    EditCustomerView editCustomerView = new EditCustomerView();
                    if (editCustomerView.ShowDialog().Value == true)
                    {
                        CustomerList = CustomerProvider.Current.GetAll();
                    }
                });
            }
        }
        #endregion
    }
}
