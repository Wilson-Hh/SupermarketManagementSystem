using GalaSoft.MvvmLight.Command;
using SupermarketManagementSystem.Entity;
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
    public class OrderViewModel:ViewModelBase2
    {
        private List<product> productList = new List<product>();
        public List<product> ProductList
        {
            get { return productList; }
            set { productList = value; RaisePropertyChanged(); }
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


        //#region commands

        //public RelayCommand<UserControl> LoadedCommand
        //{
        //    get
        //    {
        //        return new RelayCommand<UserControl>((view) =>
        //        {
        //            ProductList = ProductProvider.Current.GetAll();

        //     //加载当前用户的购物车
        //     var tempOrder = OrderProvider.Current.GetAll().FirstOrDefault(t => t.CustomerId == AppData.CurrentCustomer.Id && t.OrderState == OrderState.未完成.ToString());
        //            if (tempOrder == null)
        //            {
        //                //创建新的购物车
        //                order order = new order();
        //                order.CustomerId = AppData.CurrentCustomer.Id;
        //                order.OrderDate = DateTime.Now;
        //                order.OrderState = OrderState.未完成.ToString();
        //                order.InsertDate = DateTime.Now;
        //                order.SN = Guid.NewGuid().ToString();
        //                var count = OrderProvider.Current.Insert(order);
        //                if (count > 0)
        //                {
        //                    AppData.CurrentOrder = order;
        //                }
        //            }
        //            else
        //            {
        //                AppData.CurrentOrder = tempOrder;


        //         //查询当前购物车的订单详情
        //         var list = OrderDetailProvider.Current.GetAll().Where(t => t.OrderId == tempOrder.Id).ToList();
        //                AppData.CurrentOrder.Children.Clear();
        //                list.ForEach(t => AppData.CurrentOrder.Children.Add(t));
        //            }

        //        });
        //    }
        //}

        ///// <summary>
        ///// 加入购物车
        ///// </summary>
        //public RelayCommand<product> OrderCommand
        //{
        //    get
        //    {
        //        return new RelayCommand<product>((product) =>
        //        {
        //            if (product.Quantity <= 0)
        //            {
        //                MessageBox.Show("已售罄");
        //                return;
        //            }
        //            var tempOrderDetail = AppData.CurrentOrder.Children.FirstOrDefault(t => t.OrderId == AppData.CurrentOrder.Id && t.ProductId == product.Id);
        //            int count = 0;
        //            if (tempOrderDetail == null)
        //            {
        //                OrderDetail orderDetail = new OrderDetail();
        //                orderDetail.OrderId = AppData.CurrentOrder.Id;
        //                orderDetail.ProductId = product.Id;
        //                orderDetail.InsertDate = DateTime.Now;
        //                orderDetail.Quantity = 1;
        //                orderDetail.Price = product.Price.Value;
        //                count = OrderDetailProvider.Current.Insert(orderDetail);
        //                AppData.CurrentOrder.Children.Add(orderDetail);
        //            }
        //            else
        //            {
        //                if (tempOrderDetail.Quantity + 1 > product.Quantity)
        //                {
        //                    MessageBox.Show("库存不足");
        //                    return;
        //                }


        //                tempOrderDetail.Quantity += 1;
        //                count = OrderDetailProvider.Current.Update(tempOrderDetail);
        //            }

        //            if (count > 0)
        //            {
        //                MessageBox.Show("加入购物车成功");
        //            }
        //        });
        //    }
        //}
        //#endregion
    }
}
