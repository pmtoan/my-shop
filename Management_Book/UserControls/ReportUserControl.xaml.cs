﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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
using Management_Book.Model;
using LiveCharts;
using LiveCharts.Wpf;
using System.Diagnostics;

namespace Management_Book.UserControls
{
    /// <summary>
    /// Interaction logic for ReportUserControl.xaml
    /// </summary>
    public partial class ReportUserControl : UserControl
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["myDatabaseConnection"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);
        public SeriesCollection SeriesCollection { get; set; }
        public string[] CreateDate { get; set; }
        public Func<double, string> Formatter { get; set; }

        OrderModel.ViewModel _viewModel = new OrderModel.ViewModel();
        public ReportUserControl()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void SimpleButton_Click(object sender, RoutedEventArgs e)
        {

        }
        private void GridData_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
        }

        private void GridData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void GridData_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }
        private void filterPrice_Click(object sender, RoutedEventArgs e)
        {
            DataContext = null;
            DateTime dateFrom = (DateTime)DatePickerFrom.SelectedDate;
            dateFrom = dateFrom.Date.AddHours(0).AddMinutes(0).AddSeconds(0);
            DateTime dateTo = (DateTime)DatePickerTo.SelectedDate;
            dateTo = dateTo.Date.AddHours(23).AddMinutes(59).AddSeconds(59);

            Debug.WriteLine(dateFrom);
            Debug.WriteLine(dateTo);

            OrderEntities.getInstance().openConnection();

            _viewModel.Orders = OrderEntities.getInstance().getTotalProfitFilterByDate(dateFrom, dateTo);

            OrderEntities.getInstance().closeConnection();

            GridData.ItemsSource = _viewModel.Orders;

            List<double> Total = new List<double>();
            List<double> Profit = new List<double>();
            List<string> listDate = new List<string>(); 

            foreach (OrderModel.Purchase row in _viewModel.Orders)
            {
                Total.Add(row.Total);
                Profit.Add(row.Profit);
                listDate.Add(row.CreateDate.ToString().Substring(0,10));
            }

            SeriesCollection = new SeriesCollection() { };
            SeriesCollection.Add(new ColumnSeries
            {
                Title="Total",
                Values = new ChartValues<double> (Total)  
            });

            SeriesCollection.Add(new ColumnSeries
            {
                Title = "Profit",
                Values = new ChartValues<double>(Profit)
            });
            CreateDate = listDate.ToArray();
            Formatter = value => value.ToString("C");

            DataContext = this;
        }
    }
}
