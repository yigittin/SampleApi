using egitimTest.Data;
using egitimTest.Modals.Books;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace egitimTest.Services.BookServices
{
    public class BookServices : IBookServices
    {
        private readonly AppDbContext _context;
        public BookServices(AppDbContext context)
        {
            _context = context;            
        }

        public async Task<List<Book>> GetBookList()
        {
            var entity = await _context.Book.ToListAsync();
            return entity;
        }

        public async Task<Book> GetBook(int id)
        {
            var entity=await _context.Book.FindAsync(id);
            if(entity is null)
                    return null;
            return entity;
        }
        public async Task DeleteBook(int id)
        {
            var entity = await _context.Book.FindAsync(id);
            if (entity is null)
                return;
            _context.Book.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<Book> EditBook(int id, Book book)
        {
            var entity = await _context.Book.FindAsync(id);
            if (entity is null)
                return null;
            if (book.YayinEvi!=entity.YayinEvi)
            {
                entity.YayinEvi=book.YayinEvi;
            }
            if(book.Aciklama!=entity.Aciklama)
            {
                entity.Aciklama=book.Aciklama;
            }
            if(book.Adi!=entity.Adi)
            {
                entity.Adi=book.Adi;
            }
            if(book.PageCount!=entity.PageCount)
            {
                entity.PageCount=book.PageCount;
            }

            await _context.SaveChangesAsync();
            var res= await _context.Book.FindAsync(id);
            return res;
        }

        public async Task<Book> AddBook(Book book)
        {
            var entity=new Book{
                Aciklama= book.Aciklama,
                Adi= book.Adi,
                PageCount= book.PageCount,
                YayinEvi= book.YayinEvi,
            };
            await _context.Book.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
