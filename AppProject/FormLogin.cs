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
    public partial class FormLogin : Form
    {
        private DataSet ds;
        private NpgsqlDataAdapter da;
        private NpgsqlDataReader rd;

        public FormLogin()
        {
            InitializeComponent();
        }
        
        void bersih()
        {
            textBox1.Text="";
            textBox2.Text="";
            checkBox1.Text="";
        }
        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" )
            {
                MessageBox.Show("Data Salah");
            }

            else
            {
                using (NpgsqlConnection connection = new NpgsqlConnection("Server=localhost ; Port=5432 ; Database=PBOrental ;User Id=postgres; Password=gedanggoreng;"))
                {

                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "Select * from login_admin where username_admin='" + textBox1.Text + "' and password_admin='" + textBox2.Text + "'";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@username_admin", textBox1.Text));
                    cmd.Parameters.Add(new NpgsqlParameter("@password_admin", textBox2.Text));
                    connection.Open();
                    rd = cmd.ExecuteReader();
                    if (rd.HasRows)
                    {
                        MessageBox.Show("Selamat Datang "+ textBox1.Text, "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        home h = new home();
                        h.ShowDialog();
                        this.Hide();
                        connection.Close();
                    }
                    else
                    {
                        MessageBox.Show("Data tidak sesuai", "Denied",  MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Apakah Anda Ingin Keluar ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
                textBox2.UseSystemPasswordChar = true;
            else
                textBox2.UseSystemPasswordChar = false;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            bersih();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            bersih();
            textBox2.MaxLength=8;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
