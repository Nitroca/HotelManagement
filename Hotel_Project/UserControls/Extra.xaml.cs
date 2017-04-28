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
    /// Interaction logic for Extra.xaml
    /// </summary>
    public partial class Extra : UserControl
    {

        hotelEntities db = new hotelEntities();

        public Extra()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var erg = db.extra;
            
        }
    }
}
