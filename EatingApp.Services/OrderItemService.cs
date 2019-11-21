using AutoMapper;
using EatingApp.Core.Abstractions;
using EatingApp.Core.Abstractions.Services;
using EatingApp.Core.DTO;
using EatingApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EatingApp.Services
{
    public class OrderItemService : IOrderItemService
    {
        private IUnitOfWork unitOfWork;
        private IMapper mapper;

        public OrderItemService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public List<OrderItemDto> GetAll()
        {

            return unitOfWork.OrderItemRepository.List().Select(item => mapper.Map(item, new OrderItemDto())).ToList();
        }

        public OrderItemDto GetById(int id)
        {
            var item = unitOfWork.OrderItemRepository.GetById(id);
            if (item == null)
                throw new Exception("Not found");
            var dto = new OrderItemDto();
            mapper.Map(item, dto);
            return dto;
        }

        public OrderItemDto Insert(OrderItemDto order)
        {
            var ord = new OrderItem();
            mapper.Map(order, ord);
            unitOfWork.OrderItemRepository.Add(ord);
            unitOfWork.Save();
            order.Id = ord.Id;

            return order;
        }

        public void Update(OrderItemDto order)
        {
            var ord = new OrderItem();
            mapper.Map(order, ord);
            unitOfWork.OrderItemRepository.Edit(ord);
            unitOfWork.Save();

        }

        public void Delete(int orderId)
        {
            unitOfWork.OrderItemRepository.Delete(orderId);
            unitOfWork.Save();
        }
    }
}
