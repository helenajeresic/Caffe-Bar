﻿using System;
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
        private SqlCommand naredba;
        public Dictionary<Pice, decimal> narucenaPica = new Dictionary<Pice, decimal>();
        public int id_ulogirani;
        public string ime_ulogirani;
        public string prezime_ulogirani;
        public string username_ulogirani;
        public KonobarForm(int id_konobar, string ime_konobar, string prezime_konobar, string username_konobar)
        {
            InitializeComponent();
            naredba = new SqlCommand();
            id_ulogirani = id_konobar;
            ime_ulogirani = ime_konobar;
            prezime_ulogirani = prezime_konobar;
            username_ulogirani = username_konobar;

            labelUsername.Text = "Prijavljen konobar: " + username_konobar;
            dataGridViewPica.CellFormatting += dataGridViewPica_CellFormatting;

            
        }

        private List<Pice> GetPicaFromDatabase(string upit)
        {
            SqlConnection veza = new SqlConnection(connectionString);
            veza.Open();
            naredba = new SqlCommand(upit, veza);
            naredba.Parameters.AddWithValue("@unos", "%" + textBoxTrazi.Text + "%");
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
            }
            veza.Close();

            return pica;
        }

        private void primjeniPopustNaPica(List<Pice> pica, decimal popust)
        {
            pica.ForEach(x => x.cijena_pica -= popust * x.cijena_pica);
        }

        private void prikaziPicaDataGridView(List<Pice> pica)
        {
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

            if(provjeraAkcije() > 0)
            {
                foreach (DataGridViewRow row in dataGridViewPica.Rows)
                {
                    if (row.Cells["cijena_pica"].Value != null)
                    {
                        row.Cells["cijena_pica"].Style.ForeColor = Color.Blue;
                    }
                }
            }
        }

        private void buttonPrikaziPica_Click(object sender, EventArgs e)
        {
            List<Pice> pica = GetPicaFromDatabase("SELECT * FROM Pica");

            if(provjeraAkcije() != 0)
            {
                decimal popust = provjeraAkcije() / 100;
                primjeniPopustNaPica(pica, popust);
                labelAkcijaUTijeku.Text = "U tijeku je akcija - " + provjeraAkcije().ToString() + "%";
            }
            prikaziPicaDataGridView(pica);
        }

        private void textBoxTrazi_TextChanged(object sender, EventArgs e)
        {
            List<Pice> pica = GetPicaFromDatabase("SELECT * FROM Pica");

            
            if (textBoxTrazi.Text.Length > 0)
            {
                pica = GetPicaFromDatabase("SELECT * FROM Pica WHERE naziv_pica LIKE @unos");
            }
            prikaziPicaDataGridView(pica);
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
                        e.Value = roundedValue.ToString("0.00");
                        e.CellStyle.Format = "0.00";
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
            decimal total = izdajRacun.calculateTotal(narucenaPica);
            izdajRacun.updateFinalniRacun(textRacuna.Rtf);
            izdajRacun.updateKonobarInfo(id_ulogirani, ime_ulogirani, prezime_ulogirani);
            DateTime vrijeme = izdajRacun.VrijemeRacuna;
            
            if (izdajRacun.ShowDialog() == DialogResult.OK)
            {
                updateKolicinaPica(narucenaPica);
                zapisRacunStavke(vrijeme);
                //zapisKonobarPopust();

                MessageBox.Show("Račun uspješno evidentiran!", "Obavijest");
                textRacuna.Clear();
                narucenaPica.Clear();
            }
            else
            {
                MessageBox.Show("Račun nije evidentiran!", "Obavijest");
            }

        }

        private void updateKolicinaPica(Dictionary<Pice, decimal> narucenaPica)
        {
            using(SqlConnection veza = new SqlConnection(connectionString))
            {
                veza.Open();

                foreach(KeyValuePair<Pice, decimal> stavkaRacuna in narucenaPica)
                {
                    Pice pice = stavkaRacuna.Key;
                    decimal novaKolicina = pice.kolicina_kafic - stavkaRacuna.Value;

                    string azuriraj = "UPDATE Pica SET kolicina_kafic = @novaKolicina WHERE id_pica = @idPica";

                    using (SqlCommand azurirajNaredba = new SqlCommand(azuriraj, veza))
                    {
                        azurirajNaredba.Parameters.AddWithValue("@novaKolicina", novaKolicina);
                        azurirajNaredba.Parameters.AddWithValue("@idPica", pice.id_pica);

                        azurirajNaredba.ExecuteNonQuery();
                    }
                }
                veza.Close();
            }
        }

        private void zapisRacunStavke(DateTime vrijeme)
        {
            int id_racuna = 0;

            using (SqlConnection veza = new SqlConnection(connectionString))
            {
                veza.Open();

                string selectQuery = "SELECT id_racun FROM Racun WHERE datum_vrijeme = @vrijeme";
                SqlCommand selectCommand = new SqlCommand(selectQuery, veza);
                selectCommand.Parameters.AddWithValue("@vrijeme", vrijeme);

                using (SqlDataReader čitač = selectCommand.ExecuteReader())
                {
                    if (čitač.Read())
                    {
                        id_racuna = čitač.GetInt32(0);
                    }
                }

                if (id_racuna == 0)
                {
                    MessageBox.Show("Greška u dohvatu id_racuna", "Greška");
                }
                else
                {
                    foreach (KeyValuePair<Pice, decimal> pice in narucenaPica)
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            string insertQuery = "INSERT INTO RacunStavke (id_racun, id_pica, kolicina, vrijeme) " +
                                "VALUES (@id_racun, @id_pica, @kolicina, @vrijeme)";
                            SqlCommand insertCommand = new SqlCommand(insertQuery, connection);

                            insertCommand.Parameters.AddWithValue("@id_racun", id_racuna);
                            insertCommand.Parameters.AddWithValue("@id_pica", pice.Key.id_pica);
                            insertCommand.Parameters.AddWithValue("@kolicina", pice.Value);
                            insertCommand.Parameters.AddWithValue("@vrijeme", vrijeme);

                            try
                            {
                                insertCommand.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Greška prilikom upisa u RacunStavke: " + ex.Message, "Greška");
                            }
                        }
                    }
                }
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

        private decimal provjeraAkcije()
        {
            decimal akcija = 0;

            SqlConnection veza = new SqlConnection(connectionString);
            veza.Open();
            string upit = "SELECT * FROM Akcija WHERE GETDATE() BETWEEN [od] AND [do];";
            SqlCommand naredba = new SqlCommand(upit, veza);
            using (SqlDataReader čitač = naredba.ExecuteReader())
            {
                if (čitač.Read())
                {
                    akcija = čitač.GetDecimal(4);
                }
            }
            veza.Close();
            return akcija;
        }

        private void gumbOdjavaKonobara_Click(object sender, EventArgs e)
        {
            labelUsername.Text = "";
            PrijavaForm forma = new PrijavaForm();
            forma.Show();
            this.Hide();
        }
        
        private void buttonPrikaziStanjeSanka_Click(object sender, EventArgs e)
        {
            //popuvanjanje forme sa stanjima pica u sanku
            SqlConnection veza = new SqlConnection(connectionString);

            veza.Open();

            string upit = "SELECT naziv_pica as 'Naziv Pica', kolicina_kafic as 'Količina'" +
                " FROM Pica" +
                " ORDER BY naziv_pica";
            SqlDataAdapter adapter = new SqlDataAdapter(upit, veza);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            dataGridViewSank.DataSource = dt;

            veza.Close();
        }

        private void buttonPrikaziStanjeSanka_Click_1(object sender, EventArgs e)
        {
            //popuvanjanje forme sa stanjima pica u sanku - potrebno za tab Šank
            //popuvanja se kod samog pokretanja forme
            SqlConnection veza = new SqlConnection(connectionString);

            veza.Open();

            string upit = "SELECT naziv_pica as 'Naziv pića', kolicina_kafic as 'Količina'" +
                " FROM Pica" +
                " ORDER BY naziv_pica";
            SqlDataAdapter adapter = new SqlDataAdapter(upit, veza);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            dataGridViewSank.DataSource = dt;


            //popunjavanje labele koja upozorava korisnika da napuni sank ako je kolicina nekog pica u sanku manja od 5
            //labela se popunjava odmah kod pokretanja forme
            upit = "SELECT naziv_pica, kolicina_kafic FROM Pica " +
                "WHERE kolicina_kafic <= 5";
            SqlCommand naredba1 = new SqlCommand(upit, veza);
            Dictionary<string, decimal> pica = new Dictionary<string, decimal>();
            using (SqlDataReader citac = naredba1.ExecuteReader())
            {
                while (citac.Read())
                {
                    pica.Add(citac.GetString(0), citac.GetDecimal(1));
                }
            }
            veza.Close();
            string popuniLabelu;

            if (pica.Count > 0)
            {
                labelPotrebnoNapunitiSank.ForeColor = Color.Red;
                popuniLabelu = "Niska zaliha sljedećih pića u šanku! \n" +
                "Potrebno je nadopuniti iz skladišta! \n\n";

                foreach (var stavka in pica)
                {
                    popuniLabelu += "   " + stavka.Key + ": trenutna količina " + stavka.Value + "\n";
                }
            }
            else
            {
                labelPotrebnoNapunitiSank.ForeColor = Color.Green;
                popuniLabelu = "Zaliha svih pića u šanku je dobra!";
            }
            labelPotrebnoNapunitiSank.Text = popuniLabelu;
        }

        private void KonobarForm_Load(object sender, EventArgs e)
        {

        }
    }
}