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
    public class CreateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _orderDetailRepository;
        public CreateOrderDetailCommandHandler(IRepository<OrderDetail> orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }
        public async Task Handle(CreateOrderDetailCommand createOrderDetailCommand)
        {
            var orderDetail = new OrderDetail
            {
                ProductID = createOrderDetailCommand.ProductID,
                ProductName = createOrderDetailCommand.ProductName,
                ProductPrice = createOrderDetailCommand.ProductPrice,
                ProductAmount = createOrderDetailCommand.ProductAmount,
                ProductTotalPrice = createOrderDetailCommand.ProductTotalPrice,
                OrderingID = createOrderDetailCommand.OrderingID
            };
            await _orderDetailRepository.CreateAsync(orderDetail);
        }
    }
}
