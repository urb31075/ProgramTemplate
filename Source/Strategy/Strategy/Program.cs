// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="urb31075">
//   All Right Reserved
// </copyright>
// <summary>
//   The program.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Strategy
{
    using System;

    /// <summary>
    /// The Strategy interface.
    /// </summary>
    public interface IStrategy
    {
        /// <summary>
        /// The algoritm.
        /// </summary>
        /// <param name="str">
        /// The str.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        string Algoritm(string str);
    }

    /// <summary>
    /// The executor.
    /// </summary>
    internal static class Executor
    {
        /// <summary>
        /// The run.
        /// </summary>
        /// <param name="str">
        /// The str.
        /// </param>
        /// <param name="strategy">
        /// The strategy.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string Run(string str, IStrategy strategy)
        {
            return strategy.Algoritm(str);
        }

        /// <summary>
        /// The run.
        /// </summary>
        /// <param name="str">
        /// The str.
        /// </param>
        /// <param name="strategy">
        /// The strategy.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string Run(string str, Strategy strategy)
        {
            return strategy.Algoritm(str);
        }
    }

    /// <summary>
    /// The strategy.
    /// </summary>
    internal abstract class Strategy
    {
        /// <summary>
        /// The algoritm.
        /// </summary>
        /// <param name="str">
        /// The str.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public abstract string Algoritm(string str);
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
            Console.WriteLine(Executor.Run("111", new StrategyAaa()));
            Console.WriteLine(Executor.Run("111", new StrategyBbb()));
            Console.WriteLine(Executor.Run("111", new StrategyCcc()));
            Console.WriteLine(Executor.Run("111", new StrategyXxx()));
            Console.WriteLine(Executor.Run("111", new StrategyYyy()));
            Console.WriteLine(Executor.Run("111", new StrategyZzz()));
            Console.ReadLine();
        }
    }

    /// <summary>
    /// The strategy a.
    /// </summary>
    internal class StrategyAaa : IStrategy
    {
        /// <summary>
        /// The algoritm.
        /// </summary>
        /// <param name="str">
        /// The str.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string Algoritm(string str)
        {
            return str + " AAA";
        }
    }

    /// <summary>
    /// The strategy b.
    /// </summary>
    internal class StrategyBbb : IStrategy
    {
        /// <summary>
        /// The algoritm.
        /// </summary>
        /// <param name="str">
        /// The str.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string Algoritm(string str)
        {
            return str + " BBB";
        }
    }

    /// <summary>
    /// The strategy c.
    /// </summary>
    internal class StrategyCcc : IStrategy
    {
        /// <summary>
        /// The algoritm.
        /// </summary>
        /// <param name="str">
        /// The str.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string Algoritm(string str)
        {
            return str + " CCC";
        }
    }

    /// <summary>
    /// The strategy Xxx.
    /// </summary>
    internal class StrategyXxx : Strategy
    {
        /// <summary>
        /// The algoritm.
        /// </summary>
        /// <param name="str">
        /// The str.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public override string Algoritm(string str)
        {
            return str + " XXX";
        }
    }

    /// <summary>
    /// The strategy Yyy.
    /// </summary>
    internal class StrategyYyy : Strategy
    {
        /// <summary>
        /// The algoritm.
        /// </summary>
        /// <param name="str">
        /// The str.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public override string Algoritm(string str)
        {
            return str + " YYY";
        }
    }

    /// <summary>
    /// The strategy Zzz.
    /// </summary>
    internal class StrategyZzz : Strategy
    {
        /// <summary>
        /// The algoritm.
        /// </summary>
        /// <param name="str">
        /// The str.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public override string Algoritm(string str)
        {
            return str + " ZZZ";
        }
    }
}