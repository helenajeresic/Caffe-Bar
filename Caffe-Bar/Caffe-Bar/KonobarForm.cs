using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Caffe-Bar
{
    public partial class KonobarForm : Form
    {
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\baza.mdf;Integrated Security=True";
        public KonobarForm()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void buttonPrikaziPica_Click(object sender, EventArgs e)
        {
            SqlConnection veza = new SqlConnection(connectionString);
            veza.Open();
            string upit = "SELECT * FROM Pica";
            SqlCommand naredba = new SqlCommand(upit, veza);
            List<Pice> pica = new List<Pice>();
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            veza.Close();
        }

        private void textBoxTrazi_TextChanged(object sender, EventArgs e)
        {
            SqlConnection veza = new SqlConnection(connectionString);
            veza.Open();
            string upit = "SELECT naziv_pica AS 'Naziv pića'," +
                          "cijena_pica AS 'Cijena pića' FROM Pica " +
                          "WHERE naziv_pica LIKE '%" + textBoxTrazi.Text + "%'";
            SqlDataAdapter adapter = new SqlDataAdapter(upit, veza);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            veza.Close();
        }
    }
}