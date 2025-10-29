using System.Collections.Generic;

namespace WorkDoService.Models
{
    public class ClockPunchQueryResponse
    {
        public List<ClockPunchRecord> list { get; set; }
    }

    public class ClockPunchRecord
    {
        public string type { get; set; }
        public string result { get; set; }
        public string punchDay { get; set; }
        public string punchTime { get; set; }
    }
}
