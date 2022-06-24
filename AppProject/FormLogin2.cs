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
    public partial class FormLogin2 : Form
    {
        private DataSet ds;
        private NpgsqlDataAdapter da;
        private NpgsqlDataReader rd;
        Form1 conn = new Form1();


        public FormLogin2()
        {
            InitializeComponent();
        }
        void bersih()
        {
            textBox1.Text="";
            textBox2.Text="";
            checkBox2.Text="";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            using (NpgsqlConnection connection = new NpgsqlConnection("Server=localhost ; Port=5432 ; Database=PBOrental ;User Id=postgres; Password=gedanggoreng;"))
            {
               
                connection.Open();
                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "Select * from login_customer where Username='" + textBox1.Text + "' and Password='" + textBox2.Text + "'";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new NpgsqlParameter("@Username", textBox1.Text));
                cmd.Parameters.Add(new NpgsqlParameter("@Password", textBox2.Text));
                rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    MessageBox.Show("Selamat Datang "+ textBox1.Text, "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HOME2 h = new HOME2();
                    h.Show();
                    this.Hide();
                    connection.Close();
                }
                else
                {
                    MessageBox.Show("Data tidak sesuai", "Denied", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


                }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Apakah Anda Ingin Keluar ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            bersih();
        }

        private void FormLogin2_Load(object sender, EventArgs e)
        {
            bersih();
            textBox2.MaxLength=8;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == false)
                textBox2.UseSystemPasswordChar = true;
            else
                textBox2.UseSystemPasswordChar = false;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lupa lp = new lupa();
            lp.Show();
            this.Hide();
            

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Signup s = new Signup();
            s.Show();
            this.Hide();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
