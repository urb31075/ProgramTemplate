// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="urb31075">
// All Right Reserved
// </copyright>
// <summary>
//   The program.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Composite
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The program.
    /// </summary>
    internal class Program
    {
        public MyComponent cnt;

        /// <summary>
        /// The main.
        /// </summary>
        private static void Main()
        {
            MyComponent root = new RootItem("FAT");
            MyComponent diskC = new RootItem("DiskC");
            MyComponent diskD = new RootItem("DiskD");
            root.Add(diskC);
            root.Add(diskD);
            MyComponent item1 = new ChildItem("item1");
            MyComponent item2 = new ChildItem("item2");
            diskC.Add(item1);
            diskC.Add(item2);
            MyComponent item3 = new ChildItem("item3");
            MyComponent item4 = new ChildItem("item4");
            MyComponent item5 = new ChildItem("item5");
            diskD.Add(item3);
            diskD.Add(item4);
            diskD.Add(item5);

            root.Run();

            Console.WriteLine("*** Remove D ***");
            root.Remove(diskD);
            root.Run();
            Console.ReadLine();
        }
    }

    /// <summary>
    /// The root item.
    /// </summary>
    internal class RootItem : MyComponent
    {
        /// <summary>
        /// The component list.
        /// </summary>
        private readonly List<MyComponent> componentList = new List<MyComponent>();

        /// <summary>
        /// Initializes a new instance of the <see cref="RootItem"/> class.
        /// </summary>
        /// <param name="root">
        /// The root.
        /// </param>
        public RootItem(string root) : base(root)
        {
        }

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="component">
        /// The component.
        /// </param>
        public override void Add(MyComponent component)
        {
            this.componentList.Add(component);
        }

        /// <summary>
        /// The remove.
        /// </summary>
        /// <param name="component">
        /// The component.
        /// </param>
        public override void Remove(MyComponent component)
        {
            this.componentList.Remove(component);
        }

        /// <summary>
        /// The run.
        /// </summary>
        public override void Run()
        {
            Console.WriteLine("ROOT: {0}", this.Name);
            Console.WriteLine("Content: ");
            foreach (var c in this.componentList)
            {
                c.Run();
            }
        }
    }

    /// <summary>
    /// The root item.
    /// </summary>
    internal class ChildItem : MyComponent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChildItem"/> class. 
        /// </summary>
        /// <param name="root">
        /// The root.
        /// </param>
        public ChildItem(string root) : base(root){}

        /// <summary>
        /// The run.
        /// </summary>
        public override void Run()
        {
            Console.WriteLine("CHILD: {0}", this.Name);
        }
    }

    /// <summary>
    /// The my component.
    /// </summary>
    internal abstract class MyComponent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MyComponent"/> class.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        protected MyComponent(string name)
        {
            this.Name = name;
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        protected string Name { get; set; }

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="component">
        /// The component.
        /// </param>
        public virtual void Add(MyComponent component)
        {
        }

        /// <summary>
        /// The remove.
        /// </summary>
        /// <param name="component">
        /// The component.
        /// </param>
        public virtual void Remove(MyComponent component)
        {
        }

        /// <summary>
        /// The run.
        /// </summary>
        public virtual void Run()
        {
            Console.WriteLine(this.Name);
        }
    }
}