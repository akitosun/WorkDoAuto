using System;

namespace WorkDoService.Models
{
    public class PunchResult
    {
        public Enum_clocktype ClockType { get; set; }
        public bool WasPunched { get; set; }
        public string PunchTime { get; set; }
    }

    public class PunchCompletedEventArgs : EventArgs
    {
        public PunchCompletedEventArgs(PunchResult result)
        {
            Result = result;
        }

        public PunchResult Result { get; }
    }
}
