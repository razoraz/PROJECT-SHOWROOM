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
    public partial class home : Form
    {
        public home()
        {
            InitializeComponent();
        }
        void bersih()
        {
            comboBox1.Text="";
        }
        void combo()
        {
            comboBox1.Items.Add("Customer");
            comboBox1.Items.Add("Employee");
            comboBox1.Items.Add("Vehicle");
            comboBox1.Items.Add("Transaction");
            comboBox1.Items.Add("Detail Transaction");
            comboBox1.Items.Add("Pembayaran");
        }
        private void home_Load(object sender, EventArgs e)
        {
            combo();
        }


        private void button4_Click(object sender, EventArgs e)
        {
            EMPLOYEE em = new EMPLOYEE();
            em.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Customer cs = new Customer();
            cs.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Apakah Anda Ingin Keluar ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Apakah Anda Ingin Keluar ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Form1 fr = new Form1();
                fr.Show();
                this.Hide();

            }
                
        }

        private void button2_Click(object sender, EventArgs e)
        {
            VEHICLE ve = new VEHICLE();
            ve.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TRANSACTION tr = new TRANSACTION();
            tr.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DASHBOARD ds = new DASHBOARD();
            ds.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text.Trim() == "")
            {
                MessageBox.Show("Maaf Data Harus Diisi");
            }
            else
            {
                if (comboBox1.Text.Trim() == "Customer")
                {
                    Gcus cs = new Gcus();
                    cs.Show();

                }
                else if (comboBox1.Text.Trim() == "Employee")
                {
                    GEmplo ep = new GEmplo();
                    ep.Show();

                }
                else if (comboBox1.Text.Trim() == "Vehicle")
                {
                    GVechi vc = new GVechi();
                    vc.Show();
                }
                else if (comboBox1.Text.Trim() == "Transaction")
                {
                    GTrans tr = new GTrans();
                    tr.Show();
                }
                else if (comboBox1.Text.Trim() == "Detail Transaction")
                {
                    Gdet dt = new Gdet();
                    dt.Show();
                }
                else if (comboBox1.Text.Trim() == "Pembayaran")
                {
                    Gpembayaran pm = new Gpembayaran();
                    pm.Show();
                }
                else
                {
                    MessageBox.Show("Data Harus Sesuai");
                }


            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Admin a = new Admin();
            a.Show();
            this.Hide();
        }
    }
}

