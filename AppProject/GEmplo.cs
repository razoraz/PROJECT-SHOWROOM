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
    public partial class GEmplo : Form
    {
        public GEmplo()
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
        private void GEmplo_Load(object sender, EventArgs e)
        {
            operators();
        }
    }
}
