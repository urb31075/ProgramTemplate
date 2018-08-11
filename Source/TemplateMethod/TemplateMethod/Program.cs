// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="urb31075">
// All RightReserved  
// </copyright>
// <summary>
//   The program.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace TemplateMethod
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
            Device deviceA = new DeviceA();
            Device deviceB = new DeviceB();
            deviceA.Testing();
            deviceB.Testing();
            Console.ReadLine();
        }
    }

    /// <summary>
    /// The device a.
    /// </summary>
    internal class DeviceA : Device
    {
        /// <summary>
        /// The load.
        /// </summary>
        public override void Load()
        {
            Console.WriteLine("Load A");
        }

        /// <summary>
        /// The configuration.
        /// </summary>
        public override void Configuration()
        {
            Console.WriteLine("Configuration A");
        }

        /// <summary>
        /// The self test.
        /// </summary>
        public override void SelfTest()
        {
            Console.WriteLine("SelfTest A");
        }
    }

    /// <summary>
    /// The device b.
    /// </summary>
    internal class DeviceB : Device
    {
        /// <summary>
        /// The load.
        /// </summary>
        public override void Load()
        {
            Console.WriteLine("Load B");
        }

        /// <summary>
        /// The configuration.
        /// </summary>
        public override void Configuration()
        {
            Console.WriteLine("Configuration B");
        }

        /// <summary>
        /// The self test.
        /// </summary>
        public override void SelfTest()
        {
            Console.WriteLine("SelfTest1 B");
            Console.WriteLine("SelfTest2 B");
            Console.WriteLine("SelfTest3 B");
        }
    }

    /// <summary>
    /// The base device.
    /// </summary>
    internal abstract class BaseDevice
    {
        /// <summary>
        /// The testing.
        /// </summary>
        public abstract void Testing();
    }

    /// <summary>
    /// The device.
    /// </summary>
    internal abstract class Device : BaseDevice
    {
        /// <summary>
        /// The testing.
        /// </summary>
        public override sealed void Testing()
        {
            this.Load();
            this.Configuration();
            this.SelfTest();
        }

        /// <summary>
        /// The load.
        /// </summary>
        public abstract void Load();

        /// <summary>
        /// The configuration.
        /// </summary>
        public abstract void Configuration();

        /// <summary>
        /// The self test.
        /// </summary>
        public abstract void SelfTest();
    }
}