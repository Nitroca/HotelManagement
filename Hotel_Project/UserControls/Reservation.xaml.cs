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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hotel_Project
{
    /// <summary>
    /// Interaction logic for Reservation.xaml
    /// </summary>
    public partial class Reservation : UserControl
    {
        hotelEntities ht = new hotelEntities();

        public Reservation()
        {
            InitializeComponent();
        }

        private void Reservation_Loaded(object sender, RoutedEventArgs e)
        {
            lireservation.ItemsSource = ht.reservation.ToList();
            
        }


        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int i = ht.SaveChanges();
                fehler.Text = i + " rows affected";
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

            reservation r = (reservation)lireservation.SelectedItem;
            if(r != null)
            {
                ht.reservation.Remove(r);
                lireservation.Items.Refresh();

                Save_Click(sender, null);
            }

            
        }

    }
}
