using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkDoService
{
    public interface ISimulation
    {
        bool IsNotLogin();
        void LoginSimulation();
        void PunchIn();
        void PunchOut();
    }
}
