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
    /// Interaction logic for Room.xaml
    /// </summary>
    public partial class Room : UserControl
    {
        hotelEntities ht = new hotelEntities();
        public Room()
        {
            InitializeComponent();
        }

        private void Room_Loaded(object sender, RoutedEventArgs e)
        {
            var r = ht.room;
            var n = ht.category;

            r.Load();
            sg1.ItemsSource = r.Local;
            n.Load();
            sg2.ItemsSource = n.Local;
        }

        private void save1_Click_1(object sender, RoutedEventArgs e)
        {
            // speichere Veränderungen im DatGrid in die Datenbank
            try
            {
                var anz = ht.SaveChanges();
                fehler.Text = String.Format("{0} row(s) affected", anz);
            }
            catch (Exception e1)
            {

                fehler.Text = e1.Message + " " +
                    (e1.InnerException != null ? e1.InnerException.Message : "") + " " +
                    (e1.InnerException != null && e1.InnerException.InnerException != null ? e1.InnerException.InnerException.Message : "");
            }
        }


        private void sg1_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            // jedes Mal, wenn eine Spalte im DataGrid autogneriert wird
            if (!e.PropertyName.Contains("_"))   // Navigational Properties nicht anzeigen  (haben kein _ im Namen
                e.Cancel = true;
            e.Column.Header = e.PropertyName.Substring(0);
        }

        private void sg2_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            // jedes Mal, wenn eine Spalte im DataGrid autogneriert wird
            if (!e.PropertyName.Contains("_"))   // Navigational Properties nicht anzeigen  (haben kein _ im Namen
                e.Cancel = true;
            e.Column.Header = e.PropertyName.Substring(0);
        }
    }
}
