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
            var erg = hotel.customer;
            erg.Load();
            //lireservation.ItemsSource = ht.reservation.ToList();

            licustomer.ItemsSource = erg.Local.OrderBy(l => l.Customer_ID);

            //var erg = hotel.customer;
            //try
            //{
            //    erg.Load();
            //}
            //catch (Exception e1)
            //{
            //    fehler.Text = e1.Message;
            //}

        }


        private void New_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Random rd = new Random();
                customer c = new customer();
                int ranVal = rd.Next(0, 100000);
                if (c.Customer_ID != ranVal)
                {
                    c.Customer_ID = ranVal;
                }

                hotel.customer.Add(c);
                Customer_Loaded(sender, e);
                licustomer.Items.Refresh();

                Save_Click(sender, e);

                //customer c = new customer();
                //s.Employee_Name = "NEW_EMPLOYEE";
                //hotel.employee.Add(s);
                //UserControl_Loaded(sender, e);
                //employee.Items.Refresh();
            }
            catch (Exception e1)
            {
                fehler.Text = e1.Message;
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            fehler.Text = "";
            try
            {
                int anzzeilen = hotel.SaveChanges();
                fehler.Text = anzzeilen + " row(s) affected";
            }
            catch (Exception e1)
            {
                fehler.Text = e1.Message;   // zeige alle Inner Exceptins
                for (var ex = e1.InnerException; ex != null; ex = ex.InnerException)
                    fehler.Text = fehler.Text + " / " + ex.Message;
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (licustomer.SelectedItem != null)
                {
                    var sl = (customer)licustomer.SelectedItem;

                    hotel.customer.Remove(sl);

                    licustomer.Items.Refresh();
                    Customer_Loaded(sender, e);
                }
            }
            catch (Exception e1)
            {

                fehler.Text = e1.Message;
            }
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
