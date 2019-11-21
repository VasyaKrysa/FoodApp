using System;
using System.Collections.Generic;

namespace EatingApp.Core.DTO
{
    public class OrderDto
    {
        public int Id { get; set; }

        public DateTime? Timestamp { get; set; }

        public DateTime? Updated { get; set; }

        public string OrderDescription { get; set; }

        public int UserId { get; set; }

    }
}
