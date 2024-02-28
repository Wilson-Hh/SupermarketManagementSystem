﻿using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketManagementSystem.ViewModel
{
    public class ViewModelBase2: ViewModelBase
    {
        /// <summary>
        /// 只读属性 -> 当前用户
        /// </summary>
        public AppData AppData => AppData.Instance;

    }
}
