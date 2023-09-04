using data_access.Data;
using data_access.Interfaces;
using data_access.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_access.Repositories
{
    public class UnitOfWork :IUnitOfWork, IDisposable
    {
        private static BookStoreDbContext context = new BookStoreDbContext();
        private Repository<Author> authorRepo;
        private Repository<Book> bookRepo;
        private Repository<Customer> customerRepo;
        private Repository<Genre> genreRepo;
        private Repository<Order> orderRepo;
        private Repository<PublishingHouse> publisherRepo;
        private Repository<User> userRepo;

        public Repository<Author> AuthorRepo
        {
            get
            {
                if(this.authorRepo == null)
                {
                    this.authorRepo = new Repository<Author>(context);
                }
                return authorRepo;
            }
        }
        public Repository<Book> BookRepo
        {
            get
            {
                if (this.bookRepo == null)
                {
                    this.bookRepo = new Repository<Book>(context);
                }
                return bookRepo;
            }
        }
        public Repository<Customer> CustomerRepo
        {
            get
            {
                if (this.customerRepo == null)
                {
                    this.customerRepo = new Repository<Customer>(context);
                }
                return customerRepo;
            }
        }
        public Repository<Genre> GenreRepo
        {
            get
            {
                if (this.genreRepo == null)
                {
                    this.genreRepo = new Repository<Genre>(context);
                }
                return genreRepo;
            }
        }
        public Repository<Order> OrderRepo
        {
            get
            {
                if (this.orderRepo == null)
                {
                    this.orderRepo = new Repository<Order>(context);
                }
                return orderRepo;
            }
        }
        public Repository<PublishingHouse> PublisherRepo
        {
            get
            {
                if (this.publisherRepo == null)
                {
                    this.publisherRepo = new Repository<PublishingHouse>(context);
                }
                return publisherRepo;
            }
        }
        public Repository<User> UserRepo
        {
            get
            {
                if (this.userRepo == null)
                {
                    this.userRepo = new Repository<User>(context);
                }
                return userRepo;
            }
        }
        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
