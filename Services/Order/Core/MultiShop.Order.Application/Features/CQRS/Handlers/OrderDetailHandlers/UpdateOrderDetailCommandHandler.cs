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
    public class UpdateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _orderDetailRepository;
        public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }
        public async Task Handle(UpdateOrderDetailCommand updateOrderDetailCommand)
        {
            var orderDetail = await _orderDetailRepository.GetByIdAsync(updateOrderDetailCommand.OrderDetailID);
            if (orderDetail != null)
            {
                orderDetail.OrderDetailID = updateOrderDetailCommand.OrderDetailID;
                orderDetail.OrderingID = updateOrderDetailCommand.OrderingID;
                orderDetail.ProductID = updateOrderDetailCommand.ProductID;
                orderDetail.ProductName = updateOrderDetailCommand.ProductName;
                orderDetail.ProductPrice = updateOrderDetailCommand.ProductPrice;
                orderDetail.ProductAmount = updateOrderDetailCommand.ProductAmount;
                orderDetail.ProductTotalPrice = updateOrderDetailCommand.ProductTotalPrice;
                await _orderDetailRepository.UpdateAsync(orderDetail);
            }
        }
    }
}
