// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileConfigurator.cs" company="urb31075">
//  All Right Reserved
// </copyright>
// <summary>
//   The file configurator.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Configurator
{
    using System;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// The file configurator.
    /// </summary>
    public class FileConfigurator
    {
        /// <summary>
        /// The sync root.
        /// </summary>
        private static readonly object SyncRoot = new object();

        /// <summary>
        /// The instance.
        /// </summary>
        private static FileConfigurator instance;

        /// <summary>
        /// The init status.
        /// </summary>
        private bool initStatus;

        /// <summary>
        /// The init date time.
        /// </summary>
        private DateTime initDateTime;

        /// <summary>
        /// The init value.
        /// </summary>
        private string initValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileConfigurator"/> class. 
        /// Prevents a default instance of the <see cref="FileConfigurator"/> class from being created.
        /// </summary>
        protected FileConfigurator()
        {
            this.initDateTime = DateTime.Now;
        }

        /// <summary>
        /// The get instance.
        /// </summary>
        /// <returns>
        /// The <see cref="FileConfigurator"/>.
        /// </returns>
        public static FileConfigurator GetInstance()
        {
            if (instance == null)
            {
                lock (SyncRoot)
                {
                    return instance ?? (instance = new FileConfigurator());
                }
            }

            return instance;
        }

        /// <summary>
        /// The init.
        /// </summary>
        /// <param name="value">
        /// The init value.
        /// </param>
        public void Init(string value)
        {
            this.initStatus = true;
            this.initValue = value;
        }

        /// <summary>
        /// The get config key.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string GetConfigKey()
        {
            this.CheckInitialized();
            return this.initDateTime.ToLongTimeString() + " -> " + this.initValue + " Key";
        }

        /// <summary>
        /// The write config key.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        public void WriteConfigKey(string key)
        {
            Console.WriteLine(key);
        }

        /// <summary>
        /// The check initialized.
        /// </summary>
        /// <exception cref="NullReferenceException">
        /// Configurator not initialized!
        /// </exception>
        private void CheckInitialized()
        {
            if (!this.initStatus)
            {
                throw new NullReferenceException("Configurator not initialized!");
            }
        }
    }
}