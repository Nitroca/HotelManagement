using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hotel_Project
{
    /// <summary>
    /// Interaction logic for Customer.xaml
    /// </summary>
    public partial class Customer : UserControl
    {
        hotelEntities hotel = new hotelEntities();

        public Customer()
        {
            InitializeComponent();
        }

        private void Customer_Loaded(object sender, RoutedEventArgs e)
        {



            //var erg = hotel.customer;
            //erg.Load();
            //sg1.ItemsSource = erg.Local;

            var erg = hotel.customer;
            try
            {
                erg.Load();
            }
            catch (Exception e1)
            {
                fehler.Text = e1.Message;
            }
            //customer.ItemsSource = erg.Local.OrderBy(l => l.Customer_Name);
        }







        //datagrid

        //private void save1_Click_1(object sender, RoutedEventArgs e)
        //{
        //    // speichere Veränderungen im DatGrid in die Datenbank
        //    try
        //    {
        //        var anz = hotel.SaveChanges();
        //        fehler.Text = String.Format("{0} row(s) affected", anz);
        //    }
        //    catch (Exception e1)
        //    {

        //        fehler.Text = e1.Message + " " +
        //            (e1.InnerException != null ? e1.InnerException.Message : "") + " " +
        //            (e1.InnerException != null && e1.InnerException.InnerException != null ? e1.InnerException.InnerException.Message : "");
        //    }
        //}


        //private void sg1_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        //{
        //    // jedes Mal, wenn eine Spalte im DataGrid autogneriert wird
        //    if (!e.PropertyName.Contains("_"))   // Navigational Properties nicht anzeigen  (haben kein _ im Namen
        //        e.Cancel = true;
        //    e.Column.Header = e.PropertyName.Substring(0);
        //}


    }
}
