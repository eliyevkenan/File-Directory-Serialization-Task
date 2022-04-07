using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp77
{
    internal class Library
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Book> Books { get; set; } = new List<Book>();
        public void AddBook(Book book)
        {
            if (book == null)
            {
                throw new Exception("Xeta");
            }
            Books.Add(book);
        }
        public List<Book> GetBookById(int Id)
        {
            var result = Books.FindAll(x => x.Id == Id);
            if (result.Count == 0)
            {
                throw new Exception("Xeta");
            }
            return result;
        }
        public void RemoveBook(int? Id)
        {
            if (Id == null)
            {
                throw new Exception("Xeta");
            }
            var result = Books.Find(x => x.Id == Id);
            if (result == null)
            {
                throw new Exception("Xeta");
            }
            Books.Remove(result);

        }

        internal object GetBookById(object enterId)
        {
            throw new NotImplementedException();
        }

    }
}
