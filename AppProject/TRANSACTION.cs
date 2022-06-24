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
    public partial class TRANSACTION : Form
    {
        public TRANSACTION()
        {
            InitializeComponent();
        }
        private NpgsqlDataReader rd;

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Apakah Anda Ingin Keluar ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
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
                cmd.CommandText=("Select detail_transaksi_id from detail_transaksi where detail_transaksi_id in(select max(detail_transaksi_id) from detail_transaksi) order by detail_transaksi_id desc");
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new NpgsqlParameter("detail_transaksi_id", textBox4.Text));
                rd = cmd.ExecuteReader();
                rd.Read();
                if (rd.HasRows)
                {
                    hitung = Convert.ToInt64(rd[0].ToString().Substring(rd["detail_transaksi_id"].ToString().Length -3, 3)) +1;
                    string joinstr = "000" + hitung;
                    urutan = "DT" +joinstr.Substring(joinstr.Length -3, 3);
                }
                else
                {
                    urutan = "DT001";
                }
                rd.Close();
                textBox4.Enabled = false;
                textBox4.Text = urutan;
                connection.Close();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            home hm = new home();
            hm.Show();
            this.Hide();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
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
                    cmd.CommandText = "Select * from transaksi";
                    cmd.CommandType = CommandType.Text;
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    DataSet ds = new DataSet();

                    da.Fill(ds, "transaksi");
                    dataGridView1.DataSource=ds;
                    dataGridView1.DataMember="transaksi";
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    connection.Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void operator2()
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection("Server=localhost ; Port=5432 ; Database=PBOrental ;User Id=postgres; Password=gedanggoreng;"))
                {
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "Select * from detail_transaksi";
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
        void combo()
        {
            comboBox1.Items.Add("Transaksi");
            comboBox1.Items.Add("Detail Transaksi");
        }
        private void TRANSACTION_Load(object sender, EventArgs e)
        {
            operators();
            kunci();
            combo();
            id_Tis();
        }
        void bersih()
        {
            textBox1.Text="";
            textBox3.Text="";
            textBox8.Text="";
            textBox7.Text="";
            textBox5.Text="";
            button3.Text="";
            button5.Text="";
            textBox6.Text="";
            textBox9.Text="";
        }
        void kunci()
        {
            textBox1.Enabled=false;
            textBox3.Enabled=false;
            textBox8.Enabled=false;
            textBox7.Enabled=false;
            textBox5.Enabled=false;
            button3.Enabled=false;
            button5.Enabled=false;
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells["transaksi_id"].Value.ToString();
                textBox3.Text = row.Cells["no_seri"].Value.ToString();
                textBox8.Text = row.Cells["id_customer"].Value.ToString();
                textBox7.Text = row.Cells["quantity"].Value.ToString();
                textBox5.Text = row.Cells["keterangan"].Value.ToString();

            }
            catch (Exception p)
            {
                MessageBox.Show(p.ToString());
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection("Server=localhost ; Port=5432 ; Database=PBOrental ;User Id=postgres; Password=gedanggoreng;"))
            {
                connection.Open();
                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "Select pegawai_id from pegawai where nama_pegawai='" + textBox2.Text + "'";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new NpgsqlParameter("@nama_pegawai", textBox2.Text));
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "pegawai");
                dataGridView2.DataSource=ds;
                dataGridView2.DataMember="pegawai";
                dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    MessageBox.Show("Nama Telah Sesuai", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    button3.Enabled=true;
                    button5.Enabled=true;
                   
 
                    connection.Close();
                }
                else
                {
                    MessageBox.Show("Nama_Tidak Sesuai", "Denied", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bersih();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox4.Text.Trim() == "" || textBox9.Text.Trim() == "" || textBox4.Text.Trim() == "")
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
                        cmd.CommandText = "Insert into detail_transaksi(detail_transaksi_id, pegawai_id, transaksi_id, tanggal)values(@detail_transaksi_id, @pegawai_id, @transaksi_id, @tanggal)";
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add(new NpgsqlParameter("@detail_transaksi_id", textBox4.Text));
                        cmd.Parameters.Add(new NpgsqlParameter("@pegawai_id", textBox9.Text));
                        cmd.Parameters.Add(new NpgsqlParameter("@transaksi_id",textBox1.Text));
                        cmd.Parameters.Add(new NpgsqlParameter("@tanggal", dateTimePicker1.Value));
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Data Sudah Tersimpan", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        delete_tr2();
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
            if (comboBox1.Text.Trim() == "")
            {
                MessageBox.Show("Data Salah");
            }
            else
            {
                try /* Insertion After Validations*/
                {
                    if (comboBox1.Text.Trim() == "Transaksi")
                    {
                        operators();
                    }
                    else if (comboBox1.Text.Trim() == "Detail Transaksi")
                    {
                        operator2();
                    }
                    else
                    {
                        MessageBox.Show("Data Harus Sesuai");
                    }
                }
                catch (Exception ex)
                {

                }

            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            delete_tr();
            
        }
        void delete_tr()
        {
            if (MessageBox.Show("Yakin Ingin Menghapus Data Barang : " + textBox1.Text + " ? ", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (NpgsqlConnection connection = new NpgsqlConnection("Server=localhost ; Port=5432 ; Database=PBOrental ;User Id=postgres; Password=gedanggoreng;"))
                    {
                        connection.Open();
                        NpgsqlCommand cmd = new NpgsqlCommand();
                        cmd.Connection = connection;
                        cmd.CommandText = "Delete from transaksi  where transaksi_id=@transaksi_id";
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add(new NpgsqlParameter("@transaksi_id", textBox1.Text));
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
                        cmd.CommandText = "Delete from transaksi  where transaksi_id=@transaksi_id";
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add(new NpgsqlParameter("@transaksi_id", textBox1.Text));
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
    }
}

