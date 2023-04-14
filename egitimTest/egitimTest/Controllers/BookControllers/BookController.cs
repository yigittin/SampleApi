using egitimTest.Modals.Books;
using egitimTest.Services.BookServices;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace egitimTest.Controllers.BookControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookServices _bookService;

        public BookController(IBookServices bookServices)
        {
            _bookService = bookServices;
        }
        // GET: api/<BookController>
        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetBookList()
        {
            return await _bookService.GetBookList();
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> Get(int id)
        {
            var res= await _bookService.GetBook(id);
            if (res == null)
            {
                return NotFound("Book Not Found");
            }
            return Ok(res);
        }

        // POST api/<BookController>
        [HttpPost]
        public async Task<ActionResult<Book>> AddBook([FromBody]Book book)
        {
            var res=await _bookService.AddBook(book);
            if(res == null)
            {
                return NotFound("Couldn't Add The Book");
            }
            return Ok(res);
        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Book>> EditBook(int id, [FromBody] Book book)
        {
            var res = await _bookService.EditBook(id, book);
            if(res == null)
            {
                return NotFound("Book Not Edited");
            }
            return Ok(res);
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _bookService.DeleteBook(id);
            return Ok();
        }

    }
}
