using Microsoft.Win32;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls.DataVisualization.Charting;
using wpf_basic_reports.src.model;

namespace wpf_basic_reports.src.ui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly TownDisplay townDisplay;
        private List<Town> FilteredList { get; set; }
        public MainWindow()
        {
            townDisplay = new TownDisplay();
            FilteredList = new List<Town>();
            InitializeComponent();
        }
        private void OpenButtonClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new();
            if (openFileDialog.ShowDialog() == true)
            {
                townDisplay.ReadData(openFileDialog.FileName);
                TownGrid.ItemsSource = townDisplay.Towns;
                TownGrid.Items.Refresh();
                SelectBox.Items.Add("");
                SelectBox.SelectedIndex = 0;
                for (int i = 0; i < townDisplay.Towns.Count; i++)
                {
                    if (!SelectBox.Items.Contains(townDisplay.Towns[i].DepartmentName))
                    {
                        SelectBox.Items.Add(townDisplay.Towns[i].DepartmentName);
                    }
                }
                TableButtonClick(sender, e);
                LoadBarChartData();
            }
        }
        private void TableButtonClick(object sender, RoutedEventArgs e)
        {
            TownChart.Visibility = Visibility.Hidden;
            SelectBox.Visibility = Visibility.Visible;
            TownGrid.Visibility = Visibility.Visible;
            ScrollBar.Visibility = Visibility.Visible;
        }
        private void ChartButtonClick(object sender, RoutedEventArgs e)
        {
            TownChart.Visibility = Visibility.Visible;
            SelectBox.Visibility = Visibility.Hidden;
            TownGrid.Visibility = Visibility.Hidden;
            ScrollBar.Visibility = Visibility.Hidden;
        }
        private void ComboBoxSelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if ((string)SelectBox.SelectedItem != "")
            {
                FilteredList.Clear();
                for (int i = 0; i < townDisplay.Towns.Count; i++)
                {
                    if (townDisplay.Towns[i].DepartmentName.Equals(SelectBox.SelectedItem))
                    {
                        FilteredList.Add(townDisplay.Towns[i]);
                    }
                }
                TownGrid.ItemsSource = FilteredList;
                TownGrid.Items.Refresh();
            }
            else
            {
                TownGrid.ItemsSource = townDisplay.Towns;
                TownGrid.Items.Refresh();
            }
        }
        public void LoadBarChartData() 
        {
            int area = 0;
            int town = 0;
            int island = 0;
            for (int i  = 0; i < townDisplay.Towns.Count; i++) 
            {
                switch (townDisplay.Towns[i].TownType) 
                {
                    case "Municipio":
                        town++;
                        break;
                    case "Isla":
                        island++;
                        break;
                    case "Área no municipalizada":
                        area++;
                        break;
                }
            }
            ((BarSeries)TownChart.Series[0]).ItemsSource =
                new KeyValuePair<string, int>[] {
                    new KeyValuePair<string, int>("Town (" + town + ") ", town) ,
                    new KeyValuePair<string, int>("Island (" + island + ") ", island) ,
                    new KeyValuePair<string, int>("Non-municipalized area (" + area + ") ", area)
                };
        }
    }
}
