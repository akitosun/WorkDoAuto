using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkDoAuto.ResponseData
{
    

    public class LoginResponse
    {
        public Skywebinfo skyWebInfo { get; set; }
        public Bdduserdata bddUserData { get; set; }
        public string displayName { get; set; }
    }

    public class Skywebinfo
    {
        public bool devMode { get; set; }
        public int svcRid { get; set; }
        public int userOid { get; set; }
        public string loginId { get; set; }
        public string name { get; set; }
        public string dispUserNickname { get; set; }
        public string email { get; set; }
        public string sessionId { get; set; }
        public bool testUser { get; set; }
        public Servicelist[] serviceList { get; set; }
        public Allowedfunctions allowedFunctions { get; set; }
        public Awebroles awebRoles { get; set; }
        public Mwebroles mwebRoles { get; set; }
        public string locale { get; set; }
        public object[] tenantList { get; set; }
        public string loginType { get; set; }
        public string userLoginState { get; set; }
        public string firstSvcUrl { get; set; }
        public Menutree menuTree { get; set; }
        public string execMode { get; set; }
        public string country { get; set; }
        public bool feedbackSupport { get; set; }
        public Site site { get; set; }
        public bool multiSiteEnabled { get; set; }
        public string currentSiteId { get; set; }
        public string homeSiteUrl { get; set; }
        public string tenantSiteUrl { get; set; }
        public bool showOnlineHelp { get; set; }
        public object[] appServiceList { get; set; }
        public Platformservicelist[] platformServiceList { get; set; }
    }

    public class Allowedfunctions
    {
        public ABS210W ABS210W { get; set; }
        public ACC110W ACC110W { get; set; }
        public ACC120W ACC120W { get; set; }
        public ACC130W ACC130W { get; set; }
        public ACC140W ACC140W { get; set; }
        public ACC150W ACC150W { get; set; }
        public ACC160W ACC160W { get; set; }
        public ACC170W ACC170W { get; set; }
        public ACC180W ACC180W { get; set; }
        public ACC190W ACC190W { get; set; }
        public ACC200W ACC200W { get; set; }
        public ACC210W ACC210W { get; set; }
        public ACC220W ACC220W { get; set; }
        public ACC230W ACC230W { get; set; }
        public ACC240W ACC240W { get; set; }
        public ACC250W ACC250W { get; set; }
        public ACC260W ACC260W { get; set; }
        public ACC270W ACC270W { get; set; }
        public ACC280W ACC280W { get; set; }
        public ACC290W ACC290W { get; set; }
        public ACC300W ACC300W { get; set; }
        public ACC700M ACC700M { get; set; }
        public ACC712M ACC712M { get; set; }
        public ACC720M ACC720M { get; set; }
        public ACC721M ACC721M { get; set; }
        public ACC731M ACC731M { get; set; }
        public ACC750M ACC750M { get; set; }
        public ACC790M ACC790M { get; set; }
        public ACC800M ACC800M { get; set; }
        public ADB010W ADB010W { get; set; }
        public ADB110W ADB110W { get; set; }
        public BBI001I BBI001I { get; set; }
        public BDD100W BDD100W { get; set; }
        public BDD400M BDD400M { get; set; }
        public BDD500M BDD500M { get; set; }
        public BDD501M BDD501M { get; set; }
        public BDD502M BDD502M { get; set; }
        public BDD550M BDD550M { get; set; }
        public BDD570M BDD570M { get; set; }
        public BDD600M BDD600M { get; set; }
        public BDD605M BDD605M { get; set; }
        public BDD650M BDD650M { get; set; }
        public BDD700M BDD700M { get; set; }
        public BDD701M BDD701M { get; set; }
        public BDD702M BDD702M { get; set; }
        public BDD703M BDD703M { get; set; }
        public BDD704M BDD704M { get; set; }
        public BDD705M BDD705M { get; set; }
        public BDD706M BDD706M { get; set; }
        public BDD708M BDD708M { get; set; }
        public BDD709M BDD709M { get; set; }
        public BDD710M BDD710M { get; set; }
        public BDD711M BDD711M { get; set; }
        public BDD712M BDD712M { get; set; }
        public BDD713M BDD713M { get; set; }
        public BDD714M BDD714M { get; set; }
        public BDD715M BDD715M { get; set; }
        public BDD716M BDD716M { get; set; }
        public BDD717M BDD717M { get; set; }
        public BDD718M BDD718M { get; set; }
        public BDD719M BDD719M { get; set; }
        public BDD721M BDD721M { get; set; }
        public BDD722M BDD722M { get; set; }
        public BDD723M BDD723M { get; set; }
        public BDD724M BDD724M { get; set; }
        public BDD725M BDD725M { get; set; }
        public BDD726M BDD726M { get; set; }
        public BDD727M BDD727M { get; set; }
        public BDD728M BDD728M { get; set; }
        public BDD729M BDD729M { get; set; }
        public BDD730M BDD730M { get; set; }
        public BDD731M BDD731M { get; set; }
        public BDD732M BDD732M { get; set; }
        public BDD733M BDD733M { get; set; }
        public BDD734M BDD734M { get; set; }
        public BDD735M BDD735M { get; set; }
        public BDD736M BDD736M { get; set; }
        public BDD737M BDD737M { get; set; }
        public BDD738M BDD738M { get; set; }
        public BDD739M BDD739M { get; set; }
        public BDD740M BDD740M { get; set; }
        public BDD741M BDD741M { get; set; }
        public BDD742M BDD742M { get; set; }
        public BDD743M BDD743M { get; set; }
        public BDD744M BDD744M { get; set; }
        public BDD745M BDD745M { get; set; }
        public BDD746M BDD746M { get; set; }
        public BDD747M BDD747M { get; set; }
        public BDD748M BDD748M { get; set; }
        public BDD749M BDD749M { get; set; }
        public BDD750M BDD750M { get; set; }
        public BDD751M BDD751M { get; set; }
        public BDD752M BDD752M { get; set; }
        public BDD753M BDD753M { get; set; }
        public BDD754M BDD754M { get; set; }
        public BDD755M BDD755M { get; set; }
        public BDD756M BDD756M { get; set; }
        public BDD757M BDD757M { get; set; }
        public BDD758M BDD758M { get; set; }
        public BDD759M BDD759M { get; set; }
        public BDD760M BDD760M { get; set; }
        public BDD761M BDD761M { get; set; }
        public BDD762M BDD762M { get; set; }
        public BDD763M BDD763M { get; set; }
        public BDD764M BDD764M { get; set; }
        public BDD765M BDD765M { get; set; }
        public BDD766M BDD766M { get; set; }
        public BDD767M BDD767M { get; set; }
        public BDD770M BDD770M { get; set; }
        public BDD771M BDD771M { get; set; }
        public BDD772M BDD772M { get; set; }
        public BDD773M BDD773M { get; set; }
        public BDD775M BDD775M { get; set; }
        public BDD776M BDD776M { get; set; }
        public BDD778M BDD778M { get; set; }
        public BDD779M BDD779M { get; set; }
        public BDD780M BDD780M { get; set; }
        public BDD781M BDD781M { get; set; }
        public BDD782M BDD782M { get; set; }
        public BDD783M BDD783M { get; set; }
        public BDD790M BDD790M { get; set; }
        public BDD791M BDD791M { get; set; }
        public BDD800M BDD800M { get; set; }
        public BDD850M BDD850M { get; set; }
        public BDD851M BDD851M { get; set; }
        public BDD852M BDD852M { get; set; }
        public BDD853M BDD853M { get; set; }
        public BDD854M BDD854M { get; set; }
        public BDD855M BDD855M { get; set; }
        public BDD856M BDD856M { get; set; }
        public BDD857M BDD857M { get; set; }
        public BDD858M BDD858M { get; set; }
        public BDD863M BDD863M { get; set; }
        public BDD864M BDD864M { get; set; }
        public BDD865M BDD865M { get; set; }
        public BDD866M BDD866M { get; set; }
        public BDD867M BDD867M { get; set; }
        public BDD888M BDD888M { get; set; }
        public BDD898M BDD898M { get; set; }
        public BDD899M BDD899M { get; set; }
        public BDD900I BDD900I { get; set; }
        public BDD901W BDD901W { get; set; }
        public BDD902W BDD902W { get; set; }
        public BDD903W BDD903W { get; set; }
        public BDD904W BDD904W { get; set; }
        public BDD905W BDD905W { get; set; }
        public BDD906W BDD906W { get; set; }
        public BDD907W BDD907W { get; set; }
        public BDD908W BDD908W { get; set; }
        public BDD909W BDD909W { get; set; }
        public BDD910W BDD910W { get; set; }
        public BDD912W BDD912W { get; set; }
        public BDD913W BDD913W { get; set; }
        public BDD914W BDD914W { get; set; }
        public BDD915W BDD915W { get; set; }
        public BDD916S BDD916S { get; set; }
        public BDD917W BDD917W { get; set; }
        public BDD918W BDD918W { get; set; }
        public BDD919S BDD919S { get; set; }
        public BDD920W BDD920W { get; set; }
        public BDD921W BDD921W { get; set; }
        public BDD922W BDD922W { get; set; }
        public BDD926S BDD926S { get; set; }
        public BDD952C BDD952C { get; set; }
        public BDD999W BDD999W { get; set; }
        public BDI001I BDI001I { get; set; }
        public BDI002I BDI002I { get; set; }
        public BDI003I BDI003I { get; set; }
        public BDI004I BDI004I { get; set; }
        public BDI005I BDI005I { get; set; }
        public BDI006I BDI006I { get; set; }
        public BDI007I BDI007I { get; set; }
        public BDI008I BDI008I { get; set; }
        public BDI009I BDI009I { get; set; }
        public BPM001W BPM001W { get; set; }
        public BPM002W BPM002W { get; set; }
        public BPM003W BPM003W { get; set; }
        public BPM004W BPM004W { get; set; }
        public BPM005W BPM005W { get; set; }
        public BPM011W BPM011W { get; set; }
        public BPM021W BPM021W { get; set; }
        public BPM031W BPM031W { get; set; }
        public BPM041W BPM041W { get; set; }
    }

    public class ABS210W
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class ACC110W
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class ACC120W
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class ACC130W
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class ACC140W
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class ACC150W
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class ACC160W
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class ACC170W
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class ACC180W
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class ACC190W
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class ACC200W
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class ACC210W
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class ACC220W
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class ACC230W
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class ACC240W
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class ACC250W
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class ACC260W
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class ACC270W
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class ACC280W
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class ACC290W
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class ACC300W
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class ACC700M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class ACC712M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class ACC720M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class ACC721M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class ACC731M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class ACC750M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class ACC790M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class ACC800M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class ADB010W
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class ADB110W
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BBI001I
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD100W
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD400M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD500M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD501M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD502M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD550M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD570M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD600M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD605M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD650M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD700M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD701M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD702M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD703M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD704M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD705M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD706M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD708M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD709M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD710M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD711M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD712M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD713M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD714M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD715M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD716M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD717M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD718M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD719M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD721M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD722M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD723M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD724M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD725M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD726M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD727M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD728M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD729M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD730M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD731M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD732M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD733M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD734M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD735M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD736M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD737M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD738M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD739M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD740M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD741M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD742M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD743M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD744M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD745M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD746M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD747M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD748M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD749M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD750M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD751M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD752M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD753M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD754M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD755M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD756M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD757M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD758M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD759M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD760M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD761M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD762M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD763M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD764M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD765M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD766M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD767M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD770M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD771M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD772M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD773M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD775M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD776M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD778M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD779M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD780M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD781M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD782M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD783M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD790M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD791M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD800M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD850M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD851M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD852M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD853M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD854M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD855M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD856M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD857M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD858M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD863M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD864M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD865M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD866M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD867M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD888M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD898M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD899M
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD900I
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD901W
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD902W
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD903W
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD904W
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD905W
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD906W
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD907W
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD908W
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD909W
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD910W
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD912W
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD913W
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD914W
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD915W
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD916S
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD917W
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD918W
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD919S
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD920W
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD921W
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD922W
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD926S
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD952C
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDD999W
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDI001I
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDI002I
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDI003I
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDI004I
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDI005I
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDI006I
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDI007I
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDI008I
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BDI009I
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BPM001W
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BPM002W
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BPM003W
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BPM004W
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BPM005W
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BPM011W
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BPM021W
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BPM031W
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class BPM041W
    {
        public string svcCode { get; set; }
        public string functionCode { get; set; }
        public bool allowView { get; set; }
        public bool allowUpdate { get; set; }
        public string webType { get; set; }
        public string dataBound { get; set; }
        public string systemCode { get; set; }
    }

    public class Awebroles
    {
        public Accuser ACCUser { get; set; }
        public Bdiadmin BDIAdmin { get; set; }
        public Adbuser ADBUser { get; set; }
        public Bbiadmin BBIAdmin { get; set; }
        public Bpmuser BPMUser { get; set; }
        public Bddmember BDDMember { get; set; }
        public Bpmadmin BPMAdmin { get; set; }
        public Absuser ABSUser { get; set; }
    }

    public class Accuser
    {
        public string appCode { get; set; }
        public string roleCode { get; set; }
        public string roleName { get; set; }
        public string info { get; set; }
        public string webType { get; set; }
    }

    public class Bdiadmin
    {
        public string appCode { get; set; }
        public string roleCode { get; set; }
        public string roleName { get; set; }
        public string info { get; set; }
        public string webType { get; set; }
    }

    public class Adbuser
    {
        public string appCode { get; set; }
        public string roleCode { get; set; }
        public string roleName { get; set; }
        public string info { get; set; }
        public string webType { get; set; }
    }

    public class Bbiadmin
    {
        public string appCode { get; set; }
        public string roleCode { get; set; }
        public string roleName { get; set; }
        public string info { get; set; }
        public string webType { get; set; }
    }

    public class Bpmuser
    {
        public string appCode { get; set; }
        public string roleCode { get; set; }
        public string roleName { get; set; }
        public string info { get; set; }
        public string webType { get; set; }
    }

    public class Bddmember
    {
        public string appCode { get; set; }
        public string roleCode { get; set; }
        public string roleName { get; set; }
        public string info { get; set; }
        public string webType { get; set; }
    }

    public class Bpmadmin
    {
        public string appCode { get; set; }
        public string roleCode { get; set; }
        public string roleName { get; set; }
        public string info { get; set; }
        public string webType { get; set; }
    }

    public class Absuser
    {
        public string appCode { get; set; }
        public string roleCode { get; set; }
        public string roleName { get; set; }
        public string info { get; set; }
        public string webType { get; set; }
    }

    public class Mwebroles
    {
    }

    public class Menutree
    {
        public string webType { get; set; }
        public int androidVersion { get; set; }
        public string androidVersionName { get; set; }
        public Menu[] menu { get; set; }
        public Menuasreference1[] menuAsReference { get; set; }
        public int minAndroidVersion { get; set; }
        public object[] mobileAppTypes { get; set; }
        public object[] mobileAppTypesAsReference { get; set; }
        public int menuCount { get; set; }
        public int mobileAppTypesCount { get; set; }
        public string content { get; set; }
    }

    public class Menu
    {
        public string svcName { get; set; }
        public bool ready { get; set; }
        public string menuId { get; set; }
        public string menuCode { get; set; }
        public string labelKey { get; set; }
        public string functionCode { get; set; }
        public L10nasreference[] l10NAsReference { get; set; }
        public int l10NCount { get; set; }
        public Menu1[] menu { get; set; }
        public Menuasreference[] menuAsReference { get; set; }
        public int menuCount { get; set; }
        public L10n2[] l10N { get; set; }
        public string info { get; set; }
        public string label { get; set; }
        public string content { get; set; }
    }

    public class L10nasreference
    {
    }

    public class Menu1
    {
        public string svcName { get; set; }
        public bool ready { get; set; }
        public string menuId { get; set; }
        public string menuUri { get; set; }
        public string menuCode { get; set; }
        public string labelKey { get; set; }
        public string functionCode { get; set; }
        public L10nasreference1[] l10NAsReference { get; set; }
        public int l10NCount { get; set; }
        public object[] menu { get; set; }
        public object[] menuAsReference { get; set; }
        public int menuCount { get; set; }
        public L10n[] l10N { get; set; }
        public string info { get; set; }
        public string label { get; set; }
        public string content { get; set; }
    }

    public class L10nasreference1
    {
    }

    public class L10n
    {
    }

    public class Menuasreference
    {
        public string svcName { get; set; }
        public bool ready { get; set; }
        public string menuId { get; set; }
        public string menuUri { get; set; }
        public string menuCode { get; set; }
        public string labelKey { get; set; }
        public string functionCode { get; set; }
        public L10nasreference2[] l10NAsReference { get; set; }
        public int l10NCount { get; set; }
        public object[] menu { get; set; }
        public object[] menuAsReference { get; set; }
        public int menuCount { get; set; }
        public L10n1[] l10N { get; set; }
        public string info { get; set; }
        public string label { get; set; }
        public string content { get; set; }
    }

    public class L10nasreference2
    {
    }

    public class L10n1
    {
    }

    public class L10n2
    {
    }

    public class Menuasreference1
    {
        public string svcName { get; set; }
        public bool ready { get; set; }
        public string menuId { get; set; }
        public string menuCode { get; set; }
        public string labelKey { get; set; }
        public string functionCode { get; set; }
        public L10nasreference3[] l10NAsReference { get; set; }
        public int l10NCount { get; set; }
        public Menu2[] menu { get; set; }
        public Menuasreference2[] menuAsReference { get; set; }
        public int menuCount { get; set; }
        public L10n5[] l10N { get; set; }
        public string info { get; set; }
        public string label { get; set; }
        public string content { get; set; }
    }

    public class L10nasreference3
    {
    }

    public class Menu2
    {
        public string svcName { get; set; }
        public bool ready { get; set; }
        public string menuId { get; set; }
        public string menuUri { get; set; }
        public string menuCode { get; set; }
        public string labelKey { get; set; }
        public string functionCode { get; set; }
        public L10nasreference4[] l10NAsReference { get; set; }
        public int l10NCount { get; set; }
        public object[] menu { get; set; }
        public object[] menuAsReference { get; set; }
        public int menuCount { get; set; }
        public L10n3[] l10N { get; set; }
        public string info { get; set; }
        public string label { get; set; }
        public string content { get; set; }
    }

    public class L10nasreference4
    {
    }

    public class L10n3
    {
    }

    public class Menuasreference2
    {
        public string svcName { get; set; }
        public bool ready { get; set; }
        public string menuId { get; set; }
        public string menuUri { get; set; }
        public string menuCode { get; set; }
        public string labelKey { get; set; }
        public string functionCode { get; set; }
        public L10nasreference5[] l10NAsReference { get; set; }
        public int l10NCount { get; set; }
        public object[] menu { get; set; }
        public object[] menuAsReference { get; set; }
        public int menuCount { get; set; }
        public L10n4[] l10N { get; set; }
        public string info { get; set; }
        public string label { get; set; }
        public string content { get; set; }
    }

    public class L10nasreference5
    {
    }

    public class L10n4
    {
    }

    public class L10n5
    {
    }

    public class Site
    {
        public string siteId { get; set; }
        public string siteName { get; set; }
        public string webUrl { get; set; }
        public string dwebUrl { get; set; }
        public string ejbUrl { get; set; }
        public string imHost { get; set; }
        public int imPort { get; set; }
        public int imWsPort { get; set; }
    }

    public class Servicelist
    {
        public string appId { get; set; }
        public string svcCode { get; set; }
        public string systemCode { get; set; }
        public string systemName { get; set; }
        public string info { get; set; }
        public string appType { get; set; }
        public Mobileapptypes mobileAppTypes { get; set; }
        public Svcl10nlist[] svcL10NList { get; set; }
        public string contextPath { get; set; }
    }

    public class Mobileapptypes
    {
        public int value { get; set; }
        public string enumClass { get; set; }
        public object[] selectedType { get; set; }
        public string binaryStr { get; set; }
    }

    public class Svcl10nlist
    {
        public string localeVal { get; set; }
        public string name { get; set; }
        public string info { get; set; }
    }

    public class Platformservicelist
    {
        public string appId { get; set; }
        public string svcCode { get; set; }
        public string systemCode { get; set; }
        public string systemName { get; set; }
        public string info { get; set; }
        public string appType { get; set; }
        public Mobileapptypes1 mobileAppTypes { get; set; }
        public Svcl10nlist1[] svcL10NList { get; set; }
        public string contextPath { get; set; }
    }

    public class Mobileapptypes1
    {
        public int value { get; set; }
        public string enumClass { get; set; }
        public object[] selectedType { get; set; }
        public string binaryStr { get; set; }
    }

    public class Svcl10nlist1
    {
        public string localeVal { get; set; }
        public string name { get; set; }
        public string info { get; set; }
    }

    public class Bdduserdata
    {
        public int userOid { get; set; }
        public string uid { get; set; }
        public string sessionId { get; set; }
        public string userState { get; set; }
        public string name { get; set; }
        public string nickname { get; set; }
        public bool testUser { get; set; }
        public string loginId { get; set; }
        public string email { get; set; }
        public string[] didList { get; set; }
        public Imsystemdata imSystemData { get; set; }
        public Icesystemdata iceSystemData { get; set; }
        public Usersite userSite { get; set; }
        public string userId { get; set; }
        public string inviterUid { get; set; }
        public string currentTime { get; set; }
        public long currentTimeLong { get; set; }
        public string displayName { get; set; }
    }

    public class Imsystemdata
    {
        public string username { get; set; }
        public string password { get; set; }
        public string domain { get; set; }
        public int port { get; set; }
        public string wsHost { get; set; }
        public int wsPort { get; set; }
        public string host { get; set; }
        public string[] ipList { get; set; }
        public int connTimeout { get; set; }
        public int respTimeout { get; set; }
        public int echoTimeout { get; set; }
        public int heartbeatInterval { get; set; }
        public int retryMax { get; set; }
        public int retryTimeout { get; set; }
        public int maxDelay { get; set; }
        public string cnGatewayHost { get; set; }
        public string displayName { get; set; }
    }

    public class Icesystemdata
    {
        public string host { get; set; }
        public int port { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public int connTimeout { get; set; }
        public int respTimeout { get; set; }
        public int retryMax { get; set; }
        public int retryTimeout { get; set; }
        public string displayName { get; set; }
    }

    public class Usersite
    {
        public string url { get; set; }
        public bool multiSiteEnabled { get; set; }
        public string imServerHost { get; set; }
        public int imServerPort { get; set; }
        public string displayName { get; set; }
    }

}
