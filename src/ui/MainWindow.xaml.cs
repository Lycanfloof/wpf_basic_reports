using Microsoft.Win32;
using System;
using System.Windows;
using wpf_basic_reports.src.model;

namespace wpf_basic_reports.src.ui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TownDisplay townDisplay;
        public MainWindow()
        {
            townDisplay = new TownDisplay();
            InitializeComponent();
        }

        private void OpenButtonClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new();
            if (openFileDialog.ShowDialog() == true)
            {
                townDisplay.ReadData(openFileDialog.FileName);
                TableButtonClick(sender, e);
            }
        }

        private void TableButtonClick(object sender, RoutedEventArgs e)
        {
            MenuFrame.Source = new Uri("/src/ui/TableView.xaml", UriKind.RelativeOrAbsolute);
        }

        private void ChartButtonClick(object sender, RoutedEventArgs e)
        {
            MenuFrame.Source = new Uri("/src/ui/ChartView.xaml", UriKind.RelativeOrAbsolute);
        }
    }
}
