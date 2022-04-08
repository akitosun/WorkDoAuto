using System.Net;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkDoService;

namespace WorkDoServiceIntegrationTests
{
    [TestClass()]
    public class SimulationTests
    {
        /// <summary>
        /// 使用這測試前請先將『測試專案』的app.config裡面的登入資訊設定正確
        /// </summary>
        [TestMethod()]
        public void LoginShouldBePass()
        {
            var simulation = new Simulation();
            simulation.LoginSimulation();
            simulation.IsNotLogin().Should().BeFalse();
        }
        /// <summary>
        /// 使用這測試前請先將『測試專案』的app.config裡面的登入資訊設定成錯誤的，才能驗證到登入錯誤的例外
        /// </summary>
        [ExpectedException(typeof(WebException))]
        [TestMethod()]
        public void LoginShouldBeFail()
        {
            var simulation = new Simulation();
            simulation.LoginSimulation();
        }
    }
}