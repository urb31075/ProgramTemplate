// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="urb31075">
//   All Right Reserved
// </copyright>
// <summary>
//   The program.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Decorator
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
            var device = new BaseDevice();
            device.Run();
            Console.WriteLine();

            var deviceExtendSlot = new DeviceExtendSlot(device);
            deviceExtendSlot.Run();
            Console.WriteLine();

            var deviceExtendSlotAndChannel = new DeviceExtendChannel(deviceExtendSlot);
            deviceExtendSlotAndChannel.Run();
            Console.WriteLine();

            var deviceExtendChannel = new DeviceExtendChannel(device);
            deviceExtendChannel.Run();

            Console.ReadLine();
        }
    }

    /// <summary>
    /// The device.
    /// </summary>
    internal abstract class Device
    {
        /// <summary>
        /// The run.
        /// </summary>
        public abstract void Run();
    }

    /// <summary>
    /// The device extend.
    /// </summary>
    internal abstract class DeviceExtend : Device
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceExtend"/> class.
        /// </summary>
        /// <param name="device">
        /// The device.
        /// </param>
        protected DeviceExtend(Device device)
        {
            this.Device = device;
        }

        /// <summary>
        /// Gets or sets the device.
        /// </summary>
        protected Device Device { get; set; }

        /// <summary>
        /// The run.
        /// </summary>
        public override void Run()
        {
            this.Device.Run();
        }
    }

    /// <summary>
    /// The device.
    /// </summary>
    internal class BaseDevice : Device
    {
        /// <summary>
        /// The run.
        /// </summary>
        public override void Run()
        {
            Console.WriteLine("Run of BaseDevice");
        }
    }

    /// <summary>
    /// The device extend slot.
    /// </summary>
    internal class DeviceExtendSlot : DeviceExtend
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceExtendSlot"/> class.
        /// </summary>
        /// <param name="device">
        /// The device.
        /// </param>
        public DeviceExtendSlot(Device device) : base(device)
        {
        }

        /// <summary>
        /// The run.
        /// </summary>
        public override void Run()
        {
            base.Run();
            Console.WriteLine("Run of ExtendSlot");
        }
    }

    /// <summary>
    /// The device extend channel.
    /// </summary>
    internal class DeviceExtendChannel : DeviceExtend
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceExtendChannel"/> class.
        /// </summary>
        /// <param name="device">
        /// The device.
        /// </param>
        public DeviceExtendChannel(Device device) : base(device)
        {
        }

        /// <summary>
        /// The run.
        /// </summary>
        public override void Run()
        {
            base.Run();
            Console.WriteLine("Run of ExtendChannel");
        }
    }
}