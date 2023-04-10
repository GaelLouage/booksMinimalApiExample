using MinimalApi.Classes;

namespace MinimalApi.Data
{
    public static class BookRepo
    {
       public static List<Book> Books = new List<Book>
            {
                new Book { Id = 1, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", Year = 1925 },           
                new Book { Id = 2, Title = "To Kill a Mockingbird", Author = "Harper Lee", Year = 1960 },           
                new Book { Id = 3, Title = "1984", Author = "George Orwell", Year = 1949 }
            };
    }
}
