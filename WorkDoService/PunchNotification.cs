using System;
using WorkDoService.Models;

namespace WorkDoService
{
    public static class PunchNotification
    {
        public static event EventHandler<PunchCompletedEventArgs> PunchCompleted;

        public static void Notify(PunchResult result)
        {
            PunchCompleted?.Invoke(null, new PunchCompletedEventArgs(result));
        }
    }
}
