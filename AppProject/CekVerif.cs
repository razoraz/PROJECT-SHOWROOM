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
    public partial class CekVerif : Form
    {
        public CekVerif()
        {
            InitializeComponent();
        }

        private NpgsqlDataReader rd;
        private void button3_Click(object sender, EventArgs e)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection("Server=localhost ; Port=5432 ; Database=PBOrental ;User Id=postgres; Password=gedanggoreng;"))
            {
                connection.Open();
                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "Select * from customer where nama_customer='" + textBox1.Text + "' and no_ktp='" + textBox4.Text +"' ";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new NpgsqlParameter("@nama_customer", textBox1.Text));
                cmd.Parameters.Add(new NpgsqlParameter("@no_ktp", textBox4.Text));

                rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    MessageBox.Show("Data Telah Sesuai", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                else
                {
                    MessageBox.Show("Data Tidak Sesuai", "Denied", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }

        private void CekVerif_Load(object sender, EventArgs e)
        {

        }
    }
}
