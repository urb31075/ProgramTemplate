// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="urb31075">
// All Right Reserved  
// </copyright>
// <summary>
//   The program.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Adapter
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
            var commandSender = new CommandSender();

            var deviceA = new DeviceA();
            commandSender.Push(new DeviceAdapterA(deviceA));
            commandSender.Push(new DeviceAdapterInterfaceA(deviceA));

            var deviceB = new DeviceB();
            commandSender.Push(new DeviceAdapterB(deviceB));
            commandSender.Push(new DeviceAdapterInterfaceB(deviceB));

            var deviceC = new DeviceC();
            commandSender.Push(new DeviceAdapterC(deviceC));
            commandSender.Push(new DeviceAdapterInterfaceC(deviceC));

            Console.ReadLine();
        }
    }

    #region через наследование

    internal abstract class BaseDevice
    {
        public abstract void Push();
    }

    internal class DeviceAdapterA : BaseDevice
    {
        private readonly DeviceA device;
        public DeviceAdapterA(DeviceA device)
        {
            this.device = device;
        }

        public override void Push()
        {
            this.device.Run();
        }
    }

    internal class DeviceAdapterB : BaseDevice
    {
        private readonly DeviceB device;        
        public DeviceAdapterB(DeviceB device)
        {
            this.device = device;            
        }

        public override void Push()
        {
            this.device.Tumbler1On();
            this.device.Tumbler2On();
            this.device.Tumbler3On();
        }
    }

    internal class DeviceAdapterC : BaseDevice
    {
        private readonly DeviceC device;
        public DeviceAdapterC(DeviceC device)
        {
            this.device = device;
        }

        public override void Push()
        {
            this.device.Heatting();
            this.device.RubilnikOn();
        }
    }

    #endregion

    #region через интерфейс

    interface IBaseDevice
    {
        void Push();
    }

    internal class DeviceAdapterInterfaceA : IBaseDevice
    {
        private readonly DeviceA device;
        public DeviceAdapterInterfaceA(DeviceA device)
        {
            this.device = device;
        }

        public void Push()
        {
            this.device.Run();
        }
    }

    internal class DeviceAdapterInterfaceB : IBaseDevice
    {
        private readonly DeviceB device;
        public DeviceAdapterInterfaceB(DeviceB device)
        {
            this.device = device;
        }

        public void Push()
        {
            this.device.Tumbler1On();
            this.device.Tumbler2On();
            this.device.Tumbler3On();
        }
    }

    internal class DeviceAdapterInterfaceC : IBaseDevice
    {
        private readonly DeviceC device;
        public DeviceAdapterInterfaceC(DeviceC device)
        {
            this.device = device;
        }

        public void Push()
        {
            this.device.Heatting();
            this.device.RubilnikOn();
        }
    }

    #endregion
}