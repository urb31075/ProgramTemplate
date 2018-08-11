// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="urb31075">
// All Right Reserved  
// </copyright>
// <summary>
//   The program.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Proxies
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The Book interface.
    /// </summary>
    internal interface IBook : IDisposable
    {
        /// <summary>
        /// The get page.
        /// </summary>
        /// <param name="number">
        /// The number.
        /// </param>
        /// <returns>
        /// The <see cref="Page"/>.
        /// </returns>
        Page GetPage(int number);
    }

    /// <summary>
    /// The program.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// The main.
        /// </summary>
        private static void Main()
        {
            var book = new BookStoreProxy();
            var page1 = book.GetPage(1);
            Console.WriteLine(page1.ToString());
            var page2 = book.GetPage(2);
            Console.WriteLine(page2.ToString());
            var page3 = book.GetPage(3);
            Console.WriteLine(page3.ToString());
            var page4 = book.GetPage(1);
            Console.WriteLine(page4.ToString());

            Console.ReadLine();
        }
    }

    /// <summary>
    /// The book store.
    /// </summary>
    internal class BookStore : IBook
    {
        /// <summary>
        /// The page db.
        /// </summary>
        public readonly Dictionary<int, Page> PageDb = new Dictionary<int, Page>();

        /// <summary>
        /// Initializes a new instance of the <see cref="BookStore"/> class.
        /// </summary>
        public BookStore()
        {
            this.PageDb.Add(1, new Page { Id = 1, Number = 1, Text = "Text1" });
            this.PageDb.Add(2, new Page { Id = 2, Number = 2, Text = "Text2" });
            this.PageDb.Add(3, new Page { Id = 3, Number = 3, Text = "Text3" });
        }

        /// <summary>
        /// The get page.
        /// </summary>
        /// <param name="number">
        /// The number.
        /// </param>
        /// <returns>
        /// The <see cref="BookStore"/>.
        /// </returns>
        public Page GetPage(int number)
        {
            return this.PageDb[number];
        }

        public void Dispose()
        {
            this.PageDb.Clear(); // Чисто что бы было
        }
    }

    /// <summary>
    /// The book store proxy.
    /// </summary>
    internal class BookStoreProxy : IBook
    {
        /// <summary>
        /// The page cache.
        /// </summary>
        private readonly Dictionary<int, Page> pageCache = new Dictionary<int, Page>();

        /// <summary>
        /// The book store.
        /// </summary>
        private BookStore bookStore;

        /// <summary>
        /// The get page.
        /// </summary>
        /// <param name="number">
        /// The number.
        /// </param>
        /// <returns>
        /// The <see cref="Page"/>.
        /// </returns>
        public Page GetPage(int number)
        {
            if (this.bookStore == null)
            {
                this.bookStore = new BookStore();
            }

            if (this.pageCache.ContainsKey(number))
            {
                return this.pageCache[number];
            }

            var page = this.bookStore.GetPage(number);
            this.pageCache.Add(number, page);
            return page;
        }

        /// <summary>
        /// The dispose.
        /// </summary>
        public void Dispose()
        {
            this.bookStore.Dispose();
        }
    }

    /// <summary>
    /// The page.
    /// </summary>
    internal class Page
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the number.
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// The to string.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public override string ToString()
        {
            return string.Format("{0} {1} {2}", this.Id, this.Number, this.Text);
        }
    }
}