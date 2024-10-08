﻿using System;
using Bookstore;

class Program
{
    // static void Main(string[] args)
    // {
    //     using (var context = new AppDbContext())
    //     {
    //         context.EnsureDbCreated();
    //         
    //         if(!context.Books.Any() && !context.Authors.Any())
    //             BookstoreQueries.SeedDatabase(context);
    //         else
    //             Console.WriteLine("Database already seeded.");
    //         
    //         RunAllQuerries(context);
    //     }
    // }
    public static void RunAllQuerries(AppDbContext context)
    {
        BookstoreQueries.PrintAllBooks(context);
        BookstoreQueries.PrintAllBooksPublishedInYear(context, 2000);
        BookstoreQueries.PrintAllAuthorsAndTheirBooks(context);
        BookstoreQueries.PrintAllBooksWithPriceBetweenBoundaries(context, 10, 20);
        BookstoreQueries.PrintAllAuthorsWhichWrittenMoreThanTwoBooks(context);
        BookstoreQueries.PrintAllBooksWithNameContainingString(context, "Harry");
        BookstoreQueries.PrintAllAuthorsInAgeRangeInOrder(context, 50, 70);
        BookstoreQueries.PrintAllAuthorsWhichWrittenABookIn2024(context);
        BookstoreQueries.PrintMostExpensiveBook(context);
        BookstoreQueries.PrintAllBooksByAuthorName(context, "J.K. Rowling");
        BookstoreQueries.PrintBooksWithHighestPriceByYear(context);
        BookstoreQueries.PrintAuthorsWithBooksPricedOver(context, 20);
        BookstoreQueries.PrintBooksAndAuthorsWithPriceLessThan(context, 15);
        BookstoreQueries.PrintAuthorsWithBooksInMultipleYears(context);
        BookstoreQueries.PrintBooksPricedAboveAverage(context);
        BookstoreQueries.PrintAverageBookPricePerAuthor(context);
        BookstoreQueries.PrintBooksWithTitleLongerThan(context, 20);
        BookstoreQueries.PrintBooksByAuthorsStartingWith(context, 'J');
        BookstoreQueries.PrintAuthorsOrderedByBookCount(context);
        BookstoreQueries.PrintUniquePublicationYears(context);
    }
}