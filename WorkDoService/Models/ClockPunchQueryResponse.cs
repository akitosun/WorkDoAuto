using System.Collections.Generic;

namespace WorkDoService.Models
{
    public class ClockPunchQueryResponse
    {
        public List<ClockPunchRecord> list { get; set; }
    }

    public class ClockPunchRecord
    {
        public Dictionary<string, object> fileInfoMap { get; set; }
        public List<object> fileInfoList { get; set; }
        public ClockPunchButtonDisplayMap btnDisplayMap { get; set; }
        public Dictionary<string, object> customAttrMap { get; set; }
        public long reqOid { get; set; }
        public long depOid { get; set; }
        public long empOid { get; set; }
        public string type { get; set; }
        public string punchDay { get; set; }
        public string punchTime { get; set; }
        public string place { get; set; }
        public string flowState { get; set; }
        public string result { get; set; }
        public string personalSummaryKey { get; set; }
        public string groupSummaryKey { get; set; }
        public string punchPoint { get; set; }
        public string reqOidEnc { get; set; }
        public string appId { get; set; }
        public string dbkeyString { get; set; }
        public string displayName { get; set; }
        public string reqPunchTime { get; set; }
        public string reqPlace { get; set; }
        public string reqWifiPoint { get; set; }
        public string reqWifiMac { get; set; }
        public string reqGpsPlace { get; set; }
        public ClockPunchLocation reqGpsLocation { get; set; }
        public string reqFaceDeviceName { get; set; }
        public string reqFaceDeviceOid { get; set; }
    }

    public class ClockPunchButtonDisplayMap
    {
        public bool view { get; set; }
    }

    public class ClockPunchLocation
    {
        public string text { get; set; }
        public string value { get; set; }
        public float? x { get; set; }
        public float? y { get; set; }
    }
}
