using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;

namespace WorkDoService
{
    [DisallowConcurrentExecution]
    public class ClockOutJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            try
            {
                var simulation = new Simulation();
                simulation.LoginSimulation();
                simulation.PunchOut();
                var msg = $"Punch Out finish at {DateTime.UtcNow.AddHours(08)}";
                return Console.Out.WriteLineAsync(msg);
            }
            catch (Exception e)
            {
                return Console.Out.WriteLineAsync(e.Message);
            }
            
        }
    }
}
