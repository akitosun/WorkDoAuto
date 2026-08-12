using System;
using System.Reflection;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkDoService;

namespace WorkDoServiceIntegrationTests
{
    [TestClass]
    public class SimulationTests
    {
        [TestMethod]
        [TestCategory("Integration")]
        public void LoginShouldBePass()
        {
            RequireLiveIntegrationTests();
            var simulation = CreateSimulation(
                RequireEnvironmentVariable("WORKDO_TEST_EMAIL"),
                RequireEnvironmentVariable("WORKDO_TEST_PASSWORD"));

            simulation.LoginSimulation();

            simulation.IsNotLogin().Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("Integration")]
        public void LoginShouldBeFail()
        {
            RequireLiveIntegrationTests();
            var simulation = CreateSimulation(
                "invalid-workdo-user-" + Guid.NewGuid().ToString("N") + "@example.invalid",
                Guid.NewGuid().ToString("N"));

            Action login = () => simulation.LoginSimulation();

            login.Should().Throw<InvalidOperationException>();
        }

        private static void RequireLiveIntegrationTests()
        {
            if (!string.Equals(
                Environment.GetEnvironmentVariable("WORKDO_RUN_INTEGRATION_TESTS"),
                "true",
                StringComparison.OrdinalIgnoreCase))
            {
                Assert.Inconclusive(
                    "Set WORKDO_RUN_INTEGRATION_TESTS=true to run tests against the live WorkDo API.");
            }
        }

        private static string RequireEnvironmentVariable(string name)
        {
            string value = Environment.GetEnvironmentVariable(name);
            if (string.IsNullOrWhiteSpace(value))
            {
                Assert.Inconclusive(name + " must be set for live WorkDo integration tests.");
            }

            return value;
        }

        private static Simulation CreateSimulation(string email, string password)
        {
            var simulation = new Simulation();
            SetPrivateField(simulation, "_email", email);
            SetPrivateField(simulation, "_password", password);
            return simulation;
        }

        private static void SetPrivateField(Simulation simulation, string fieldName, string value)
        {
            FieldInfo field = typeof(Simulation).GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.IsNotNull(field, "Simulation field was not found: " + fieldName);
            field.SetValue(simulation, value);
        }
    }
}
