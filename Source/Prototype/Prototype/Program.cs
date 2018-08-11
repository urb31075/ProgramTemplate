// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="urb31075">
//   All Right Reserved
// </copyright>
// <summary>
//   The program.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Prototype
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Security.Cryptography.X509Certificates;

    internal class GroupedValue
    {
        public IGrouping<int, int> myvalue;

        public GroupedValue(IGrouping<int, int> v)
        {
            this.myvalue = v;
        }
    }

    /// <summary>
    /// The gr.
    /// </summary>
    class MyGrouping : IGrouping<int, int>
    {
        public MyGrouping(int k)
        {
            this.Key = k;
        }
        readonly List<int> numbers = new List<int>(){ 1, 2, 3};

        public IEnumerator<int> GetEnumerator()
        {
            return this.numbers.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public int Key { get; private set; }
    }

    /// <summary>
    /// The program.
    /// </summary>
    internal class Program
    {

        public static List<GroupedValue> Linq40()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var numberGroups =
                from n in numbers
                group n by n % 5 into g
                select new GroupedValue(g);

            return numberGroups.ToList();
        }

        /// <summary>
        /// The main.
        /// </summary>
        private static void Main()
        {
            var gr = new MyGrouping(12);
            Console.WriteLine("Key: {0}", gr.Key);
            foreach (var g in gr)
            {
                Console.WriteLine("value: {0}", g);
            }

            var groupedValueList = new List<MyGrouping> { new MyGrouping(11), new MyGrouping(12), new MyGrouping(13) };

            var numberGroups = Linq40();
            foreach (var g in numberGroups)
            {
                Console.WriteLine("Key: {0}", g.myvalue.Key);
                foreach (var n in g.myvalue)
                {
                    Console.WriteLine(n);
                }
            }

            var deviceA = new DeviceA("AAA") { UnikumA = "UnikumA" };
            deviceA.DeviceAInit();
            Console.WriteLine("Created:  " + deviceA);
            var cloneDeviceA = (DeviceA)deviceA.DeepCopy();
            //var cloneDeviceA = (DeviceA)deviceA.Clone();
            cloneDeviceA.Name = "aaa";
            cloneDeviceA.UnikumA = "UnikumZ";

            cloneDeviceA.DeviceVersionA.Build = "YYY";
            cloneDeviceA.DeviceVersionA.Minor = "XXX";

            Console.WriteLine("Original: " + deviceA);
            Console.WriteLine("Cloned:   " + cloneDeviceA);

            /*
            var deviceB = new DeviceB("BBB") { UnikumB = "UnikumB" };
            deviceB.DeviceBInit();
            Console.WriteLine(deviceB.ToString());
            
            var cloneDeviceB = (DeviceB)deviceB.Clone();
            cloneDeviceB.Name = "BBB###";
            Console.WriteLine(cloneDeviceB.ToString());
            cloneDeviceB.DeviceBInit();
            Console.WriteLine(cloneDeviceB.ToString());*/
            Console.ReadLine();
        }
    }

    /// <summary>
    /// The device.
    /// </summary>
    [Serializable]
    internal abstract class Device
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Device"/> class.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        protected Device(string name)
        {
            this.Name = name;
            this.ParamA = 0;
            this.ParamB = 0;
            this.ParamC = 0;
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the index.
        /// </summary>
        public List<string> Index { get; set; }

        /// <summary>
        /// Gets or sets the param a.
        /// </summary>
        protected int ParamA { get; set; }

        /// <summary>
        /// Gets or sets the param b.
        /// </summary>
        protected int ParamB { get; set; }

        /// <summary>
        /// Gets or sets the param c.
        /// </summary>
        protected int ParamC { get; set; }

        /// <summary>
        /// The to string.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} {4}", this.Name, this.ParamA, this.ParamB, this.ParamC, this.Index.First());
        }

        /// <summary>
        /// The clone.
        /// </summary>
        /// <returns>
        /// The <see cref="Device"/>.
        /// </returns>
        public Device Clone()
        {
            Console.WriteLine("Clone");
            return (Device)this.MemberwiseClone();
        }

        /// <summary>
        /// The deep copy.
        /// </summary>
        /// <returns>
        /// The <see cref="Device"/>.
        /// </returns>
        public Device DeepCopy()
        {
            using (var tempStream = new MemoryStream())
            {
                var binFormatter = new BinaryFormatter(null, new StreamingContext(StreamingContextStates.Clone));
                binFormatter.Serialize(tempStream, this);
                tempStream.Seek(0, SeekOrigin.Begin);
                var device = (Device)binFormatter.Deserialize(tempStream);
                return device;
            }
        }
    }

    /// <summary>
    /// The device version.
    /// </summary>
    [Serializable]
    internal class DeviceVersion
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceVersion"/> class.
        /// </summary>
        public DeviceVersion()
        {
            this.Build = @"unknown";
            this.Minor = @"unknown";
        }

        /// <summary>
        /// Gets or sets the build.
        /// </summary>
        public string Build { get; set; }

        /// <summary>
        /// Gets or sets the minor.
        /// </summary>
        public string Minor { get; set; }

        /// <summary>
        /// The to string.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public override string ToString()
        {
            return string.Format("{0} {1}", this.Build, this.Minor);
        }
    }

    /// <summary>
    /// The device a.
    /// </summary>
    [Serializable]
    internal class DeviceA : Device
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceA"/> class.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        public DeviceA(string name) : base(name)
        {
            Console.WriteLine("Create A");            
            this.ParamA = 1;
            this.ParamB = 2;
            this.ParamC = 3;
        }

        /// <summary>
        /// Gets or sets the unikum a.
        /// </summary>
        public string UnikumA { get; set; }

        /// <summary>
        /// Gets or sets the device version.
        /// </summary>
        public DeviceVersion DeviceVersionA { get; set; }

        /// <summary>
        /// The device a init.
        /// </summary>
        public void DeviceAInit()
        {
            Console.WriteLine("Init A");
            this.Index = new List<string> { "AAA" };
            this.DeviceVersionA = new DeviceVersion { Build = "111", Minor = "0111" };
        }

        /// <summary>
        /// The to string.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public override string ToString()
        {
            return base.ToString() + " " + this.UnikumA + " " + this.DeviceVersionA;
        }
    }

    /// <summary>
    /// The device b.
    /// </summary>
    [Serializable]
    internal class DeviceB : Device
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceB"/> class.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        public DeviceB(string name) : base(name)
        {
            Console.WriteLine("Create B");                        
            this.ParamA = 7;
            this.ParamB = 8;
            this.ParamC = 9;
        }

        /// <summary>
        /// Gets or sets the unikum b.
        /// </summary>
        public string UnikumB { get; set; }

        /// <summary>
        /// Gets or sets the device version.
        /// </summary>
        public DeviceVersion DeviceVersionB { get; set; }
        
        /// <summary>
        /// The device b init.
        /// </summary>
        public void DeviceBInit()
        {
            Console.WriteLine("Init B");
            this.Index = new List<string> { "BBB" };
            this.DeviceVersionB = new DeviceVersion { Build = "222", Minor = "0222" };
        }

        /// <summary>
        /// The to string.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public override string ToString()
        {
            return base.ToString() + " " + this.UnikumB + " " + this.DeviceVersionB;
        }
    }
}