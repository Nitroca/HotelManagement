using Hotel_Project;
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
using System.Windows.Shapes;

namespace Hotel_Project
{
    /// <summary>
    /// Interaction logic for Reservation_Edit.xaml
    /// </summary>
    public partial class Reservation_Edit : Window
    {
        hotelEntities ht = new hotelEntities();

        public Reservation_Edit()
        {
            InitializeComponent();
        }

        private void ReservationEdit_Loaded(object sender, RoutedEventArgs e)
        {
            lireservation.ItemsSource = ht.reservation.ToList();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                int i = ht.SaveChanges();
                fehler.Text = i + " rows affected";
            }
            catch (Exception e1)
            {
                fehler.Text = e1.Message;
                for (var ex = e1.InnerException; ex != null; ex = ex.InnerException)
                {
                    fehler.Text = fehler.Text + " / " + ex.Message;
                }

            }
        }

    }
}
