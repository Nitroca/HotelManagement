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

        hotelEntities hotel = new hotelEntities();

        public Extra()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var erg = hotel.extra;
            erg.Load();
            extraList.ItemsSource = erg.Local.OrderBy(l => l.Extra_Name);
        }
    }
}
