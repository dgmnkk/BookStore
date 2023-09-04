using data_access.Interfaces;
using data_access.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BookStore
{
    /// <summary>
    /// Interaction logic for BookStoreInfo.xaml
    /// </summary>
    public partial class BookStoreInfo : Window
    {
        private IUnitOfWork uow = new UnitOfWork();
        public BookStoreInfo()
        {
            InitializeComponent();
            booksTable.ItemsSource = uow.BookRepo.Get(includeProperties: "Author").Select(x => new
            {
                x.Id,
                x.Name,
                AuthorName = x.Author.Name,
                AuthorSurname = x.Author.Surname,
                x.Cost,
                x.Price,
                x.Year,

            });
            uow.Save();
        }

        private void TopDay_Click(object sender, RoutedEventArgs e)
        {
            DateTime targetDate = DateTime.Today;
            int topCount = 10;

            booksTable.ItemsSource = uow.BookRepo.Get(
                filter: book => book.Orders.Any(order => order.Time.Day == targetDate.Day),
                orderBy: query => query.OrderBy(book => book.Orders.Count(order => order.Time.Day == targetDate.Day)),
                includeProperties: "Author")
                .Take(topCount)
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                    AuthorName = x.Author.Name,
                    AuthorSurname = x.Author.Surname,
                    x.Cost,
                    x.Price,
                    x.Year,
                    NumberOfOrders = x.Orders.Count(order => order.Time.Day == targetDate.Day)
                });
            uow.Save() ;
        }
        private void TopWeek_Click(object sender, RoutedEventArgs e)
        {
            DateTime startDate = DateTime.Today.AddDays(-7); 
            DateTime endDate = DateTime.Today;

            var topCount = 10;

            booksTable.ItemsSource = uow.BookRepo.Get(
                filter: book => book.Orders.Any(order => order.Time.Day >= startDate.Day && order.Time.Day <= endDate.Day),
                orderBy: query => query.OrderBy(book => book.Orders.Count(order => order.Time.Day >= startDate.Day && order.Time.Day <= endDate.Day)),
                includeProperties: "Author")
                .Take(topCount)
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                    AuthorName = x.Author.Name,
                    AuthorSurname = x.Author.Surname,
                    x.Cost,
                    x.Price,
                    x.Year,
                    NumberOfOrders = x.Orders.Count(order => order.Time.Day >= startDate.Day && order.Time.Day <= endDate.Day)
                });
            uow.Save();

        }
        private void TopMonth_Click(object sender, RoutedEventArgs e)
        {
            DateTime startDate = DateTime.Today.AddDays(-30);
            DateTime endDate = DateTime.Today;

            var topCount = 10;

            booksTable.ItemsSource = uow.BookRepo.Get(
                filter: book => book.Orders.Any(order => order.Time.Day >= startDate.Day && order.Time.Day <= endDate.Day),
                orderBy: query => query.OrderBy(book => book.Orders.Count(order => order.Time.Day >= startDate.Day && order.Time.Day <= endDate.Day)),
                includeProperties: "Author")
                .Take(topCount)
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                    AuthorName = x.Author.Name,
                    AuthorSurname = x.Author.Surname,
                    x.Cost,
                    x.Price,
                    x.Year,
                    NumberOfOrders = x.Orders.Count(order => order.Time.Day >= startDate.Day && order.Time.Day <= endDate.Day)
                });
            uow.Save();
        }
        private void TopYear_Click(object sender, RoutedEventArgs e)
        {
            DateTime startDate = DateTime.Today.AddDays(-365);
            DateTime endDate = DateTime.Today;

            var topCount = 10;

            booksTable.ItemsSource = uow.BookRepo.Get(
                filter: book => book.Orders.Any(order => order.Time.Day >= startDate.Day && order.Time.Day <= endDate.Day),
                orderBy: query => query.OrderBy(book => book.Orders.Count(order => order.Time.Day >= startDate.Day && order.Time.Day <= endDate.Day)),
                includeProperties: "Author")
                .Take(topCount)
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                    AuthorName = x.Author.Name,
                    AuthorSurname = x.Author.Surname,
                    x.Cost,
                    x.Price,
                    x.Year,
                    NumberOfOrders = x.Orders.Count(order => order.Time.Day >= startDate.Day && order.Time.Day <= endDate.Day)
                });
            uow.Save();
        }

        private void TopDayAuthor_Click(object sender, RoutedEventArgs e)
        {
            DateTime targetDate = DateTime.Today;
            int topAuthorCount = 10;

            booksTable.ItemsSource = uow.AuthorRepo.Get(
                includeProperties: "Book")
                .Where(author => author.Books.Any(book => book.Orders.Any(order => order.Time.Day == targetDate.Day)))
                .GroupBy(author => new { author.Id, author.Name })
                .OrderByDescending(group => group.Sum(author => author.Books.Sum(book => book.Orders.Count(order => order.Time.Day == targetDate.Day))))
                .Select(group => new
                {
                    AuthorId = group.Key.Id,
                    AuthorName = group.Key.Name,
                    TotalNumberOfOrders = group.Sum(author => author.Books.Sum(book => book.Orders.Count(order => order.Time.Day == targetDate.Day)))
                })
                .Take(topAuthorCount);
            uow.Save();
        }
        private void TopWeekAuthor_Click(object sender, RoutedEventArgs e)
        {
            DateTime startDate = DateTime.Today.AddDays(-7);
            DateTime endDate = DateTime.Today;
            int topAuthorCount = 10;

            booksTable.ItemsSource = uow.AuthorRepo.Get(
                includeProperties: "Book")
                .Where(author => author.Books.Any(book => book.Orders.Any(order => order.Time.Day >= startDate.Day && order.Time.Day <= endDate.Day)))
                .GroupBy(author => new { author.Id, author.Name })
                .OrderByDescending(group => group.Sum(author => author.Books.Sum(book => book.Orders.Count(order => order.Time.Day >= startDate.Day && order.Time.Day <= endDate.Day))))
                .Select(group => new
                {
                    AuthorId = group.Key.Id,
                    AuthorName = group.Key.Name,
                    TotalNumberOfOrders = group.Sum(author => author.Books.Sum(book => book.Orders.Count(order => order.Time.Day >= startDate.Day && order.Time.Day <= endDate.Day)))
                })
                .Take(topAuthorCount);
            uow.Save();
        }
        private void TopMonthAuthor_Click(object sender, RoutedEventArgs e)
        {
            DateTime startDate = DateTime.Today.AddDays(-30);
            DateTime endDate = DateTime.Today;
            int topAuthorCount = 10;

            booksTable.ItemsSource = uow.AuthorRepo.Get(
                includeProperties: "Book")
                .Where(author => author.Books.Any(book => book.Orders.Any(order => order.Time.Day >= startDate.Day && order.Time.Day <= endDate.Day)))
                .GroupBy(author => new { author.Id, author.Name })
                .OrderByDescending(group => group.Sum(author => author.Books.Sum(book => book.Orders.Count(order => order.Time.Day >= startDate.Day && order.Time.Day <= endDate.Day))))
                .Select(group => new
                {
                    AuthorId = group.Key.Id,
                    AuthorName = group.Key.Name,
                    TotalNumberOfOrders = group.Sum(author => author.Books.Sum(book => book.Orders.Count(order => order.Time.Day >= startDate.Day && order.Time.Day <= endDate.Day)))
                })
                .Take(topAuthorCount);
            uow.Save();

        }
        private void TopYearAuthor_Click(object sender, RoutedEventArgs e)
        {
            DateTime startDate = DateTime.Today.AddDays(-365);
            DateTime endDate = DateTime.Today;
            int topAuthorCount = 10;

            booksTable.ItemsSource = uow.AuthorRepo.Get(
                includeProperties: "Book")
                .Where(author => author.Books.Any(book => book.Orders.Any(order => order.Time.Day >= startDate.Day && order.Time.Day <= endDate.Day)))
                .GroupBy(author => new { author.Id, author.Name })
                .OrderByDescending(group => group.Sum(author => author.Books.Sum(book => book.Orders.Count(order => order.Time.Day >= startDate.Day && order.Time.Day <= endDate.Day))))
                .Select(group => new
                {
                    AuthorId = group.Key.Id,
                    AuthorName = group.Key.Name,
                    TotalNumberOfOrders = group.Sum(author => author.Books.Sum(book => book.Orders.Count(order => order.Time.Day >= startDate.Day && order.Time.Day <= endDate.Day)))
                })
                .Take(topAuthorCount);
            uow.Save();
        }

        private void TopDayGenre_Click(object sender, RoutedEventArgs e)
        {
            DateTime targetDate = DateTime.Today; 
            int topGenreCount = 3;

            booksTable.ItemsSource = uow.GenreRepo.Get(
                includeProperties: "Book")
                .Where(genre => genre.Books.Any(book => book.Orders.Any(order => order.Time.Day == targetDate.Day)))
                .GroupBy(genre => new { genre.Id, genre.Name })
                .OrderByDescending(group => group.Sum(genre => genre.Books.Sum(book => book.Orders.Count(order => order.Time.Day == targetDate.Day))))
                .Select(group => new
                {
                    GenreId = group.Key.Id,
                    GenreName = group.Key.Name,
                    TotalNumberOfOrders = group.Sum(genre => genre.Books.Sum(book => book.Orders.Count(order => order.Time.Day == targetDate.Day)))
                })
                .Take(topGenreCount);
            uow.Save();
        }
        private void TopWeekGenre_Click(object sender, RoutedEventArgs e)
        {
            DateTime startDate = DateTime.Today.AddDays(-7);
            DateTime endDate = DateTime.Today;
            int topGenreCount = 3;

            booksTable.ItemsSource = uow.GenreRepo.Get(
                includeProperties: "Book")
                .Where(genre => genre.Books.Any(book => book.Orders.Any(order => order.Time.Day >= startDate.Day && order.Time.Day <= endDate.Day)))
                .GroupBy(genre => new { genre.Id, genre.Name })
                .OrderByDescending(group => group.Sum(genre => genre.Books.Sum(book => book.Orders.Count(order => order.Time.Day >= startDate.Day && order.Time.Day <= endDate.Day))))
                .Select(group => new
                {
                    GenreId = group.Key.Id,
                    GenreName = group.Key.Name,
                    TotalNumberOfOrders = group.Sum(genre => genre.Books.Sum(book => book.Orders.Count(order => order.Time.Day >= startDate.Day && order.Time.Day <= endDate.Day)))
                })
                .Take(topGenreCount);
            uow.Save();
        }
        private void TopMonthGenre_Click(object sender, RoutedEventArgs e)
        {
            DateTime startDate = DateTime.Today.AddDays(-30);
            DateTime endDate = DateTime.Today;
            int topGenreCount = 3;

            booksTable.ItemsSource = uow.GenreRepo.Get(
                includeProperties: "Book")
                .Where(genre => genre.Books.Any(book => book.Orders.Any(order => order.Time.Day >= startDate.Day && order.Time.Day <= endDate.Day)))
                .GroupBy(genre => new { genre.Id, genre.Name })
                .OrderByDescending(group => group.Sum(genre => genre.Books.Sum(book => book.Orders.Count(order => order.Time.Day >= startDate.Day && order.Time.Day <= endDate.Day))))
                .Select(group => new
                {
                    GenreId = group.Key.Id,
                    GenreName = group.Key.Name,
                    TotalNumberOfOrders = group.Sum(genre => genre.Books.Sum(book => book.Orders.Count(order => order.Time.Day >= startDate.Day && order.Time.Day <= endDate.Day)))
                })
                .Take(topGenreCount);
            uow.Save();
        }
        private void TopYearGenre_Click(object sender, RoutedEventArgs e)
        {
            DateTime startDate = DateTime.Today.AddDays(-365);
            DateTime endDate = DateTime.Today;
            int topGenreCount = 3;

            booksTable.ItemsSource = uow.GenreRepo.Get(
                includeProperties: "Book")
                .Where(genre => genre.Books.Any(book => book.Orders.Any(order => order.Time.Day >= startDate.Day && order.Time.Day <= endDate.Day)))
                .GroupBy(genre => new { genre.Id, genre.Name })
                .OrderByDescending(group => group.Sum(genre => genre.Books.Sum(book => book.Orders.Count(order => order.Time.Day >= startDate.Day && order.Time.Day <= endDate.Day))))
                .Select(group => new
                {
                    GenreId = group.Key.Id,
                    GenreName = group.Key.Name,
                    TotalNumberOfOrders = group.Sum(genre => genre.Books.Sum(book => book.Orders.Count(order => order.Time.Day >= startDate.Day && order.Time.Day <= endDate.Day)))
                })
                .Take(topGenreCount);
            uow.Save();
        }

        private void NewDay_Click(object sender, RoutedEventArgs e)
        {
            booksTable.ItemsSource = uow.BookRepo.Get(x => x.Orders.Any(x=> x.Time.Day == DateTime.Today.Day), includeProperties: "Author").Select(x => new
            {
                x.Id,
                x.Name,
                AuthorName = x.Author.Name,
                AuthorSurname = x.Author.Surname,
                x.Cost,
                x.Price,
                x.Year,

            });
            uow.Save();
        }
        private void NewWeek_Click(object sender, RoutedEventArgs e)
        {
            booksTable.ItemsSource = uow.BookRepo.Get(x => x.Orders.Any(x => x.Time.Day >= DateTime.Today.AddDays(-365).Day && x.Time.Day <= DateTime.Today.Day), includeProperties: "Author").Select(x => new
            {
                x.Id,
                x.Name,
                AuthorName = x.Author.Name,
                AuthorSurname = x.Author.Surname,
                x.Cost,
                x.Price,
                x.Year,

            });
            uow.Save();
        }
        private void NewMonth_Click(object sender, RoutedEventArgs e)
        {
            booksTable.ItemsSource = uow.BookRepo.Get(x => x.Orders.Any(x => x.Time.Day >= DateTime.Today.AddDays(-30).Day && x.Time.Day <= DateTime.Today.Day), includeProperties: "Author").Select(x => new
            {
                x.Id,
                x.Name,
                AuthorName = x.Author.Name,
                AuthorSurname = x.Author.Surname,
                x.Cost,
                x.Price,
                x.Year,

            });
            uow.Save();
        }
        private void NewYear_Click(object sender, RoutedEventArgs e)
        {
            booksTable.ItemsSource = uow.BookRepo.Get(x => x.Orders.Any(x => x.Time.Day >= DateTime.Today.AddDays(-365).Day && x.Time.Day <= DateTime.Today.Day), includeProperties: "Author").Select(x => new
            {
                x.Id,
                x.Name,
                AuthorName = x.Author.Name,
                AuthorSurname = x.Author.Surname,
                x.Cost,
                x.Price,
                x.Year,

            });
            uow.Save();
        }
    }
}
