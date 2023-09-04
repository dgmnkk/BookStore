using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace data_access.Data
{
    

    public static class ModelBuilderExtensions
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().HasData(
                new Genre { Id = 1, Name = "Science Fiction" },
                new Genre { Id = 2, Name = "Mystery" },
                new Genre { Id = 3, Name = "Fantasy" }
               
            );

            modelBuilder.Entity<Author>().HasData(
                new Author { Id = 1, Name = "John", Surname = "Doe" },
                new Author { Id = 2, Name = "Jane", Surname = "Smith" },
                new Author { Id = 3, Name = "Michael", Surname = "Johnson" }
            );

            modelBuilder.Entity<PublishingHouse>().HasData(
                new PublishingHouse { Id = 1, Name = "Publisher A" },
                new PublishingHouse { Id = 2, Name = "Publisher B" },
                new PublishingHouse { Id = 3, Name = "Publisher C" }
            );

            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    Name = "Book 1",
                    AuthorId = 1,
                    PublisherId = 1,
                    GenreId = 1,
                    Pages = 300,
                    Year = 2020,
                    Cost = 15,
                    Price = 25
                    
                },
                new Book
                {
                    Id = 2,
                    Name = "Book 2",
                    AuthorId = 2,
                    PublisherId = 2,
                    GenreId = 2,
                    Pages = 250,
                    Year = 2019,
                    Cost = 12,
                    Price = 20
                    
                },
                new Book
                {
                    Id = 3,
                    Name = "Book 3",
                    AuthorId = 3,
                    PublisherId = 3,
                    GenreId = 3,
                    Pages = 500,
                    Year = 2023,
                    Cost = 120,
                    Price = 200

                },
                new Book
                {
                    Id = 4,
                    Name = "Book 4",
                    AuthorId = 2,
                    PublisherId = 2,
                    GenreId = 2,
                    Pages = 123,
                    Year = 2000,
                    Cost = 100,
                    Price = 200

                },
                new Book
                {
                    Id = 5,
                    Name = "Book 5",
                    AuthorId = 1,
                    PublisherId = 2,
                    GenreId = 3,
                    Pages = 600,
                    Year = 2012,
                    Cost = 83,
                    Price = 166

                }
                
            );

            modelBuilder.Entity<Customer>().HasData(
                new Customer { Id = 1, Name = "Alice", Surname = "Johnson" },
                new Customer { Id = 2, Name = "Bob", Surname = "Smith"},
                new Customer { Id = 3, Name = "Ann", Surname = "Brown" },
                new Customer { Id = 4, Name = "Phillip", Surname = "Jackson" }

            );

            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    Id = 1,
                    CustomerId = 1,
                    Time = DateTime.Now,

                },
                new Order
                {
                    Id = 2,
                    CustomerId = 2,
                    Time = DateTime.Today
                },
                new Order
                {
                    Id = 3,
                    CustomerId = 3,
                    Time = DateTime.Today

                },
                new Order
                {
                    Id = 4,
                    CustomerId = 4,
                    Time = DateTime.Today

                },
                new Order
                {
                    Id = 5,
                    CustomerId = 2,
                    Time = DateTime.Today

                }
               
            );

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Login = "admin", Password = "admin" },
                new User { Id = 2, Login = "consultant", Password = "consultant" }
                
            );
        }
    }

}
