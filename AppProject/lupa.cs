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
    public partial class lupa : Form
    {
        private NpgsqlDataReader rd;
        public lupa()
        {
            InitializeComponent();
        }

        void bersih()
        {
            textBox1.Text="";
            textBox2.Text="";
            textBox3.Text="";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection("Server=localhost ; Port=5432 ; Database=PBOrental ;User Id=postgres; Password=gedanggoreng;"))
            {
                connection.Open();
                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "Select * from login_customer where Username='" + textBox1.Text + "'";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new NpgsqlParameter("@Username", textBox1.Text));
                rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    MessageBox.Show("Nama Telah Sesuai", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox2.Enabled=true;
                    textBox3.Enabled=true;
                    textBox1.Enabled=false;
                    button2.Enabled=false;
                    button1.Enabled=true;
                    connection.Close();
                }
                else
                {
                    MessageBox.Show("Nama_Tidak Sesuai", "Denied", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
               // if comboBox1.Text.Trim() == "admin"

        }

        private void lupa_Load(object sender, EventArgs e)
        {
            bersih();
            button1.Enabled=false;
            textBox2.Enabled=false;
            textBox3.Enabled=false;
            textBox2.MaxLength=8;
            textBox3.MaxLength=8;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Apakah Anda Ingin Keluar ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Trim() ==textBox3.Text.Trim())
            {
                try /* Insertion After Validations*/
                {
                    using (NpgsqlConnection connection = new NpgsqlConnection("Server=localhost ; Port=5432 ; Database=PBOrental ;User Id=postgres; Password=gedanggoreng;"))
                    {
                        connection.Open();
                        NpgsqlCommand cmd = new NpgsqlCommand();
                        cmd.Connection = connection;
                        cmd.CommandText = "update login_customer set password=@password where username=@username";
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add(new NpgsqlParameter("@username", textBox1.Text));
                        cmd.Parameters.Add(new NpgsqlParameter("@password", textBox2.Text));
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Password Telah Diganti", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FormLogin2 fll = new FormLogin2();
                        fll.Show();
                        this.Hide();
                        connection.Close();
                    }
                }
                catch (Exception b)
                {
                    MessageBox.Show(b.Message);
                }

            }
            else
            {
                MessageBox.Show("Password Tidak Sesuai", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            bersih();
            button2.Enabled=true;
            textBox1.Enabled=true;
            textBox2.Enabled=false;
            textBox3.Enabled=false;
            button2.Enabled=false;
        }
    }
}
