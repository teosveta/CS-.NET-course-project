/*
 * ============================================================================
 * БИБЛИОТЕЧНА СИСТЕМА - Клас за управление на библиотеката
 * ============================================================================
 * 
 * Проект по "Основи на програмиране на приложения с Microsoft Visual C# .NET"
 * 
 * Автор: Теосвета Красимирова Велкова
 * Факултетен номер: F108355
 * 
 * Дата на създаване: 2025
 * 
 * Описание на файла:
 * Този файл съдържа дефиницията на класа Library и делегата LibraryNotification.
 * Класът Library управлява колекция от книги и предоставя методи за
 * добавяне, заемане, връщане и търсене на книги.
 * 
 * ООП Концепции в този клас:
 * 1. ДЕЛЕГАТИ (Delegates) - LibraryNotification за callback известия
 * 2. КОЛЕКЦИИ - List<Book> за съхранение на книги
 * 3. ЕНКАПСУЛАЦИЯ - private поле books, public методи за достъп
 * 4. ПОЛИМОРФИЗЪМ - колекцията съдържа Book и EBook обекти
 * 
 * ============================================================================
 */

using System;
using System.Collections.Generic;  // Необходимо за List<T>

namespace LibraryProject
{
    /*
     * ========================================
     * ДЕЛЕГАТ (Delegate)
     * ========================================
     * 
     * ООП Концепция: ДЕЛЕГАТИ
     * - Делегатът е тип, който представлява референция към метод
     * - Можем да го мислим като "указател към функция"
     * - Позволява да предаваме методи като параметри
     * - Използва се за callback механизми и събития
     * 
     * Синтаксис: delegate връщан_тип ИмеДелегат(параметри);
     * 
     * В този случай LibraryNotification е делегат, който:
     * - Не връща стойност (void)
     * - Приема един параметър от тип string (съобщение)
     */

    /// <summary>
    /// Делегат за известяване при действия в библиотеката.
    /// Методите, които съответстват на този делегат, трябва:
    /// - Да не връщат стойност (void)
    /// - Да приемат един string параметър
    /// </summary>
    /// <param name="message">Съобщението за известяване</param>
    public delegate void LibraryNotification(string message);

    /// <summary>
    /// Клас Library - управлява колекция от книги в библиотеката.
    /// 
    /// Този клас демонстрира:
    /// - Използване на колекции (List&lt;Book&gt;)
    /// - Използване на делегати за callback известия
    /// - Енкапсулация чрез private полета и public методи
    /// </summary>
    public class Library
    {
        /*
         * ========================================
         * ПОЛЕТА (Fields)
         * ========================================
         * 
         * ООП Концепция: ЕНКАПСУЛАЦИЯ
         * - Полето "books" е private - не може да се достъпи директно отвън
         * - Достъпът до данните става само чрез public методи
         * - Това защитава данните от неправилна употреба
         */

        /// <summary>
        /// Колекция (списък) от книги в библиотеката.
        /// 
        /// ООП Концепция: КОЛЕКЦИИ
        /// - List&lt;Book&gt; е generic колекция, която съхранява обекти от тип Book
        /// - Благодарение на полиморфизма, в този списък могат да се добавят
        ///   и обекти от тип EBook (защото EBook наследява Book)
        /// - private - достъпно само в този клас
        /// </summary>
        private List<Book> books;

        /*
         * ========================================
         * ДЕЛЕГАТ ЗА ИЗВЕСТИЯ
         * ========================================
         */

        /// <summary>
        /// Делегат за известия при извършване на действия в библиотеката.
        /// 
        /// Как работи:
        /// 1. Външен код регистрира метод към този делегат (+=)
        /// 2. Когато се случи събитие (добавяне, заемане, връщане на книга),
        ///    Library извиква OnNotification с подходящо съобщение
        /// 3. Регистрираният метод се изпълнява автоматично
        /// 
        /// Пример за регистрация: library.OnNotification += MoiqMetod;
        /// </summary>
        public LibraryNotification OnNotification;

        /*
         * ========================================
         * КОНСТРУКТОР
         * ========================================
         */

        /// <summary>
        /// Конструктор на класа Library.
        /// Инициализира празна колекция от книги.
        /// </summary>
        public Library()
        {
            // Създаваме нова празна колекция (списък) от книги
            books = new List<Book>();
        }

        /*
         * ========================================
         * МЕТОДИ ЗА УПРАВЛЕНИЕ НА КНИГИ
         * ========================================
         */

        /// <summary>
        /// Добавя нова книга в библиотеката.
        /// След добавянето изпраща известие чрез делегата.
        /// </summary>
        /// <param name="book">Книгата, която да се добави (Book или EBook)</param>
        public void AddBook(Book book)
        {
            // Добавяме книгата в колекцията
            books.Add(book);

            // Изпращаме известие чрез делегата (ако има регистриран метод)
            // Проверяваме дали делегатът не е null (дали има регистриран метод)
            if (OnNotification != null)
            {
                // Извикваме делегата с подходящо съобщение
                OnNotification("Добавена книга: " + book.Title);
            }
        }

        /// <summary>
        /// Връща списък с всички книги в библиотеката.
        /// </summary>
        /// <returns>List&lt;Book&gt; с всички книги</returns>
        public List<Book> GetAllBooks()
        {
            return books;
        }

        /// <summary>
        /// Връща списък само с наличните (незаети) книги.
        /// 
        /// Използва цикъл foreach за обхождане на колекцията
        /// и проверява свойството IsBorrowed на всяка книга.
        /// </summary>
        /// <returns>List&lt;Book&gt; с наличните книги</returns>
        public List<Book> GetAvailableBooks()
        {
            // Създаваме нов списък за резултата
            List<Book> availableBooks = new List<Book>();

            // Обхождаме всички книги
            foreach (Book book in books)
            {
                // Ако книгата НЕ е заета, добавяме я в резултата
                if (!book.IsBorrowed)
                {
                    availableBooks.Add(book);
                }
            }

            return availableBooks;
        }

        /// <summary>
        /// Връща списък само със заетите книги.
        /// </summary>
        /// <returns>List&lt;Book&gt; със заетите книги</returns>
        public List<Book> GetBorrowedBooks()
        {
            // Създаваме нов списък за резултата
            List<Book> borrowedBooks = new List<Book>();

            // Обхождаме всички книги
            foreach (Book book in books)
            {
                // Ако книгата Е заета, добавяме я в резултата
                if (book.IsBorrowed)
                {
                    borrowedBooks.Add(book);
                }
            }

            return borrowedBooks;
        }

        /// <summary>
        /// Заема книга по заглавие.
        /// Търси книга с даденото заглавие, която не е заета,
        /// и я маркира като заета от посочения човек.
        /// </summary>
        /// <param name="title">Заглавието на книгата за заемане</param>
        /// <param name="borrowerName">Името на човека, който заема книгата</param>
        /// <returns>true ако заемането е успешно, false ако книгата не е намерена или вече е заета</returns>
        public bool BorrowBook(string title, string borrowerName)
        {
            // Търсим книга с даденото заглавие, която не е заета
            foreach (Book book in books)
            {
                // Проверяваме заглавието и дали книгата не е заета
                if (book.Title == title && !book.IsBorrowed)
                {
                    // Заемаме книгата
                    book.Borrow(borrowerName);

                    // Изпращаме известие чрез делегата
                    if (OnNotification != null)
                    {
                        OnNotification(borrowerName + " зае книгата: " + title);
                    }

                    // Връщаме true за успех
                    return true;
                }
            }

            // Книгата не е намерена или е заета - връщаме false
            return false;
        }

        /// <summary>
        /// Връща заета книга по заглавие.
        /// Търси книга с даденото заглавие, която е заета,
        /// и я маркира като налична.
        /// </summary>
        /// <param name="title">Заглавието на книгата за връщане</param>
        /// <returns>true ако връщането е успешно, false ако книгата не е намерена или не е заета</returns>
        public bool ReturnBook(string title)
        {
            // Търсим книга с даденото заглавие, която е заета
            foreach (Book book in books)
            {
                // Проверяваме заглавието и дали книгата е заета
                if (book.Title == title && book.IsBorrowed)
                {
                    // Запазваме името на заемателя преди да го изтрием
                    string borrowerName = book.BorrowerName;

                    // Връщаме книгата
                    book.Return();

                    // Изпращаме известие чрез делегата
                    if (OnNotification != null)
                    {
                        OnNotification("Върната книга: " + title + " (от " + borrowerName + ")");
                    }

                    // Връщаме true за успех
                    return true;
                }
            }

            // Книгата не е намерена или не е заета - връщаме false
            return false;
        }

        /// <summary>
        /// Търси книги по автор.
        /// Връща всички книги, чийто автор съдържа търсения текст.
        /// Търсенето е case-insensitive (не различава главни от малки букви).
        /// </summary>
        /// <param name="author">Текст за търсене в името на автора</param>
        /// <returns>List&lt;Book&gt; с намерените книги</returns>
        public List<Book> SearchByAuthor(string author)
        {
            // Създаваме нов списък за резултата
            List<Book> foundBooks = new List<Book>();

            // Обхождаме всички книги
            foreach (Book book in books)
            {
                // Проверяваме дали авторът съдържа търсения текст
                // ToLower() преобразува в малки букви за case-insensitive търсене
                if (book.Author.ToLower().Contains(author.ToLower()))
                {
                    foundBooks.Add(book);
                }
            }

            return foundBooks;
        }

        /// <summary>
        /// Връща общия брой книги в библиотеката.
        /// </summary>
        /// <returns>Броят на книгите</returns>
        public int GetTotalBooks()
        {
            // Count е свойство на List<T>, което връща броя елементи
            return books.Count;
        }

        /// <summary>
        /// Изтрива книга от библиотеката по заглавие.
        /// </summary>
        /// <param name="title">Заглавието на книгата за изтриване</param>
        /// <returns>true ако изтриването е успешно, false ако книгата не е намерена</returns>
        public bool RemoveBook(string title)
        {
            // Търсим книга с даденото заглавие
            foreach (Book book in books)
            {
                if (book.Title == title)
                {
                    // Изтриваме книгата от колекцията
                    books.Remove(book);

                    // Изпращаме известие
                    if (OnNotification != null)
                    {
                        OnNotification("Изтрита книга: " + title);
                    }

                    return true;
                }
            }

            return false;
        }
    }
}
