// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="urb31075">
// All Right Reserved  
// </copyright>
// <summary>
//   The program.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Iterator
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// The my static container.
    /// </summary>
    internal static class EnumeratorFabrikam
    {
        /// <summary>
        /// The get enumerator.
        /// </summary>
        /// <param name="suffix">
        /// The suffix.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerator"/>.
        /// </returns>
        public static IEnumerator GetEnumerator(string suffix)
        {
            return new MyEnumerator(suffix);
        }

        /// <summary>
        /// The get dupel.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public static IEnumerable GetDupel()
        {
            return new Dupel();
        }
    }

    /// <summary>
    /// The program.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// The main.
        /// </summary>
        internal static void Main()
        {
            foreach (var dupel in EnumeratorFabrikam.GetDupel())
            {
                Console.WriteLine("cycle: {0}", dupel);   
            }

            var i = EnumeratorFabrikam.GetEnumerator("III");
            var o = EnumeratorFabrikam.GetEnumerator("OOO");

            while (i.MoveNext())
            {
                Console.WriteLine("cycle: {0}", (string)i.Current);    
            }

            while (o.MoveNext())
            {
                Console.WriteLine("cycle: {0}", (string)o.Current);
            }

            Console.ReadLine();
        }
    }

    /// <summary>
    /// The dupel.
    /// </summary>
    internal class Dupel : IEnumerable
    {
        /// <summary>
        /// The get enumerator.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerator"/>.
        /// </returns>
        public IEnumerator GetEnumerator()
        {
            return new MyEnumerator("DUPEL");
        }
    }

    /// <summary>
    /// The my enumerator.
    /// </summary>
    internal class MyEnumerator : IEnumerator
    {
        /// <summary>
        /// The item list.
        /// </summary>
        private readonly List<string> rawList = new List<string> { "XXX 1", "XXX 2", "XXX 3", "XXX 4" };

        /// <summary>
        /// The item list.
        /// </summary>
        private readonly List<string> itemList = new List<string>(); 

        /// <summary>
        /// The count.
        /// </summary>
        private int count;

        /// <summary>
        /// Initializes a new instance of the <see cref="MyEnumerator"/> class.
        /// </summary>
        /// <param name="suffix">
        /// The suffix.
        /// </param>
        public MyEnumerator(string suffix)
        {
            foreach (var item in this.rawList)
            {
              this.itemList.Add(item + "  " + suffix);   
            }
        }

        /// <summary>
        /// Gets the current.
        /// </summary>
        public object Current { get; private set; }

        /// <summary>
        /// The move next.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool MoveNext()
        {
            if (this.count < this.itemList.Count)
            {
                this.Current = this.itemList[this.count];
                this.count++;
                return true;
            }

            return false;
        }

        /// <summary>
        /// The reset.
        /// </summary>
        public void Reset()
        {
            this.count = 0;
            this.Current = this.itemList[this.count];
        }
    }
}