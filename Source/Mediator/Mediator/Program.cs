// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="urb31075">
//   All Right Reserved
// </copyright>
// <summary>
//   The program.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Mediator
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
            var controlBlock1 = new ControlBlock1();
            var worker1A = new DeviceA(controlBlock1);
            var worker1B = new DeviceB(controlBlock1);
            var worker1C = new DeviceC(controlBlock1);

            controlBlock1.DeviceA = worker1A;
            controlBlock1.DeviceB = worker1B;
            controlBlock1.DeviceC = worker1C;

            worker1A.SetTask("Signal for A");
            worker1B.SetTask("Signal for B");
            worker1C.SetTask("Signal for C");
            
            var controlBlock2 = new ControlBlock2();

            var worker2A = new DeviceA(controlBlock2);
            var worker2B = new DeviceB(controlBlock2);
            var worker2C = new DeviceC(controlBlock2);

            controlBlock2.DeviceA = worker2A;
            controlBlock2.DeviceB = worker2B;
            controlBlock2.DeviceC = worker2C;

            worker2A.SetTask("Signal for A");
            worker2B.SetTask("Signal for B");
            worker2C.SetTask("Signal for C");
            
            Console.ReadLine();
        }
    }

    /// <summary>
    /// The manager.
    /// </summary>
    internal abstract class ControlBlock
    {
        /// <summary>
        /// The send message.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="device">
        /// The worker.
        /// </param>
        public abstract void SendMessage(string message, Device device);
    }

    /// <summary>
    /// The worker.
    /// </summary>
    internal abstract class Device
    {
        /// <summary>
        /// The manager.
        /// </summary>
        private readonly ControlBlock controlBlock;

        /// <summary>
        /// Initializes a new instance of the <see cref="Device"/> class.
        /// </summary>
        /// <param name="controlBlock">
        /// The control block.
        /// </param>
        protected Device(ControlBlock controlBlock)
        {
            this.controlBlock = controlBlock;
        }

        /// <summary>
        /// The send message.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public virtual void SetTask(string message)
        {
            this.controlBlock.SendMessage(message, this);
        }

        /// <summary>
        /// The notify.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public abstract void ExecuteOperation(string message);
    }

    /// <summary>
    /// The worker a.
    /// </summary>
    internal class DeviceA : Device
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceA"/> class.
        /// </summary>
        /// <param name="manager">
        /// The manager.
        /// </param>
        public DeviceA(ControlBlock manager)
            : base(manager)
        {
        }

        /// <summary>
        /// The notify.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public override void ExecuteOperation(string message)
        {
            Console.WriteLine("Сообщение для A: {0}", message);
        }
    }

    /// <summary>
    /// The worker a.
    /// </summary>
    internal class DeviceB : Device
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceB"/> class.
        /// </summary>
        /// <param name="manager">
        /// The manager.
        /// </param>
        public DeviceB(ControlBlock manager)
            : base(manager)
        {
        }

        /// <summary>
        /// The notify.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public override void ExecuteOperation(string message)
        {
            Console.WriteLine("Сообщение для B: {0}", message);
        }
    }

    /// <summary>
    /// The worker a.
    /// </summary>
    internal class DeviceC : Device
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceC"/> class.
        /// </summary>
        /// <param name="manager">
        /// The manager.
        /// </param>
        public DeviceC(ControlBlock manager)
            : base(manager)
        {
        }

        /// <summary>
        /// The notify.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public override void ExecuteOperation(string message)
        {
            Console.WriteLine("Сообщение для С : {0}", message);
        }
    }

    /// <summary>
    /// The dirrector.
    /// </summary>
    internal class ControlBlock1 : ControlBlock
    {
        /// <summary>
        /// Gets or sets the worker a.
        /// </summary>
        public Device DeviceA { get; set; }

        /// <summary>
        /// Gets or sets the worker b.
        /// </summary>
        public Device DeviceB { get; set; }

        /// <summary>
        /// Gets or sets the worker c.
        /// </summary>
        public Device DeviceC { get; set; }

        /// <summary>
        /// The send message.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="device">
        /// The worker.
        /// </param>
        public override void SendMessage(string message, Device device)
        {
            if (device == this.DeviceA)
            {
                Console.WriteLine("Manager 1 Dispatch A");
                this.DeviceB.ExecuteOperation(message);
            }

            if (device == this.DeviceB)
            {
                Console.WriteLine("Manager 1 Dispatch B");
                this.DeviceC.ExecuteOperation(message);
            }

            if (device == this.DeviceC)
            {
                Console.WriteLine("Manager 1 Dispatch C");
                this.DeviceA.ExecuteOperation(message);
            }
        }
    }

    /// <summary>
    /// The dirrector.
    /// </summary>
    internal class ControlBlock2 : ControlBlock
    {
        /// <summary>
        /// Gets or sets the worker a.
        /// </summary>
        public Device DeviceA { get; set; }

        /// <summary>
        /// Gets or sets the worker b.
        /// </summary>
        public Device DeviceB { get; set; }

        /// <summary>
        /// Gets or sets the worker c.
        /// </summary>
        public Device DeviceC { get; set; }

        /// <summary>
        /// The send message.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="device">
        /// The worker.
        /// </param>
        public override void SendMessage(string message, Device device)
        {
            if (device == this.DeviceA)
            {
                Console.WriteLine("Manager 2 Dispatch A");
                this.DeviceB.ExecuteOperation(message);
            }

            if (device == this.DeviceB)
            {
                Console.WriteLine("Manager 2 Dispatch B");                
                this.DeviceC.ExecuteOperation(message);
            }

            if (device == this.DeviceC)
            {
                Console.WriteLine("Manager 2 Dispatch C");                
                this.DeviceA.ExecuteOperation(message);
            }
        }
    }
}