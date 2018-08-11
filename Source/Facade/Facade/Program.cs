// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="urb31075">
//   All Right Reserved
// </copyright>
// <summary>
//   The program.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Facade
{
    using System;

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
            var executor = new SubSystemFacade(new SubSystemA(), new SubSystemB());
            Console.WriteLine("***");            
            executor.Operation1();
            Console.WriteLine("***");
            executor.Operation2();
            Console.ReadLine();
        }
    }

    /// <summary>
    /// The sub system facade.
    /// </summary>
    internal class SubSystemFacade
    {
        /// <summary>
        /// The sub system a.
        /// </summary>
        private readonly SubSystemA subSystemA;

        /// <summary>
        /// The sub system b.
        /// </summary>
        private readonly SubSystemB subSystemB;

        /// <summary>
        /// Initializes a new instance of the <see cref="SubSystemFacade"/> class.
        /// </summary>
        /// <param name="subSystemA">
        /// The sub system a.
        /// </param>
        /// <param name="subSystemB">
        /// The sub system b.
        /// </param>
        public SubSystemFacade(SubSystemA subSystemA, SubSystemB subSystemB)
        {
            this.subSystemA = subSystemA;
            this.subSystemB = subSystemB;
        }

        /// <summary>
        /// The operation 1.
        /// </summary>
        public void Operation1()
        {
            this.subSystemA.A();
            this.subSystemB.X();
        }

        /// <summary>
        /// The operation 2.
        /// </summary>
        public void Operation2()
        {
            this.subSystemA.B();
            this.subSystemA.C();
            this.subSystemB.Y();
            this.subSystemB.Z();
        }
    }

    /// <summary>
    /// The sub system a.
    /// </summary>
    internal class SubSystemA
    {
        /// <summary>
        /// The a 1.
        /// </summary>
        public void A()
        {
            Console.WriteLine("A");
        }

        /// <summary>
        /// The b 1.
        /// </summary>
        public void B()
        {
            Console.WriteLine("B");
        }

        /// <summary>
        /// The c 1.
        /// </summary>
        public void C()
        {
            Console.WriteLine("C");
        }
    }

    /// <summary>
    /// The sub system b.
    /// </summary>
    internal class SubSystemB
    {
        /// <summary>
        /// The x 1.
        /// </summary>
        public void X()
        {
            Console.WriteLine("X");
        }

        /// <summary>
        /// The y 1.
        /// </summary>
        public void Y()
        {
            Console.WriteLine("Y");
        }

        /// <summary>
        /// The z 1.
        /// </summary>
        public void Z()
        {
            Console.WriteLine("Z");
        }
    }
}