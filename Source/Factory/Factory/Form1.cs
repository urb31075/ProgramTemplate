// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Form1.cs" company="urb31075">
// All Right Reserved   
// </copyright>
// <summary>
//   The form 1.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Factory
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;

    using Product;

    /// <summary>
    /// The form 1.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// The button 1 click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void Button1Click(object sender, EventArgs e)
        {
            var productCreatorA = new ProductCreatorA();
            var productCreatorB = new ProductCreatorB();
            var productCreatorC = new ProductCreatorC();
            var productList = new List<AbstractProduct>
                {
                    productCreatorA.Generate(), 
                    productCreatorB.Generate(), 
                    productCreatorC.Generate()
                };

            var paramProductCreator = new ParamProductCreator();
            productList.Add(paramProductCreator.Generate(1));
            productList.Add(paramProductCreator.Generate(2));
            productList.Add(paramProductCreator.Generate(3));

            productList.Add(new ProductA());
            productList.Add(new ProductB());
            productList.Add(new ProductC());

            foreach (var product in productList)
            {
                this.listBox1.Items.Add(product.Work());
            }
        }

        /// <summary>
        /// The form 1 load.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void Form1Load(object sender, EventArgs e)
        {
            this.listBox1.Items.Clear();
        }
    }
}