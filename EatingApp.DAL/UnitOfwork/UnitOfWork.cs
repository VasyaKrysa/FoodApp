using EatingApp.Core.Abstractions;
using EatingApp.Core.Abstractions.Repositories;
using EatingApp.DAL.EntityRepository;

namespace EatingApp.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private IOrderRepository orderRepository;
        private IUserRepository userRepository;
        private IProductTypeRepository productTypeRepository;
        private IProductRepository productRepository;
        private IOrderItemRepository orderItemRepository;

        private FoodApiContext _context;

        public UnitOfWork(FoodApiContext context)
        {
            _context = context;

        }
        public IOrderRepository OrderRepository
        {
            get
            {
                return orderRepository ??= new OrderRepository(_context);
            }
        }

        public IUserRepository UserRepository
        {
            get
            {
                return userRepository ??= new UserRepository(_context);
            }
        }

        public IProductTypeRepository ProductTypeRepository
        {
            get
            {
                return productTypeRepository ??= new ProductTypeRepository(_context);
            }
        }

        public IProductRepository ProductRepository
        {
            get
            {
                return productRepository ??= new ProductRepository(_context);
            }
        }

        public IOrderItemRepository OrderItemRepository
        {
            get
            {
                return orderItemRepository ??= new OrderItemRepository(_context);
            }
        }
        public void Dispose()
        {
           if(_context!=null)
            {
                _context.Dispose();
                _context = null;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
