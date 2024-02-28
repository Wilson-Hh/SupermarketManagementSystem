using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SupermarketManagementSystem.View
{
    /// <summary>
    /// Dialog.xaml 的交互逻辑
    /// </summary>
    public partial class Dialog : Window
    {
        public static Dialog Instance { get; private set; } = new Dialog();
        public static new bool Show()
        {
            Dialog dialog = new Dialog();
            var result = dialog.ShowDialog();
            return dialog.IsOk;
        }
        
        public bool IsOk = false;
        public Dialog()
        {
            InitializeComponent();
        }

        private void Button_ClickOK(object sender, RoutedEventArgs e)
        {
            IsOk = true;
            Close();
        }

        private void Button_ClickCancel(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void TextBlok_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Close();
        }
    }
}
