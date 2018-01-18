using Dashboard.WPF.Model;
using De.TorstenMandelkow.MetroChart;
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
using System.Xml;
using System.Xml.Serialization;

namespace Dashboard.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _currentDataFileName;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var fileOpenDialog = new System.Windows.Forms.OpenFileDialog();
            fileOpenDialog.Filter = "CSV (*.csv)|*.csv";

            if (fileOpenDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _currentDataFileName = fileOpenDialog.FileName;

                DisplayData();
            } 
        }

        private void DisplayData()
        {
            var dataSeries = ParseData(_currentDataFileName);

            var series = new ChartSeries
            {
                SeriesTitle = dataSeries.SeriesDisplayName,
                DisplayMember = "Column0",
                ValueMember = "Column1",
            };

            
            dataSeries.Items.ToList().ForEach(_ => series.Items.Add(_));

            this.stackCharts.Children.Add(CreateChart(series,  dataSeries.SeriesDisplayName, dataSeries.SubTitle));            
        }

        private UIElement CreateChart(ChartSeries chartSeries, string header, string subHeader)
        {
            ClusteredColumnChart ccc = new ClusteredColumnChart();

            ccc.ChartTitle = header;
            ccc.ChartSubTitle = subHeader;

            ccc.Series.Clear();
            ccc.Series.Add(chartSeries);
            ccc.Visibility = System.Windows.Visibility.Visible;

            return ccc;
        }


        private static SeriesData ParseData(string currentDataFileName)
        {
            var result = new SeriesData
            {
                SeriesDisplayName = System.IO.Path.GetFileNameWithoutExtension(currentDataFileName),
                SubTitle = System.IO.Path.GetDirectoryName(currentDataFileName),
                Items = new System.Collections.ObjectModel.ObservableCollection<ChartData>(),                
            };

            foreach (var line in File.ReadAllLines(currentDataFileName))
	        {
                var columns = line.Split(';');

                if (columns.Length > 2)
	            {
                    throw new Exception("only two columns are supported");
	            }

                result.Items.Add(new ChartData
                {
                    Column0 = columns.ElementAt(0),
                    Column1 = columns.ElementAt(1),
                });
	        }

            return result;
        }

        private void aboutButton_Click(object sender, RoutedEventArgs e)
        {
            AboutWindow aboutWindow = new AboutWindow();
            aboutWindow.ShowDialog();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            PersistedData dataToBePersisted = new PersistedData();
            if (this.stackCharts.Children.Count > 1)
            {
                for (int i = this.stackCharts.Children.Count - 1; i > 0; i--)
                {
                    var clusteredColumnChartSeriesData = ((ClusteredColumnChart)this.stackCharts.Children[i]).Series;
                    SeriesData seriesData = new SeriesData();

                    dataToBePersisted.Series.Add(seriesData);
                    seriesData.SeriesDisplayName = ((ClusteredColumnChart)this.stackCharts.Children[i]).ChartTitle;
                    seriesData.SubTitle = ((ClusteredColumnChart)this.stackCharts.Children[i]).ChartSubTitle;


                    foreach (var x in clusteredColumnChartSeriesData[0].Items)
                    {
                        seriesData.Items.Add((ChartData)x);
                    }

                }
            }

            StreamWriter streanWriter = new StreamWriter("SavedData.xml");
            XmlSerializer serializer = new XmlSerializer(typeof(PersistedData));
            serializer.Serialize(streanWriter, dataToBePersisted);
            streanWriter.Flush();
            streanWriter.Close();
       
        }

        private void loadButton_Click(object sender, RoutedEventArgs e)
        {
            this._currentDataFileName = "SavedData.xml";
            StreamReader streamReader = new StreamReader("SavedData.xml");
            XmlSerializer serializer = new XmlSerializer(typeof(PersistedData));
            var x = (PersistedData) serializer.Deserialize(streamReader);

            foreach (var seriesData in x.Series)
            {
                var series = new ChartSeries
                {
                    SeriesTitle = this._currentDataFileName, 
                    DisplayMember = "Column0",
                    ValueMember = "Column1",
                };

                seriesData.Items.ToList().ForEach(_ => series.Items.Add(_));

                
 
                this.stackCharts.Children.Add(CreateChart(series, seriesData.SeriesDisplayName, seriesData.SubTitle));          

            }
            
                



        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            //Made it extra ugly! - tw
            if (this.stackCharts.Children.Count > 1)
            {
                for (int i = this.stackCharts.Children.Count -1; i > 0; i-- )
                {
                    this.stackCharts.Children.RemoveAt(i);
                }
            }            
        }
    }
}
