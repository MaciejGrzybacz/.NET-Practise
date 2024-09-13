using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Bookstore
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public List<Book> Books { get; set; }
    }

    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int YearPublished { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }

    public class AppDbContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = Path.Combine(Directory.GetCurrentDirectory(), "bookstore.db");
            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
                .HasMany(a => a.Books)
                .WithOne(b => b.Author)
                .HasForeignKey(b => b.AuthorId);
        }
        
        public void EnsureDbCreated()
        {
            Database.EnsureCreated();
        }
    }

    public static class BookstoreQueries
    {
        public static void PrintAllBooks(AppDbContext context)
        {
            var result = context.Books.Select(book => new { book.Title, book.Price, book.YearPublished, book.AuthorId })
                .ToList();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("All books:");
            Console.ResetColor();
            foreach (var book in result)
                Console.WriteLine(
                    $"Title: {book.Title}, Price: {book.Price}, Year Published: {book.YearPublished}, Author ID: {book.AuthorId}");
        }

        public static void PrintAllBooksPublishedInYear(AppDbContext context, int year)
        {
            var result = context.Books.Where(book => book.YearPublished == year).ToList();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Books published in {year}:");
            Console.ResetColor();
            foreach (var book in result)
                Console.WriteLine(
                    $"Title: {book.Title}, Price: {book.Price}, Year Published: {book.YearPublished}, Author ID: {book.AuthorId}");
        }

        public static void PrintAllAuthorsAndTheirBooks(AppDbContext context)
        {
            var result = context.Books.Join(context.Authors, book => book.AuthorId, author => author.Id,
                (book, author) => new
                {
                    book.Title,
                    book.Price,
                    book.YearPublished,
                    author.Name
                }).ToList();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("All authors and their books:");
            Console.ResetColor();
            foreach (var book in result)
                Console.WriteLine(
                    $"Title : {book.Title}, Price : {book.Price}, Published in : {book.YearPublished}, Author Name : {book.Name}");
        }

        public static void PrintAllBooksWithPriceBetweenBoundaries(AppDbContext context, int min, int max)
        {
            var result = context.Books.Where(book => book.Price >= min && book.Price <= max).ToList();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Books with price between {min} and {max}:");
            Console.ResetColor();
            foreach (var book in result) Console.WriteLine($"Title: {book.Title}, Price: {book.Price}");
        }

        public static void PrintAllAuthorsWhichWrittenMoreThanTwoBooks(AppDbContext context)
        {
            var result = context.Authors
                .Join(context.Books, author => author.Id, book => book.AuthorId,
                    (author, book) => new { Author = author, Book = book })
                .GroupBy(ab => ab.Author)
                .Select(group => new { AuthorName = group.Key.Name, BookCount = group.Count() })
                .Where(author => author.BookCount > 2).ToList();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Authors who have written more than two books:");
            Console.ResetColor();
            foreach (var author in result)
                Console.WriteLine($"Name: {author.AuthorName}, Number of books written: {author.BookCount}");
        }

        public static void PrintAllBooksWithNameContainingString(AppDbContext context, string str)
        {
            var result = context.Books.Where(book => book.Title.Contains(str)).ToList();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Books with title containing '{str}':");
            Console.ResetColor();
            foreach (var book in result) Console.WriteLine($"Title: {book.Title}");
        }

        public static void PrintAllAuthorsInAgeRangeInOrder(AppDbContext context, int min, int max)
        {
            var result = context.Authors.Where(author => author.Age >= min && author.Age <= max)
                .OrderBy(author => author.Age);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Authors in age range {min} - {max} in order:");
            Console.ResetColor();
            foreach (var author in result) Console.WriteLine($"Name: {author.Name}, Age: {author.Age}");
        }

        public static void PrintAllAuthorsWhichWrittenABookIn2024(AppDbContext context)
        {
            var result = context.Authors
                .Join(context.Books, author => author.Id, book => book.AuthorId,
                    (author, book) => new { author.Name, book.YearPublished })
                .Where(ab => ab.YearPublished == 2024)
                .ToList();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Authors who have written a book in 2024:");
            Console.ResetColor();
            foreach (var author in result) Console.WriteLine($"Name: {author.Name}");
        }

        public static void PrintMostExpensiveBook(AppDbContext context)
        {
            var result = context.Books.AsEnumerable().OrderBy(book => book.Price).LastOrDefault();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Most expensive book:");
            Console.ResetColor();
            if (result != null)
                Console.WriteLine($"Title: {result.Title}, Price: {result.Price}");
            else
                Console.WriteLine("No books found.");
        }

        public static void PrintAllBooksByAuthorName(AppDbContext context, string authorName)
        {
            var result = context.Books
                .Join(context.Authors, book => book.AuthorId, author => author.Id,
                    (book, author) => new
                    {
                        book.Title, Author = author.Name, book.Price, book.YearPublished
                    })
                .Where(ab => ab.Author == authorName)
                .ToList();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Books by author '{authorName}':");
            Console.ResetColor();
            foreach (var book in result)
                Console.WriteLine($"Title: {book.Title}, Price: {book.Price}, Year Published: {book.YearPublished}");
        }

        public static void PrintBooksWithHighestPriceByYear(AppDbContext context)
        {
            var result = context.Books.AsEnumerable()
                .GroupBy(book => book.YearPublished)
                .Select(group => new
                {
                    Year = group.Key,
                    MostExpensiveBook = group.OrderByDescending(book => book.Price).FirstOrDefault()
                })
                .OrderBy(book => book.Year)
                .ToList();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Most expensive book by year:");
            Console.ResetColor();
            foreach (var entry in result)
                if (entry.MostExpensiveBook != null)
                    Console.WriteLine(
                        $"Year: {entry.Year}, Title: {entry.MostExpensiveBook.Title}, Price: {entry.MostExpensiveBook.Price}");
        }

        public static void PrintAuthorsWithBooksPricedOver(AppDbContext context, decimal priceThreshold)
        {
            var result = context.Books
                .Join(context.Authors, book => book.AuthorId, author => author.Id,
                    (book, author) => new { author.Name, book.Title, book.Price })
                .Where(ab => ab.Price > priceThreshold)
                .Select(ab => ab.Name)
                .Distinct()
                .ToList();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Authors with books priced over {priceThreshold}:");
            Console.ResetColor();
            foreach (var authorName in result) Console.WriteLine($"Author: {authorName}");
        }

        public static void PrintBooksAndAuthorsWithPriceLessThan(AppDbContext context, decimal priceThreshold)
        {
            var result = context.Books
                .AsEnumerable()
                .Where(book => book.Price < priceThreshold)
                .Join(context.Authors, book => book.AuthorId, author => author.Id,
                    (book, author) => new { book.Title, AuthorName = author.Name, book.Price })
                .OrderBy(ab => ab.Price)
                .ToList();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Books with price less than {priceThreshold}:");
            Console.ResetColor();
            foreach (var entry in result)
                Console.WriteLine($"Book Title: {entry.Title}, Author Name: {entry.AuthorName}, Price: {entry.Price}");
        }

        public static void PrintAuthorsWithBooksInMultipleYears(AppDbContext context)
        {
            var result = context.Books
                .GroupBy(book => book.AuthorId)
                .Select(group => new
                {
                    Id = group.Key,
                    Years = group.Select(book => book.YearPublished).Distinct().Count()
                })
                .Where(author => author.Years > 1)
                .Join(context.Authors, author => author.Id, auth => auth.Id,
                    (author, auth) => new { auth.Name })
                .ToList();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Authors with books published in multiple years:");
            Console.ResetColor();
            foreach (var author in result) Console.WriteLine($"Author: {author.Name}");
        }

        public static void PrintBooksPricedAboveAverage(AppDbContext context)
        {
            var avg = context.Books.AsEnumerable().Average(book => book.Price);
            var result = context.Books
                .AsEnumerable()
                .Where(book => book.Price > avg)
                .ToList();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Books priced above average:");
            Console.ResetColor();
            foreach (var book in result) Console.WriteLine($"Title: {book.Title}, Price: {book.Price}");
        }

        public static void PrintAverageBookPricePerAuthor(AppDbContext context)
        {
            var result = context.Books
                .AsEnumerable()
                .GroupBy(book => book.AuthorId)
                .Select(group => new
                {
                    AuthorId = group.Key,
                    PriceAVG = group.Average(book => book.Price)
                })
                .Join(context.Authors, arg => arg.AuthorId, author => author.Id, (arg1, author) => new
                {
                    AuthorName = author.Name,
                    AveragePrice = arg1.PriceAVG
                })
                .ToList();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Average book price per author:");
            Console.ResetColor();
            foreach (var entry in result)
                Console.WriteLine($"Author: {entry.AuthorName}, Average Price: {entry.AveragePrice}");
        }

        public static void PrintBooksWithTitleLongerThan(AppDbContext context, int length)
        {
            var result = context.Books
                .Where(book => book.Title.Length > length);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Books with title longer than {length} characters:");
            Console.ResetColor();
            foreach (var book in result) Console.WriteLine($"Title: {book.Title}");
        }

        public static void PrintBooksByAuthorsStartingWith(AppDbContext context, char initial)
        {
            var result = context.Authors
                .AsEnumerable()
                .Where(author => author.Name.StartsWith(initial))
                .Join(context.Books, author => author.Id, book => book.AuthorId,
                    (author, book) => new { book.Title, AuthorName = author.Name })
                .ToList();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Books by authors whose name starts with '{initial}':");
            Console.ResetColor();
            foreach (var entry in result) Console.WriteLine($"Title: {entry.Title}, Author Name: {entry.AuthorName}");
        }

        public static void PrintAuthorsOrderedByBookCount(AppDbContext context)
        {
            var result = context.Books
                .GroupBy(book => book.AuthorId)
                .Select(group => new
                {
                    AuthorId = group.Key,
                    BookCount = group.Count()
                })
                .Join(context.Authors, ab => ab.AuthorId, author => author.Id,
                    (ab, author) => new { author.Name, ab.BookCount })
                .OrderByDescending(ab => ab.BookCount)
                .ToList();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Authors ordered by book count:");
            Console.ResetColor();
            foreach (var author in result) Console.WriteLine($"Author: {author.Name}, Book Count: {author.BookCount}");
        }

        public static void PrintUniquePublicationYears(AppDbContext context)
        {
            var result = context.Books
                .Select(book => book.YearPublished)
                .Distinct()
                .ToList();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Unique publication years:");
            Console.ResetColor();
            foreach (var year in result) Console.WriteLine($"Year: {year}");
        }
        
        public static void SeedDatabase(AppDbContext context)
        {
            var authors = new List<Author>
            {
                new()
                {
                    Name = "George Orwell", Age = 46, Books = new List<Book>
                    {
                        new() { Title = "1984", Price = 19.99m, YearPublished = 1949 }
                    }
                },
                new()
                {
                    Name = "J.K. Rowling", Age = 58, Books = new List<Book>
                    {
                        new() { Title = "Harry Potter and the Philosopher's Stone", Price = 24.99m, YearPublished = 1997 },
                        new() { Title = "Harry Potter and the Chamber of Secrets", Price = 24.99m, YearPublished = 1998 },
                        new() { Title = "Harry Potter and the Prisoner of Azkaban", Price = 24.99m, YearPublished = 1999 },
                        new() { Title = "Harry Potter and the Goblet of Fire", Price = 24.99m, YearPublished = 2000 },
                        new() { Title = "Harry Potter and the Order of the Phoenix", Price = 24.99m, YearPublished = 2003 },
                        new() { Title = "Harry Potter and the Half-Blood Prince", Price = 24.99m, YearPublished = 2005 },
                        new() { Title = "Harry Potter and the Deathly Hallows", Price = 24.99m, YearPublished = 2007 }
                    }
                },
                new()
                {
                    Name = "J.R.R. Tolkien", Age = 81, Books = new List<Book>
                    {
                        new() { Title = "The Hobbit", Price = 15.99m, YearPublished = 1937 },
                        new() { Title = "The Lord of the Rings: The Fellowship of the Ring", Price = 29.99m, YearPublished = 1954 },
                        new() { Title = "The Lord of the Rings: The Two Towers", Price = 29.99m, YearPublished = 1954 },
                        new() { Title = "The Lord of the Rings: The Return of the King", Price = 29.99m, YearPublished = 1955 },
                        new() { Title = "The Silmarillion", Price = 24.99m, YearPublished = 1977 }
                    }
                },
                new()
                {
                    Name = "Agatha Christie", Age = 85, Books = new List<Book>
                    {
                        new() { Title = "Murder on the Orient Express", Price = 12.99m, YearPublished = 1934 },
                        new() { Title = "And Then There Were None", Price = 12.99m, YearPublished = 1939 },
                        new() { Title = "The Murder of Roger Ackroyd", Price = 12.99m, YearPublished = 1926 },
                        new() { Title = "The ABC Murders", Price = 12.99m, YearPublished = 1936 }
                    }
                },
                new()
                {
                    Name = "Stephen King", Age = 76, Books = new List<Book>
                    {
                        new() { Title = "The Shining", Price = 18.99m, YearPublished = 1977 },
                        new() { Title = "It", Price = 18.99m, YearPublished = 1986 },
                        new() { Title = "Misery", Price = 18.99m, YearPublished = 1987 },
                        new() { Title = "Carrie", Price = 18.99m, YearPublished = 1974 },
                        new() { Title = "Pet Sematary", Price = 18.99m, YearPublished = 1983 },
                        new() { Title = "The Dark Tower: The Gunslinger", Price = 18.99m, YearPublished = 1982 },
                        new() { Title = "The Dark Tower: The Drawing of the Three", Price = 18.99m, YearPublished = 1987 },
                        new() { Title = "The Dark Tower: The Waste Lands", Price = 18.99m, YearPublished = 1991 },
                        new() { Title = "The Dark Tower: Wizard and Glass", Price = 18.99m, YearPublished = 1997 },
                        new() { Title = "The Dark Tower: Wolves of the Calla", Price = 18.99m, YearPublished = 2003 },
                        new() { Title = "The Dark Tower: Song of Susannah", Price = 18.99m, YearPublished = 2004 },
                        new() { Title = "The Dark Tower: The Dark Tower", Price = 18.99m, YearPublished = 2004 }
                    }
                },
                new()
                {
                    Name = "Isaac Asimov", Age = 72, Books = new List<Book>
                    {
                        new() { Title = "Foundation", Price = 14.99m, YearPublished = 1951 },
                        new() { Title = "Foundation and Empire", Price = 14.99m, YearPublished = 1952 },
                        new() { Title = "Second Foundation", Price = 14.99m, YearPublished = 1953 },
                        new() { Title = "Foundation's Edge", Price = 14.99m, YearPublished = 1982 },
                        new() { Title = "Foundation and Earth", Price = 14.99m, YearPublished = 1986 },
                        new() { Title = "The Gods Themselves", Price = 14.99m, YearPublished = 1972 }
                    }
                },
                new()
                {
                    Name = "J.D. Salinger", Age = 91, Books = new List<Book>
                    {
                        new() { Title = "The Catcher in the Rye", Price = 10.99m, YearPublished = 1951 }
                    }
                },
                new()
                {
                    Name = "H.G. Wells", Age = 79, Books = new List<Book>
                    {
                        new() { Title = "The War of the Worlds", Price = 13.99m, YearPublished = 1898 },
                        new() { Title = "The Invisible Man", Price = 13.99m, YearPublished = 1897 },
                        new() { Title = "The Time Machine", Price = 13.99m, YearPublished = 1895 },
                        new() { Title = "The Island of Doctor Moreau", Price = 13.99m, YearPublished = 1896 }
                    }
                },
                new()
                {
                    Name = "Orson Scott Card", Age = 71, Books = new List<Book>
                    {
                        new() { Title = "Ender's Game", Price = 16.99m, YearPublished = 1985 },
                        new() { Title = "Speaker for the Dead", Price = 16.99m, YearPublished = 1986 },
                        new() { Title = "Xenocide", Price = 16.99m, YearPublished = 1991 },
                        new() { Title = "Children of the Mind", Price = 16.99m, YearPublished = 1996 }
                    }
                },
                new()
                {
                    Name = "Philip K. Dick", Age = 53, Books = new List<Book>
                    {
                        new() { Title = "Do Androids Dream of Electric Sheep?", Price = 15.99m, YearPublished = 1968 },
                        new() { Title = "The Man in the High Castle", Price = 15.99m, YearPublished = 1962 },
                        new() { Title = "Ubik", Price = 15.99m, YearPublished = 1969 },
                        new() { Title = "A Scanner Darkly", Price = 15.99m, YearPublished = 1977 }
                    }
                },
                new()
                {
                    Name = "Douglas Adams", Age = 59, Books = new List<Book>
                    {
                        new() { Title = "The Hitchhiker's Guide to the Galaxy", Price = 14.99m, YearPublished = 1979 },
                        new() { Title = "The Restaurant at the End of the Universe", Price = 14.99m, YearPublished = 1980 },
                        new() { Title = "Life, the Universe and Everything", Price = 14.99m, YearPublished = 1982 },
                        new() { Title = "So Long, and Thanks for All the Fish", Price = 14.99m, YearPublished = 1984 },
                        new() { Title = "Mostly Harmless", Price = 14.99m, YearPublished = 1992 }
                    }
                },
                new()
                {
                    Name = "Margaret Atwood", Age = 83, Books = new List<Book>
                    {
                        new() { Title = "The Handmaid's Tale", Price = 18.99m, YearPublished = 1985 },
                        new() { Title = "Oryx and Crake", Price = 18.99m, YearPublished = 2003 },
                        new() { Title = "The Year of the Flood", Price = 18.99m, YearPublished = 2009 },
                        new() { Title = "MaddAddam", Price = 18.99m, YearPublished = 2013 }
                    }
                }
            };

            context.Authors.AddRange(authors);
            context.SaveChanges();
        }
    }
}
