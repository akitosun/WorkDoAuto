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
        public MainService()
        {
            var clockin = ConfigHelper.GetInstance().GetAppSettingValue("ClockIn").Split(':');
            var clockout = ConfigHelper.GetInstance().GetAppSettingValue("ClockOut").Split(':');
            var clockInCron = $"0 {clockin[1]} {clockin[0]} ? * 1,2,3,4,5 ";
            var clockOutCron = $"0 {clockout[1]} {clockout[0]} ? * 1,2,3,4,5 ";
            // create Clock in job
            IJobDetail jobIn = JobBuilder.Create<ClockInJob>()
                .WithIdentity("ClockInJob", "MainGroup")
                .Build();
            // create trigger (Clock in)
            ITrigger inTrigger = TriggerBuilder.Create()
                .WithIdentity("ClockInTrigger", "MainGroup")
                .WithCronSchedule(clockInCron)
                .StartAt(DateTime.Now)
                .WithPriority(1)
                .Build();
            // create Clock out job
            IJobDetail jobOut = JobBuilder.Create<ClockOutJob>()
                .WithIdentity("ClockOutJob", "MainGroup")
                .Build();
            // create trigger (Clock out)
            ITrigger outTrigger = TriggerBuilder.Create()
                .WithIdentity("ClockOutTrigger", "MainGroup")
                .WithCronSchedule(clockOutCron)
                //.WithCronSchedule("0/2 * * * * ? *")//測試用，每2秒執行一次
                .StartAt(DateTime.Now)
                .WithPriority(1)
                .Build();

            // schedule job + trigger
            _scheduler = StdSchedulerFactory.GetDefaultScheduler().GetAwaiter().GetResult();
            _scheduler.ScheduleJob(jobIn, inTrigger);
            _scheduler.ScheduleJob(jobOut, outTrigger);
        }

        public void Start()
        {
            _scheduler.Start();
            Console.WriteLine("排程啟動");
        }

        public void Stop()
        {
            _scheduler.Shutdown();
            Console.WriteLine("排程停止");
        }

    }
    
}
