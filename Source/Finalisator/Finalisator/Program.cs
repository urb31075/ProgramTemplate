// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="urb31075">
// All Right Reserved  
// </copyright>
// <summary>
//   The program.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Finalisator
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;

    /// <summary>
    /// The program.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// The mc.
        /// </summary>
        private static MyComponent mc;

        /// <summary>
        /// The main.
        /// </summary>
        private static void Main()
        {
            var a = 1;
            switch (a)
            {
                case 0:
                        mc = new MyComponent();
                        mc.Run();
                        throw new Exception("Test exeption");

                case 1:
                    try
                    {
                        using (mc = new MyComponent())
                        {
                            mc.Run();
                            throw new Exception("Test exeption");
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.SaveLog(ex.Message);
                        throw;
                    }

                case 2:
                        try
                        {
                            mc = new MyComponent();
                            mc.Run();
                            throw new Exception("Test exeption");
                        }
                        catch (Exception ex)
                        {
                            Logger.SaveLog(ex.Message);
                            throw;
                        }
                        finally
                        {
                            mc.Dispose();
                        }
            }

            Thread.Sleep(2000);
            Logger.SaveLog("***");
            Logger.SaveTotalMemory();
            Logger.SaveLog("GC.Collect");
            GC.Collect();
            Logger.SaveTotalMemory();

            while (true)
            {
                Console.WriteLine("GC.GetTotalMemory " + GC.GetTotalMemory(false) + " " + DateTime.Now.ToLongTimeString());
                Thread.Sleep(10000);
            }
        }
    }

    /// <summary>
    /// The logger.
    /// </summary>
    internal static class Logger
    {
        /// <summary>
        /// The save log.
        /// </summary>
        /// <param name="msg">
        /// The msg.
        /// </param>
        public static void SaveLog(string msg)
        {
            using (var file = new StreamWriter(@"C:\Log.txt", true))
            {
                file.WriteLine(msg + " : " + DateTime.Now.ToLongTimeString());
            }
        }

        /// <summary>
        /// The save total memory.
        /// </summary>
        public static void SaveTotalMemory()
        {
            SaveLog("GC.GetTotalMemory " + GC.GetTotalMemory(true));
        }
    }

    /// <summary>
    /// The my component.
    /// </summary>
    internal class MyComponent : IDisposable
    {
        /// <summary>
        /// The tmp.
        /// </summary>
        private readonly List<int> tmp = new List<int>(); 

        /// <summary>
        /// Initializes a new instance of the <see cref="MyComponent"/> class.
        /// </summary>
        public MyComponent()
        {
            if (File.Exists(@"C:\Log.txt"))
            {
                File.Delete(@"C:\Log.txt");
            }

            Logger.SaveLog("Constructor");
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="MyComponent"/> class. 
        /// </summary>
        ~MyComponent()
        {
            Logger.SaveLog("Finalisator");
            this.Dispose();
        }

        /// <summary>
        /// The dispose.
        /// </summary>
        public void Dispose()
        {
            Logger.SaveLog("Dispose");
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// The run.
        /// </summary>
        public void Run()
        {
            Logger.SaveLog("Run");
            Logger.SaveTotalMemory();
            for (var i = 0; i < 1; i++)
            {
                this.tmp.Add(0);
            }

            Logger.SaveLog("Allocate menory " + this.tmp.Count);
            Logger.SaveTotalMemory();
        }
    }
}
