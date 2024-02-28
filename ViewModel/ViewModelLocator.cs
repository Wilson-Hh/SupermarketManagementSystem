/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:SupermarketManagementSystem"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;

namespace SupermarketManagementSystem.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);   


            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<LoginViewModel>();
            SimpleIoc.Default.Register<IndexViewModel>();
            SimpleIoc.Default.Register<OrderViewModel>();
            SimpleIoc.Default.Register<ProductViewModel>();
            SimpleIoc.Default.Register<CustomerViweModel>();
            SimpleIoc.Default.Register<InstorageViewModel>();
            SimpleIoc.Default.Register<OrderDetailViewModel>();
            SimpleIoc.Default.Register<OutStorageViewModel>();
            SimpleIoc.Default.Register<SettingViewModel>();
            SimpleIoc.Default.Register<SupplierViewModel>();
            SimpleIoc.Default.Register<MemberViewModel>();
            SimpleIoc.Default.Register<AddCustomerViewModel>();
            SimpleIoc.Default.Register<AddSupplierViewModel>();
            SimpleIoc.Default.Register<EditCustomerViewModel>();
            SimpleIoc.Default.Register<EditSupplierViewModel>();
            SimpleIoc.Default.Register<AddMemberViewModel>();
            SimpleIoc.Default.Register<AddMemberViewModel>();
            SimpleIoc.Default.Register<EditMemberViewModel>();
            SimpleIoc.Default.Register<AddProductViewModel>();
            SimpleIoc.Default.Register<EditProductViewModel>();
            SimpleIoc.Default.Register<CustomerWindowViewModel>();
        }

        /// <summary>
        /// main��һ�����ԣ�Main��������MainViewModel
        /// </summary>
        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();
        /// <summary>
        /// ��¼��������֮ViewModel
        /// </summary>
        public LoginViewModel LoginViewModel => ServiceLocator.Current.GetInstance<LoginViewModel>();

        public IndexViewModel IndexViewModel => ServiceLocator.Current.GetInstance<IndexViewModel>();
        public OrderViewModel OrderViewModel => ServiceLocator.Current.GetInstance<OrderViewModel>();
        public CustomerViweModel CustomerViweModel => ServiceLocator.Current.GetInstance<CustomerViweModel>();
        public ProductViewModel ProductViewModel => ServiceLocator.Current.GetInstance<ProductViewModel>();
        public InstorageViewModel InstorageViewModel => ServiceLocator.Current.GetInstance<InstorageViewModel>();
        public OrderDetailViewModel OrderDetailViewModel => ServiceLocator.Current.GetInstance<OrderDetailViewModel>();
        public OutStorageViewModel OutStorageViewModel => ServiceLocator.Current.GetInstance<OutStorageViewModel>();
        public SettingViewModel SettingViewModel => ServiceLocator.Current.GetInstance<SettingViewModel>();
        public SupplierViewModel SupplierViewModel => ServiceLocator.Current.GetInstance<SupplierViewModel>();
        public MemberViewModel MemberViewModel => ServiceLocator.Current.GetInstance<MemberViewModel>();
        public AddCustomerViewModel AddCustomerViewModel => ServiceLocator.Current.GetInstance<AddCustomerViewModel>();
        public EditCustomerViewModel EditCustomerViewModel => ServiceLocator.Current.GetInstance<EditCustomerViewModel>();
        public AddSupplierViewModel AddSupplierViewModel => ServiceLocator.Current.GetInstance<AddSupplierViewModel>();
        public EditSupplierViewModel EditSupplierViewModel => ServiceLocator.Current.GetInstance<EditSupplierViewModel>();
        public AddMemberViewModel AddMemberViewModel => ServiceLocator.Current.GetInstance<AddMemberViewModel>();
        public EditMemberViewModel EditMemberViewModel => ServiceLocator.Current.GetInstance<EditMemberViewModel>();
        public AddProductViewModel AddProductViewModel => ServiceLocator.Current.GetInstance<AddProductViewModel>();
        public EditProductViewModel EditProductViewModel => ServiceLocator.Current.GetInstance<EditProductViewModel>();
        public CustomerWindowViewModel CustomerWindowViewModel => ServiceLocator.Current.GetInstance<CustomerWindowViewModel>();

        public static void Cleanup()
        {
            // TODO Clear the ViewModels 
            // TODO Clear the ViewModels
        }
    }
}