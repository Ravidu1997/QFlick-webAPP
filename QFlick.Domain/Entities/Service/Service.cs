using QFlick.Domain.Entities.Queue;
using QFlick.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QFlick.Domain.Entities.Service
{
    public class Service : Entity
    {
        public int StaffId { get; set; }
        public string ServiceName { get; set; } = string.Empty;
        public bool IsAvailable { get; set; } = true;
        public List<QueueDetail> Queues { get; set; } = [];

    }
}
