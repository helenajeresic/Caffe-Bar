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

namespace CaffeBar
{
    public partial class KonobarForm : Form
    {
        public string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\baza.mdf;Integrated Security=True";
        public KonobarForm()
        {
            InitializeComponent();
            dataGridViewPica.CellFormatting += dataGridViewPica_CellFormatting;
        }

        private void buttonPrikaziPica_Click(object sender, EventArgs e)
        {
            SqlConnection veza = new SqlConnection(connectionString);
            veza.Open();
            string upit = "SELECT * FROM Pica";
            SqlCommand naredba = new SqlCommand(upit, veza);
            List<Pice> pica = new List<Pice>();

            using (SqlDataReader čitač = naredba.ExecuteReader())
            {
                while (čitač.Read())
                {
                    pica.Add(new Pice()
                    {
                        id_pica = čitač.GetInt32(0),
                        naziv_pica = čitač.GetString(1),
                        cijena_pica = čitač.GetDecimal(2),
                        id_kategorija_pica = čitač.GetInt32(3),
                        kolicina_kafic = čitač.GetDecimal(4),
                        kolicina_skladista = čitač.GetDecimal(5),
                        najmanja_kolicina = čitač.GetString(6)
                    });
                }
                pica.Sort((x,y) => x.naziv_pica.CompareTo(y.naziv_pica));
                dataGridViewPica.DataSource = pica;

                dataGridViewPica.Columns[0].Visible = false;
                dataGridViewPica.Columns[3].Visible = false;
                dataGridViewPica.Columns[4].Visible = false;
                dataGridViewPica.Columns[5].Visible = false;
                dataGridViewPica.Columns[6].Visible = false;

                dataGridViewPica.Columns[1].HeaderText = "Naziv pića";
                dataGridViewPica.Columns[2].HeaderText = "Cijena pića";
            }
            veza.Close();
        }

        public void textBoxTrazi_TextChanged(object sender, EventArgs e)
        {
            SqlConnection veza = new SqlConnection(connectionString);
            veza.Open();
            string upit = "SELECT * FROM Pica";
            SqlCommand naredba = new SqlCommand();
            naredba.CommandText = upit;
            naredba.Connection = veza;
            if(textBoxTrazi.Text.Length > 0)
            {
                naredba.CommandText += " WHERE naziv_pica LIKE @unos";
                naredba.Parameters.AddWithValue("@unos", "%" + textBoxTrazi.Text + "%");
            }
            SqlDataAdapter adapter = new SqlDataAdapter(naredba);
            DataTable dt = new DataTable();
            dt.Clear();
            adapter.Fill(dt);
            dataGridViewPica.DataSource = dt;

            dataGridViewPica.Columns[0].Visible = false;
            dataGridViewPica.Columns[3].Visible = false;
            dataGridViewPica.Columns[4].Visible = false;
            dataGridViewPica.Columns[5].Visible = false;
            dataGridViewPica.Columns[6].Visible = false;

            dataGridViewPica.Columns[1].HeaderText = "Naziv pića";
            dataGridViewPica.Columns[2].HeaderText = "Cijena pića";

            veza.Close();
        }

        private void dataGridViewPica_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.RowIndex >= 0)
            {
                object cellValue = e.Value;

                if (cellValue != null && cellValue != DBNull.Value)
                {
                    string stringValue = cellValue.ToString();

                    if (decimal.TryParse(stringValue, out decimal originalValue))
                    {
                        decimal roundedValue = Math.Round(originalValue, 2);
                        e.Value = roundedValue.ToString(".00");
                        e.CellStyle.Format = ".00";
                        e.FormattingApplied = true;
                    }
                    else
                    {
                        e.Value = stringValue;
                        e.FormattingApplied = true;
                    }
                }
            }
        }
    }
}