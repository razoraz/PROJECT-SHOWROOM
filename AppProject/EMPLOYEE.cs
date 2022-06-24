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
    public partial class EMPLOYEE : Form
    {
        public EMPLOYEE()
        {
            InitializeComponent();
        }
        private NpgsqlDataReader rd;
        void bersih()
        {
            comboBox1.Text="";
            textBox2.Text="";
            textBox3.Text="";
            textBox4.Text="";
            textBox5.Text="";
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
                    cmd.CommandText = "Select * from pegawai where nama_pegawai ilike '%"+ textBox6.Text + "%' ";
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
        void id_Tis()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection("Server=localhost ; Port=5432 ; Database=PBOrental ;User Id=postgres; Password=gedanggoreng;"))
            {
                long hitung;
                string urutan;
                connection.Open();
                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = connection;
                cmd.CommandText=("Select pegawai_id from pegawai where pegawai_id in(select max(pegawai_id) from pegawai) order by pegawai_id desc");
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new NpgsqlParameter("@pegawai_id", textBox1.Text));
                rd = cmd.ExecuteReader();
                rd.Read();
                if (rd.HasRows)
                {
                    hitung = Convert.ToInt64(rd[0].ToString().Substring(rd["pegawai_id"].ToString().Length -3, 3)) +1;
                    string joinstr = "000" + hitung;
                    urutan = "PG" +joinstr.Substring(joinstr.Length -3, 3);
                }
                else
                {
                    urutan = "PG001";
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
            catch(Exception ex)
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

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells["pegawai_id"].Value.ToString();
                textBox2.Text = row.Cells["nama_pegawai"].Value.ToString();
                textBox3.Text = row.Cells["no_ktp"].Value.ToString();
                textBox7.Text = row.Cells["alamat"].Value.ToString();
                textBox5.Text = row.Cells["no_hp"].Value.ToString();
                textBox4.Text = row.Cells["tahun_masuk"].Value.ToString();

            }
            catch (Exception p)
            {
                MessageBox.Show(p.ToString());
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            cari();
        }

        private void EMPLOYEE_Load(object sender, EventArgs e)
        {
            combo();
            operators();
            id_Tis();
            bersih();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bersih();
            id_Tis();
        }
        void combo()
        {
            comboBox1.Items.Add("IDENTITY");
            comboBox1.Items.Add("ADMIN");
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text.Trim() == "")
            {
                MessageBox.Show("Maaf Data Harus Diisi");
            }
            else
            {
                if (comboBox1.Text.Trim() == "IDENTITY")
                {
                    operators();
                }
                else if (comboBox1.Text.Trim() == "ADMIN")
                {
                    operators2();
                }
                else
                {
                    MessageBox.Show("Data Harus Sesuai");
                }


            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() =="" ||  textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "" || textBox5.Text.Trim() == "" || textBox7.Text.Trim() == "")
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
                        cmd.CommandText = "Insert into pegawai(pegawai_id, Nama_pegawai, Alamat, No_KTP, No_HP, tahun_masuk) values(@pegawai_id,@Nama_pegawai,@alamat, @No_KTP, @No_HP, @tahun_masuk)";
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add(new NpgsqlParameter("@pegawai_id", textBox1.Text));
                        cmd.Parameters.Add(new NpgsqlParameter("@Nama_pegawai", textBox2.Text));
                        cmd.Parameters.Add(new NpgsqlParameter("@alamat", textBox3.Text));
                        cmd.Parameters.Add(new NpgsqlParameter("@No_KTP", textBox7.Text));
                        cmd.Parameters.Add(new NpgsqlParameter("@No_HP", textBox5.Text));
                        cmd.Parameters.Add(new NpgsqlParameter("@tahun_masuk", Convert.ToInt32( textBox4.Text)));
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

        private void button3_Click(object sender, EventArgs e)
        {

            if (textBox1.Text.Trim() =="" ||  textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "" || textBox5.Text.Trim() == "" || textBox7.Text.Trim() == "")
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
                        cmd.CommandText = "update pegawai set nama_pegawai=@nama_pegawai, tahun_masuk=@tahun_masuk, No_KTP=@No_KTP, No_HP=@No_HP, alamat=@alamat where pegawai_id=@pegawai_id";
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add(new NpgsqlParameter("@pegawai_id", textBox1.Text));
                        cmd.Parameters.Add(new NpgsqlParameter("@Nama_pegawai", textBox2.Text));
                        cmd.Parameters.Add(new NpgsqlParameter("@alamat", textBox3.Text));
                        cmd.Parameters.Add(new NpgsqlParameter("@No_KTP", textBox7.Text));
                        cmd.Parameters.Add(new NpgsqlParameter("@No_HP", textBox5.Text));
                        cmd.Parameters.Add(new NpgsqlParameter("@tahun_masuk", Convert.ToInt32(textBox4.Text)));
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
                        cmd.CommandText = "Delete from pegawai  where pegawai_id=@pegawai_id";
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add(new NpgsqlParameter("@pegawai_id", textBox1.Text));
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
    }
}
