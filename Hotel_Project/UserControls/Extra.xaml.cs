using Hotel_Project;
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
    /// Interaction logic for Extra.xaml
    /// </summary>
    public partial class Extra : UserControl
    {

        hotelEntities ht = new hotelEntities();

        public Extra()
        {
            InitializeComponent();
        }

        private void Extra_Loaded(object sender, RoutedEventArgs e)
        {
            var erg = ht.extra;
            erg.Load();
            liextra.ItemsSource = erg.Local.OrderBy(l => l.Extra_Name);
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int i = ht.SaveChanges();
                fehler.Text = i + " row(s) affected";
            }
            catch (Exception e1)
            {
                fehler.Text = e1.Message; //zeige alle inner Exception
                for (var ex = e1.InnerException; ex != null; ex = ex.InnerException)
                {
                    fehler.Text = fehler.Text + " / " + ex.Message;
                }

            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            extra ex = (extra)liextra.SelectedItem;
            if (ex != null)
            {
                ht.extra.Remove(ex);
                liextra.Items.Refresh();

                Save_Click(sender, null);
            }
        }

        private void New_Click(object sender, RoutedEventArgs e)
        {
            //booking b = (booking)libooking.SelectedItem;
            //customer c = new customer();
            //b.Booking_ID += 1;
            //c.Customer_Name = "New";
            //ht.booking.Add(b);
            //ht.customer.Add(c);
            //libooking.Items.Refresh();
        }
    }
}
