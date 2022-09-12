using System;
using System.Text;
using Topshelf;
using WorkDoService;

namespace WorkDoWinService
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            HostFactory.Run(x =>
            {
                x.Service<MainService>(s =>
                {
                    s.ConstructUsing(name => new MainService());
                    s.WhenStarted(ms => ms.Start());
                    s.WhenStopped(ms => ms.Stop());
                });

                x.SetServiceName("WorkDoAutoPunchService");
                x.SetDisplayName("WorkDoAutoPunchService");
                x.SetDescription("WorkDoAutoPunchService");
                x.RunAsLocalSystem();
                x.StartAutomatically();
            });
            //底下為測試用Code
            //DateTime Time_PunchIn = DateTime.Now.Date + TimeSpan.Parse(ConfigHelper.GetInstance().GetAppSettingValue("ClockIn"));
            //var service = new Simulation();
            //service.LoginSimulation();
            //service.PunchOut();
        }
    }
}
