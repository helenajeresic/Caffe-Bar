using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CaffeBar
{
    public partial class KonobarForm : Form
    {
        public string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\baza.mdf;Integrated Security=True";
        public Dictionary<Pice, decimal> narucenaPica = new Dictionary<Pice, decimal>();
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

        public void dataGridViewPica_CellClick(object sender, DataGridViewCellEventArgs e)
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

                string label = nazivPica;
                decimal kolicina = dohvatiUnesenuKolicinu(label, idPica);

                if (kolicina > 0)
                {
                    if(narucenaPica.Any(item => item.Key.naziv_pica == label))
                    {
                        Pice existingItem = narucenaPica.Keys.FirstOrDefault(item => item.naziv_pica == label);
                        narucenaPica[existingItem] += kolicina;
                        decimal ukupna_cijena = Math.Round(existingItem.cijena_pica * kolicina, 2);
                        string info = $"{existingItem.naziv_pica,-20}{Math.Round(existingItem.cijena_pica, 2),-10} x {kolicina,-5} = {ukupna_cijena,-5}";
                        MessageBox.Show("Dodano na račun: " + info, "Obavijest");
                        textRacuna.AppendText(info + "\n\n");
                    }
                    else
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
                        narucenaPica[narucenoPice] = kolicina;

                        decimal ukupnaCijena = Math.Round(cijenaPica * kolicina, 2);
                        string piceInfo = $"{nazivPica,-20}{Math.Round(cijenaPica, 2),-10} x {kolicina,-5} = {ukupnaCijena,-5}";
                        MessageBox.Show("Dodano na račun: " + piceInfo, "Obavijest");
                        textRacuna.AppendText(piceInfo + "\n\n");
                    }

                }
            }
        }

        private void initializeBill()
        {
            textRacuna.SelectionStart = 0;
            textRacuna.SelectionLength = 0; 
            textRacuna.SelectionAlignment = HorizontalAlignment.Center;

            textRacuna.AppendText("\n");
            textRacuna.AppendText("Caffe-Bar Naziv \n\n");
            textRacuna.AppendText("Bijenička cesta 30\n");
            textRacuna.AppendText("10000 Zagreb\n");
            textRacuna.AppendText("--------------------------------------\n\n");
            textRacuna.SelectionAlignment = HorizontalAlignment.Left;
            textRacuna.AppendText($"{"Naziv",-20}{"Cijena",-10}{"Količina",-5}  {"Ukupno",-5}\n\n");
            textRacuna.Font = new Font(FontFamily.GenericMonospace, textRacuna.Font.Size);

            textRacuna.SelectionStart = textRacuna.Text.Length;
            textRacuna.ScrollToCaret();
        }

        public decimal dohvatiUnesenuKolicinu(string label, int idPica)
        {
            UnosKolicine unosKolicine = new UnosKolicine();
            if (narucenaPica.Any(item => item.Key.naziv_pica == label))
            {
                unosKolicine.urediLabel(label);
                Pice existingItem = narucenaPica.Keys.FirstOrDefault(item => item.naziv_pica == label);
                decimal existingQuantity = narucenaPica[existingItem];
                unosKolicine.setDostupnaKolicina(dohvatiDostupnuKolicinu(idPica) - existingQuantity);
                if (unosKolicine.ShowDialog() == DialogResult.OK)
                {
                    return unosKolicine.Kolicina;
                }
                else
                {
                    MessageBox.Show("Ne dodajemo proizvod na račun!", "Upozorenje");
                    if (narucenaPica.Count == 0)
                    {
                        textRacuna.Clear();
                    }
                    return 0;
                }
            }
            else
            {
                unosKolicine.setDostupnaKolicina(dohvatiDostupnuKolicinu(idPica));
                unosKolicine.urediLabel(label);
                if (unosKolicine.ShowDialog() == DialogResult.OK)
                {
                    return unosKolicine.Kolicina;
                }
                else
                {
                    MessageBox.Show("Ne dodajemo proizvod na račun!", "Upozorenje");
                    if (narucenaPica.Count == 0)
                    {
                        textRacuna.Clear();
                    }
                    return 0;
                }
            }
        }

        public void gumbIzdajRacun_Click(object sender, EventArgs e)
        {
            IzdajRacun izdajRacun = new IzdajRacun();
            izdajRacun.calculateTotal(narucenaPica);
            izdajRacun.updateFinalniRacun(textRacuna.Rtf);

            if (izdajRacun.ShowDialog() == DialogResult.OK)
            {
                //skini s baze kolicine 
                // zapisi racun stavke
                // zapisi konobar popust
                MessageBox.Show("Račun uspješno evidentiran!", "Obavijest");
                textRacuna.Clear();
                narucenaPica.Clear();
            }
            else
            {
                MessageBox.Show("Račun nije evidentiran!", "Obavijest");
            }

        }

        public decimal dohvatiDostupnuKolicinu(int idPica)
        {
            decimal dostupnaKolicina = 0;

            SqlConnection veza = new SqlConnection(connectionString);
            veza.Open();
            string upit = "SELECT kolicina_kafic FROM Pica WHERE id_pica = @idPica";
            SqlCommand naredba = new SqlCommand(upit, veza);

            naredba.Parameters.AddWithValue("@IdPica", idPica);

            using (SqlDataReader čitač = naredba.ExecuteReader())
            {
                if (čitač.Read())
                {
                    dostupnaKolicina = čitač.GetDecimal(0);
                }
            }
            veza.Close();

            return dostupnaKolicina;
        }

        private void buttonOcistiRacun_Click(object sender, EventArgs e)
        {
            textRacuna.Clear() ;
            narucenaPica.Clear();
        }
    }
}