﻿using System;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Reservation_Click(object sender, RoutedEventArgs e)
        {
            contentct1.Children.Clear();
            contentct1.Children.Add(new Reservation());
        }

        private void Customer_Click(object sender, RoutedEventArgs e)
        {
            contentct1.Children.Clear();
            contentct1.Children.Add(new Customer());
        }

        private void Booking_Click(object sender, RoutedEventArgs e)
        {
            contentct1.Children.Clear();
            contentct1.Children.Add(new Booking());
        }

        private void Room_Click(object sender, RoutedEventArgs e)
        {
            contentct1.Children.Clear();
            var nc = new Room();
            contentct1.Children.Add(nc);
        }

        private void Employee_Click(object sender, RoutedEventArgs e)
        {
            contentct1.Children.Clear();
            var nc = new Employee();
            contentct1.Children.Add(new Employee());
        }

        private void Service_Click(object sender, RoutedEventArgs e)
        {
            contentct1.Children.Clear();
            var nc = new Service();
            contentct1.Children.Add(nc);
        }

        private void Extra_Click(object sender, RoutedEventArgs e)
        {
            contentct1.Children.Clear();
            var nx = new Extra();
            contentct1.Children.Add(nx);
        }

        private void Security_Click(object sender, RoutedEventArgs e)
        {
            contentct1.Children.Clear();
            var nc = new SecurityCam();
            contentct1.Children.Add(nc);
        }

    }
}
