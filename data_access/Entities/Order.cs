﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_access
{
    public class Order
    {
        public int Id { get; set; }
        public ICollection<Book> Books { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

    }
}
