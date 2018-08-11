// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="urb31075">
//   All Right Reserved
// </copyright>
// <summary>
//   The program.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Command
{
    using System;

    /// <summary>
    /// The Command interface.
    /// </summary>
    internal interface ICommand
    {
        /// <summary>
        /// The execute.
        /// </summary>
        void Execute();

        /// <summary>
        /// The undo.
        /// </summary>
        void RollBack();
    }

    /// <summary>
    /// The Device interface.
    /// </summary>
    internal interface IDevice
    {
        /// <summary>
        /// The on.
        /// </summary>
        void On();

        /// <summary>
        /// The off.
        /// </summary>
        void Off();

        /// <summary>
        /// The self testing.
        /// </summary>
        /// <param name="testName">
        /// The test Name.
        /// </param>
        void SelfTesting(string testName);
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
            var pult = new Pult();

            var deviceA = new DeviceA();
            pult.SetCommand(new OnAndOfCommand(deviceA));
            pult.ExecuteCommand();
            pult.RollBackCommand();

            pult.SetCommand(new SelfTesting(deviceA, "Test 1"));
            pult.ExecuteCommand();

            var deviceB = new DeviceB();
            pult.SetCommand(new OnAndOfCommand(deviceB));
            pult.ExecuteCommand();
            pult.RollBackCommand();

            pult.SetCommand(new SelfTesting(deviceB, "Test X"));
            pult.ExecuteCommand();

            Console.ReadLine();
        }
    }

    /// <summary>
    /// The pult.
    /// </summary>
    internal class Pult
    {
        /// <summary>
        /// The command.
        /// </summary>
        private ICommand command;

        /// <summary>
        /// The set command.
        /// </summary>
        /// <param name="cmd">
        /// The cmd.
        /// </param>
        public void SetCommand(ICommand cmd)
        {
            this.command = cmd;
        }

        /// <summary>
        /// The press button.
        /// </summary>
        public void ExecuteCommand()
        {
            if (this.command != null)
            {
                this.command.Execute();
            }
        }

        /// <summary>
        /// The press undo.
        /// </summary>
        public void RollBackCommand()
        {
            if (this.command != null)
            {
                this.command.RollBack();
            }
        }
    }

    /// <summary>
    /// The DeviceCommand Command.
    /// </summary>
    internal class OnAndOfCommand : ICommand
    {
        /// <summary>
        /// The tv.
        /// </summary>
        private readonly IDevice device;

        /// <summary>
        /// Initializes a new instance of the <see cref="OnAndOfCommand"/> class.
        /// </summary>
        /// <param name="device">
        /// The device.
        /// </param>
        public OnAndOfCommand(IDevice device)
        {
            this.device = device;
        }

        /// <summary>
        /// The execute.
        /// </summary>
        public void Execute()
        {
            this.device.On();
        }

        /// <summary>
        /// The undo.
        /// </summary>
        public void RollBack()
        {
            this.device.Off();
        }
    }

    /// <summary>
    /// The DeviceCommand Command.
    /// </summary>
    internal class SelfTesting : ICommand
    {
        /// <summary>
        /// The tv.
        /// </summary>
        private readonly IDevice device;

        /// <summary>
        /// The test name.
        /// </summary>
        private readonly string testName; 

        /// <summary>
        /// Initializes a new instance of the <see cref="SelfTesting"/> class.
        /// </summary>
        /// <param name="device">
        /// The device.
        /// </param>
        /// <param name="testName">
        /// The test Name.
        /// </param>
        public SelfTesting(IDevice device, string testName)
        {
            this.device = device;
            this.testName = testName;
        }

        /// <summary>
        /// The execute.
        /// </summary>
        public void Execute()
        {
            this.device.SelfTesting(this.testName);
        }

        /// <summary>
        /// The undo.
        /// </summary>
        public void RollBack()
        {
            this.device.Off();
        }
    }

    /// <summary>
    /// The tv.
    /// </summary>
    internal class DeviceA : IDevice
    {
        /// <summary>
        /// The DeviceA
        /// </summary>
        public void On()
        {
            Console.WriteLine("DeviceA On!");
        }

        /// <summary>
        /// The off.
        /// </summary>
        public void Off()
        {
            Console.WriteLine("DeviceA Off!");
        }

        /// <summary>
        /// The self testing.
        /// </summary>
        /// <param name="testName">
        /// The test Name.
        /// </param>
        public void SelfTesting(string testName)
        {
            Console.WriteLine("DeviceA SelfTesting: {0}", testName);
        }
    }

    /// <summary>
    /// The DeviceB
    /// </summary>
    internal class DeviceB : IDevice
    {
        /// <summary>
        /// The on.
        /// </summary>
        public void On()
        {
            Console.WriteLine("DeviceB On!");
        }

        /// <summary>
        /// The off.
        /// </summary>
        public void Off()
        {
            Console.WriteLine("DeviceB Off!");
        }

        /// <summary>
        /// The self testing.
        /// </summary>
        /// <param name="testName">
        /// The test Name.
        /// </param>
        public void SelfTesting(string testName)
        {
            Console.WriteLine("DeviceB SelfTesting: {0}", testName);
        }
    }
}