using EatingApp.Core.Entities;
using System.Collections.Generic;

namespace EatingApp.Entities
{
    public class Product: IEntity<int>
    {
        public int Id { get; set; }
        public int ProductTypeId { get; set; }
        public ProductType ProductType { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public decimal Price { get; set; }
    }
}