// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="urb31075">
//   All Right Reserved
// </copyright>
// <summary>
//   The program.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace State
{
    using System;

    /// <summary>
    /// The WorkState interface.
    /// </summary>
    internal interface IWorkState
    {
        /// <summary>
        /// The action.
        /// </summary>
        void Action();

        /// <summary>
        /// The go next state.
        /// </summary>
        /// <param name="workContect">
        /// The work Contect.
        /// </param>
        void GoNextState(WorkContext workContect);

        /// <summary>
        /// The go prev state.
        /// </summary>
        /// <param name="workContect">
        /// The work Contect.
        /// </param>
        void GoPrevState(WorkContext workContect);
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
            var context = new WorkContext(new WorkStateA());
            context.Run();
            context.GoNextState();
            context.Run();
            context.GoNextState();
            context.Run();
            context.GoNextState();
            context.Run();
            Console.WriteLine("***");
            context.GoPrevState();
            context.Run();
            context.GoPrevState();
            context.Run();
            context.GoPrevState();
            context.Run();

            Console.ReadLine();
        }
    }

    /// <summary>
    /// The work context.
    /// </summary>
    internal class WorkContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WorkContext"/> class.
        /// </summary>
        /// <param name="state">
        /// The state.
        /// </param>
        public WorkContext(IWorkState state)
        {
            this.State = state;
        }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        public IWorkState State { get; set; }

        /// <summary>
        /// The run.
        /// </summary>
        public void Run()
        {
            this.State.Action();
        }

        /// <summary>
        /// The go next state.
        /// </summary>
        public void GoNextState()
        {
            this.State.GoNextState(this);
        }

        /// <summary>
        /// The go prev state.
        /// </summary>
        public void GoPrevState()
        {
            this.State.GoPrevState(this);
        }
    }

    /// <summary>
    /// The state a.
    /// </summary>
    internal class WorkStateA : IWorkState
    {
        /// <summary>
        /// The action.
        /// </summary>
        public void Action()
        {
            Console.WriteLine("State A");
        }

        /// <summary>
        /// The go next state.
        /// </summary>
        /// <param name="workContect">
        /// The work contect.
        /// </param>
        public void GoNextState(WorkContext workContect)
        {
            workContect.State = new WorkStateB();
        }

        /// <summary>
        /// The go prev state.
        /// </summary>
        /// <param name="workContect">
        /// The work contect.
        /// </param>
        public void GoPrevState(WorkContext workContect)
        {
            Console.WriteLine("Error: The start state!");
        }
    }

    /// <summary>
    /// The state b.
    /// </summary>
    internal class WorkStateB : IWorkState
    {
        /// <summary>
        /// The action.
        /// </summary>
        public void Action()
        {
            Console.WriteLine("State B");
        }

        /// <summary>
        /// The go next state.
        /// </summary>
        /// <param name="workContect">
        /// The work contect.
        /// </param>
        public void GoNextState(WorkContext workContect)
        {
            workContect.State = new WorkStateC();
        }

        /// <summary>
        /// The go prev state.
        /// </summary>
        /// <param name="workContect">
        /// The work contect.
        /// </param>
        public void GoPrevState(WorkContext workContect)
        {
            workContect.State = new WorkStateA();
        }
    }

    /// <summary>
    /// The state c.
    /// </summary>
    internal class WorkStateC : IWorkState
    {
        /// <summary>
        /// The action.
        /// </summary>
        public void Action()
        {
            Console.WriteLine("State C");
        }

        /// <summary>
        /// The go next state.
        /// </summary>
        /// <param name="workContect">
        /// The work contect.
        /// </param>
        public void GoNextState(WorkContext workContect)
        {
            Console.WriteLine("Error: The finish state!");
        }

        /// <summary>
        /// The go prev state.
        /// </summary>
        /// <param name="workContect">
        /// The work contect.
        /// </param>
        public void GoPrevState(WorkContext workContect)
        {
            workContect.State = new WorkStateB();
        }
    }
}