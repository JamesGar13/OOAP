using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ooap_lab1_reserve
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.OutputEncoding = Encoding.UTF8;

            IBookCollection bookCollection = new BookCollectionProxy(true);

            bookCollection.Add(new Book("1984", "Джордж Орвелл"));
            bookCollection.Add(new Book("Сліди на дорозі", "Валерій Маркус"));

            var book = bookCollection.FindByAuthor("Джордж Орвелл");
            if (book != null)
            {
                Console.WriteLine($"Книгу знайдено: {book}");
            }
            else
            {
                Console.WriteLine("Книгу не знайдено");
            }

            bookCollection.Remove("Сліди на дорозі");

            var book1 = bookCollection.FindByAuthor("Валерій Маркус");
            if (book1 != null)
            {
                Console.WriteLine($"Книгу знайдено: {book1}");
            }
            else
            {
                Console.WriteLine("Книгу не знайдено");
            }


            IBookCollection unauthorizedCollection = new BookCollectionProxy(false);
            unauthorizedCollection.Add(new Book("Четверта шафка", "Скотт Коутон"));
            unauthorizedCollection.Remove("Четверта шафка");
        }

    }
}
