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

                var _currentTime_Taiwan = DateTime.UtcNow.AddHours(8);

                simulation.LoginSimulation();
                await simulation.SupplementMissingPunchAsync();

                List<string> vacationlist = await simulation.QueryHoliday();
                PunchHistory punchHistory = await simulation.Query_PunchHistory(Enum_clocktype.ClockIn);

                if (!vacationlist.Contains(_currentTime_Taiwan.ToShortDateString()))   // 判斷 當前時間 是否為國定假日
                {
                    PunchResult result = await simulation.PunchWithValidationAsync(Enum_clocktype.ClockIn);
                    punchHistory.punchTime = result.PunchTime;
                    msg = result.WasPunched ? "Punch In Successfully at " : "You already punched in at ";

                    PunchNotification.Notify(result);

                    await Console.Out.WriteLineAsync(
                        $"{msg}{DateTime.Parse(punchHistory.punchTime.Replace("+0800", "")):yyyy/MM/dd HH:mm:ss}");



                    // 取得今日預計打卡時間
                    DateTime _clockOut_time_today = _currentTime_Taiwan.Date + TimeSpan.Parse(ConfigHelper.GetInstance().GetAppSettingValue("ClockOut"));

                    // 啟用彈性下班時，依實際上班比設定時間晚的分鐘數延後下班；提早上班不會提早下班。
                    bool enableFlexibleClockOut = GetBooleanSetting("EnableFlexibleClockOut", true);
                    if (enableFlexibleClockOut)
                    {
                        DateTime configuredClockIn = _currentTime_Taiwan.Date +
                            TimeSpan.Parse(ConfigHelper.GetInstance().GetAppSettingValue("ClockIn"));
                        DateTime actualClockIn = DateTime.Parse(punchHistory.punchTime.Replace("+0800", ""));
                        TimeSpan delay = actualClockIn - configuredClockIn;
                        if (delay > TimeSpan.Zero)
                        {
                            _clockOut_time_today = _clockOut_time_today.Add(delay);
                        }
                    }


                    var _clockOut_timeSplit = _clockOut_time_today.TimeOfDay.ToString().Split(':');



                    IJobDetail _clockOut_Job = JobBuilder.Create<ClockOutJob>()
                                          .WithIdentity("clockOut_Job", "RegularClockOutGroup")
                                          .Build();

                    ITrigger _clockOut_Trigger;

                    if (DateTime.Compare(_currentTime_Taiwan, _clockOut_time_today) >= 0)     // 當前時間 是否 超過排程打下班卡時間，決定是否要立即執行打下班卡
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
                    await _clockOut_scheduler.ScheduleJob(_clockOut_Job, _clockOut_Trigger);
                    await _clockOut_scheduler.Start();



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

        private static bool GetBooleanSetting(string key, bool defaultValue)
        {
            try
            {
                bool parsedValue;
                return bool.TryParse(ConfigHelper.GetInstance().GetAppSettingValue(key), out parsedValue)
                    ? parsedValue
                    : defaultValue;
            }
            catch (ApplicationException)
            {
                return defaultValue;
            }
        }
    }
}
