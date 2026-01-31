using QFlick.Domain.DTOs;
using QFlick.Domain.DTOs.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QFlick.Application.Abstractions
{
    public interface IUserService
    {
        //Task<List<QueueDetail>> GetUsersByQueueId(int queueId);
        Task AddNewCustomer(RegCustomerDto user, CancellationToken cancellationToken);
        Task AddNewBusiness(BusinessRegisterDto user, CancellationToken cancellationToken);
        Task<AppUserDto> GetUserDetailAsync(string uid);
    }
}
