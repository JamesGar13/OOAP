using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ooap_lab1_reserve
{
    public interface IBookCollection
    {
        void Add(Book book);
        void Remove(string title);
        Book FindByAuthor(string author);
    }
    #region BookCollection
    public class BookCollection : IBookCollection
    {
        private List<Book> books = new List<Book>();
        public void Add(Book book)
        {
            books.Add(book);
            Console.WriteLine($"Книгу додано: {book}");
        }
        public void Remove(string title) 
        {
            var bookToRemove = books.FirstOrDefault(b => b.Title == title);
            if (bookToRemove != null)
            {
                books.Remove(bookToRemove);
                Console.WriteLine($"Книгу видалено: {bookToRemove}");
            }
            else
            {
                Console.WriteLine("Книгу не знайдено");
            }
        }
        public Book FindByAuthor(string author) 
        {
            return books.FirstOrDefault(b => b.Author == author);
        }

    }
    #endregion

    #region Proxy
    public class BookCollectionProxy : IBookCollection
    {
        private BookCollection bookCollection;
        private bool isAuthorized;

        public BookCollectionProxy(bool isAuthorized)
        {
            this.isAuthorized = isAuthorized;
            bookCollection = new BookCollection();
        }

        public void Add(Book book) 
        {
        if (isAuthorized) 
            {
                bookCollection.Add(book);
            }
        else
            {
                Console.WriteLine("Невірний доступ: неможливе додавання");
            }
        }
        public void Remove(string title) 
        {
            if (isAuthorized)
            {
                bookCollection.Remove(title);
            }
            else
            {
                Console.WriteLine("Невірний доступ: неможливе видалення");
            }
        }
        public Book FindByAuthor(string author) 
        {
            if (isAuthorized)
            {
                return bookCollection.FindByAuthor(author);
            }
            else
            {
                Console.WriteLine("Невірний доступ: неможливий пошук");
                return null;
            }
        }
    }
    #endregion


}
