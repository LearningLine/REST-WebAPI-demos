using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Mod01.Api
{
    public class BooksController : ApiController
    {
        //[HttpGet]
        public Book[] GetBooks()
        {
            return new Book[]
            {
                new Book()
                {
                    Title = "The REST book"
                }, 
            };
        }
    }


    public class Book
    {
        public string Title { get; set; }
    }
}