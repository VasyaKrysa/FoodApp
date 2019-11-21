using EatingApp.Core.Abstractions.Repositories;
using EatingApp.Entities;

namespace EatingApp.DAL.EntityRepository
{
    public class ProductTypeRepository : BaseRepository<ProductType>, IProductTypeRepository
    {
        public ProductTypeRepository(FoodApiContext _context) : base(_context)
        {
        }

    }
}
