// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="urb31075">
//   All Right Reserved
// </copyright>
// <summary>
//   The program.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Bridge
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
            Abstraction abstractionA = new AbstractionA();
            Abstraction abstractionB = new AbstractionB();
            Implementator implementatorA = new ImplementatorA();
            Implementator implementatorB = new ImplementatorB();

            abstractionA.Implementator = implementatorA;
            abstractionA.Operation();
            abstractionA.Implementator = implementatorB;
            abstractionA.Operation();

            abstractionB.Implementator = implementatorA;
            abstractionB.Operation();
            abstractionB.Implementator = implementatorB;
            abstractionB.Operation();

            Console.ReadLine();
        }
    }

    #region Abstract

    /// <summary>
    /// The abstraction.
    /// </summary>
    internal abstract class Abstraction
    {
        /// <summary>
        /// Gets or sets the implementator.
        /// </summary>
        public Implementator Implementator { get; set; }

        /// <summary>
        /// The operation.
        /// </summary>
        public abstract void Operation();
    }

    /// <summary>
    /// The abstraction a.
    /// </summary>
    internal class AbstractionA : Abstraction
    {
        /// <summary>
        /// The operation.
        /// </summary>
        public override void Operation()
        {
            Console.WriteLine("Execute operation A");
            this.Implementator.DoWork();
        }
    }

    /// <summary>
    /// The abstraction b.
    /// </summary>
    internal class AbstractionB : Abstraction
    {
        /// <summary>
        /// The operation.
        /// </summary>
        public override void Operation()
        {
            Console.WriteLine("Execute operation B");
            this.Implementator.DoWork();
        }
    }

    #endregion

    #region Implementor

    /// <summary>
    /// The implementator.
    /// </summary>
    internal abstract class Implementator
    {
        /// <summary>
        /// The do work.
        /// </summary>
        public abstract void DoWork();
    }

    /// <summary>
    /// The implementator a.
    /// </summary>
    internal class ImplementatorA : Implementator
    {
        /// <summary>
        /// The do work.
        /// </summary>
        public override void DoWork()
        {
            Console.WriteLine("Use implementator A");
        }
    }

    /// <summary>
    /// The implementator b.
    /// </summary>
    internal class ImplementatorB : Implementator
    {
        /// <summary>
        /// The do work.
        /// </summary>
        public override void DoWork()
        {
            Console.WriteLine("Use implementator B");
        }
    }

    #endregion
}