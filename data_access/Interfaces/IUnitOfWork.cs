using data_access.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_access.Interfaces
{
    public interface IUnitOfWork
    {
        Repository<Author> AuthorRepo { get; }
        Repository<Book> BookRepo { get; }
        Repository<Customer> CustomerRepo { get; }
        Repository<Genre> GenreRepo { get; }
        Repository<Order> OrderRepo { get; }
        Repository<PublishingHouse> PublisherRepo { get; }
        Repository<User> UserRepo { get; }

        void Save();

    }
}
