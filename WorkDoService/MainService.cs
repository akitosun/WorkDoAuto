using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using NLog;
using Quartz;
using Quartz.Impl;
using Utility.Helper;
using WorkDoService.Models;

namespace WorkDoService
{
    public class MainService
    {
        private IScheduler _scheduler;

        private static Logger _logger = LogManager.GetCurrentClassLogger();

        public MainService()
        {
            // create main job
            IJobDetail job = JobBuilder.Create<MainJob>()
                .WithIdentity("MainJob", "MainGroup")
                .Build();
            var clockin= ConfigHelper.GetInstance().GetAppSettingValue("ClockIn").Split(':');
            var clockout = ConfigHelper.GetInstance().GetAppSettingValue("ClockOut").Split(':');
            // create trigger (Clock in)
            ITrigger inTrigger = TriggerBuilder.Create()
                .WithIdentity("ClockInTrigger", "MainGroup")
                .WithCronSchedule($"0 {clockin[1]} {clockin[0]} 0 0 MON-FRI ")
                .StartAt(DateTime.UtcNow.AddHours(08))
                .WithPriority(1)
                .Build();
            // create trigger (Clock out)
            ITrigger outTrigger = TriggerBuilder.Create()
                .WithIdentity("ClockOutTrigger", "MainGroup")
                .WithCronSchedule($"0 {clockout[1]} {clockout[0]} 0 0 MON-FRI ")
                .StartAt(DateTime.UtcNow.AddHours(08))
                .WithPriority(1)
                .Build();
            // schedule job + trigger
            _scheduler = StdSchedulerFactory.GetDefaultScheduler().GetAwaiter().GetResult();
            _scheduler.ScheduleJob(job, inTrigger);
            _scheduler.ScheduleJob(job, outTrigger);
        }

        private void MainTask(object sender, ElapsedEventArgs args)
        {
            // do main task here
            Console.WriteLine("do main task at: " + DateTime.Now);
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
