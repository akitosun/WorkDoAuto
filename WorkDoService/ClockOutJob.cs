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
                PunchHistory punchHistory = await simulation.Query_PunchHistory(Enum_clocktype.ClockOut);

                if (String.IsNullOrEmpty(punchHistory.punchTime))      // 無打卡紀錄，執行打卡
                {
                    simulation.PunchOut();
                    punchHistory = await simulation.Query_PunchHistory(Enum_clocktype.ClockOut);
                    msg += "Punch Out Sucessfully at ";
                }
                else
                {
                    msg += "You already punched out at ";
                }

                Console.Out.WriteLineAsync(msg + DateTime.Parse(punchHistory.punchTime.Replace("+0800", "")));
            }
            catch (Exception e)
            {
                Console.Out.WriteLineAsync(e.Message);
                _logger.Debug(e);
                throw;
            }

        }
    }
}
