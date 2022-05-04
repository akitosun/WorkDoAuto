using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkDoService.Models
{
    public class PunchHistory
    {
        public string type { get; set; }        // ClockIn, ClockOut
        public string punchTime { get; set; }   // 2022-04-22 08:34:14+0800
    }
}
