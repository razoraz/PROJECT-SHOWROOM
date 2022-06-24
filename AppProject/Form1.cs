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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        void combo_box()
        {
            comboBox1.Items.Add("Admin");
            comboBox1.Items.Add("User");
            
        }
        void bersih()
        {
            comboBox1.Text="";
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            combo_box();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text.Trim() == "")
            {
                MessageBox.Show("Maaf Data Harus Diisi");
            }
            else
            {
                if (comboBox1.Text.Trim() == "Admin" )
                {
                    MessageBox.Show("Anda Login sebagai Admin");
                    FormLogin fl = new FormLogin();
                    Form1 f = new Form1();
                    fl.Show();


                }
                else if ( comboBox1.Text.Trim() == "User")
                {
                    MessageBox.Show("Anda Login sebagai User");
                    FormLogin2 flq = new FormLogin2();
                    Form1 f = new Form1();
                    flq.Show();


                }
                else
                {
                    MessageBox.Show("Data Harus Sesuai");
                }
              
                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bersih();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
