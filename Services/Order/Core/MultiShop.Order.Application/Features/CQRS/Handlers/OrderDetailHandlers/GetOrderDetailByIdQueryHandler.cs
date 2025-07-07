using MultiShop.Order.Application.Features.CQRS.Queries.OrderDetailQueries;
using MultiShop.Order.Application.Features.CQRS.Results.OrderDetailResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailByIdQueryHandler
    {
        private readonly IRepository<OrderDetail> _orderDetailRepository;

        public GetOrderDetailByIdQueryHandler(IRepository<OrderDetail> orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }
        public async Task<GetOrderDetailByIdQueryResult> Handle(GetOrderDetailByIdQuery getOrderDetailByIdQuery)
        {
            var values = await _orderDetailRepository.GetByIdAsync(getOrderDetailByIdQuery.ID);
            return new GetOrderDetailByIdQueryResult
            {
                OrderDetailID = values.OrderDetailID,
                ProductID = values.ProductID,
                ProductName = values.ProductName,
                ProductPrice= values.ProductPrice,
                ProductAmount= values.ProductAmount,
                ProductTotalPrice = values.ProductTotalPrice,
                OrderingID= values.OrderingID
            };
        }
    }
}
