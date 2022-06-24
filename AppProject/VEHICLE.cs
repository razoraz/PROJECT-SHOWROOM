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
    public partial class VEHICLE : Form
    {
        public VEHICLE()
        {
            InitializeComponent();
        }

        private NpgsqlDataReader rd;
        void bersih()
        {
            
            textBox2.Text="";
            textBox4.Text="";
            textBox5.Text="";
            textBox6.Text="";
            comboBox2.Text="";
            comboBox3.Text="";
            
 
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
                    cmd.CommandText = "Select * from kendaraan where nama_kendaraan ilike '%"+ textBox6.Text + "%' ";
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
        void combo2()
        {
            comboBox2.Items.Add(1);
            comboBox2.Items.Add(2);
            comboBox2.Items.Add(3);
            comboBox2.Items.Add(4);
            comboBox2.Items.Add(5);
            comboBox2.Items.Add(6);
            comboBox2.Items.Add(7);
            comboBox2.Items.Add(8);
            comboBox2.Items.Add(9);
            comboBox2.Items.Add(10);
            comboBox2.Items.Add(11);
            comboBox2.Items.Add(12);
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
                cmd.CommandText=("Select no_seri from kendaraan where no_seri in(select max(no_seri) from kendaraan) order by no_seri desc");
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new NpgsqlParameter("@no_seri", textBox1.Text));
                rd = cmd.ExecuteReader();
                rd.Read();
                if (rd.HasRows)
                {
                    hitung = Convert.ToInt64(rd[0].ToString().Substring(rd["no_seri"].ToString().Length -3, 3)) +1;
                    string joinstr = "000" + hitung;
                    urutan = "VHC" +joinstr.Substring(joinstr.Length -3, 3);
                }
                else
                {
                    urutan = "VHC001";
                }
                rd.Close();
                textBox1.Enabled = false;
                textBox1.Text = urutan;
                connection.Close();
            }
        }

        void tam()
        {
            if (comboBox2.Text.Trim() == "")
            {
                MessageBox.Show("Maaf Data Harus Diisi");
            }
            else
            {
                using (NpgsqlConnection connection = new NpgsqlConnection("Server=localhost ; Port=5432 ; Database=PBOrental ;User Id=postgres; Password=gedanggoreng;"))
                {

                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "Select nama_merek from Merek_kendaraan where merek_id='" + comboBox2.Text + "'";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@merek_id", Convert.ToInt32(comboBox2.Text)));
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Merek_kendaraan");
                    dataGridView2.DataSource=ds;
                    dataGridView2.DataMember="Merek_kendaraan";
                    dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    connection.Close();

                }
            }

        }
        void tem()
        {
            if (comboBox3.Text.Trim() == "")
            {
                MessageBox.Show("Maaf Data Harus Diisi");
            }
            else
            {
                using (NpgsqlConnection connection = new NpgsqlConnection("Server=localhost ; Port=5432 ; Database=PBOrental ;User Id=postgres; Password=gedanggoreng;"))
                {

                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "Select nama_jenis from jenis_kendaraan where jenis_kendaraan_id='" + comboBox3.Text + "'";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@merek_id", Convert.ToInt32(comboBox3.Text)));
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "jenis_kendaraan");
                    dataGridView3.DataSource=ds;
                    dataGridView3.DataMember="jenis_kendaraan";
                    dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    connection.Close();

                }
            }

        }

        
        
    void combo3()
        {
            comboBox3.Items.Add(1);
            comboBox3.Items.Add(2);
        }

    

        private void label7_Click(object sender, EventArgs e)
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
            home hm = new home();
            hm.Show();
            this.Hide();
        }

        private void comboBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }

        private void comboBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }

        private void VEHICLE_Load(object sender, EventArgs e)
        {
            bersih();
            combo2();
            combo3();
            id_Tis();
            operators();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() =="" ||  textBox2.Text.Trim() == "" || comboBox2.Text.Trim() == "" || textBox4.Text.Trim() == "" || textBox5.Text.Trim() == "" || comboBox3.Text.Trim() == "")
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
                        cmd.CommandText = "Insert into kendaraan(no_seri, Nama_kendaraan, tahun_pembuatan, harga, id_jenis_kendaraan, id_merek) values(@no_seri,@Nama_kendaraan, @tahun_pembuatan, @harga, @id_jenis_kendaraan, @id_merek)";
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add(new NpgsqlParameter("@no_seri", textBox1.Text));
                        cmd.Parameters.Add(new NpgsqlParameter("@Nama_kendaraan", textBox2.Text));
                        cmd.Parameters.Add(new NpgsqlParameter("@tahun_pembuatan", Convert.ToInt32( textBox5.Text)));
                        cmd.Parameters.Add(new NpgsqlParameter("@harga", Convert.ToInt32( textBox4.Text)));
                        cmd.Parameters.Add(new NpgsqlParameter("@id_jenis_kendaraan", Convert.ToInt32( comboBox3.Text)));
                        cmd.Parameters.Add(new NpgsqlParameter("@id_merek", Convert.ToInt32( comboBox2.Text)));
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Data Sudah Tersimpan", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        operators();
                        bersih();
                        id_Tis();
                        connection.Close();
                    }
                }
                catch (Exception b)
                {
                    MessageBox.Show(b.Message);
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            tam();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            tem();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bersih();
            textBox1.Text="";
            id_Tis();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            operators();
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
                textBox1.Text = row.Cells["no_seri"].Value.ToString();
                textBox2.Text = row.Cells["nama_kendaraan"].Value.ToString();
                comboBox2.Text = row.Cells["id_merek"].Value.ToString();
                comboBox3.Text = row.Cells["id_jenis_kendaraan"].Value.ToString();
                textBox4.Text = row.Cells["harga"].Value.ToString();
                textBox5.Text = row.Cells["tahun_pembuatan"].Value.ToString();

            }
            catch (Exception p)
            {
                MessageBox.Show(p.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || comboBox2.Text.Trim() == "")
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
                        cmd.CommandText = "update kendaraan set nama_kendaraan=@nama_kendaraan, tahun_pembuatan=@tahun_pembuatan, harga=@harga,id_jenis_kendaraan=@id_jenis_kendaraan, id_merek=@id_merek where no_seri=@no_seri";
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add(new NpgsqlParameter("@no_seri", textBox1.Text));
                        cmd.Parameters.Add(new NpgsqlParameter("@Nama_kendaraan", textBox2.Text));
                        cmd.Parameters.Add(new NpgsqlParameter("@tahun_pembuatan", Convert.ToInt32(textBox5.Text)));
                        cmd.Parameters.Add(new NpgsqlParameter("@harga", Convert.ToInt32(textBox4.Text)));
                        cmd.Parameters.Add(new NpgsqlParameter("@id_jenis_kendaraan", Convert.ToInt32(comboBox3.Text)));
                        cmd.Parameters.Add(new NpgsqlParameter("@id_merek", Convert.ToInt32(comboBox2.Text)));
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Data Sudah Terupdate", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        operators();
                        bersih();
                        id_Tis();
                        connection.Close();
                    }
                }
                catch (Exception b)
                {
                    MessageBox.Show(b.Message);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
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
                        cmd.CommandText = "Delete from kendaraan  where no_seri=@no_seri";
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add(new NpgsqlParameter("@no_seri", textBox1.Text));
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

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
