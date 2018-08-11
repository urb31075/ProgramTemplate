// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AbstractProductCreator.cs" company="urb31075">
// All Right Reserved  
// </copyright>
// <summary>
//   The abstract product creator.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Product
{
    /// <summary>
    /// The abstract product creator.
    /// </summary>
    public abstract class AbstractProductCreator
    {
        /// <summary>
        /// The generate.
        /// </summary>
        /// <returns>
        /// The <see cref="AbstractProduct"/>.
        /// </returns>
        public abstract AbstractProduct Generate();
    }
}