using QFlick.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QFlick.Domain.Entities.Queue
{
    public class QueueDetail : Entity
    {
        public int BuisnessId { get; set; }
        public int Waiting { get; set; }
        public int Completed { get; set; }
        public int Missed { get; set; }
        public int Count { get; set; }
        public int MinLength { get; set; }
        public int MaxLength { get; set; }

    }
}
