using System;
using WorkDoService;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            //var service = new WorkDoService.Service();
            //service.PunchIn();
            var s = new Simulation();
            s.LoginSimulation();
            s.PunchOut();
            Console.WriteLine("Done!");

        }
    }
}
