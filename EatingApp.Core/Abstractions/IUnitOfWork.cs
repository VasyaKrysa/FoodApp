using EatingApp.Core.Abstractions.Repositories;
using System;

namespace EatingApp.Core.Abstractions
{
    public interface IUnitOfWork:IDisposable
    {

        IOrderRepository OrderRepository { get; }
        IUserRepository UserRepository { get; }
        IProductTypeRepository ProductTypeRepository { get; }

        IProductRepository ProductRepository { get; }

        IOrderItemRepository OrderItemRepository { get; }
        void Save();
    }
}
