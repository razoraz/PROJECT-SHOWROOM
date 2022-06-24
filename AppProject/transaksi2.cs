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
    public partial class transaksi2 : Form
    {
        public transaksi2()
        {
            InitializeComponent();
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
                    cmd.CommandText = "Select * from pembayaran";
                    cmd.CommandType = CommandType.Text;
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "pembayaran");
                    dataGridView1.DataSource=ds;
                    dataGridView1.DataMember="pembayaran";
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void cari2()
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection("Server=localhost ; Port=5432 ; Database=PBOrental ;User Id=postgres; Password=gedanggoreng;"))
                {
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "Select detail_transaksi_id from detail_transaksi where nama_kendaraan ilike '%"+ textBox6.Text + "%' ";
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
        void cari()
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection("Server=localhost ; Port=5432 ; Database=PBOrental ;User Id=postgres; Password=gedanggoreng;"))
                {
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "Select * from detail_transaksi where transaksi_id='"+ textBox6.Text + "' ";
                    cmd.CommandType = CommandType.Text;
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "detail_transaksi");
                    dataGridView1.DataSource=ds;
                    dataGridView1.DataMember="detail_transaksi";
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    connection.Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
                    cmd.CommandText = "Select * from Alat_pembayaran";
                    cmd.CommandType = CommandType.Text;
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Alat_pembayaran");
                    dataGridView2.DataSource=ds;
                    dataGridView2.DataMember="Alat_pembayaran";
                    dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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


        
        private void transaksi2_Load(object sender, EventArgs e)
        {
            
            operators2();
        }

        void bersih()
        {
            textBox1.Text="";
            textBox2.Text="";
            textBox6.Text="";
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
                textBox1.Text = row.Cells["detail_transaksi_id"].Value.ToString();
            }
            catch (Exception p)
            {
                MessageBox.Show(p.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Trim() == ""  || textBox1.Text.Trim() == "")
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
                        cmd.CommandText = "Insert into pembayaran(detail_transaksi_id, id_alat, tanggal)values(@detail_transaksi_id,  @id_alat, @tanggal)";
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add(new NpgsqlParameter("@detail_transaksi_id", textBox1.Text));
                        cmd.Parameters.Add(new NpgsqlParameter("@id_alat", Convert.ToInt16( textBox2.Text)));
                        cmd.Parameters.Add(new NpgsqlParameter("@tanggal", dateTimePicker1.Value));
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Pembayaran Berhasil", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        delete_tr2();
                        
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
        void delete_tr()
        {
            if (MessageBox.Show("Yakin Ingin Menghapus Data  " + textBox1.Text + " ? ", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (NpgsqlConnection connection = new NpgsqlConnection("Server=localhost ; Port=5432 ; Database=PBOrental ;User Id=postgres; Password=gedanggoreng;"))
                    {
                        connection.Open();
                        NpgsqlCommand cmd = new NpgsqlCommand();
                        cmd.Connection = connection;
                        cmd.CommandText = "Delete from detail_transaksi  where detail_transaksi_id=@detail_transaksi_id";
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add(new NpgsqlParameter("@detail_transaksi_id", textBox1.Text));
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Data sudah terdelete", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        void delete_tr2()
        {
            
                try
                {
                    using (NpgsqlConnection connection = new NpgsqlConnection("Server=localhost ; Port=5432 ; Database=PBOrental ;User Id=postgres; Password=gedanggoreng;"))
                    {
                        connection.Open();
                        NpgsqlCommand cmd = new NpgsqlCommand();
                        cmd.Connection = connection;
                        cmd.CommandText = "Delete from detail_transaksi  where detail_transaksi_id=@detail_transaksi_id";
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add(new NpgsqlParameter("@detail_transaksi_id", textBox1.Text));
                        cmd.ExecuteNonQuery();
                        
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
        private void button2_Click(object sender, EventArgs e)
        {
            delete_tr();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];
                textBox2.Text = row.Cells["id_alat"].Value.ToString();
            }
            catch (Exception p)
            {
                MessageBox.Show(p.ToString());
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            bersih();
        }
    }
}
