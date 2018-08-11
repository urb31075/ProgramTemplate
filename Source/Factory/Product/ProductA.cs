// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProductA.cs" company="urb31075">
//  All Right Reserved 
// </copyright>
// <summary>
//   The product a.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Product
{
    /// <summary>
    /// The product a.
    /// </summary>
    public class ProductA : AbstractProduct
    {
        /// <summary>
        /// The work.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public override string Work()
        {
            return "Product A";
        }
    }
}