using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Common.Logging;
using Quartz;
using Quartz.Impl;
using Utility.Helper;
using WorkDoService.Models;

namespace WorkDoService
{
    public class MainService
    {
        private IScheduler _scheduler;
        private readonly ILog _logger
            = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private Timer _timer;

        //public MainService()
        //{
        //    _timer = new Timer(1000) { AutoReset = true };
        //    _timer.Elapsed += new ElapsedEventHandler(this.MainTask);
        //}

        //private void MainTask(object sender, ElapsedEventArgs args)
        //{
        //    // do main task here
        //    Console.WriteLine("do main task at: " + DateTime.Now);
        //}

        //public void Start()
        //{
        //    _timer.Start();
        //}

        //public void Stop()
        //{
        //    _timer.Stop();
        //}
        public MainService()
        {
            // create main job
            IJobDetail job = JobBuilder.Create<MainJob>()
                .WithIdentity("MainJob", "MainGroup")
                .Build();
            var clockin = ConfigHelper.GetInstance().GetAppSettingValue("ClockIn").Split(':');
            var clockout = ConfigHelper.GetInstance().GetAppSettingValue("ClockOut").Split(':');
            var clockInCron = $"0 {clockin[1]} {clockin[0]} ? * 1,2,3,4,5 ";
            // create trigger (Clock in)
            ITrigger inTrigger = TriggerBuilder.Create()
                .WithIdentity("ClockInTrigger", "MainGroup")
                .WithCronSchedule("0/5 * * * * ? *")
                .StartAt(DateTime.UtcNow.AddHours(08))
                .WithPriority(1)
                .Build();
            // create trigger (Clock out)
            ITrigger outTrigger = TriggerBuilder.Create()
                .WithIdentity("ClockOutTrigger", "MainGroup")
                .WithCronSchedule($"0 {clockout[1]} {clockout[0]} ? * 1,2,3,4,5 ")
                .StartAt(DateTime.UtcNow.AddHours(08))
                .WithPriority(1)
                .Build();
            // schedule job + trigger
            _scheduler = StdSchedulerFactory.GetDefaultScheduler().GetAwaiter().GetResult();
            _scheduler.ScheduleJob(job, inTrigger);
            _scheduler.ScheduleJob(job, outTrigger);
        }

        public void Start()
        {
            _scheduler.Start();
        }

        public void Stop()
        {
            _scheduler.Shutdown();
        }
        
    }
    
}
