using EatingApp.Core.Entities;
using System;
using System.Collections.Generic;

namespace EatingApp.Entities
{
    public class Order : IEntity<int>
    {
        public int Id { get; set; }
            
        public DateTime Timestamp { get; set; }

        public DateTime Updated { get; set; }

        public string OrderDescription { get; set; }

        public List<OrderItem> OrderItems { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
    }
}
