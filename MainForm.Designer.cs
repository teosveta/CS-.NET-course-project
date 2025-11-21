/*
 * ============================================================================
 * БИБЛИОТЕЧНА СИСТЕМА - Дизайн на главната форма
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
 * Този файл съдържа ДИЗАЙНЕРСКИЯ КОД на главната форма (MainForm).
 * Тук се дефинират всички контроли (бутони, текстови полета, етикети)
 * и техните свойства (позиция, размер, текст, събития).
 * 
 * ВАЖНО: Този файл обикновено се генерира автоматично от Visual Studio Designer.
 * Ръчните промени в този файл могат да бъдат загубени при използване на Designer.
 * 
 * Windows Forms Контроли използвани в този проект:
 * - ListBox - за показване на списък с книги
 * - TextBox - за въвеждане на текст
 * - Button - за извършване на действия
 * - Label - за показване на етикети
 * - GroupBox - за групиране на свързани контроли
 * 
 * ============================================================================
 */

namespace LibraryProject
{
    /// <summary>
    /// Частичен клас MainForm - дизайнерска част.
    /// 
    /// Ключовата дума "partial" означава, че класът е разделен на няколко файла:
    /// - MainForm.Designer.cs - съдържа дизайна (контролите)
    /// - MainForm.cs - съдържа логиката (event handlers)
    /// 
    /// Това разделение помага за по-добра организация на кода.
    /// </summary>
    partial class MainForm
    {
        /// <summary>
        /// Контейнер за компоненти, използвани от дизайнера.
        /// Необходим е за правилно освобождаване на ресурсите.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Метод за освобождаване на ресурсите, използвани от формата.
        /// Извиква се автоматично при затваряне на формата.
        /// </summary>
        /// <param name="disposing">true ако управляваните ресурси трябва да се освободят</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Метод, генериран от дизайнера, за инициализация на компонентите.
        /// 
        /// ВАЖНО: Не модифицирайте съдържанието на този метод с редактора на код.
        /// Използвайте дизайнера за промени в контролите.
        /// 
        /// Този метод:
        /// 1. Създава всички контроли (бутони, текстови полета, етикети)
        /// 2. Задава техните свойства (позиция, размер, текст)
        /// 3. Свързва събитията (Click) с методите за обработка (event handlers)
        /// 4. Добавя контролите към формата
        /// </summary>
        private void InitializeComponent()
        {
            /*
             * ========================================
             * СЪЗДАВАНЕ НА КОНТРОЛИТЕ
             * ========================================
             * Всички контроли се създават с оператора new
             */

            // ListBox - списък с книги
            this.listBoxBooks = new System.Windows.Forms.ListBox();

            // Бутони за действия
            this.btnAddBook = new System.Windows.Forms.Button();
            this.btnAddEBook = new System.Windows.Forms.Button();
            this.btnBorrow = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();

            // Бутони за филтриране
            this.btnShowAll = new System.Windows.Forms.Button();
            this.btnShowAvailable = new System.Windows.Forms.Button();
            this.btnShowBorrowed = new System.Windows.Forms.Button();

            // Текстови полета за въвеждане
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.txtBorrower = new System.Windows.Forms.TextBox();
            this.txtNotifications = new System.Windows.Forms.TextBox();

            // Етикети
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.lblYear = new System.Windows.Forms.Label();
            this.lblBorrower = new System.Windows.Forms.Label();
            this.lblNotifications = new System.Windows.Forms.Label();
            this.lblStats = new System.Windows.Forms.Label();
            this.lblHeader = new System.Windows.Forms.Label();

            // Бутон за изход
            this.btnExit = new System.Windows.Forms.Button();

            // GroupBox за групиране на контролите
            this.groupBoxInput = new System.Windows.Forms.GroupBox();
            this.groupBoxActions = new System.Windows.Forms.GroupBox();

            // Спираме оформлението, докато конфигурираме контролите
            this.SuspendLayout();
            this.groupBoxInput.SuspendLayout();
            this.groupBoxActions.SuspendLayout();

            /*
             * ========================================
             * КОНФИГУРАЦИЯ НА HEADER LABEL
             * ========================================
             */
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblHeader.Location = new System.Drawing.Point(12, 9);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(350, 24);
            this.lblHeader.Text = "БИБЛИОТЕЧНА СИСТЕМА";

            /*
             * ========================================
             * КОНФИГУРАЦИЯ НА LISTBOX
             * ========================================
             * ListBox показва списък с елементи, от които потребителят може да избира.
             */
            this.listBoxBooks.FormattingEnabled = true;
            this.listBoxBooks.Location = new System.Drawing.Point(12, 40);
            this.listBoxBooks.Name = "listBoxBooks";
            this.listBoxBooks.Size = new System.Drawing.Size(560, 186);
            this.listBoxBooks.TabIndex = 0;
            // Събитие при избиране на елемент от списъка
            this.listBoxBooks.SelectedIndexChanged += new System.EventHandler(this.listBoxBooks_SelectedIndexChanged);

            /*
             * ========================================
             * БУТОНИ ЗА ФИЛТРИРАНЕ
             * ========================================
             */
            // Бутон "Всички"
            this.btnShowAll.Location = new System.Drawing.Point(12, 232);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(90, 28);
            this.btnShowAll.TabIndex = 5;
            this.btnShowAll.Text = "Всички";
            this.btnShowAll.UseVisualStyleBackColor = true;
            // Свързване на Click събитието с метода btnShowAll_Click
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);

            // Бутон "Налични"
            this.btnShowAvailable.Location = new System.Drawing.Point(108, 232);
            this.btnShowAvailable.Name = "btnShowAvailable";
            this.btnShowAvailable.Size = new System.Drawing.Size(90, 28);
            this.btnShowAvailable.TabIndex = 6;
            this.btnShowAvailable.Text = "Налични";
            this.btnShowAvailable.UseVisualStyleBackColor = true;
            this.btnShowAvailable.Click += new System.EventHandler(this.btnShowAvailable_Click);

            // Бутон "Заети"
            this.btnShowBorrowed.Location = new System.Drawing.Point(204, 232);
            this.btnShowBorrowed.Name = "btnShowBorrowed";
            this.btnShowBorrowed.Size = new System.Drawing.Size(90, 28);
            this.btnShowBorrowed.TabIndex = 7;
            this.btnShowBorrowed.Text = "Заети";
            this.btnShowBorrowed.UseVisualStyleBackColor = true;
            this.btnShowBorrowed.Click += new System.EventHandler(this.btnShowBorrowed_Click);

            // Статистика
            this.lblStats.AutoSize = true;
            this.lblStats.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblStats.Location = new System.Drawing.Point(320, 238);
            this.lblStats.Name = "lblStats";
            this.lblStats.Size = new System.Drawing.Size(200, 15);
            this.lblStats.Text = "Общо: 0 | Налични: 0 | Заети: 0";

            /*
             * ========================================
             * GROUPBOX ЗА ВЪВЕЖДАНЕ НА ДАННИ
             * ========================================
             * GroupBox групира свързани контроли визуално.
             */
            this.groupBoxInput.Text = "Данни за книга";
            this.groupBoxInput.Location = new System.Drawing.Point(12, 268);
            this.groupBoxInput.Size = new System.Drawing.Size(280, 160);

            // Етикет и текстово поле за Заглавие
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(10, 25);
            this.lblTitle.Text = "Заглавие:";

            this.txtTitle.Location = new System.Drawing.Point(80, 22);
            this.txtTitle.Size = new System.Drawing.Size(185, 20);
            this.txtTitle.TabIndex = 8;

            // Етикет и текстово поле за Автор
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Location = new System.Drawing.Point(10, 55);
            this.lblAuthor.Text = "Автор:";

            this.txtAuthor.Location = new System.Drawing.Point(80, 52);
            this.txtAuthor.Size = new System.Drawing.Size(185, 20);
            this.txtAuthor.TabIndex = 9;

            // Етикет и текстово поле за Година
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(10, 85);
            this.lblYear.Text = "Година:";

            this.txtYear.Location = new System.Drawing.Point(80, 82);
            this.txtYear.Size = new System.Drawing.Size(185, 20);
            this.txtYear.TabIndex = 10;

            // Етикет и текстово поле за Заемател
            this.lblBorrower.AutoSize = true;
            this.lblBorrower.Location = new System.Drawing.Point(10, 115);
            this.lblBorrower.Text = "Заемател:";

            this.txtBorrower.Location = new System.Drawing.Point(80, 112);
            this.txtBorrower.Size = new System.Drawing.Size(185, 20);
            this.txtBorrower.TabIndex = 11;

            // Добавяме контролите към GroupBox
            this.groupBoxInput.Controls.Add(this.lblTitle);
            this.groupBoxInput.Controls.Add(this.txtTitle);
            this.groupBoxInput.Controls.Add(this.lblAuthor);
            this.groupBoxInput.Controls.Add(this.txtAuthor);
            this.groupBoxInput.Controls.Add(this.lblYear);
            this.groupBoxInput.Controls.Add(this.txtYear);
            this.groupBoxInput.Controls.Add(this.lblBorrower);
            this.groupBoxInput.Controls.Add(this.txtBorrower);

            /*
             * ========================================
             * GROUPBOX ЗА ДЕЙСТВИЯ
             * ========================================
             */
            this.groupBoxActions.Text = "Действия";
            this.groupBoxActions.Location = new System.Drawing.Point(300, 268);
            this.groupBoxActions.Size = new System.Drawing.Size(272, 160);

            // Бутон "Добави книга"
            this.btnAddBook.Location = new System.Drawing.Point(10, 25);
            this.btnAddBook.Size = new System.Drawing.Size(120, 30);
            this.btnAddBook.Text = "Добави книга";
            this.btnAddBook.UseVisualStyleBackColor = true;
            this.btnAddBook.Click += new System.EventHandler(this.btnAddBook_Click);

            // Бутон "Добави E-Book"
            this.btnAddEBook.Location = new System.Drawing.Point(140, 25);
            this.btnAddEBook.Size = new System.Drawing.Size(120, 30);
            this.btnAddEBook.Text = "Добави E-Book";
            this.btnAddEBook.UseVisualStyleBackColor = true;
            this.btnAddEBook.Click += new System.EventHandler(this.btnAddEBook_Click);

            // Бутон "Заеми книга"
            this.btnBorrow.Location = new System.Drawing.Point(10, 65);
            this.btnBorrow.Size = new System.Drawing.Size(120, 30);
            this.btnBorrow.Text = "Заеми книга";
            this.btnBorrow.UseVisualStyleBackColor = true;
            this.btnBorrow.Click += new System.EventHandler(this.btnBorrow_Click);

            // Бутон "Върни книга"
            this.btnReturn.Location = new System.Drawing.Point(140, 65);
            this.btnReturn.Size = new System.Drawing.Size(120, 30);
            this.btnReturn.Text = "Върни книга";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);

            // Бутон "Изтрий книга"
            this.btnRemove.Location = new System.Drawing.Point(10, 105);
            this.btnRemove.Size = new System.Drawing.Size(120, 30);
            this.btnRemove.Text = "Изтрий книга";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);

            // Бутон "Изход"
            this.btnExit.Location = new System.Drawing.Point(140, 105);
            this.btnExit.Size = new System.Drawing.Size(120, 30);
            this.btnExit.Text = "Изход";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);

            // Добавяме бутоните към GroupBox
            this.groupBoxActions.Controls.Add(this.btnAddBook);
            this.groupBoxActions.Controls.Add(this.btnAddEBook);
            this.groupBoxActions.Controls.Add(this.btnBorrow);
            this.groupBoxActions.Controls.Add(this.btnReturn);
            this.groupBoxActions.Controls.Add(this.btnRemove);
            this.groupBoxActions.Controls.Add(this.btnExit);

            /*
             * ========================================
             * ИЗВЕСТИЯ
             * ========================================
             */
            this.lblNotifications.AutoSize = true;
            this.lblNotifications.Location = new System.Drawing.Point(12, 435);
            this.lblNotifications.Text = "Известия:";

            // TextBox за известия (multiline, readonly)
            this.txtNotifications.Location = new System.Drawing.Point(12, 455);
            this.txtNotifications.Multiline = true;
            this.txtNotifications.ReadOnly = true;
            this.txtNotifications.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNotifications.Size = new System.Drawing.Size(560, 80);
            this.txtNotifications.TabIndex = 17;

            /*
             * ========================================
             * КОНФИГУРАЦИЯ НА ФОРМАТА
             * ========================================
             */
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 545);

            // Добавяме всички контроли към формата
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.listBoxBooks);
            this.Controls.Add(this.btnShowAll);
            this.Controls.Add(this.btnShowAvailable);
            this.Controls.Add(this.btnShowBorrowed);
            this.Controls.Add(this.lblStats);
            this.Controls.Add(this.groupBoxInput);
            this.Controls.Add(this.groupBoxActions);
            this.Controls.Add(this.lblNotifications);
            this.Controls.Add(this.txtNotifications);

            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Библиотечна Система - Теосвета Велкова F108355";

            // Възстановяваме оформлението
            this.groupBoxInput.ResumeLayout(false);
            this.groupBoxInput.PerformLayout();
            this.groupBoxActions.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        /*
         * ========================================
         * ДЕКЛАРАЦИИ НА КОНТРОЛИТЕ
         * ========================================
         * Тези полета съдържат референции към контролите на формата.
         * private - достъпни само в този клас
         */

        // ListBox за показване на книгите
        private System.Windows.Forms.ListBox listBoxBooks;

        // Бутони за действия с книги
        private System.Windows.Forms.Button btnAddBook;
        private System.Windows.Forms.Button btnAddEBook;
        private System.Windows.Forms.Button btnBorrow;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Button btnRemove;

        // Бутони за филтриране
        private System.Windows.Forms.Button btnShowAll;
        private System.Windows.Forms.Button btnShowAvailable;
        private System.Windows.Forms.Button btnShowBorrowed;

        // Текстови полета за въвеждане
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.TextBox txtBorrower;
        private System.Windows.Forms.TextBox txtNotifications;

        // Етикети
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Label lblBorrower;
        private System.Windows.Forms.Label lblNotifications;
        private System.Windows.Forms.Label lblStats;
        private System.Windows.Forms.Label lblHeader;

        // Бутон за изход
        private System.Windows.Forms.Button btnExit;

        // GroupBox контейнери
        private System.Windows.Forms.GroupBox groupBoxInput;
        private System.Windows.Forms.GroupBox groupBoxActions;
    }
}
