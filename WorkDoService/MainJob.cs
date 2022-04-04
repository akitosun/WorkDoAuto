using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Quartz;

namespace WorkDoService
{
    [DisallowConcurrentExecution]
    public class MainJob : IJob
    {
        private string _type;
        public MainJob(string clockType)
        {
            _type = clockType;
        }
        public Task Execute(IJobExecutionContext context)
        {
            var service = new Simulation();
            service.LoginSimulation();
            service.Punch(_type);
            return Console.Out.WriteLineAsync($"Punch {_type} finish at {DateTime.UtcNow.AddHours(08)}");
        }
    }
}
