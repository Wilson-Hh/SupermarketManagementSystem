﻿using GalaSoft.MvvmLight;
using SupermarketManagementSystem.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace SupermarketManagementSystem.Model.Expand
{/// <summary>
 /// 扩展实体的基类
 /// </summary>
    public class BaseModel : ObservableObject
    {
        /// <summary>
        /// 用户等级BaseModel
        /// </summary>
        public List<string> Levels
        {

            get
            {

                List<string> levelTypes = new List<string>();
                var array = Enum.GetNames(typeof(LevelType));
                foreach (var type in array)
                {
                    levelTypes.Add(type.ToString());
                }
                return levelTypes;
            }
        }


        /// <summary>
        /// 商品单位
        /// </summary>
        public List<string> Units
        {
            get
            {
                List<string> levelTypes = new List<string>();
                var array = Enum.GetNames(typeof(UnitType));
                foreach (var type in array)
                {
                    levelTypes.Add(type.ToString());
                }
                return levelTypes;
            }
        }

        /// <summary>
        /// 商品类型
        /// </summary>
        public List<string> ProductTypes
        {
            get
            {
                List<string> levelTypes = new List<string>();
                var array = Enum.GetNames(typeof(ProductType));
                foreach (var type in array)
                {
                    levelTypes.Add(type.ToString());
                }
                return levelTypes;
            }
        }

    }
}
