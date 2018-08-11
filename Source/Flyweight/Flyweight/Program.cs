// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="urb31075">
//   All Right Reserved
// </copyright>
// <summary>
//   The program.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Flyweight
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
            var houseList = new List<House>();
            var houseFactory = new HouseFactory();
            for (var i = 0; i < 5; i++)
            {
                var house = houseFactory.GetHouse("Panel");
                houseList.Add(house);
            }

            for (var i = 0; i < 5; i++)
            {
                var house = houseFactory.GetHouse("Brick");
                houseList.Add(house);
            }

            int count = 0;
            foreach (var house in houseList)
            {
                house.Run(count++);
            }

            Console.ReadLine();
        }
    }

    /// <summary>
    /// The house factory.
    /// </summary>
    internal class HouseFactory
    {
        /// <summary>
        /// The house dictionary.
        /// </summary>
        private readonly Dictionary<string, House> houseDictionary = new Dictionary<string, House>();

        /// <summary>
        /// Initializes a new instance of the <see cref="HouseFactory"/> class.
        /// </summary>
        public HouseFactory()
        {
            this.houseDictionary.Add("Panel", new PanelHouse());
            this.houseDictionary.Add("Brick", new BrickHouse());
        }

        /// <summary>
        /// The get house.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <returns>
        /// The <see cref="House"/>.
        /// </returns>
        public House GetHouse(string key)
        {
            return this.houseDictionary[key];
        }
    }

    /// <summary>
    /// The house.
    /// </summary>
    internal abstract class House
    {
        /// <summary>
        /// The run.
        /// </summary>
        /// <param name="parameter">
        /// The parameter.
        /// </param>
        public virtual void Run(int parameter)
        {
            Console.WriteLine("Abstract House: {0}", parameter);
        }
    }

    /// <summary>
    /// The panel house.
    /// </summary>
    internal class PanelHouse : House
    {
        /// <summary>
        /// The in parameter.
        /// </summary>
        private readonly string inParameter;

        /// <summary>
        /// Initializes a new instance of the <see cref="PanelHouse"/> class.
        /// </summary>
        public PanelHouse()
        {
            this.inParameter = "PanelHouse";
        }

        /// <summary>
        /// The run.
        /// </summary>
        /// <param name="parameter">
        /// The parameter.
        /// </param>
        public override void Run(int parameter)
        {
            Console.WriteLine("{0}   {1}", this.inParameter, parameter);
        }
    }

    /// <summary>
    /// The brick house.
    /// </summary>
    internal class BrickHouse : House
    {
        /// <summary>
        /// The in parameter.
        /// </summary>
        private readonly string inParameter;

        /// <summary>
        /// Initializes a new instance of the <see cref="BrickHouse"/> class.
        /// </summary>
        public BrickHouse()
        {
            this.inParameter = "BrickHouse";
        }

        /// <summary>
        /// The run.
        /// </summary>
        /// <param name="parameter">
        /// The parameter.
        /// </param>
        public override void Run(int parameter)
        {
            Console.WriteLine("{0}   {1}", this.inParameter, parameter);
        }
    }
}