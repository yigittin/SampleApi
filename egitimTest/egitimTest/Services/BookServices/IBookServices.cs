
using egitimTest.Modals.Books;

namespace egitimTest.Services.BookServices
{
    public interface IBookServices
    {
        
        public Task<List<Book>> GetBookList();
        public Task<Book>? GetBook(int id);
        public Task<Book> AddBook(Book book);

        public Task DeleteBook(int id); 
        public Task<Book>? EditBook(int id, Book book);
    }
}
