using EatingApp.Core.Abstractions.Repositories;
using EatingApp.Entities;

namespace EatingApp.DAL.EntityRepository
{
    public class UserRepository:BaseRepository<User>,IUserRepository
    {
        public UserRepository(FoodApiContext _context) : base(_context)
        {
        }
    }
}
