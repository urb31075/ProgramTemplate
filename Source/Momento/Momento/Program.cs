// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="urb31075">
//   All Right Reserved
// </copyright>
// <summary>
//   The program.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Momento
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;

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
            var history = new Stack<HeroMemento>();
            var sniper = new Hero();
            sniper.Shoot();
            var memento = sniper.GetState();
            history.Push(memento);
            sniper.Shoot();
            sniper.Shoot();
            sniper.Shoot();
            memento = history.Pop();
            sniper.SetState(memento);
            sniper.Shoot();
            Console.ReadLine();
        }
    }

    /// <summary>
    /// The hero.
    /// </summary>
    internal class Hero
    {
        /// <summary>
        /// The patrons.
        /// </summary>
        private int patrons = 10;

        /// <summary>
        /// Initializes a new instance of the <see cref="Hero"/> class.
        /// </summary>
        public Hero()
        {
            Console.WriteLine("Создание игрока {0}", this.patrons);
        }

        /// <summary>
        /// The shoot.
        /// </summary>
        public void Shoot()
        {
            this.patrons--;
            Console.WriteLine("Выстрел, осталось патронов {0}", this.patrons);
        }

        /// <summary>
        /// The save state.
        /// </summary>
        /// <returns>
        /// The <see cref="HeroMemento"/>.
        /// </returns>
        public HeroMemento GetState()
        {
            Console.WriteLine("Сохранение игры {0}", this.patrons);
            return new HeroMemento(this.patrons);
        }

        /// <summary>
        /// The restore state.
        /// </summary>
        /// <param name="memento">
        /// The memento.
        /// </param>
        public void SetState(HeroMemento memento)
        {
            this.patrons = memento.Patrons;
            Console.WriteLine("Восстановление игры {0}", this.patrons);
        }
    }

    /// <summary>
    /// The hero momento.
    /// </summary>
    internal class HeroMemento
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HeroMemento"/> class.
        /// </summary>
        /// <param name="patrons">
        /// The patrons.
        /// </param>
        public HeroMemento(int patrons)
        {
            this.Patrons = patrons;
        }

        /// <summary>
        /// Gets the patrons.
        /// </summary>
        public int Patrons { get; private set; }
    }
}