using data_access.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_access
{
    public class Book : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public int PublisherId { get; set; }
        public PublishingHouse Publisher { get; set; }
        public int Pages { get; set; }
        public int Year { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        public int Cost { get; set; }
        public int Price { get; set; }
        public int? PreviousBookId { get; set; }
        public Book? PreviousBook { get; set; }
       
        public Book? NextBook { get; set; }
        public ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}
