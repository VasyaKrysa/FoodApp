using System;
using EatingApp.Core.Abstractions.Repositories;
using EatingApp.Entities;

namespace EatingApp.DAL.EntityRepository
{
    public class OrderRepository: BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(FoodApiContext _context) : base(_context)
        {
        }

        public override Order Add(Order entity)
        {
            entity.Timestamp = DateTime.UtcNow;
            base.Add(entity);

            return entity;
        }
        public override void Edit(Order entity)
        { 
            entity.Updated = DateTime.UtcNow;
           
            base.Edit(entity);  
        }
    }
}
