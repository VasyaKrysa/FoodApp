using EatingApp.Core.Abstractions.Repositories;
using EatingApp.Entities;

namespace EatingApp.DAL.EntityRepository
{
    public class OrderItemRepository : BaseRepository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(FoodApiContext _context) : base(_context)
        {
        }
    }
}
