using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Common.Logging;
using Quartz;

namespace WorkDoService
{
    [DisallowConcurrentExecution]
    public class MainJob : IJob
    {
        private string _type;
        //private readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public MainJob(string clockType)
        {
            _type = clockType;
        }
        public Task Execute(IJobExecutionContext context)
        {
            try
            {
                var service = new Simulation();
                service.LoginSimulation();
                service.Punch(_type);
                var msg= $"Punch {_type} finish at {DateTime.UtcNow.AddHours(08)}";
                //_logger.Info(msg);
                return Console.Out.WriteLineAsync(msg);
            }
            catch (Exception e)
            {
                //_logger.Debug(e);
                throw;
            }
            
        }
    }
}
