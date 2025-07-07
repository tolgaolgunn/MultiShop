using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class UpdateAddressCommandHandler
    {
        private readonly IRepository<Address> _addressRepository;
        public UpdateAddressCommandHandler(IRepository<Address> addressRepository)
        {
            _addressRepository = addressRepository;
        }
        public async Task Handle(UpdateAddressCommand updateAddressCommand)
        {
            var address = await _addressRepository.GetByIdAsync(updateAddressCommand.AddressID);
            if (address != null)
            {
                address.UserID = updateAddressCommand.UserID;
                address.District = updateAddressCommand.District;
                address.City = updateAddressCommand.City;
                address.Detail = updateAddressCommand.Detail;
                await _addressRepository.UpdateAsync(address);
            }
        }
    }
}
