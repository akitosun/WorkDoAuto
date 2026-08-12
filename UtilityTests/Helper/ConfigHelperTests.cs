using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utility.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace Utility.Helper.Tests
{
    [TestClass()]
    public class ConfigHelperTests
    {
        [TestMethod()]
        [DataRow("PunchIn", "")]
        public void GetAppSettingValue_ShouldBePass(string key,string expectedValue)
        {
            
            var actual = ConfigHelper.GetInstance().GetAppSettingValue(key);
            actual.Should().Be(expectedValue);
        }
    }
}
