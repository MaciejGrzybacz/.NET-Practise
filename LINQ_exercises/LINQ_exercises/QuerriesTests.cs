using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace Bookstore.Tests
{
    public class BookstoreQueriesTests
    {
        private readonly Mock<DbSet<Book>> _mockBookDbSet;
        private readonly Mock<DbSet<Author>> _mockAuthorDbSet;
        private readonly Mock<AppDbContext> _mockContext;
        private readonly List<string> _output;

        public BookstoreQueriesTests()
        {
            var mockBooks = new List<Book>
            {
                new Book { Title = "1984", Price = 19.99m, YearPublished = 1949, AuthorId = 1},
                new Book { Title = "Animal Farm", Price = 9.99m, YearPublished = 1945, AuthorId = 1},
                new Book { Title = "Brave New World", Price = 14.99m, YearPublished = 1932, AuthorId = 2}
            }.AsQueryable();
            
            var mockAuthors = new List<Author>
            {
                new Author { Id = 1, Name = "George Orwell", Age = 46 },
                new Author { Id = 2, Name = "Aldous Huxley", Age = 69 }
            }.AsQueryable();
            
            _mockBookDbSet = new Mock<DbSet<Book>>();
            _mockBookDbSet.As<IQueryable<Book>>().Setup(m => m.Provider).Returns(mockBooks.Provider);
            _mockBookDbSet.As<IQueryable<Book>>().Setup(m => m.Expression).Returns(mockBooks.Expression);
            _mockBookDbSet.As<IQueryable<Book>>().Setup(m => m.ElementType).Returns(mockBooks.ElementType);
            _mockBookDbSet.As<IQueryable<Book>>().Setup(m => m.GetEnumerator()).Returns(mockBooks.GetEnumerator());
            
            _mockAuthorDbSet = new Mock<DbSet<Author>>();
            _mockAuthorDbSet.As<IQueryable<Author>>().Setup(m => m.Provider).Returns(mockAuthors.Provider);
            _mockAuthorDbSet.As<IQueryable<Author>>().Setup(m => m.Expression).Returns(mockAuthors.Expression);
            _mockAuthorDbSet.As<IQueryable<Author>>().Setup(m => m.ElementType).Returns(mockAuthors.ElementType);
            _mockAuthorDbSet.As<IQueryable<Author>>().Setup(m => m.GetEnumerator()).Returns(mockAuthors.GetEnumerator());

            _mockContext = new Mock<AppDbContext>();
            _mockContext.Setup(c => c.Books).Returns(_mockBookDbSet.Object);
            _mockContext.Setup(c => c.Authors).Returns(_mockAuthorDbSet.Object);

            _output = new List<string>();
        }

        [Fact]
        public void PrintAllBooks_ShouldPrintBooksToConsole()
        {
            using (var consoleOutput = new ConsoleOutput(_output))
            {
                BookstoreQueries.PrintAllBooks(_mockContext.Object);
            }
            
            Assert.Equal(4, _output.Count());
            Assert.Contains("Title: 1984, Price: 19,99, Year Published: 1949, Author ID: 1", _output);
            Assert.Contains("Title: Animal Farm, Price: 9,99, Year Published: 1945, Author ID: 1", _output);
            Assert.Contains("Title: Brave New World, Price: 14,99, Year Published: 1932, Author ID: 2", _output);
        }
    }

    public class ConsoleOutput : IDisposable
    {
        private readonly TextWriter _originalOutput;
        private readonly StringWriter _outputWriter;

        public ConsoleOutput(List<string> output)
        {
            _originalOutput = Console.Out;
            _outputWriter = new StringWriter();
            Console.SetOut(_outputWriter);
            Output = output;
        }

        public List<string> Output { get; }

        public void Dispose()
        {
            Console.SetOut(_originalOutput);
            Output.AddRange(_outputWriter.ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries));
            _outputWriter.Dispose();
        }
    }
}
