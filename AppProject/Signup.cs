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
    public partial class Signup : Form
    {
        private NpgsqlDataReader rd;
        public Signup()
        {
            InitializeComponent();

            textBox2.MaxLength=8;
            textBox3.MaxLength=8;
        }

        int angka = 5;
        Random chr = new Random();

        void bersih()
        {
            textBox1.Text="";
            textBox2.Text="";
            textBox3.Text="";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            pass_lenght(8);

        }
        private void pass_lenght(int pas_length)
        {
            string allcharacter = "ABCDEFGHIJKLMNOPQRSTUVXYZabcdefghijklmnopqrstuvwxyz1234567890!@#$%^&*";
            string random_pass = " ";
            for (int i = 0; i < pas_length; i++)
            {
                int randomm = chr.Next(0, allcharacter.Length);
                random_pass += allcharacter[randomm];
            }
            textBox2.Text = random_pass;
            textBox3.Text = random_pass;

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Apakah Anda Ingin Keluar ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

 

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == false)
            {
                textBox2.UseSystemPasswordChar = true;
                textBox3.UseSystemPasswordChar = true;

            }

            else
            {
                textBox2.UseSystemPasswordChar = false;
                textBox3.UseSystemPasswordChar = false;
            }

        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            bersih();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "") 
            {
                MessageBox.Show("Data Salah");
            }
            else
            {
                try /* Insertion After Validations*/
                {
                    using (NpgsqlConnection connection = new NpgsqlConnection("Server=localhost ; Port=5432 ; Database=PBOrental ;User Id=postgres; Password=gedanggoreng;"))
                    {
                        connection.Open();

                        NpgsqlCommand cmd = new NpgsqlCommand();
                        cmd.Connection = connection;
                        cmd.CommandText = "Insert into login_customer(username, password) values(@username, @password)";
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add(new NpgsqlParameter("@username", textBox1.Text));
                        cmd.Parameters.Add(new NpgsqlParameter("@password", textBox2.Text));
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Data Has been Saved", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FormLogin2 rm = new FormLogin2();
                        rm.Show();
                        this.Hide();
                        connection.Close();
                    }
                }
                catch (Exception b)
                {
                    MessageBox.Show(b.Message);
                }
            }
        }

        private void Signup_Load(object sender, EventArgs e)
        {
            bersih();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
