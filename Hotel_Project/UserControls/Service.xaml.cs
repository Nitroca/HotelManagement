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
    /// Interaction logic for Service.xaml
    /// </summary>
    public partial class Service : UserControl
    {
        hotelEntities hotel = new hotelEntities();
        public Service()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var erg = hotel.service;
            try
            {
                erg.Load();
            }
            catch (Exception e1)
            {
                fehler.Text = e1.Message;
            }
            ServiceList.ItemsSource = erg.Local.OrderBy(l => l.Service_Name);

            //ServiceList.ItemsSource = hotel.service.ToList();
        }

        private void New_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                service s = new service();
                
                s.Service_Name = "NEW_SERVICE";
                hotel.service.Add(s);
                UserControl_Loaded(sender, e);
                ServiceList.Items.Refresh();
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
                fehler.Text = anzzeilen + " Zeilen geändert";
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
                if (ServiceList.SelectedItem != null)
                {
                    var sl = (service)ServiceList.SelectedItem;

                    hotel.service.Remove(sl);

                    ServiceList.Items.Refresh();
                    UserControl_Loaded(sender, e);
                }
            }
            catch (Exception e1)
            {

               fehler.Text = e1.Message;
            }
        }
    }
}
