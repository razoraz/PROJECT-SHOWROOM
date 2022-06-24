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
    public partial class CekVerif2 : Form
    {
        private NpgsqlDataReader rd;
        public CekVerif2()
        {
            InitializeComponent();
        }
        void bersih()
        {
            textBox2.Text="";
            textBox3.Text="";
            textBox4.Text="";
            textBox5.Text="";
            
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
                cmd.CommandText=("Select Customer_id from Customer where Customer_id in(select max(Customer_id) from Customer) order by Customer_id desc");
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new NpgsqlParameter("@Customer_id", textBox1.Text));
                rd = cmd.ExecuteReader();
                rd.Read();
                if (rd.HasRows)
                {
                    hitung = Convert.ToInt64(rd[0].ToString().Substring(rd["Customer_id"].ToString().Length -3, 3)) +1;
                    string joinstr = "000" + hitung;
                    urutan = "USR" +joinstr.Substring(joinstr.Length -3, 3);
                }
                else
                {
                    urutan = "USR001";
                }
                rd.Close();
                textBox1.Enabled = false;
                textBox1.Text = urutan;
                connection.Close();
            }

        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() =="" ||  textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "" || textBox5.Text.Trim() == "")
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
                        cmd.CommandText = "Insert into customer(Customer_id, Nama_customer, No_KTP, No_HP, Email) values(@Customer_id,@Nama_customer, @No_KTP, @No_HP, @Email)";
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add(new NpgsqlParameter("@Customer_id", textBox1.Text));
                        cmd.Parameters.Add(new NpgsqlParameter("@Nama_customer", textBox2.Text));
                        cmd.Parameters.Add(new NpgsqlParameter("@No_KTP", textBox3.Text));
                        cmd.Parameters.Add(new NpgsqlParameter("@No_HP", textBox4.Text));
                        cmd.Parameters.Add(new NpgsqlParameter("@Email", textBox5.Text));
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Data Sudah Tersimpan", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        id_Tis();
                        bersih();
                        HOME2 hm = new HOME2();
                        hm.Show();
                        HOME2.menu.button1.Enabled=true;
                        HOME2.menu.button2.Enabled=true;
                        HOME2.menu.button3.Enabled=true;
                        HOME2.menu.button4.Enabled=true;
                        HOME2.menu.button8.Enabled=false;
                        HOME2.menu.comboBox1.Enabled=false;
                        connection.Close();
                        this.Hide();
                    }
                }
                catch (Exception b)
                {
                    MessageBox.Show(b.Message);
                }
            }
        }

        private void CekVerif2_Load(object sender, EventArgs e)
        {
            id_Tis();
            bersih();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            bersih();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }
    }
}
