// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="urb31075">
//   All Right Reserved
// </copyright>
// <summary>
//   The program.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ChainOfResponsibility
{
    using System;
    using System.Collections.Generic;

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
            PyamentHandler handlerD = new PyamentHandlerD { Name = "Handler D", };
            PyamentHandler handlerC = new PyamentHandlerC { Name = "Handler C", Successor = handlerD };
            PyamentHandler handlerB = new PyamentHandlerB { Name = "Handler B", Successor = handlerC };
            PyamentHandler handlerA = new PyamentHandlerA { Name = "Handler A", Successor = handlerB };
            var token = new ResponsibilityToken();
            token.AddHandler("A");
            token.AddHandler("B");
            token.AddHandler("C");
            token.AddHandler("D");

            handlerA.Handle(token);
            Console.ReadLine();
        }
    }

    /// <summary>
    /// The responsibility token.
    /// </summary>
    internal class ResponsibilityToken
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResponsibilityToken"/> class.
        /// </summary>
        public ResponsibilityToken()
        {
            this.Rnd = new Random();
        }

        /// <summary>
        /// Gets or sets the rnd.
        /// </summary>
        public Random Rnd { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is handled.
        /// </summary>
        public bool IsHandled { get; set; }

        /// <summary>
        /// Gets or sets the handler id list.
        /// </summary>
        public List<string> HandlerIdList { get; set; }

        /// <summary>
        /// The add handler.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        public void AddHandler(string id)
        {
            if (this.HandlerIdList == null)
            {
                this.HandlerIdList = new List<string>();
            }

            this.HandlerIdList.Add(id);
        }
    }

    /// <summary>
    /// The pyament handler a.
    /// </summary>
    internal class PyamentHandlerA : PyamentHandler
    {
        /// <summary>
        /// The handle.
        /// </summary>
        /// <param name="token">
        /// The token.
        /// </param>
        public override void Handle(ResponsibilityToken token)
        {
            Console.WriteLine("Обработчик {0}", this.Name);
            if (!token.HandlerIdList.Contains("A"))
            {
                return;
            }

            var x = token.Rnd.Next(2);
            if (x == 1)
            {
                Console.WriteLine("Произведена обработка {0}", this.Name);
                token.IsHandled = true;
            }
            else
            {
                if (this.Successor != null)
                {
                    Console.WriteLine("Передача управления на: {0}", this.Successor.Name);
                    this.Successor.Handle(token);
                }
            }
        }
    }

    /// <summary>
    /// The pyament handler b.
    /// </summary>
    internal class PyamentHandlerB : PyamentHandler
    {
        /// <summary>
        /// The handle.
        /// </summary>
        /// <param name="token">
        /// The token.
        /// </param>
        public override void Handle(ResponsibilityToken token)
        {
            Console.WriteLine("Обработчик {0}", this.Name);
            if (!token.HandlerIdList.Contains("B"))
            {
                return;
            }

            var x = token.Rnd.Next(2);
            if (x == 1)
            {
                Console.WriteLine("Произведена обработка {0}", this.Name);
                token.IsHandled = true;
            }
            else
            {
                if (this.Successor != null)
                {
                    Console.WriteLine("Передача управления на: {0}", this.Successor.Name);
                    this.Successor.Handle(token);
                }
            }
        }
    }

    /// <summary>
    /// The pyament handler c.
    /// </summary>
    internal class PyamentHandlerC : PyamentHandler
    {
        /// <summary>
        /// The handle.
        /// </summary>
        /// <param name="token">
        /// The token.
        /// </param>
        public override void Handle(ResponsibilityToken token)
        {
            Console.WriteLine("Обработчик {0}", this.Name);
            if (!token.HandlerIdList.Contains("C"))
            {
                return;
            }

            var x = token.Rnd.Next(2);
            if (x == 1)
            {
                Console.WriteLine("Произведена обработка {0}", this.Name);
                token.IsHandled = true;
            }
            else
            {
                if (this.Successor != null)
                {
                    Console.WriteLine("Передача управления на: {0}", this.Successor.Name);
                    this.Successor.Handle(token);
                }
            }
        }
    }

    /// <summary>
    /// The pyament handler c.
    /// </summary>
    internal class PyamentHandlerD : PyamentHandler
    {
        /// <summary>
        /// The handle.
        /// </summary>
        /// <param name="token">
        /// The token.
        /// </param>
        public override void Handle(ResponsibilityToken token)
        {
            Console.WriteLine("Обработчик {0}", this.Name);
            if (!token.HandlerIdList.Contains("D"))
            {
                return;
            }

            var x = token.Rnd.Next(2);
            if (x == 1)
            {
                Console.WriteLine("Произведена обработка {0}", this.Name);
                token.IsHandled = true;
            }
            else
            {
                if (this.Successor != null)
                {
                    Console.WriteLine("Передача управления на: {0}", this.Successor.Name);
                    this.Successor.Handle(token);
                }
            }
        }
    }

    /// <summary>
    /// The pyament handler.
    /// </summary>
    internal abstract class PyamentHandler
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the successor.
        /// </summary>
        public PyamentHandler Successor { get; set; }

        /// <summary>
        /// The handle.
        /// </summary>
        /// <param name="token">
        /// The token.
        /// </param>
        public abstract void Handle(ResponsibilityToken token);
    }
}