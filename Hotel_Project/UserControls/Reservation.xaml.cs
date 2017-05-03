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
            //lireservation.ItemsSource = ht.reservation.ToList();
            var erg = ht.reservation;
            erg.Load();
            lireservation.ItemsSource = erg.Local.OrderBy(l => l.Booking_ID);
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
            if(lireservation.SelectedItem != null)
            {       
                var n = (reservation)lireservation.SelectedItem;
                ht.reservation.Remove(n);
                lireservation.Items.Refresh();
                Reservation_Loaded(sender, e);
            }

            Save_Click(sender, e);

            
        }

        private void New_Click(object sender, RoutedEventArgs e)
        {
            
            Random rd = new Random();
            reservation r = new reservation();
            int ranVal = rd.Next(0, 100000);
            if (r.reservation_ID != ranVal)
            {
                r.reservation_ID = ranVal;
            }

            ht.reservation.Add(r);
            Reservation_Loaded(sender, e);
            lireservation.Items.Refresh();

            Save_Click(sender, e);

        }

        
    }
}
