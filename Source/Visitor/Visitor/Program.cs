// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="urb31075">
//   All Right Reserved
// </copyright>
// <summary>
//   The program.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Visitor
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The ProtocolHandler interface.
    /// </summary>
    internal interface IProtocolHandler
    {
        /// <summary>
        /// The visit person acc.
        /// </summary>
        /// <param name="acc">
        /// The acc.
        /// </param>
        void SendXyz(ProtokolXyz acc);

        /// <summary>
        /// The visit company acc.
        /// </summary>
        /// <param name="acc">
        /// The acc.
        /// </param>
        void SendAbc(ProtocolAbc acc);

        /// <summary>
        /// The send null.
        /// </summary>
        /// <param name="acc">
        /// The acc.
        /// </param>
        void SendNull(ProtocolNull acc);
    }

    /// <summary>
    /// The Account interface.
    /// </summary>
    internal interface IExecuteOperation
    {
        /// <summary>
        /// The accept.
        /// </summary>
        /// <param name="visitor">
        /// The visitor.
        /// </param>
        void ExecuteOperation(IProtocolHandler visitor);
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
            var device = new Device();
            device.AddProtocol(new ProtokolXyz { Header = "XXX", CriptoKey = "7642467864" });
            device.AddProtocol(new ProtocolAbc { StartStr = "AAA", StopStr = "aaa", PrivateKey = "989877866" });
            device.AddProtocol(new ProtocolNull());

            device.ExecuteOperation(new Handler1());
            device.ExecuteOperation(new Handler2());
            device.ExecuteOperation(new Handler3());
            device.ExecuteOperation(new Handler4());
            device.ExecuteOperation(new Handler5());

            Console.Read();
        }
    }

    /// <summary>
    /// The xml visitor.
    /// </summary>
    internal class Handler1 : IProtocolHandler
    {
        /// <summary>
        /// The visit person acc.
        /// </summary>
        /// <param name="acc">
        /// The acc.
        /// </param>
        public void SendXyz(ProtokolXyz acc)
        {
            Console.WriteLine("Handler1 Send XYZ");
        }

        /// <summary>
        /// The visit company acc.
        /// </summary>
        /// <param name="acc">
        /// The acc.
        /// </param>
        public void SendAbc(ProtocolAbc acc)
        {
            Console.WriteLine("Handler1 Send ABC");
        }

        /// <summary>
        /// The send null.
        /// </summary>
        /// <param name="acc">
        /// The acc.
        /// </param>
        public void SendNull(ProtocolNull acc)
        {
            Console.WriteLine("Handler1 Send NULL");
        }
    }

    /// <summary>
    /// The html visitor.
    /// </summary>
    internal class Handler2 : IProtocolHandler
    {
        /// <summary>
        /// The visit person acc.
        /// </summary>
        /// <param name="acc">
        /// The acc.
        /// </param>
        public void SendXyz(ProtokolXyz acc)
        {
            Console.WriteLine("Handler2 Send XYZ");
        }

        /// <summary>
        /// The visit company acc.
        /// </summary>
        /// <param name="acc">
        /// The acc.
        /// </param>
        public void SendAbc(ProtocolAbc acc)
        {
            Console.WriteLine("Handler2 Send ABC");
        }

        /// <summary>
        /// The send null.
        /// </summary>
        /// <param name="acc">
        /// The acc.
        /// </param>
        public void SendNull(ProtocolNull acc)
        {
            Console.WriteLine("Handler2 Send NULL");
        }
    }

    /// <summary>
    /// The xml visitor.
    /// </summary>
    internal class Handler3 : IProtocolHandler
    {
        /// <summary>
        /// The visit person acc.
        /// </summary>
        /// <param name="acc">
        /// The acc.
        /// </param>
        public void SendXyz(ProtokolXyz acc)
        {
            Console.WriteLine("Handler3 Send XYZ");
        }

        /// <summary>
        /// The visit company acc.
        /// </summary>
        /// <param name="acc">
        /// The acc.
        /// </param>
        public void SendAbc(ProtocolAbc acc)
        {
            Console.WriteLine("Handler3 Send ABC");
        }
        
        /// <summary>
        /// The send null.
        /// </summary>
        /// <param name="acc">
        /// The acc.
        /// </param>
        public void SendNull(ProtocolNull acc)
        {
            Console.WriteLine("Handler3 Send NULL");
        }
    }

    /// <summary>
    /// The xml visitor.
    /// </summary>
    internal class Handler4 : IProtocolHandler
    {
        /// <summary>
        /// The visit person acc.
        /// </summary>
        /// <param name="acc">
        /// The acc.
        /// </param>
        public void SendXyz(ProtokolXyz acc)
        {
            Console.WriteLine("Handler4 Send XYZ");
        }

        /// <summary>
        /// The visit company acc.
        /// </summary>
        /// <param name="acc">
        /// The acc.
        /// </param>
        public void SendAbc(ProtocolAbc acc)
        {
            Console.WriteLine("Handler4 Send ABC");
        }

        /// <summary>
        /// The send null.
        /// </summary>
        /// <param name="acc">
        /// The acc.
        /// </param>
        public void SendNull(ProtocolNull acc)
        {
            Console.WriteLine("Handler4 Send NULL");
        }
    }

    /// <summary>
    /// The xml visitor.
    /// </summary>
    internal class Handler5 : IProtocolHandler
    {
        /// <summary>
        /// The visit person acc.
        /// </summary>
        /// <param name="acc">
        /// The acc.
        /// </param>
        public void SendXyz(ProtokolXyz acc)
        {
            Console.WriteLine("Handler5 Send XYZ");
        }

        /// <summary>
        /// The visit company acc.
        /// </summary>
        /// <param name="acc">
        /// The acc.
        /// </param>
        public void SendAbc(ProtocolAbc acc)
        {
            Console.WriteLine("Handler5 Send ABC");
        }

        /// <summary>
        /// The send null.
        /// </summary>
        /// <param name="acc">
        /// The acc.
        /// </param>
        public void SendNull(ProtocolNull acc)
        {
            Console.WriteLine("Handler5 Send NULL");
        }
    }


    /// <summary>
    /// The person.
    /// </summary>
    internal class ProtokolXyz : IExecuteOperation
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Header { get; set; }

        /// <summary>
        /// Gets or sets the number.
        /// </summary>
        public string CriptoKey { get; set; }

        /// <summary>
        /// The accept.
        /// </summary>
        /// <param name="visitor">
        /// The visitor.
        /// </param>
        public void ExecuteOperation(IProtocolHandler visitor)
        {
            visitor.SendXyz(this);
        }
    }

    /// <summary>
    /// The company.
    /// </summary>
    internal class ProtocolAbc : IExecuteOperation
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string StartStr { get; set; }

        /// <summary>
        /// Gets or sets the stop str.
        /// </summary>
        public string StopStr { get; set; }

        /// <summary>
        /// Gets or sets the number.
        /// </summary>
        public string PrivateKey { get; set; }

        /// <summary>
        /// The accept.
        /// </summary>
        /// <param name="visitor">
        /// The visitor.
        /// </param>
        public void ExecuteOperation(IProtocolHandler visitor)
        {
            visitor.SendAbc(this);
        }
    }

    /// <summary>
    /// The company.
    /// </summary>
    internal class ProtocolNull : IExecuteOperation
    {
        /// <summary>
        /// The accept.
        /// </summary>
        /// <param name="visitor">
        /// The visitor.
        /// </param>
        public void ExecuteOperation(IProtocolHandler visitor)
        {
            visitor.SendNull(this);
        }
    }

    /// <summary>
    /// The bank.
    /// </summary>
    internal class Device
    {
        /// <summary>
        /// The accounts.
        /// </summary>
        private readonly List<IExecuteOperation> accounts = new List<IExecuteOperation>();

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the number.
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="acc">
        /// The acc.
        /// </param>
        public void AddProtocol(IExecuteOperation acc)
        {
            this.accounts.Add(acc);
        }

        /// <summary>
        /// The accept.
        /// </summary>
        /// <param name="visitor">
        /// The visitor.
        /// </param>
        public void ExecuteOperation(IProtocolHandler visitor)
        {
            foreach (IExecuteOperation acc in this.accounts)
            {
                acc.ExecuteOperation(visitor);
            }
        }
    }
}