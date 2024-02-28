using SupermarketManagementSystem.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketManagementSystem.Model
{
    /// <summary>
    /// 抽象类
    /// </summary>
    public abstract class ProviderBase
    {
        public shoppingdbEntities db = new shoppingdbEntities();
    }
}
