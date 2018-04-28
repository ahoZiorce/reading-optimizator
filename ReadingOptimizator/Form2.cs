using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReadingOptimizator
{
    public partial class Form2 : Form
    {
        private List<string> words;
        private int interval;
        public Form2(List<string> wordsList, int a_interval)
        {
            InitializeComponent();
            words = wordsList;
            interval = a_interval;
            this.Shown += onShown;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            this.Bounds = Screen.PrimaryScreen.Bounds;
            this.label1.Location = new Point(this.Size.Width / 2 - ((this.label1.Width / 2) - this.label1.Text.Length / 2), this.Size.Height / 2 - (this.label1.Height / 2));
        }

        private void onShown(object sender, EventArgs e)
        {
            new Thread(() => {
                for (int i = 0; i < words.Count; i++)
                {
                    this.label1.Text = words[i];
                    this.label1.Location = new Point(this.Size.Width / 2 - ((this.label1.Width / 2) - this.label1.Text.Length / 2), this.Size.Height / 2 - (this.label1.Height / 2));
                    Thread.Sleep(interval);
                }
                this.label1.ForeColor = Color.Green;
                this.label1.Text = "Finished";
                this.label1.Location = new Point(this.Size.Width / 2 - ((this.label1.Width / 2) - this.label1.Text.Length / 2), this.Size.Height / 2 - (this.label1.Height / 2));
                this.label1.Click += label1Click;
            }).Start();
        }

        private void label1Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
