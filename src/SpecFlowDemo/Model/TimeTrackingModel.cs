using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowDemo.Model
{
   public class TimeTrackingModel
    {
        public string Activity { get; set; }
        public string TimeSpent { get; set; }
        public string Category { get; set; }
        public string SubProject { get; set; }
        public string RecordType { get; set; }
        public bool Billable { get; set; }

        public TimeTrackingModel() { }
    }
}
