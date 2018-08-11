// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="urb31075">
//   All Right Reserved
// </copyright>
// <summary>
//   The MyObservable interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Observer
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The MyObservable interface.
    /// </summary>
    internal interface IPublisher
    {
        /// <summary>
        /// The add observer.
        /// </summary>
        /// <param name="o">
        /// The o.
        /// </param>
        void AddObserver(ISubscriber o);

        /// <summary>
        /// The remove observer.
        /// </summary>
        /// <param name="o">
        /// The o.
        /// </param>
        void RemoveObserver(ISubscriber o);

        /// <summary>
        /// The notify observers.
        /// </summary>
        void NotifyObservers();
    }

    /// <summary>
    /// The MyObserver interface.
    /// </summary>
    internal interface ISubscriber
    {
        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="price">
        /// The price.
        /// </param>
        void Update(int price);
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
            var stock = new Stock();
            var broker = new Broker(stock);

            broker.AddSubscribe();
            stock.Market();
            stock.Market();
            stock.Market();
            stock.Market();

            broker.RemoveSubscribe();
            stock.Market();
            stock.Market();
            stock.Market();
            stock.Market();

            Console.ReadLine();
        }
    }

    /// <summary>
    /// The stock.
    /// </summary>
    internal class Stock : IPublisher
    {
        /// <summary>
        /// The observers.
        /// </summary>
        private readonly List<ISubscriber> observers = new List<ISubscriber>();

        /// <summary>
        /// The price.
        /// </summary>
        private int price;

        /// <summary>
        /// The add observer.
        /// </summary>
        /// <param name="o">
        /// The o.
        /// </param>
        public void AddObserver(ISubscriber o)
        {
            this.observers.Add(o);
        }

        /// <summary>
        /// The remove observer.
        /// </summary>
        /// <param name="o">
        /// The o.
        /// </param>
        public void RemoveObserver(ISubscriber o)
        {
            this.observers.Remove(o);
        }

        /// <summary>
        /// The notify observers.
        /// </summary>
        public void NotifyObservers()
        {
            foreach (var o in this.observers)
            {
                o.Update(this.price);
            }
        }

        /// <summary>
        /// The market.
        /// </summary>
        public void Market()
        {
            this.price++;
            this.NotifyObservers();
        }
    }

    /// <summary>
    /// The broker.
    /// </summary>
    internal class Broker : ISubscriber
    {
        /// <summary>
        /// The stosk.
        /// </summary>
        private readonly IPublisher stosk;

        /// <summary>
        /// Initializes a new instance of the <see cref="Broker"/> class.
        /// </summary>
        /// <param name="publisher">
        /// The publisher.
        /// </param>
        public Broker(IPublisher publisher)
        {
            this.stosk = publisher;
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="price">
        /// The price.
        /// </param>
        public void Update(int price)
        {
            Console.WriteLine("Broker: {0}", price);
        }

        /// <summary>
        /// The add subscribe.
        /// </summary>
        public void AddSubscribe()
        {
            this.stosk.AddObserver(this);
        }

        /// <summary>
        /// The remove subscribe.
        /// </summary>
        public void RemoveSubscribe()
        {
            this.stosk.RemoveObserver(this);
        }
    }
}