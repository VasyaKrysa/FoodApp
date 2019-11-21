using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using EatingApp.Core.Abstractions;
using EatingApp.Core.Abstractions.Services;
using EatingApp.Core.DTO;
using EatingApp.Entities;

namespace EatingApp.Services
{
    public class OrderService : IOrderService
    {
        private IUnitOfWork unitOfWork;
        private IMapper mapper;

        public OrderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public List<OrderDto> GetAll()
        {
            var list = unitOfWork.OrderRepository.List().ToList();

            return mapper.Map<List<Order>, List<OrderDto>>(list);
        }

        public OrderDto GetById(int id)
        {
            var item = unitOfWork.OrderRepository.GetById(id);
            if (item == null)
                throw new Exception("Not found");

            return mapper.Map<Order, OrderDto>(item);
        }

        public OrderDto Insert(OrderDto item)
        {
            var order = mapper.Map<OrderDto, Order>(item);
            order= unitOfWork.OrderRepository.Add(order);
            unitOfWork.Save();

            return mapper.Map<Order, OrderDto>(order);
        }

        public void Update(OrderDto order)
        {
            var ord = new Order();
            mapper.Map(order, ord);

            unitOfWork.OrderRepository.Edit(ord);
            unitOfWork.Save();
        }

        public void Delete(int orderId)
        {
            unitOfWork.OrderRepository.Delete(orderId);
            unitOfWork.Save();
        }
    }
}
