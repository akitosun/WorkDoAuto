namespace WorkDoService.Models
{

    public class PunchResponse
    {
        public Fileinfomap fileInfoMap { get; set; }
        public Btndisplaymap btnDisplayMap { get; set; }
        public object[] fileInfoList { get; set; }
        public int reqOid { get; set; }
        public int depOid { get; set; }
        public int empOid { get; set; }
        public string type { get; set; }
        public string source { get; set; }
        public string place { get; set; }
        public string gpsPlace { get; set; }
        public Gpslocation gpsLocation { get; set; }
        public string punchTime { get; set; }
        public string punchDay { get; set; }
        public string result { get; set; }
        public string personalSummaryKey { get; set; }
        public string groupSummaryKey { get; set; }
        public Departmentebo departmentEbo { get; set; }
        public Employeeebo employeeEbo { get; set; }
        public string reqOidEnc { get; set; }
        public string appId { get; set; }
        public string displayName { get; set; }
    }

    public class Fileinfomap
    {
    }

    public class Btndisplaymap
    {
    }

    public class Gpslocation
    {
        public string text { get; set; }
        public string value { get; set; }
        public float x { get; set; }
        public float y { get; set; }
    }

    public class Departmentebo
    {
        public Btndisplaymap1 btnDisplayMap { get; set; }
        public string displayName { get; set; }
    }

    public class Btndisplaymap1
    {
    }

    public class Employeeebo
    {
        public Btndisplaymap2 btnDisplayMap { get; set; }
        public string displayName { get; set; }
    }

    public class Btndisplaymap2
    {
    }

}
