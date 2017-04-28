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
        hotelEntities hotel = new hotelEntities();

        public Reservation()
        {
            InitializeComponent();
        }

        private void Reservation_Loaded(object sender, RoutedEventArgs e)
        {
               
            lireservation.ItemsSource = hotel.reservation.ToList();
            
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
