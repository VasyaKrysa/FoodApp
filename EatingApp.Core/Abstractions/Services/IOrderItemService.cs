using EatingApp.Core.DTO;
using System.Collections.Generic;

namespace EatingApp.Core.Abstractions.Services
{
    public interface IOrderItemService
    {
        public List<OrderItemDto> GetAll();


        public OrderItemDto GetById(int id);


        public OrderItemDto Insert(OrderItemDto order);


        public void Update(OrderItemDto order);


        public void Delete(int orderId);
    }
}
