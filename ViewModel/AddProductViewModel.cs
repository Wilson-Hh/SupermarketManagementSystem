using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using SupermarketManagementSystem.Entity;
using SupermarketManagementSystem.Helper;
using SupermarketManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace SupermarketManagementSystem.ViewModel
{
    public class AddProductViewModel:ViewModelBase2
    {
        private ProductProvider productProvider = new ProductProvider();
        private SupplierProvider supplierProvider = new SupplierProvider();

        private List<supplier> supplierList = new List<supplier>();
        public List<supplier> SupplierList
        {
            get { return supplierList; }
            set { supplierList = value; RaisePropertyChanged(); }
        }

        private supplier supplier;
        /// <summary>
        ///  当前选中的供应商
        /// </summary>
        public supplier Supplier
        {
            get { return supplier; }
            set { supplier = value; RaisePropertyChanged(); }
        }

        private product product;
        /// <summary>
        ///  当前选中的商品
        /// </summary>
        public product Product
        {
            get { return product; }
            set { product = value; RaisePropertyChanged(); }
        }

        private BitmapImage imageSource;
        /// <summary>
        ///  当前商品图片
        /// </summary>
        public BitmapImage ImageSource
        {
            get { return imageSource; }
            set { imageSource = value; RaisePropertyChanged(); }
        }


        public RelayCommand<Window> LoadedCommand
        {
            get
            {
                return new RelayCommand<Window>((view) =>
                {
                    Product = new product();
                    SupplierList = supplierProvider.GetAll();
                    ImageSource = null;
                    Supplier = null;
                });
            }
        }

        public RelayCommand<Window> OkCommand
        {
            get
            {
                return new RelayCommand<Window>((view) =>
                {
                    if (string.IsNullOrEmpty(Product.Name))
                    {
                        MessageBox.Show("商品名不能为空!");
                        return;
                    }

                    if (Supplier == null)
                    {
                        MessageBox.Show("请选择供应商!");
                        return;
                    }

                    Product.SupplierId = Supplier.Id;
                    Product.InsertDate = DateTime.Now;
                    int count = productProvider.Insert(Product);
                    if (count > 0)
                    {
                        MessageBox.Show("操作成功!");
                    }
                    view.DialogResult = true;
                    view.Close();
                });
            }
        }

        /// <summary>
        /// 选择图片
        /// </summary>
        public RelayCommand<Window> SelectImageCommand
        {
            get
            {
                return new RelayCommand<Window>((view) =>
                {
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    //打开的文件选择对话框上的标题
                    openFileDialog.Title = "请选择文件";
                    //设置文件类型
                    openFileDialog.Filter = "图片文件(*.jpg)|*.jpg|所有文件(*.*)|*.*";
                    //设置默认文件类型显示顺序
                    openFileDialog.FilterIndex = 1;
                    //保存对话框是否记忆上次打开的目录
                    openFileDialog.RestoreDirectory = true;
                    //设置是否允许多选
                    openFileDialog.Multiselect = false;
                    //按下确定选择的按钮
                    if (openFileDialog.ShowDialog().Value == true)
                    {
                        //获得文件路径
                        string fileName = openFileDialog.FileName;
                        ImageSource = new BitmapImage(new Uri(fileName));

                        Product.Image = ImageHelper.GetImageString(fileName);
                    }
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

