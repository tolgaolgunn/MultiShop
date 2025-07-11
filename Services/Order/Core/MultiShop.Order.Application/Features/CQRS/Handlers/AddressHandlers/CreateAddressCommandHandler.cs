﻿using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class CreateAddressCommandHandler
    {
        public IRepository<Address> _addressRepository;

        public CreateAddressCommandHandler(IRepository<Address> addressRepository)
        {
            _addressRepository = addressRepository;
        }
        public async Task Handle(CreateAddressCommand createAddressCommand)
        {
            await _addressRepository.CreateAsync(new Address
            {
                UserID = createAddressCommand.UserID,
                District = createAddressCommand.District,
                City = createAddressCommand.City,
                Detail = createAddressCommand.Detail
            });
        }
    }
}
