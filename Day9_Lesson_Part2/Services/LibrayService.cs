using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Day9_Lesson_Part2.IService;
using Day9_Lesson_Part2.Models;

namespace Day9_Lesson_Part2.Services
{
    public class LibrayService : ILibraryService
    {
        private Library _library;
        public LibrayService(Library library)
        {
            _library = library;
        }
        public List<Book> FindAllBooks(Func<Book,bool> predicate)
        {
            List<Book> result = _library.Books.Where(predicate).ToList();
            if (result == null)
            {
                Console.WriteLine($"Tapilmadi");
                return result;
            }
            return result;
        }

        public bool RemoveAllBooks(Func<Book,bool> predicate)
        {
            var result = _library.Books.Where(predicate).ToList();
            if (result == null)
            {
                Console.WriteLine($"Kitab bazada movcud deyil");
                return false;
            }

            foreach (var item in result)
            {
                _library.Books.Remove(item);
            }
            Console.WriteLine($"Kitablar Silindi");
            return true;
        }

        public List<Book> SearcBooks(Func<Book, bool> predicate)
        {
            var result = _library.Books.Where(predicate).ToList();
            if (result == null)
            {
                Console.WriteLine("Kitab tapilmadi");
                return result;
            }
            return result;
        }

        public List<Book> FindAllBooksbyPageCountRange(Func<Book,bool> predicate)
        {
            var result = _library.Books.Where(predicate).ToList();
            if (result == null)
            {
                Console.WriteLine("Kitab tapilmadi");
                return result;
            }

            return result;
        }

        public void RemoveBook(Func<Book, bool> predicate)
        {
            var result = _library.Books.Where(predicate);
            if (result == null)
            {
                Console.WriteLine($"Kitab tapilmadi");

            }
            else
            {
                _library.Books.Remove(result.ToList()[0]);
                Console.WriteLine($"Kitab silindi");
            }

        }
    }
}
