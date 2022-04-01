using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using Utility.Helper;
using WorkDoService.Models;

namespace WorkDoService
{
    public class Service
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// Email
        /// </summary>
        private string Email = ConfigHelper.GetInstance().GetAppSettingValue("Email");

        /// <summary>
        /// Secret Text
        /// </summary>
        private string Password = ConfigHelper.GetInstance().GetAppSettingValue("Pw");

        /// <summary>
        /// loginURL
        /// </summary>
        private string loginURL = "https://www.workdo.co/bdddweb/api/dweb/BDD771M/userLogin";

        private string punchURL = "https://www.workdo.co/ccndweb/api/dweb/CCN102M/saveFromCreate102M3";
        

    }
    
}
