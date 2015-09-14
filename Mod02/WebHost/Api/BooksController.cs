using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using RestDemo.Models;

namespace WebHost.Api
{
    public class BooksController : ApiController
    {
        private IBooksRepository _repo = new BooksRepository();

        public Task<IEnumerable<Book>> Get()
        {
            return _repo.GetBooks();
        }

        public async Task<HttpResponseMessage> Get(int id)
        {
            var book = await _repo.GetBook(id);

            if (book == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, book);
        }
    }
}