using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Singleton
{
    using Configurator;

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FileConfigurator.GetInstance().Init("123456789");
            Console.WriteLine(@"Init");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine(FileConfigurator.GetInstance().GetConfigKey());
            }
            catch (Exception ex)
            {
                this.listBox1.Items.Add(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int? a = null;
            int d = a ?? 25;
            int? f = a ?? (a = 34);
            return;
        }
    }
}
