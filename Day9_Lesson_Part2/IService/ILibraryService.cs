using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Day9_Lesson_Part2.Models;

namespace Day9_Lesson_Part2.IService
{
    public interface ILibraryService
    {
        List<Book> FindAllBooks(Func<Book, bool> predicate);
        bool RemoveAllBooks(Func<Book, bool> predicate);
        List<Book> SearcBooks(Func<Book,bool> predicate);
        List<Book> FindAllBooksbyPageCountRange(Func<Book, bool> predicate);
        void RemoveBook(Func<Book, bool> predicate);
    }
}
