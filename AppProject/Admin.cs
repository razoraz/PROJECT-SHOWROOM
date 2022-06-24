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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }
        private NpgsqlDataReader rd;

        void bersih()
        {
            textBox1.Text="";
            textBox2.Text="";
            textBox6.Text="";
            textBox7.Text="";
        }
        void cari()
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection("Server=localhost ; Port=5432 ; Database=PBOrental ;User Id=postgres; Password=gedanggoreng;"))
                {
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "Select * from login_admin where username_admin='" + textBox6.Text + "'";
                    cmd.CommandType = CommandType.Text;
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "login_admin");
                    dataGridView1.DataSource=ds;
                    dataGridView1.DataMember="login_admin";
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    connection.Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void operators()
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection("Server=localhost ; Port=5432 ; Database=PBOrental ;User Id=postgres; Password=gedanggoreng;"))
                {
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "Select * from login_admin";
                    cmd.CommandType = CommandType.Text;
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    DataSet ds = new DataSet();

                    da.Fill(ds, "login_admin");
                    dataGridView1.DataSource=ds;
                    dataGridView1.DataMember="login_admin";
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    connection.Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

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
            home h = new home();
            h.Show();
            this.Hide();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            operators();
            textBox2.MaxLength=8;
            textBox1.MaxLength=8;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            cari();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox7.Text = row.Cells["username_admin"].Value.ToString();
                textBox2.Text = row.Cells["password_admin"].Value.ToString();
                textBox1.Text = row.Cells["password_admin"].Value.ToString();

            }
            catch (Exception p)
            {
                MessageBox.Show(p.ToString());
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == false)
            {
                textBox2.UseSystemPasswordChar = true;
                textBox1.UseSystemPasswordChar = true;

            }

            else
            {
                textBox2.UseSystemPasswordChar = false;
                textBox1.UseSystemPasswordChar = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bersih();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Trim() == "" || textBox1.Text.Trim() == "" || textBox7.Text.Trim() == "")
            {
                MessageBox.Show("Data Kurang Lengkap", "Denied", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try 
                {
                    using (NpgsqlConnection connection = new NpgsqlConnection("Server=localhost ; Port=5432 ; Database=PBOrental ;User Id=postgres; Password=gedanggoreng;"))
                    {
                        connection.Open();
                        NpgsqlCommand cmd = new NpgsqlCommand();
                        cmd.Connection = connection;
                        cmd.CommandText = "Insert into login_admin(username_admin, password_admin)values(@username_admin, @password_admin)";
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add(new NpgsqlParameter("@username_admin", textBox7.Text));
                        cmd.Parameters.Add(new NpgsqlParameter("@password_admin", textBox1.Text));
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Data Sudah Tersimpan", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        operators();
                        bersih();
                        connection.Close();
                    }
                }
                catch (Exception b)
                {
                    MessageBox.Show(b.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Yakin Ingin Menghapus Data Barang : " + textBox7.Text + " ? ", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (NpgsqlConnection connection = new NpgsqlConnection("Server=localhost ; Port=5432 ; Database=PBOrental ;User Id=postgres; Password=gedanggoreng;"))
                    {
                        connection.Open();
                        NpgsqlCommand cmd = new NpgsqlCommand();
                        cmd.Connection = connection;
                        cmd.CommandText = "Delete from login_admin  where username_admin=@username_admin";
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add(new NpgsqlParameter("@username_admin", textBox7.Text));
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Data sudah terdelete", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        bersih();
                        operators();
                        connection.Close();
                    }
                }
                catch (Exception b)
                {
                    MessageBox.Show(b.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox7.Text.Trim() =="" ||  textBox2.Text.Trim() == "" || textBox1.Text.Trim() == "" )
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
                        cmd.CommandText = "update login_admin set username_admin=@username_admin, password_admin=@password_admin where username_admin=@username_admin";
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add(new NpgsqlParameter("@username_admin", textBox7.Text));
                        cmd.Parameters.Add(new NpgsqlParameter("@password_admin", textBox1.Text));
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Data Sudah Terupdate", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        bersih();
                        operators();
                        connection.Close();
                    }
                }
                catch (Exception b)
                {
                    MessageBox.Show(b.Message);
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                textBox7.Enabled= true;
                button3.Enabled = false;
                button1.Enabled = false;

            }

            else
            {
                textBox7.Enabled= false;
                button1.Enabled = true;
                button3.Enabled = true;
            }
        }
    }
}
