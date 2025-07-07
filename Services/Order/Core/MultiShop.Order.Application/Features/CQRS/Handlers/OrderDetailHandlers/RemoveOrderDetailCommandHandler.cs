using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class RemoveOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _orderDetailRepository;

        public RemoveOrderDetailCommandHandler(IRepository<OrderDetail> orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }
        public async Task Handle(RemoveOrderDetailCommand removeOrderDetailCommand)
        {
            var orderDetail = await _orderDetailRepository.GetByIdAsync(removeOrderDetailCommand.OrderDetailID);
            if (orderDetail != null)
            {
                await _orderDetailRepository.DeleteAsync(orderDetail);
            }
        }
    }
}
