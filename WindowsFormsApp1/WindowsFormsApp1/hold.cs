using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class hold : holdBase, ITrackAbnormal
    {
        public string TrackTrigger(string wipID)
        {
            return $"根据wipID触发Hold，更新wiplot表和wiplothis表{wipID}";
        }
    }
}
