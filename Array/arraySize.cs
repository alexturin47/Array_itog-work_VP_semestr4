using System;
using System.Windows.Forms;

namespace Array
{
    public partial class arraySize : Form
    {
        public arraySize()
        {
            InitializeComponent();
        }

        private void arraySize_Load(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Form1 main = this.Owner as Form1;
            main.numericInput(e);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            Form1 main = this.Owner as Form1;
            main.numericInput(e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;
            if (!main.checkValue(textBox1.Text, textBox2.Text)) return;

            Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
