using System;
using System.Collections.Generic;
using EatingApp.Core.Entities;

namespace EatingApp.Entities
{

    public class User: IEntity<int>
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public List<Order> Orders { get; set; }       
    }
}
