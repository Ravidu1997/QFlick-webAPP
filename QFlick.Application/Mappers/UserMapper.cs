using QFlick.Domain.DTOs;
using QFlick.Domain.DTOs.Client;
using QFlick.Domain.Entities.Client.Business;
using QFlick.Domain.Entities.Client.User;
using Riok.Mapperly.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QFlick.Application.Mappers
{
    [Mapper]
    public partial class UserMapper
    {
        [MapperIgnoreTarget(nameof(AppUser.UId))]
        [MapperIgnoreTarget(nameof(RegCustomerDto.Password))]
        public partial AppUser RegCustomerDtoToAppUser(RegCustomerDto user);

        [MapperIgnoreTarget(nameof(BusinessUser.UId))]
        [MapperIgnoreTarget(nameof(BusinessRegisterDto.Password))]
        public partial BusinessUser BusinessRegisterDtoToBusinessUser(BusinessRegisterDto user);

        public partial AppUserDto UserToAppUserDto(AppUser user);
    }
}
