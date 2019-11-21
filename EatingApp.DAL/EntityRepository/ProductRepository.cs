using EatingApp.Core.Abstractions.Repositories;
using EatingApp.Entities;

namespace EatingApp.DAL.EntityRepository
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(FoodApiContext _context) : base(_context)
        {
        }
    }
}
