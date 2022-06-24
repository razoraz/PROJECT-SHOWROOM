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
    public partial class HOME2 : Form
    {
        public static HOME2 menu;
        Button btn;
        public HOME2()
        {
            InitializeComponent();
        }

        void bersig()
        {
            comboBox1.Text="";
            menu = this;

        }
        void kunci()
        {
            button1.Enabled=false;
            button2.Enabled=false;
            button3.Enabled=false;
            button4.Enabled=false;
        }
        void combo()
        {
            comboBox1.Items.Add("Already Verified");
            comboBox1.Items.Add("Not Verified");
        }

        private void HOME2_Load(object sender, EventArgs e)
        {
            bersig();
            combo();
            kunci();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Beli b = new Beli();
            b.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Apakah Anda Ingin Keluar ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 fl = new Form1();
            fl.Show();
            this.Hide();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            waiting w = new waiting();
            w.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            transaksi2 tr = new transaksi2();
            tr.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            deskripsi d = new deskripsi();
            d.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text.Trim() == "" )
            {
                MessageBox.Show("Data Salah");
            }
            else
            {
                try /* Insertion After Validations*/
                {
                    if (comboBox1.Text.Trim() == "Already Verified")
                    {
                        CekVerif c = new CekVerif();
                        c.Show();
                    }
                    else if (comboBox1.Text.Trim() == "Not Verified")
                    {
                        CekVerif2 cf = new CekVerif2();
                        cf.Show();
                    }
                    else
                    {
                        MessageBox.Show("Data Harus Sesuai");
                    }
                }
                catch(Exception ex)
                {

                }
                
            }
        }
    }
}


