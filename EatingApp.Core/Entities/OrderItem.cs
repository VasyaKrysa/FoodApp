using EatingApp.Core.Entities;

namespace EatingApp.Entities
{
    public class OrderItem: IEntity<int>
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public short Quantity { get; set; }

        public string Description { get; set; }
    }
}