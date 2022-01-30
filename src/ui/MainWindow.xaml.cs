using Microsoft.Win32;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls.DataVisualization.Charting.Compatible;
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
            }
        }

        private void TableButtonClick(object sender, RoutedEventArgs e)
        {
            //Implement Hide/Visualize Table
        }

        private void ChartButtonClick(object sender, RoutedEventArgs e)
        {
            //Implement Hide/Visualize Chart
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
            }
        }

        public void loadBarChartData() 
        {
            ((BarSeries)TownChart.Series[0]).ItemsSource =
                new KeyValuePair<string, int>[] {
                    new KeyValuePair<string, int>("Hola", 10) 
                };
        }
    }
}
