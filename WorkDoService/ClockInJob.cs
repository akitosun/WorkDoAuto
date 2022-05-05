using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using Quartz;
using Quartz.Impl;
using Utility.Helper;
using WorkDoService.Models;

namespace WorkDoService
{
    [DisallowConcurrentExecution]
    public class ClockInJob : IJob
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        public async Task Execute(IJobExecutionContext context)
        {
            try
            {
                string msg = "";

                var simulation = new Simulation();

                var _currentTime__Taiwan = DateTime.UtcNow.AddHours(8);

                simulation.LoginSimulation();

                List<string> vacationlist = await simulation.QueryHoliday();
                PunchHistory punchHistory = await simulation.Query_PunchHistory(Enum_clocktype.ClockIn);

                if (!vacationlist.Contains(_currentTime__Taiwan.ToShortDateString()))   // 判斷 當前時間 是否為國定假日
                {
                    if (String.IsNullOrEmpty(punchHistory.punchTime))      // 無打卡紀錄，執行打卡
                    {
                        simulation.PunchIn();
                        punchHistory = await simulation.Query_PunchHistory(Enum_clocktype.ClockIn);
                        msg += "Punch In Sucessfully at ";
                    }
                    else
                    {
                        msg += "You already punched in at ";
                    }

                    Console.Out.WriteLineAsync(
                        $"{msg}{DateTime.Parse(punchHistory.punchTime.Replace("+0800", "")):yyyy/MM/dd HH:mm:ss}");



                    // 取得今日預計打卡時間
                    DateTime _clockOut_time_today = _currentTime__Taiwan.Date + TimeSpan.Parse(ConfigHelper.GetInstance().GetAppSettingValue("ClockOut"));

                    // 比較 今日上班打卡時間 + 9 hrs ，以及 config file 的打卡時間，取較晚者做為今日打卡下班時間。
                    _clockOut_time_today = DateTime.Compare(DateTime.Parse(punchHistory.punchTime).AddHours(9).AddMinutes(1), _clockOut_time_today) == 1 ? DateTime.Parse(punchHistory.punchTime).AddHours(9).AddMinutes(1) : _clockOut_time_today;


                    var _clockOut_timeSplit = _clockOut_time_today.TimeOfDay.ToString().Split(':');



                    IJobDetail _clockOut_Job = JobBuilder.Create<ClockOutJob>()
                                          .WithIdentity("clockOut_Job", "RegularClockOutGroup")
                                          .Build();

                    ITrigger _clockOut_Trigger;

                    if (DateTime.Compare(_currentTime__Taiwan, _clockOut_time_today) >= 0)     // 當前時間 是否 超過排程打下班卡時間，決定是否要立即執行打下班卡
                    {
                        _clockOut_Trigger = TriggerBuilder.Create()
                                               .WithIdentity("clockIn_Trigger", "RegularClockOutGroup")
                                               .WithSimpleSchedule(x => x
                                               .WithIntervalInSeconds(1)
                                               .WithRepeatCount(0))
                                               .WithPriority(1)
                                               .Build();


                    }
                    else
                    {
                        _clockOut_Trigger = TriggerBuilder.Create()
                                            .WithIdentity("clockIn_Trigger", "RegularClockOutGroup")
                                            .WithCronSchedule($"{_clockOut_timeSplit[2]} {_clockOut_timeSplit[1]} {_clockOut_timeSplit[0]} * * ?", x => x.InTimeZone(TimeZoneInfo.FindSystemTimeZoneById("Taipei Standard Time")))
                                            .EndAt(_clockOut_time_today.AddMinutes(1))
                                            .Build();
                    }


                    IScheduler _clockOut_scheduler = StdSchedulerFactory.GetDefaultScheduler().GetAwaiter().GetResult();
                    _clockOut_scheduler.ScheduleJob(_clockOut_Job, _clockOut_Trigger);
                    _clockOut_scheduler.Start();



                }
                //return Console.Out.WriteLineAsync("");
            }
            catch (Exception e)
            {
                // return Console.Out.WriteLineAsync(e.Message);
                _logger.Debug(e);
                throw;
            }

        }
    }
}
