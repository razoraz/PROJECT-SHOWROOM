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
    public partial class deskripsi : Form
    {
        public deskripsi()
        {
            InitializeComponent();
        }

        private void deskripsi_Load(object sender, EventArgs e)
        {
            combo();
            
        }
        void operators2()
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection("Server=localhost ; Port=5432 ; Database=PBOrental ;User Id=postgres; Password=gedanggoreng;"))
                {
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "Select * from kendaraan";
                    cmd.CommandType = CommandType.Text;
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    DataSet ds = new DataSet();

                    da.Fill(ds, "kendaraan");
                    dataGridView1.DataSource=ds;
                    dataGridView1.DataMember="kendaraan";
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
                    cmd.CommandText = "Select * from pegawai";
                    cmd.CommandType = CommandType.Text;
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    DataSet ds = new DataSet();

                    da.Fill(ds, "pegawai");
                    dataGridView1.DataSource=ds;
                    dataGridView1.DataMember="pegawai";
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    connection.Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void combo()
        {
            comboBox1.Items.Add("Vehicle");
            comboBox1.Items.Add("Employee");
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text.Trim() == "")
            {
                MessageBox.Show("Maaf Data Harus Diisi");
            }
            else
            {
                if (comboBox1.Text.Trim() == "Vehicle")
                {
                    operators2();
                }
                else if (comboBox1.Text.Trim() == "Employee")
                {
                    operators();
                }
                else
                {
                    MessageBox.Show("Data Harus Sesuai");
                }


            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
