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
    /// Interaction logic for Booking.xaml
    /// </summary>
    public partial class Booking : UserControl
    {
        hotelEntities hotel = new hotelEntities();

        public Booking()
        {
            InitializeComponent();
        }

        private void Booking_Loaded(object sender, RoutedEventArgs e)
        {
            libooking.ItemsSource = hotel.booking.ToList();
        }


        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int i = hotel.SaveChanges();
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
            booking b = (booking)libooking.SelectedItem;
            if (b != null)
            {
                hotel.booking.Remove(b);
                libooking.Items.Refresh();

                Save_Click(sender, null);
            }


        }

        private void New_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Random rd = new Random();
                booking b = new booking();

                int ranVal = rd.Next(0, 100000);
                if (b.Booking_ID != ranVal)
                {
                    b.Booking_ID = ranVal;
                }

                hotel.booking.Add(b);
                Booking_Loaded(sender, e);
                libooking.Items.Refresh();

                Save_Click(sender, e);

            }
            catch (Exception e1)
            {
                fehler.Text = e1.Message;
            }
        }

        
    }
}
