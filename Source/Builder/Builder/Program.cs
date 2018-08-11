// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="urb31075">
//   All Right Reserved
// </copyright>
// <summary>
//   Defines the Program type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Builder
{
    using System;
    using System.Collections.Generic;

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
            var deviceBuilderA = new DeviceBuilderA();
            var deviceBuilderB = new DeviceBuilderB();

            /*deviceBuilderA.Load();
            deviceBuilderA.Config();
            deviceBuilderA.Test();
            
            deviceBuilderB.Load();
            deviceBuilderB.Config();
            deviceBuilderB.Test();*/

            Configurator.Run(deviceBuilderA);
            Configurator.Run(deviceBuilderB);
  
            var deviceList = new List<Device> { deviceBuilderA.GetDevice(), deviceBuilderB.GetDevice() };
            foreach (var device in deviceList)
            {
               device.Run();
            }

            Console.ReadLine();
        }

        /// <summary>
        /// The device.
        /// </summary>
        public class Device
        {
            /// <summary>
            /// Gets or sets the operation.
            /// </summary>
            public string Operation { get; set; }

            /// <summary>
            /// The run.
            /// </summary>
            public void Run()
            {
                Console.WriteLine(this.Operation);
            }
        }

        /// <summary>
        /// The device builder.
        /// </summary>
        public abstract class DeviceBuilder
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="DeviceBuilder"/> class.
            /// </summary>
            protected DeviceBuilder() 
            {
              this.BildetDevice = new Device();  
            }

            /// <summary>
            /// Gets or sets the bildet device.
            /// </summary>
            protected Device BildetDevice { get; set; }

            /// <summary>
            /// The load.
            /// </summary>
            public abstract void Load();

            /// <summary>
            /// The config.
            /// </summary>
            public abstract void Config();

            /// <summary>
            /// The test.
            /// </summary>
            public abstract void Test();

            /// <summary>
            /// The get device.
            /// </summary>
            /// <returns>
            /// The <see cref="Program.Device"/>.
            /// </returns>
            public Device GetDevice()
            {
                return this.BildetDevice;                
            }
        }

        /// <summary>
        /// The device builder a.
        /// </summary>
        public class DeviceBuilderA : DeviceBuilder
        {
            /// <summary>
            /// The load.
            /// </summary>
            public override void Load()
            {
               this.BildetDevice.Operation += "LoadA ";
            }

            /// <summary>
            /// The config.
            /// </summary>
            public override void Config()
            {
                this.BildetDevice.Operation += "ConfigA ";
            }

            /// <summary>
            /// The test.
            /// </summary>
            public override void Test()
            {
                this.BildetDevice.Operation += "TestA ";                
            }
        }

        /// <summary>
        /// The device builder b.
        /// </summary>
        public class DeviceBuilderB : DeviceBuilder
        {
            /// <summary>
            /// The load.
            /// </summary>
            public override void Load()
            {
                this.BildetDevice.Operation += "LoadB ";
            }

            /// <summary>
            /// The config.
            /// </summary>
            public override void Config()
            {
                this.BildetDevice.Operation += "ConfigB ";
            }

            /// <summary>
            /// The test.
            /// </summary>
            public override void Test()
            {
                this.BildetDevice.Operation += "TestB ";                
            }
        }

        /// <summary>
        /// The configurator.
        /// </summary>
        public class Configurator
        {
            /// <summary>
            /// Prevents a default instance of the <see cref="Configurator"/> class from being created.
            /// </summary>
            private Configurator()
            {
            }

            /// <summary>
            /// The load.
            /// </summary>
            /// <param name="deviceBuilder">
            /// The device builder.
            /// </param>
            public static void Run(DeviceBuilder deviceBuilder)
            {
                deviceBuilder.Load();
                deviceBuilder.Config();
                deviceBuilder.Test();
            }
        }
    }
}