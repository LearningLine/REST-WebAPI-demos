using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using Mod04.Models;

namespace Mod04.Api
{
    public class BooksController : ApiController
    {
        private readonly IBooksRepository _repo = new BooksRepository();

        // GET api/books
        public Task<IEnumerable<Book>> Get()
        {
            return _repo.GetBooks();
        }

        // GET api/books/5
        public async Task<HttpResponseMessage> Get(int id)
        {
            var book = await _repo.GetBook(id);
            if (book == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            book.Title = DateTime.Now.ToLongTimeString();
            var response = Request.CreateResponse(HttpStatusCode.OK, book);

            //response.Headers.CacheControl = new CacheControlHeaderValue();

            return response;
        }
    }
}
