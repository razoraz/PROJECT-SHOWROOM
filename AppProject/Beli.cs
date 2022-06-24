using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppProject
{
    public partial class Beli : Form
    {
        public Beli()
        {
            InitializeComponent();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Apakah Anda Ingin Keluar ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            HOME2 hm = new HOME2();
            hm.Show();
            HOME2.menu.button1.Enabled=true;
            HOME2.menu.button2.Enabled=true;
            HOME2.menu.button3.Enabled=true;
            HOME2.menu.button4.Enabled=true;
            HOME2.menu.button8.Enabled=false;
            HOME2.menu.comboBox1.Enabled=false;
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            kendaraan2 kn = new kendaraan2();
            kn.Show();
            this.Hide();
        }

        private void Beli_Load(object sender, EventArgs e)
        {

        }
    }
}
