using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Assignment3;

namespace SimpleRESTService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        // GET: api/Book
        [HttpGet]
        public ActionResult<IEnumerable<Book>> Get()
        {
            return books;
        }

        // GET: api/Book/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<Book> Get(string id)
        {
            return books.Find(i => i.Isbn13 == id);
        }

        // POST: api/Book
        [HttpPost]
        public void Post([FromBody] Book book)

        {
            books.Add(book);
        }

        // PUT: api/Book/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] Book book)
        {

            Delete(id);
            Post(book);

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            books.RemoveAll(i => i.Isbn13 == id);
            ////books.Remove(book);
        }

        List<Book> books = new List<Book>()
        {
            new Book("9876543210765","Animals","Brown",100),
            new Book("9081234567521","Read", "Marc", 170),
            new Book ("9867423167032","Life","Bobi", 125),
            new Book ("9780012345109","Cars", "Joe",180),
        };
    }
}
