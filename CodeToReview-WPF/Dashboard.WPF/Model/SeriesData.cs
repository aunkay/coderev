using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.WPF.Model
{
    public class SeriesData
    {
        public string SeriesDisplayName { get; set; }

        public string SubTitle { get; set; }

        public ObservableCollection<ChartData> Items { get; set; }

        public SeriesData()
        {
            Items = new ObservableCollection<ChartData>();
        }
    }

   
}
