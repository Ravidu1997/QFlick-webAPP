using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QFlick.Application.Abstractions
{
    public interface IAuthenticationService
    {
        Task<string> RegisterAsync(string email, string password);
    }
}
