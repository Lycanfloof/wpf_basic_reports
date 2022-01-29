using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using wpf_basic_reports.Model;
using wpf_basic_reports.UI;

namespace wpf_basic_reports
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

        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new();
            if (openFileDialog.ShowDialog() == true)
            {
                townDisplay.ReadData(openFileDialog.FileName);
                TableButton_Click(sender, e);
            }
        }

        private void TableButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
