// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParamProductCreator.cs" company="urb31075">
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
    public class ParamProductCreator
    {
        /// <summary>
        /// The generate.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <returns>
        /// The <see cref="AbstractProduct"/>.
        /// </returns>
        public AbstractProduct Generate(int type)
        {
            switch (type)
            {
                case 1: return new ProductA();
                case 2: return new ProductB();
                case 3: return new ProductC();
            }
            
            return null;
        }
    }
}