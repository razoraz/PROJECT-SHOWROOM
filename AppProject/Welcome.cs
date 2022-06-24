using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace AppProject
{
    public partial class Welcome : Form
    {
        public Welcome()
        {
            InitializeComponent();
            timer1.Start();
        }
        int startPoint = 0;
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            startPoint += 2;
            progressBar1.Value = startPoint;
            if (progressBar1.Value == 100)
            {
                progressBar1.Value = 0;
                timer1.Stop();
                Form1 f = new Form1();
                this.Hide();
                f.ShowDialog();
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
