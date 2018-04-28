using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReadingOptimizator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            this.label2.Text = trackBar1.Value.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.label2.Text = trackBar1.Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> words = new List<string>();
            words = richTextBox1.Text.Replace('\n', ' ').Split(' ').ToList<string>();
            Form2 f2 = new Form2(words, trackBar1.Value);
            f2.Show();
        }

        private void creditsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
        }
    }
}
