using Caffe_Bar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaffeBar
{
    public partial class KonobarForm : Form
    {
        public string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\baza.mdf;Integrated Security=True";
        private List<Pice> narucenaPica = new List<Pice>();
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
                pica.Sort((x, y) => x.naziv_pica.CompareTo(y.naziv_pica));
                dataGridViewPica.DataSource = pica;

                dataGridViewPica.Columns[0].Visible = false;
                dataGridViewPica.Columns[3].Visible = false;
                dataGridViewPica.Columns[4].Visible = false;
                dataGridViewPica.Columns[5].Visible = false;
                dataGridViewPica.Columns[6].Visible = false;
                foreach (DataGridViewColumn column in dataGridViewPica.Columns)
                {
                    if (column.Visible)
                    {
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                }

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
            if (textBoxTrazi.Text.Length > 0)
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
            foreach (DataGridViewColumn column in dataGridViewPica.Columns)
            {
                if (column.Visible)
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }

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

        private void dataGridViewPica_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (narucenaPica.Count == 0)
            {
                initializeBill();
            }
            if (sender is DataGridView d && e.RowIndex >= 0)
            {
                int indeksRetka = e.RowIndex;

                int idPica = (int)d.Rows[indeksRetka].Cells[0].Value;
                string nazivPica = d.Rows[indeksRetka].Cells[1].Value.ToString();
                decimal cijenaPica = (decimal)d.Rows[indeksRetka].Cells[2].Value;
                int kategorijaPica = (int)d.Rows[indeksRetka].Cells[3].Value;
                decimal kolicinaKafic = (decimal)d.Rows[indeksRetka].Cells[4].Value;
                decimal kolicinaSkladiste = (decimal)d.Rows[indeksRetka].Cells[5].Value;
                string najmanjaKolicina = d.Rows[indeksRetka].Cells[6].Value.ToString();

                string label = nazivPica + "\t\t" + Math.Round(cijenaPica, 2);
                int kolicina = GetQuantityFromUser(label);

                if (kolicina > 0)
                {
                    Pice narucenoPice = new Pice()
                    {
                        id_pica = idPica,
                        naziv_pica = nazivPica,
                        cijena_pica = cijenaPica,
                        id_kategorija_pica = kategorijaPica,
                        kolicina_kafic = kolicinaKafic,
                        kolicina_skladista = kolicinaSkladiste,
                        najmanja_kolicina = najmanjaKolicina
                    };
                    narucenaPica.Add(narucenoPice);

                    decimal ukupnaCijena = Math.Round(cijenaPica * kolicina,2);
                    string piceInfo = $"{nazivPica,-20}{Math.Round(cijenaPica, 2),-10} x {kolicina,-5} = {ukupnaCijena,-5}";
                    MessageBox.Show(piceInfo, "Dodano u narudžbu");
                    textRacuna.Text += piceInfo + "\n\n";
                }
            }
        }

        private void initializeBill()
        {
            textRacuna.Font = new Font(FontFamily.GenericMonospace, textRacuna.Font.Size);

            textRacuna.SelectionAlignment = HorizontalAlignment.Center;
            textRacuna.AppendText("\n");
            textRacuna.AppendText("Caffe-Bar Naziv \n\n");
            textRacuna.AppendText("Bijenička cesta 30\n");
            textRacuna.AppendText("10000 Zagreb\n");
            textRacuna.AppendText("--------------------------------------\n\n");
            textRacuna.SelectionAlignment = HorizontalAlignment.Left;
            textRacuna.AppendText($"{"Naziv",-20}{"Cijena",-10}{"Količina",-5}  {"Ukupno",-5}\n\n");  
        }

        public int GetQuantityFromUser(string label)
        {
            UnosKolicine unosKolicine = new UnosKolicine();
            unosKolicine.updateLabel(label);
            if (unosKolicine.ShowDialog() == DialogResult.OK)
            {
                int quantity = unosKolicine.Quantity;
                return quantity;
            }
            else
            {
                MessageBox.Show("Ne dodajemo proizvod!", "Upozorenje");
                if (narucenaPica.Count == 0)
                {
                    textRacuna.Clear();
                }
                return 0;
            }
        }
    }
}