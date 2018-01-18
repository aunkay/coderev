using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.WPF.Model
{
    public class PersistedData
    {
        public List<SeriesData> Series { get; set; }

        public PersistedData()
        {
            Series = new List<SeriesData>();
        }
    }
}
