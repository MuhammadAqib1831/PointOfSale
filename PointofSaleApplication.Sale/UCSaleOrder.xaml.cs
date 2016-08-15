using PointofSaleApplication.Data;
using PointofSaleApplication.Model;
using PointofSaleApplication.Sale.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PointofSaleApplication.Sale
{
    /// <summary>
    /// Interaction logic for SalesFormm.xaml
    /// </summary>
    public partial class UCSaleOrder : UserControl
    {
        MainWindow mw = null;
        OrderMasterViewModel Order = null;
        List<OrderDetailViewModel> OrderLines = null;
        public UCSaleOrder(MainWindow mw)
        {
            InitializeComponent();
            this.mw = mw;
            NewOrder();
        }

        private void NewOrder()
        {
            Order = new OrderMasterViewModel { Id=Guid.NewGuid(),CreatiomTime=DateTime.Now };
            OrderLines = new List<OrderDetailViewModel>();
            dgSale.ItemsSource = OrderLines;
            dgSale.Items.Refresh();
        }
        private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            //Thread thread = new Thread(new ThreadStart(getProductName));
            //thread.Start();
            getProductName();
        }
        private void getProductName() 
        {
            Repository b = new Repository();
            var products = b.GetProducts();
  
 
           
            comboProduct.ItemsSource = products;
          //  comboProduct.DisplayMemberPath = "Name";
          //  comboProduct.SelectedValuePath = "Id";
            if(comboProduct.Items.Count>0){
                comboProduct.SelectedIndex = 0;


            }
        }
        Product selectedProduct = null;
        private void comboProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedProduct = comboProduct.SelectedItem as Product;
            if (selectedProduct != null)
            {
                txtSalePrice.Text = selectedProduct.UnitPrice.ToString();
            }
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            if (selectedProduct != null)
            {
                OrderDetailViewModel order = new OrderDetailViewModel();
                order.Porduct = selectedProduct;
                order.ItemId = selectedProduct.Id;
                order.ItemName = selectedProduct.Name;
                order.UnitPrice = Convert.ToDecimal(txtSalePrice.Text);
                order.Quantity = Convert.ToInt32(txtQuantity.Text);

                OrderLines.Add(order);
                dgSale.ItemsSource = OrderLines;
                dgSale.Items.Refresh();
                selectedProduct = null;
            }
           
        }
        private void addRecord(OrderDetailViewModel model) 
        { 
           
        }

        private void btnSaveOrder_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var orderMater = Order.GetFrom();
                var listDetail = new List<OrderDetail>();
                foreach(var detail in OrderLines)
                {
                    detail.Id = Guid.NewGuid();
                    detail.OrderId = orderMater.Id;
                    detail.OrderMaster = orderMater;
                    listDetail.Add(detail.GetFrom());
                }
                orderMater.orderdetail = listDetail;
                orderMater.CreatiomTime = DateTime.Now;
                orderMater.TotalSum = OrderLines.Sum(s => s.GrossTotal);
                Repository repo = new Repository();
                repo.AddOrder(orderMater);
                MessageBox.Show("Order saved successfully", "POS", MessageBoxButton.OK, MessageBoxImage.Information);
                NewOrder();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

     
        
    }
    
}
