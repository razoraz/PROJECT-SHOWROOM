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
    public partial class kendaraan2 : Form
    {
        public kendaraan2()
        {
            InitializeComponent();
        }
        private NpgsqlDataReader rd;

        void combo()
        {
            comboBox3.Items.Add("Kredit");
            comboBox3.Items.Add("Lunas");
            

        }
        void bersih()
        {
            
            textBox3.Text="";
            textBox2.Text="";
            textBox5.Text="";
            textBox6.Text="";
            comboBox3.Text="";


        }
        void tam()
        {

                using (NpgsqlConnection connection = new NpgsqlConnection("Server=localhost ; Port=5432 ; Database=PBOrental ;User Id=postgres; Password=gedanggoreng;"))
                {

                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "Select customer_id from customer where nama_customer='" + textBox6.Text + "'";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@nama_customer",textBox6.Text));
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "customer");
                    dataGridView3.DataSource=ds;
                    dataGridView3.DataMember="customer";
                    dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    connection.Close();

                }
            

        }
        void id_Tis()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection("Server=localhost ; Port=5432 ; Database=PBOrental ;User Id=postgres; Password=gedanggoreng;"))
            {
                long hitung;
                string urutan;
                connection.Open();
                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = connection;
                cmd.CommandText=("Select transaksi_id from transaksi where transaksi_id in(select max(transaksi_id) from transaksi) order by transaksi_id desc");
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new NpgsqlParameter("transaksi_id", textBox1.Text));
                rd = cmd.ExecuteReader();
                rd.Read();
                if (rd.HasRows)
                {
                    hitung = Convert.ToInt64(rd[0].ToString().Substring(rd["transaksi_id"].ToString().Length -3, 3)) +1;
                    string joinstr = "000" + hitung;
                    urutan = "TR" +joinstr.Substring(joinstr.Length -3, 3);
                }
                else
                {
                    urutan = "TR001";
                }
                rd.Close();
                textBox1.Enabled = false;
                textBox1.Text = urutan;
                connection.Close();
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
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Apakah Anda Ingin Keluar ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Beli b = new Beli();
            b.Show();
            this.Hide();
        }
        private void kendaraan2_Load(object sender, EventArgs e)
        {
            operators();
            id_Tis();
            bersih();
            combo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bersih();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Trim() == "" || textBox5.Text.Trim() == "" || comboBox3.Text.Trim() == "")
            {
                MessageBox.Show("Data Kurang Lengkap", "Denied", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        cmd.CommandText = "Insert into Transaksi(Transaksi_id, id_customer, no_seri, quantity, keterangan)values(@Transaksi_id, @id_customer, @no_seri, @quantity,@keterangan)";
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add(new NpgsqlParameter("@Transaksi_id", textBox1.Text));
                        cmd.Parameters.Add(new NpgsqlParameter("@id_customer", textBox2.Text));
                        cmd.Parameters.Add(new NpgsqlParameter("@quantity", Convert.ToInt16(textBox5.Text)));
                        cmd.Parameters.Add(new NpgsqlParameter("@no_seri", textBox3.Text));
                        cmd.Parameters.Add(new NpgsqlParameter("@keterangan", comboBox3.Text));
       
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Data Sudah Tersimpan", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        id_Tis();
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

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            tam();
        }
    }
}
