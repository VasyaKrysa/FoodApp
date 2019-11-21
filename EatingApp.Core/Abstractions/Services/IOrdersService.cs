using EatingApp.Core.DTO;
using System.Collections.Generic;

namespace EatingApp.Core.Abstractions.Services
{
    public interface IOrderService
    {
        public List<OrderDto> GetAll();


        public OrderDto GetById(int id);


        public OrderDto Insert(OrderDto order);


        public void Update(OrderDto order);


        public void Delete(int orderId);

    }
}
