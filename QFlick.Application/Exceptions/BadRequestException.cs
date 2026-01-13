using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QFlick.Application.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string message)
       : base(message)
        {
        }

        public BadRequestException(string name, object key)
            : base($"Entity \"{name}\" ({key}) was not found.")
        {
        }
    }
}
