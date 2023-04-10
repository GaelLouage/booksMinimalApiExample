using MinimalApi.Classes;
using MinimalApi.Data;
using System.Runtime.CompilerServices;
using static System.Reflection.Metadata.BlobBuilder;

namespace MinimalApi.Services
{
    public static class BookService
    {
        public static RouteHandlerBuilder BookList(this WebApplication app)
        {
            return app.MapGet("/books", () => BookRepo.Books);
        }


        public static RouteHandlerBuilder BookById(this WebApplication app)
        {
            return app.MapGet("/books/{id}", (int id) =>
            {
                var book = BookRepo.Books.FirstOrDefault(b => b.Id == id);
                return book != null ? Results.Ok(book) : Results.NotFound();
            });
        }

        public static RouteHandlerBuilder BookPost(this WebApplication app)
        {
            return app.MapPost("/books", (Book book) =>
            {
                book.Id = BookRepo.Books.Count + 1;
                BookRepo.Books.Add(book);
                return Results.Created($"/books/{book.Id}", book);
            });
        }

        public static RouteHandlerBuilder BookUpdate(this WebApplication app)
        {
            return app.MapPut("/books/{id}", (int id, Book book) =>
            {
                var existingBook = BookRepo.Books.FirstOrDefault(b => b.Id == id);
                if (existingBook == null)
                {
                    return Results.NotFound();
                }
                existingBook.Title = book.Title;
                existingBook.Author = book.Author;
                existingBook.Year = book.Year;
                return Results.Ok(existingBook);
            });
        }

        public static RouteHandlerBuilder BookDelete(this WebApplication app)
        {
            return app.MapDelete("/books/{id}", (int id) =>
            {
                var book = BookRepo.Books.FirstOrDefault(b => b.Id == id);
                if (book == null)
                {
                    return Results.NotFound();
                }
                BookRepo.Books.Remove(book);
                return Results.NoContent();
            });
        }
    }
}
