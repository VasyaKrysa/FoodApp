using EatingApp.Core.Entities;
using System.Collections.Generic;

namespace EatingApp.Entities
{
    public class ProductType: IEntity<int>
    {
        public int Id { get; set; }
        public List<Product> Products { get; set; }
        public string Name { get; set; }
    }
}
