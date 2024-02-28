using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SupermarketManagementSystem.ViewModel
{
    public class IndexViewModel:ViewModelBase2
    {
        #region

        public RelayCommand<UserControl> LoadedCommand
        {
            get
            {
                return new RelayCommand<UserControl>((view) =>
                {

                });
            }
        }

        #endregion
    }
}
