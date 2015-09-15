using System;
using System.Collections.Generic;
using System.Linq;

namespace Mod07.Models
{
    public interface IBooksRepository : IDisposable
    {
        IQueryable<Book> GetBooks();
        Book GetBook(int id);
        Book AddBook(Book newBook);
        Book UpdateBook(Book newBook);
        void DeleteBook(int id);
    }
}