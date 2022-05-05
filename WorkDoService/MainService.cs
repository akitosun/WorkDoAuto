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
        private IScheduler _clockIn_scheduler_Daily;

        public MainService()
        {
            var _clockIn_timeSplit = ConfigHelper.GetInstance().GetAppSettingValue("ClockIn").Split(':');

            var _workday = ConfigHelper.GetInstance().GetAppSettingValue("WorkDay");

            var _currentTime__Taiwan = DateTime.UtcNow.AddHours(8);

            DateTime _clockIn_time_today = _currentTime__Taiwan.Date + TimeSpan.Parse(ConfigHelper.GetInstance().GetAppSettingValue("ClockIn"));



            var _clockIn_Cron = $"0 {_clockIn_timeSplit[1]} {_clockIn_timeSplit[0]} ? * " + _workday + " ";

            IJobDetail _clockIn_Job = JobBuilder.Create<ClockInJob>()
                                               .WithIdentity("clockIn_Job", "RegularGroup")
                                               .Build();


            ITrigger _clockIn_Trigger = TriggerBuilder.Create()
                                                     .WithIdentity("clockIn_Trigger", "RegularGroup")
                                                     .WithCronSchedule(_clockIn_Cron, x => x.InTimeZone(TimeZoneInfo.FindSystemTimeZoneById("Taipei Standard Time")))
                                                     .StartAt(DateTime.Now)
                                                     .WithPriority(1)
                                                     .Build();

            ITrigger _clockIn_Trigger_Now = TriggerBuilder.Create()
                                                .WithIdentity("clockIn_Trigger_Once", "OnceGroup")
                                                .WithSimpleSchedule(x => x
                                                .WithIntervalInSeconds(1)
                                                .WithRepeatCount(0))
                                                .WithPriority(1)
                                                .Build();

            if (_workday.Contains(((int)_currentTime__Taiwan.DayOfWeek).ToString()) && DateTime.Compare(_currentTime__Taiwan, _clockIn_time_today) == 1)     // 檢查 當前時間 超過 config file打卡時間 且 是否為工作日
            {
                IScheduler _clockIn_scheduler_Once = StdSchedulerFactory.GetDefaultScheduler().GetAwaiter().GetResult();    // One time schedule
                _clockIn_scheduler_Once.ScheduleJob(_clockIn_Job, _clockIn_Trigger_Now);
                _clockIn_scheduler_Once.Start();
            }


            //// schedule job + trigger
            _clockIn_scheduler_Daily = StdSchedulerFactory.GetDefaultScheduler().GetAwaiter().GetResult();    // Daily schedule
            _clockIn_scheduler_Daily.ScheduleJob(_clockIn_Job, _clockIn_Trigger);

        }

        public void Start()
        {
            _clockIn_scheduler_Daily.Start();
            Console.WriteLine("Service Start.");
        }

        public void Stop()
        {

            _clockIn_scheduler_Daily.Shutdown();
            Console.WriteLine("Service Stop.");
        }

    }

}
