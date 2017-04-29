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
    /// Interaction logic for Employee.xaml
    /// </summary>
    public partial class Employee : UserControl
    {
        hotelEntities hotel = new hotelEntities();

        public Employee()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var erg = hotel.employee;
            try
            {
                erg.Load();
            }catch(Exception e1)
            {
                submitfehler.Text = e1.Message;
            }
            employee.ItemsSource = erg.Local.OrderBy(l => l.Employee_Name);
           
        }
    }
}
