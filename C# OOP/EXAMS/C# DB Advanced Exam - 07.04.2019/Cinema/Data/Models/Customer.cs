﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cinema.Data.Models
{
    public class Customer
    {
        //        •	Id – integer, Primary Key
        //•	FirstName – text with length[3, 20] (required)
        //•	LastName – text with length[3, 20] (required)
        //•	Age – integer in the range[12, 110] (required)
        //•	Balance - decimal (non-negative, minimum value: 0.01) (required)
        //•	Tickets - collection of type Ticket

        public Customer()
        {
            this.Tickets = new HashSet<Ticket>();
        }

        public int Id { get; set; }

        [StringLength(20, MinimumLength = 3)]
        public string FirstName { get; set; }


        [StringLength(20, MinimumLength = 3)]
        public string LastName { get; set; }

        [Range(12, 110)]
        public int Age { get; set; }

        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        public decimal Balance { get; set; }

        public ICollection<Ticket> Tickets { get; set; }

    }
}
