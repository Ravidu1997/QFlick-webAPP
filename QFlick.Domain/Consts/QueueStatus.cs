using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QFlick.Domain.Consts
{
    public enum QueueStatus
    {
        Waiting = 0,
        Serving = 1,
        Completed = 2,
        Missed = 3
    }
}
