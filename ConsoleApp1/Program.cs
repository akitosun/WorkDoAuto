using Topshelf;
using WorkDoService;

namespace WorkDoWinService
{
    internal class Program
    {
        static void Main(string[] args)
        {
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
                x.SetDescription("WorkDo自動打卡程式");
                x.RunAsLocalSystem();
                x.StartAutomatically();
            });

        }
    }
}
