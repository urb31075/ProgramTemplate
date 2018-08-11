// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProductCreatorB.cs" company="urb31075">
// All Right Reserved  
// </copyright>
// <summary>
//   The product creator a.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Product
{
    /// <summary>
    /// The product creator a.
    /// </summary>
    public class ProductCreatorB : AbstractProductCreator
    {
        /// <summary>
        /// The generate.
        /// </summary>
        /// <returns>
        /// The <see cref="AbstractProduct"/>.
        /// </returns>
        public override AbstractProduct Generate()
        {
            return new ProductB();
        }
    }
}