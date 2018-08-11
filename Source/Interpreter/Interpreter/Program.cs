// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="urb31075">
//   All Righr Reserved
// </copyright>
// <summary>
//   The program.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Interpreter
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The MyExpression interface.
    /// </summary>
    internal interface IMyExpression
    {
        /// <summary>
        /// The interpret.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        int EvaluteExpression(MyContext context);
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
            int x = 5;
            int y = 8;
            int z = 2;

            var context = new MyContext();
            context.SetVariable("x", x);
            context.SetVariable("y", y);
            context.SetVariable("z", z);

            IMyExpression exp1 =
                new SubstractExpression(
                    new AddExpression(new NumberExpression("x"), new NumberExpression("y")), 
                    new NumberExpression("z"));
            var result = exp1.EvaluteExpression(context);
            Console.WriteLine("Result = {0}", result);

            var exp2 = new AddExpression(new NumberExpression("x"), new NumberExpression("y"));
            var exp3 = new AddExpression(new NumberExpression("x"), new NumberExpression("y"));
            var exp4 = new AddExpression(exp2, exp3);
            result = exp4.EvaluteExpression(context);
            Console.WriteLine("Result = {0}", result);

            Console.ReadLine();
        }
    }

    /// <summary>
    /// The number expression.
    /// </summary>
    internal class NumberExpression : IMyExpression
    {
        /// <summary>
        /// The name.
        /// </summary>
        private readonly string name;

        /// <summary>
        /// Initializes a new instance of the <see cref="NumberExpression"/> class.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        public NumberExpression(string name)
        {
            this.name = name;
        }

        /// <summary>
        /// The interpret.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int EvaluteExpression(MyContext context)
        {
            var exp = context.GetVariable(this.name);
            return exp;
        }
    }

    /// <summary>
    /// The add expression.
    /// </summary>
    internal class AddExpression : IMyExpression
    {
        /// <summary>
        /// The left expression.
        /// </summary>
        private readonly IMyExpression leftExpression;

        /// <summary>
        /// The right expression.
        /// </summary>
        private readonly IMyExpression rightExpression;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddExpression"/> class.
        /// </summary>
        /// <param name="leftExpression">
        /// The left expression.
        /// </param>
        /// <param name="rightExpression">
        /// The right expression.
        /// </param>
        public AddExpression(IMyExpression leftExpression, IMyExpression rightExpression)
        {
            this.leftExpression = leftExpression;
            this.rightExpression = rightExpression;
        }

        /// <summary>
        /// The interpret.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int EvaluteExpression(MyContext context)
        {
            var exp = this.leftExpression.EvaluteExpression(context) + this.rightExpression.EvaluteExpression(context);
            return exp;
        }
    }

    /// <summary>
    /// The substract expression.
    /// </summary>
    internal class SubstractExpression : IMyExpression
    {
        /// <summary>
        /// The left expression.
        /// </summary>
        private readonly IMyExpression leftExpression;

        /// <summary>
        /// The right expression.
        /// </summary>
        private readonly IMyExpression rightExpression;

        /// <summary>
        /// Initializes a new instance of the <see cref="SubstractExpression"/> class.
        /// </summary>
        /// <param name="leftExpression">
        /// The left expression.
        /// </param>
        /// <param name="rightExpression">
        /// The right expression.
        /// </param>
        public SubstractExpression(IMyExpression leftExpression, IMyExpression rightExpression)
        {
            this.leftExpression = leftExpression;
            this.rightExpression = rightExpression;
        }

        /// <summary>
        /// The interpret.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int EvaluteExpression(MyContext context)
        {
            var exp = this.leftExpression.EvaluteExpression(context) - this.rightExpression.EvaluteExpression(context);
            return exp;
        }
    }

    /// <summary>
    /// The operatio context.
    /// </summary>
    internal class MyContext
    {
        /// <summary>
        /// The variables.
        /// </summary>
        private readonly Dictionary<string, int> variables = new Dictionary<string, int>();

        /// <summary>
        /// The get variable.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int GetVariable(string name)
        {
            return this.variables[name];
        }

        /// <summary>
        /// The set variable.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        public void SetVariable(string name, int value)
        {
            this.variables.Add(name, value);
        }
    }
}