/*
 * ============================================================================
 * БИБЛИОТЕЧНА СИСТЕМА - Логика на главната форма
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
 * Този файл съдържа ЛОГИКАТА на главната форма (MainForm).
 * Тук се намират всички event handlers (методи за обработка на събития)
 * и помощни методи за работа с потребителския интерфейс.
 * 
 * ООП Концепции демонстрирани в този файл:
 * 1. Частични класове (partial class)
 * 2. Използване на делегати за callback
 * 3. Работа с колекции
 * 4. Обработка на събития (event handling)
 * 
 * ============================================================================
 */

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LibraryProject
{
    /// <summary>
    /// Частичен клас MainForm - логическа част.
    /// Съдържа всички методи за обработка на събития и помощни методи.
    /// 
    /// Класът наследява Form - базовия клас за Windows Forms прозорци.
    /// </summary>
    public partial class MainForm : Form
    {
        /*
         * ========================================
         * ПОЛЕТА (Fields)
         * ========================================
         */

        /// <summary>
        /// Обект от тип Library, който управлява колекцията от книги.
        /// Този обект съхранява всички книги и предоставя методи за работа с тях.
        /// </summary>
        private Library library;

        /*
         * ========================================
         * КОНСТРУКТОР
         * ========================================
         */

        /// <summary>
        /// Конструктор на класа MainForm.
        /// Извиква се при създаване на формата.
        /// </summary>
        public MainForm()
        {
            // InitializeComponent() създава и конфигурира всички контроли
            // Този метод е дефиниран в MainForm.Designer.cs
            InitializeComponent();

            // Създаваме нов обект Library за управление на книгите
            library = new Library();

            /*
             * РЕГИСТРИРАНЕ НА ДЕЛЕГАТ
             * 
             * Тук свързваме метода ShowNotification с делегата OnNotification.
             * Операторът += добавя нов метод към делегата.
             * 
             * Когато в Library се извика OnNotification("съобщение"),
             * автоматично ще се изпълни нашият метод ShowNotification("съобщение").
             */
            library.OnNotification += ShowNotification;

            // Добавяме примерни книги за демонстрация
            InitializeSampleBooks();

            // Обновяваме списъка с книги
            RefreshBookList();
        }

        /*
         * ========================================
         * МЕТОД ЗА ДЕЛЕГАТА (Callback)
         * ========================================
         */

        /// <summary>
        /// Метод, който се извиква от делегата при известия от библиотеката.
        /// 
        /// Сигнатурата на този метод съответства на делегата LibraryNotification:
        /// - Не връща стойност (void)
        /// - Приема един string параметър
        /// 
        /// Този метод демонстрира callback механизма чрез делегати.
        /// </summary>
        /// <param name="message">Съобщението от библиотеката</param>
        private void ShowNotification(string message)
        {
            // Форматираме съобщението с текущото време
            string formattedMessage = DateTime.Now.ToString("HH:mm:ss") + " - " + message;

            // Добавяме съобщението в текстовото поле за известия
            // AppendText добавя текст в края на съществуващия текст
            // Environment.NewLine добавя нов ред
            txtNotifications.AppendText(formattedMessage + Environment.NewLine);
        }

        /*
         * ========================================
         * ПОМОЩНИ МЕТОДИ
         * ========================================
         */

        /// <summary>
        /// Инициализира библиотеката с примерни книги.
        /// Използва се за демонстрация на функционалността.
        /// </summary>
        private void InitializeSampleBooks()
        {
            // Добавяме обикновени книги (обекти от тип Book)
            library.AddBook(new Book("Под игото", "Иван Вазов", 1894));
            library.AddBook(new Book("1984", "George Orwell", 1949));
            library.AddBook(new Book("Хари Потър и Философският камък", "J.K. Rowling", 1997));

            // Добавяме електронни книги (обекти от тип EBook)
            // Това демонстрира ПОЛИМОРФИЗЪМ - и Book, и EBook могат да се добавят в колекцията
            library.AddBook(new EBook("Clean Code", "Robert C. Martin", 2008, 5.2, "PDF"));
            library.AddBook(new EBook("C# Programming", "John Sharp", 2018, 12.5, "EPUB"));
        }

        /// <summary>
        /// Обновява списъка с книги в ListBox контролата.
        /// Показва всички книги от библиотеката.
        /// </summary>
        private void RefreshBookList()
        {
            // Изчистваме текущите елементи в ListBox
            listBoxBooks.Items.Clear();

            // Обхождаме всички книги в библиотеката
            // GetAllBooks() връща List<Book>
            foreach (Book book in library.GetAllBooks())
            {
                // Добавяме информацията за книгата в ListBox
                // GetInfo() връща форматиран текст
                // Благодарение на полиморфизма, GetInfo() връща различен текст за Book и EBook
                listBoxBooks.Items.Add(book.GetInfo());
            }

            // Обновяваме статистиката
            UpdateStats();
        }

        /// <summary>
        /// Обновява етикета със статистика.
        /// Показва общия брой книги, наличните и заетите.
        /// </summary>
        private void UpdateStats()
        {
            // Получаваме статистиката от библиотеката
            int total = library.GetTotalBooks();
            int available = library.GetAvailableBooks().Count;
            int borrowed = library.GetBorrowedBooks().Count;

            // Обновяваме текста на етикета
            lblStats.Text = "Общо: " + total + " | Налични: " + available + " | Заети: " + borrowed;
        }

        /// <summary>
        /// Изчиства полетата за въвеждане.
        /// Извиква се след успешно добавяне/заемане/връщане на книга.
        /// </summary>
        private void ClearInputFields()
        {
            // Clear() изтрива текста в текстовото поле
            txtTitle.Clear();
            txtAuthor.Clear();
            txtYear.Clear();
            txtBorrower.Clear();
        }

        /*
         * ========================================
         * EVENT HANDLERS - БУТОНИ ЗА ДЕЙСТВИЯ
         * ========================================
         * 
         * Event handler е метод, който се извиква при настъпване на събитие.
         * Всички event handlers имат стандартна сигнатура:
         * - void - не връщат стойност
         * - sender - обектът, който е предизвикал събитието (бутонът)
         * - EventArgs e - допълнителна информация за събитието
         */

        /// <summary>
        /// Event handler за бутона "Добави книга".
        /// Създава нова обикновена книга и я добавя в библиотеката.
        /// </summary>
        private void btnAddBook_Click(object sender, EventArgs e)
        {
            // Валидация - проверяваме дали са попълнени необходимите полета
            // string.IsNullOrWhiteSpace проверява за null, празен низ или само интервали
            if (string.IsNullOrWhiteSpace(txtTitle.Text) ||
                string.IsNullOrWhiteSpace(txtAuthor.Text) ||
                string.IsNullOrWhiteSpace(txtYear.Text))
            {
                // Показваме съобщение за грешка чрез MessageBox
                MessageBox.Show(
                    "Моля попълнете Заглавие, Автор и Година!",
                    "Грешка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;  // Прекратяваме изпълнението на метода
            }

            // Използваме try-catch за обработка на грешки
            try
            {
                // Trim() премахва интервалите в началото и края на текста
                string title = txtTitle.Text.Trim();
                string author = txtAuthor.Text.Trim();

                // Parse преобразува текст в число
                // Ако текстът не е валидно число, ще се хвърли FormatException
                int year = int.Parse(txtYear.Text.Trim());

                // Създаваме нов обект Book
                Book newBook = new Book(title, author, year);

                // Добавяме книгата в библиотеката
                library.AddBook(newBook);

                // Обновяваме списъка и изчистваме полетата
                RefreshBookList();
                ClearInputFields();
            }
            catch (FormatException)
            {
                // Грешка при преобразуване на годината
                MessageBox.Show(
                    "Годината трябва да е число!",
                    "Грешка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Други грешки
                MessageBox.Show(
                    "Грешка при добавяне на книга: " + ex.Message,
                    "Грешка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Event handler за бутона "Добави E-Book".
        /// Създава нова електронна книга и я добавя в библиотеката.
        /// </summary>
        private void btnAddEBook_Click(object sender, EventArgs e)
        {
            // Валидация
            if (string.IsNullOrWhiteSpace(txtTitle.Text) ||
                string.IsNullOrWhiteSpace(txtAuthor.Text) ||
                string.IsNullOrWhiteSpace(txtYear.Text))
            {
                MessageBox.Show(
                    "Моля попълнете Заглавие, Автор и Година!",
                    "Грешка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string title = txtTitle.Text.Trim();
                string author = txtAuthor.Text.Trim();
                int year = int.Parse(txtYear.Text.Trim());

                // Създаваме нов обект EBook
                // За простота използваме фиксирани стойности за размер и формат
                // В реална система тези данни биха идвали от допълнителни полета
                EBook newEBook = new EBook(title, author, year, 5.0, "PDF");

                // Добавяме електронната книга в библиотеката
                // Това е пример за ПОЛИМОРФИЗЪМ - EBook се третира като Book
                library.AddBook(newEBook);

                RefreshBookList();
                ClearInputFields();
            }
            catch (FormatException)
            {
                MessageBox.Show(
                    "Годината трябва да е число!",
                    "Грешка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Грешка при добавяне на E-Book: " + ex.Message,
                    "Грешка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Event handler за бутона "Заеми книга".
        /// Заема избраната книга на посочения заемател.
        /// </summary>
        private void btnBorrow_Click(object sender, EventArgs e)
        {
            // Валидация - трябва да има заглавие и име на заемател
            if (string.IsNullOrWhiteSpace(txtTitle.Text) ||
                string.IsNullOrWhiteSpace(txtBorrower.Text))
            {
                MessageBox.Show(
                    "Моля попълнете Заглавие и Заемател!",
                    "Грешка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            string title = txtTitle.Text.Trim();
            string borrower = txtBorrower.Text.Trim();

            // Опитваме се да заемем книгата
            // BorrowBook връща true при успех, false при неуспех
            bool success = library.BorrowBook(title, borrower);

            if (success)
            {
                RefreshBookList();
                ClearInputFields();
            }
            else
            {
                MessageBox.Show(
                    "Книгата не е намерена или вече е заета!",
                    "Грешка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Event handler за бутона "Върни книга".
        /// Връща заета книга в библиотеката.
        /// </summary>
        private void btnReturn_Click(object sender, EventArgs e)
        {
            // Валидация - трябва да има заглавие
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show(
                    "Моля попълнете Заглавие!",
                    "Грешка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            string title = txtTitle.Text.Trim();

            // Опитваме се да върнем книгата
            bool success = library.ReturnBook(title);

            if (success)
            {
                RefreshBookList();
                ClearInputFields();
            }
            else
            {
                MessageBox.Show(
                    "Книгата не е намерена или не е заета!",
                    "Грешка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Event handler за бутона "Изтрий книга".
        /// Изтрива книга от библиотеката.
        /// </summary>
        private void btnRemove_Click(object sender, EventArgs e)
        {
            // Валидация
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show(
                    "Моля попълнете Заглавие!",
                    "Грешка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            string title = txtTitle.Text.Trim();

            // Питаме потребителя за потвърждение
            DialogResult result = MessageBox.Show(
                "Сигурни ли сте, че искате да изтриете книгата \"" + title + "\"?",
                "Потвърждение",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            // Ако потребителят е натиснал "Да"
            if (result == DialogResult.Yes)
            {
                bool success = library.RemoveBook(title);

                if (success)
                {
                    RefreshBookList();
                    ClearInputFields();
                }
                else
                {
                    MessageBox.Show(
                        "Книгата не е намерена!",
                        "Грешка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
        }

        /*
         * ========================================
         * EVENT HANDLERS - БУТОНИ ЗА ФИЛТРИРАНЕ
         * ========================================
         */

        /// <summary>
        /// Event handler за бутона "Всички".
        /// Показва всички книги в библиотеката.
        /// </summary>
        private void btnShowAll_Click(object sender, EventArgs e)
        {
            // Просто обновяваме списъка - RefreshBookList показва всички книги
            RefreshBookList();
        }

        /// <summary>
        /// Event handler за бутона "Налични".
        /// Показва само наличните (незаети) книги.
        /// </summary>
        private void btnShowAvailable_Click(object sender, EventArgs e)
        {
            // Изчистваме ListBox
            listBoxBooks.Items.Clear();

            // Обхождаме наличните книги
            // GetAvailableBooks() връща само книгите, които не са заети
            foreach (Book book in library.GetAvailableBooks())
            {
                listBoxBooks.Items.Add(book.GetInfo());
            }
        }

        /// <summary>
        /// Event handler за бутона "Заети".
        /// Показва само заетите книги.
        /// </summary>
        private void btnShowBorrowed_Click(object sender, EventArgs e)
        {
            // Изчистваме ListBox
            listBoxBooks.Items.Clear();

            // Обхождаме заетите книги
            // GetBorrowedBooks() връща само книгите, които са заети
            foreach (Book book in library.GetBorrowedBooks())
            {
                listBoxBooks.Items.Add(book.GetInfo());
            }
        }

        /*
         * ========================================
         * EVENT HANDLERS - ДРУГИ
         * ========================================
         */

        /// <summary>
        /// Event handler за избиране на елемент от ListBox.
        /// Автоматично попълва полето за заглавие с избраната книга.
        /// </summary>
        private void listBoxBooks_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Проверяваме дали има избран елемент
            // SelectedIndex е -1 ако няма избран елемент
            if (listBoxBooks.SelectedIndex >= 0)
            {
                // Получаваме списъка с всички книги
                List<Book> allBooks = library.GetAllBooks();

                // Проверяваме дали индексът е валиден
                if (listBoxBooks.SelectedIndex < allBooks.Count)
                {
                    // Получаваме избраната книга
                    Book selectedBook = allBooks[listBoxBooks.SelectedIndex];

                    // Попълваме полетата с данните на книгата
                    txtTitle.Text = selectedBook.Title;
                    txtAuthor.Text = selectedBook.Author;
                    txtYear.Text = selectedBook.Year.ToString();

                    // Ако книгата е заета, показваме името на заемателя
                    if (selectedBook.IsBorrowed)
                    {
                        txtBorrower.Text = selectedBook.BorrowerName;
                    }
                    else
                    {
                        txtBorrower.Clear();
                    }
                }
            }
        }

        /// <summary>
        /// Event handler за бутона "Изход".
        /// Затваря приложението след потвърждение.
        /// </summary>
        private void btnExit_Click(object sender, EventArgs e)
        {
            // Питаме потребителя за потвърждение
            DialogResult result = MessageBox.Show(
                "Сигурни ли сте, че искате да излезете?",
                "Изход",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            // Ако потребителят е натиснал "Да"
            if (result == DialogResult.Yes)
            {
                // Затваряме формата
                // Тъй като това е главната форма, приложението ще се затвори
                this.Close();
            }
        }
    }
}
