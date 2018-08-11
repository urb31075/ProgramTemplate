// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="urb31075">
//   All Right Reserved
// </copyright>
// <summary>
//   The program.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace AbstractFactory
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
            var deviceA = new Device(new DeviceCreatorA());
            deviceA.On();
            deviceA.FullTesting();

            var deviceB = new Device(new DeviceCreatorB());
            deviceB.On();
            deviceB.FullTesting();

            var deviceC = new Device(new DeviceCreatorC());
            deviceC.On();
            deviceC.FullTesting();

            Console.ReadLine();
        }

        /// <summary>
        /// The device.
        /// </summary>
        public class Device
        {
            /// <summary>
            /// The self testing.
            /// </summary>
            private readonly Configurator configurator;

            /// <summary>
            /// The chanel testing.
            /// </summary>
            private readonly Testor testor;

            /// <summary>
            /// Initializes a new instance of the <see cref="Device"/> class.
            /// </summary>
            /// <param name="deviceCreator">
            /// The device Creator.
            /// </param>
            public Device(DeviceCreator deviceCreator)
            {
                this.configurator = deviceCreator.CreateConfigurator();
                this.testor = deviceCreator.CreateTestor();
            }

            /// <summary>
            /// The self testing.
            /// </summary>
            public void On()
            {
                this.configurator.Load();
                this.configurator.Calibration();
            }

            /// <summary>
            /// The chanel testing.
            /// </summary>
            public void FullTesting()
            {
                this.testor.SelfTesting();
                this.testor.InputTesting();
            }
        }

        /// <summary>
        /// The device creator.
        /// </summary>
        public abstract class DeviceCreator
        {
            /// <summary>
            /// The create configurator.
            /// </summary>
            /// <returns>
            /// The <see cref="Configurator"/>.
            /// </returns>
            public abstract Configurator CreateConfigurator();

            /// <summary>
            /// The create testor.
            /// </summary>
            /// <returns>
            /// The <see cref="Testor"/>.
            /// </returns>
            public abstract Testor CreateTestor();
        }

        /// <summary>
        /// The device creator a.
        /// </summary>
        public class DeviceCreatorA : DeviceCreator
        {
            /// <summary>
            /// The create configurator.
            /// </summary>
            /// <returns>
            /// The <see cref="Configurator"/>.
            /// </returns>
            public override Configurator CreateConfigurator()
            {
                return new ConfiguratorA();
            }

            /// <summary>
            /// The create testor.
            /// </summary>
            /// <returns>
            /// The <see cref="Testor"/>.
            /// </returns>
            public override Testor CreateTestor()
            {
                return new TestorA();
            }
        }

        /// <summary>
        /// The device creator b.
        /// </summary>
        public class DeviceCreatorB : DeviceCreator
        {
            /// <summary>
            /// The create configurator.
            /// </summary>
            /// <returns>
            /// The <see cref="Configurator"/>.
            /// </returns>
            public override Configurator CreateConfigurator()
            {
                return new ConfiguratorB();
            }

            /// <summary>
            /// The create testor.
            /// </summary>
            /// <returns>
            /// The <see cref="Testor"/>.
            /// </returns>
            public override Testor CreateTestor()
            {
                return new TestorB();
            }
        }

        /// <summary>
        /// The device creator b.
        /// </summary>
        public class DeviceCreatorC : DeviceCreator
        {
            /// <summary>
            /// The create configurator.
            /// </summary>
            /// <returns>
            /// The <see cref="Configurator"/>.
            /// </returns>
            public override Configurator CreateConfigurator()
            {
                return new ConfiguratorC();
            }

            /// <summary>
            /// The create testor.
            /// </summary>
            /// <returns>
            /// The <see cref="Testor"/>.
            /// </returns>
            public override Testor CreateTestor()
            {
                return new TestorC();
            }
        }

        /// <summary>
        /// The chanel testing.
        /// </summary>
        public abstract class Testor
        {
            /// <summary>
            /// The self testing.
            /// </summary>
            public abstract void SelfTesting();

            /// <summary>
            /// The input testing.
            /// </summary>
            public abstract void InputTesting();
        }

        /// <summary>
        /// The self testing.
        /// </summary>
        public abstract class Configurator
        {
            /// <summary>
            /// The update.
            /// </summary>
            public abstract void Update();

            /// <summary>
            /// The load.
            /// </summary>
            public abstract void Load();

            /// <summary>
            /// The calibration.
            /// </summary>
            public abstract void Calibration();
        }

        /// <summary>
        /// The self testing.
        /// </summary>
        public class ConfiguratorA : Configurator
        {
            /// <summary>
            /// The update.
            /// </summary>
            public override void Update()
            {
                Console.WriteLine("UpdateA");
            }

            /// <summary>
            /// The load.
            /// </summary>
            public override void Load()
            {
                Console.WriteLine("LoadA");
            }

            /// <summary>
            /// The calibration.
            /// </summary>
            public override void Calibration()
            {
                Console.WriteLine("CalibrationA");
            }
        }

        /// <summary>
        /// The self testing.
        /// </summary>
        public class ConfiguratorB : Configurator
        {
            /// <summary>
            /// The update.
            /// </summary>
            public override void Update()
            {
                Console.WriteLine("UpdateB");
            }

            /// <summary>
            /// The load.
            /// </summary>
            public override void Load()
            {
                Console.WriteLine("LoadB");
            }

            /// <summary>
            /// The calibration.
            /// </summary>
            public override void Calibration()
            {
                Console.WriteLine("CalibrationB");
            }
        }

        /// <summary>
        /// The self testing.
        /// </summary>
        public class ConfiguratorC : Configurator
        {
            /// <summary>
            /// The update.
            /// </summary>
            public override void Update()
            {
                Console.WriteLine("UpdateC");
            }

            /// <summary>
            /// The load.
            /// </summary>
            public override void Load()
            {
                Console.WriteLine("LoadC");
            }

            /// <summary>
            /// The calibration.
            /// </summary>
            public override void Calibration()
            {
                Console.WriteLine("CalibrationC");
            }
        }

        /// <summary>
        /// The chanel testing.
        /// </summary>
        public class TestorA : Testor
        {
            /// <summary>
            /// The self testing.
            /// </summary>
            public override void SelfTesting()
            {
                Console.WriteLine("SelfTestingA");
            }

            /// <summary>
            /// The input testing.
            /// </summary>
            public override void InputTesting()
            {
                Console.WriteLine("InputTestingA");
            }
        }

        /// <summary>
        /// The chanel testing.
        /// </summary>
        public class TestorB : Testor
        {
            /// <summary>
            /// The self testing.
            /// </summary>
            public override void SelfTesting()
            {
                Console.WriteLine("SelfTestingB");
            }

            /// <summary>
            /// The input testing.
            /// </summary>
            public override void InputTesting()
            {
                Console.WriteLine("InputTestingB");
            }
        }

        /// <summary>
        /// The chanel testing.
        /// </summary>
        public class TestorC : Testor
        {
            /// <summary>
            /// The self testing.
            /// </summary>
            public override void SelfTesting()
            {
                Console.WriteLine("SelfTestingC");
            }

            /// <summary>
            /// The input testing.
            /// </summary>
            public override void InputTesting()
            {
                Console.WriteLine("InputTestingC");
            }
        }
    }
}