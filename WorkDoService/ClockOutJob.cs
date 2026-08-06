using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using Quartz;
using WorkDoService.Models;

namespace WorkDoService
{
    [DisallowConcurrentExecution]
    public class ClockOutJob : IJob
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();
        public async Task Execute(IJobExecutionContext context)
        {
            try
            {
                string msg = "";

                var simulation = new Simulation();
                simulation.LoginSimulation();
                await simulation.SupplementMissingPunchAsync();
                PunchResult result = await simulation.PunchWithValidationAsync(Enum_clocktype.ClockOut);
                msg = result.WasPunched ? "Punch Out Successfully at " : "You already punched out at ";

                if (result.WasPunched)
                {
                    PunchNotification.Notify(result);
                }

                await Console.Out.WriteLineAsync(
                    $"{msg}{DateTime.Parse(result.PunchTime.Replace("+0800", "")):yyyy/MM/dd HH:mm:ss}");
            }
            catch (Exception e)
            {
                await Console.Out.WriteLineAsync(e.Message);
                _logger.Debug(e);
                throw;
            }

        }
    }
}
