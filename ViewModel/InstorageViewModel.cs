using GalaSoft.MvvmLight.Command;
using SupermarketManagementSystem.Entity;
using SupermarketManagementSystem.Enums;
using SupermarketManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SupermarketManagementSystem.ViewModel
{
    public class InstorageViewModel : ViewModelBase2 
    { 
      private List<product> productList = new List<product>();
    public List<product> ProductList
    {
        get { return productList; }
        set { productList = value; RaisePropertyChanged(); }
    }

    private product product = null;
    /// <summary>
    ///  当前选中的商品
    /// </summary>
    public product Product
    {
        get { return product; }
        set { product = value; RaisePropertyChanged(); }
    }

    private stock stock;
    /// <summary>
    ///  当前入库记录实体
    /// </summary>
    public stock Stock
    {
        get { return stock; }
        set { stock = value; RaisePropertyChanged(); }
    }


    private List<stock> stockList = new List<stock>();
    /// <summary>
    /// 所有入库记录
    /// </summary>
    public List<stock> StockList
    {
        get { return stockList; }
        set { stockList = value; RaisePropertyChanged(); }
    }

    private stock currentStock;
    /// <summary>
    ///  当前选中的入库记录实体
    /// </summary>
    public stock CurrentStock
    {
        get { return currentStock; }
        set { currentStock = value; RaisePropertyChanged(); }
    }

    #region commands

    /// <summary>
    /// 加载所有商品
    /// </summary>
    public RelayCommand<UserControl> LoadedCommand
    {
        get
        {
            return new RelayCommand<UserControl>((view) =>
            {
                StockList = StockProvider.Current.GetAll().Where(t => t.Type == StockType.入库.ToString()).ToList();
                ProductList = ProductProvider.Current.GetAll();
                Product = null;
                Stock = new stock()
                {
                    Type = StockType.入库.ToString()
                };
                CurrentStock = null;
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
                if (Product == null)
                {
                    MessageBox.Show("请选择入库商品");
                    return;
                }
                if (Stock.Quantity <= 0)
                {
                    MessageBox.Show("入库数量应大于零");
                    return;
                }
                Stock.InsertDate = DateTime.Now;
                Stock.ProductId = Product.Id;
                int count = StockProvider.Current.Insert(Stock);
                if (count > 0)
                {
                  //增加库存
                  Product.Quantity += Stock.Quantity;
                    ProductProvider.Current.Update(Product);

                  //刷新界面
                  StockList = StockProvider.Current.GetAll();

                    MessageBox.Show("保存成功");
                    Stock = new stock() { Type = StockType.入库.ToString() };
                }
            });
        }
    }

    /// <summary>
    /// 删除入库记录
    /// </summary>
    public RelayCommand<UserControl> DeleteCommand
    {
        get
        {
            return new RelayCommand<UserControl>((view) =>
            {
                if (CurrentStock == null) return;
                int count = StockProvider.Current.Delete(CurrentStock);
                if (count > 0)
                {
                  //更新库存                        
                  var product = ProductProvider.Current.GetAll().FirstOrDefault(t => t.Id == CurrentStock.ProductId);
                    if (product != null)
                    {
                        product.Quantity -= CurrentStock.Quantity;
                        ProductProvider.Current.Update(product);
                    }
                  //刷新界面
                  MessageBox.Show("操作成功");
                    StockList = StockProvider.Current.GetAll().Where(t => t.Type == StockType.入库.ToString()).ToList();
                    CurrentStock = null;
                }
            });
        }
    }

    #endregion
}
}
