using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CaffeBar
{
    public partial class KonobarForm : Form
    {
        public string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Helena\Desktop\moje\Caffe-Bar\Caffe-Bar\baza.mdf;Integrated Security=True;MultipleActiveResultSets=True;";
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
            UcitajPicaUComboBoxNarudzba();
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

            if (provjeraAkcije() > 0)
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

            if (provjeraAkcije() != 0)
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
                    if (narucenaPica.Any(item => item.Key.naziv_pica == label))
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
                AzurirajStanjeSanka();
                PrikaziSveRacune();

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
            using (SqlConnection veza = new SqlConnection(connectionString))
            {
                veza.Open();

                foreach (KeyValuePair<Pice, decimal> stavkaRacuna in narucenaPica)
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
            textRacuna.Clear();
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
            ObracunForm forma = new ObracunForm(id_ulogirani);
            forma.Show();
            this.Hide();
        }


        private void KonobarForm_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Klikom na gumb prikazuju se podaci o svim količinama pića u skladištu
        /// Popuvanja se dropdown za odabir pića koje želimo za premještanje iz skladišta u šank
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonStanjeSkladista_Click(object sender, EventArgs e)
        {
            SqlConnection veza = new SqlConnection(connectionString);

            veza.Open();

            string upit = "SELECT naziv_pica as 'Naziv pića', kolicina_skladista as 'Količina na skladištu'" +
                " FROM Pica" +
                " ORDER BY naziv_pica";
            SqlDataAdapter adapter = new SqlDataAdapter(upit, veza);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            dataGridViewStanjeSkladista.DataSource = dt;

            var lista_pica = GetPicaFromDatabase("SELECT * FROM Pica");

            veza.Close();

            lista_pica.Sort((x, y) => x.naziv_pica.CompareTo(y.naziv_pica));

            foreach (var pice in lista_pica)
            {
                if (!comboBoxOdaberiPiceZaSank.Items.Contains(pice.naziv_pica))
                {
                    comboBoxOdaberiPiceZaSank.Items.Add(pice.naziv_pica);
                }
            }
        }

        /// <summary>
        /// Funkcija koja dohvaća količinu pića koja se nalazi u skladištu 
        /// </summary>
        /// <param name="idPica"></param>
        /// <returns>dostupna_kolicina</returns>
        public decimal dohvatiDostupnuKolicinuSkladista(int idPica)
        {
            decimal dostupnaKolicina = 0;

            SqlConnection veza = new SqlConnection(connectionString);
            veza.Open();
            string upit = "SELECT kolicina_skladista FROM Pica WHERE id_pica = @idPica";
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

        /// <summary>
        /// Klikom na gumb dodaje se odabrani proizvod i odabrana količina u šank, a miče se sa skladišta
        /// Ako je odabrana količina veća od količine u skladištu, javlja se poruka i može se početi ispočetka
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDodajUSank_Click(object sender, EventArgs e)
        {
            var lista_pica = GetPicaFromDatabase("SELECT * FROM Pica");
            lista_pica.Sort((x, y) => x.naziv_pica.CompareTo(y.naziv_pica));

            if (comboBoxOdaberiPiceZaSank.SelectedIndex != -1)
            {
                var odabrano_pice = comboBoxOdaberiPiceZaSank.SelectedItem.ToString();
                int odabrano_pice_id = 0;
                Pice odabrano = new Pice();
                foreach (var pice in lista_pica)
                {
                    if (pice.naziv_pica == odabrano_pice)
                    {
                        odabrano_pice_id = pice.id_pica;
                        odabrano = pice;
                        break;
                    }
                }
                var dostupno_na_skladistu = dohvatiDostupnuKolicinuSkladista(odabrano_pice_id);

                var odabrana_kolicina = numericUpDownOdaberiKolicinuZaSank.Value;
                if (odabrana_kolicina > dostupno_na_skladistu)
                {
                    MessageBox.Show("Prevelika količina! Nema toliko na skladištu!", "Dodavanje nije uspjelo");
                }
                else
                {
                    try
                    {
                        using (SqlConnection veza = new SqlConnection(connectionString))
                        {
                            veza.Open();

                            var nova_kolicina = odabrano.kolicina_kafic + odabrana_kolicina;
                            var nova_kolicina1 = odabrano.kolicina_skladista - odabrana_kolicina;

                            string azuriraj = "UPDATE Pica SET kolicina_kafic = @nova_kolicina, kolicina_skladista = @nova_kolicina1 WHERE id_pica = @odabrano_pice_id";

                            using (SqlCommand naredba = new SqlCommand(azuriraj, veza))
                            {
                                naredba.Parameters.AddWithValue("@nova_kolicina", nova_kolicina);
                                naredba.Parameters.AddWithValue("@nova_kolicina1", nova_kolicina1);
                                naredba.Parameters.AddWithValue("@odabrano_pice_id", odabrano.id_pica);

                                naredba.ExecuteNonQuery();

                                MessageBox.Show($"Dodano {odabrana_kolicina}x {odabrano_pice} u šank!", "Uspješno dodano");
                            }
                            veza.Close();

                            AzurirajStanjeSanka();
                            AzurirajStanjeSkladista();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Greška: {ex.Message}");
                    }
                }
            }
        }

        /// <summary>
        /// Klikom na gumb prikazuju se podaci o svim količinama pića u šanku
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonPrikaziStanjeSank_Click(object sender, EventArgs e)
        {
            SqlConnection veza = new SqlConnection(connectionString);

            veza.Open();

            string upit = "SELECT naziv_pica as 'Naziv pića', kolicina_kafic as 'Količina šank'" +
                " FROM Pica" +
                " ORDER BY naziv_pica";
            SqlDataAdapter adapter = new SqlDataAdapter(upit, veza);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            dataGridViewStanjeSank.DataSource = dt;
            veza.Close();
        }

        /// <summary>
        /// Funkcija koja ažurira količine pića u skladištu
        /// </summary>
        public void AzurirajStanjeSkladista()
        {
            SqlConnection veza = new SqlConnection(connectionString);

            veza.Open();

            string upit = "SELECT naziv_pica as 'Naziv pića', kolicina_skladista as 'Količina na skladištu'" +
                                " FROM Pica" +
                                " ORDER BY naziv_pica";
            SqlDataAdapter adapter = new SqlDataAdapter(upit, veza);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            dataGridViewStanjeSkladista.DataSource = dt;

            veza.Close();

        }

        /// <summary>
        /// Funkcija koja ažurira količine pića u šanku
        /// </summary>
        public void AzurirajStanjeSanka()
        {
            SqlConnection veza = new SqlConnection(connectionString);

            veza.Open();

            string upit = "SELECT naziv_pica as 'Naziv pića', kolicina_kafic as 'Količina šank'" +
                           " FROM Pica" +
                           " ORDER BY naziv_pica";
            SqlDataAdapter adapter = new SqlDataAdapter(upit, veza);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            dataGridViewStanjeSank.DataSource = dt;

            veza.Close();

        }

        private void buttonNarudžba_Click(object sender, EventArgs e)
        {
            PrikaziSveNarudzbe();
        }

        private void PrikaziSveNarudzbe()
        {
            using (SqlConnection veza = new SqlConnection(connectionString))
            {
                veza.Open();

                string upit = "SELECT N.id_narudzba AS 'id_narudzba', P.naziv_pica AS 'Naziv pića', " +
                                      "N.datum_naruceno AS 'Datum narudžbe', N.kolicina AS 'Količina', " +
                                      "CASE WHEN N.dostavljeno = 'D' THEN 'Da' ELSE 'Ne' END AS 'Dostavljeno'" +
                                      "FROM Narudzba N " +
                                      "JOIN Pica P ON N.id_pica = P.id_pica " +
                                      "ORDER BY CASE WHEN N.dostavljeno = 'N' THEN 0 ELSE 1 END, N.datum_naruceno DESC";

                SqlDataAdapter adapter = new SqlDataAdapter(upit, veza);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridViewNarudzba.DataSource = dt;

                if (dt.Columns.Contains("id_narudzba"))
                {
                    dataGridViewNarudzba.Columns["id_narudzba"].Visible = false;
                }
            }
        }

        private void UcitajPicaUComboBoxNarudzba()
        {
            comboBoxNarudzba.Items.Clear();

            using (SqlConnection veza = new SqlConnection(connectionString))
            {
                veza.Open();
                string upit = "SELECT id_pica, naziv_pica FROM Pica";
                SqlCommand cmd = new SqlCommand(upit, veza);

                using (SqlDataReader citac = cmd.ExecuteReader())
                {
                    while (citac.Read())
                    {
                        ComboboxItem item = new ComboboxItem
                        {
                            Text = citac["naziv_pica"].ToString(),
                            Value = citac["id_pica"]
                        };
                        comboBoxNarudzba.Items.Add(item);
                    }
                }
            }
        }

        private void buttonNarudzba_Click(object sender, EventArgs e)
        {
            if (comboBoxNarudzba.SelectedItem == null)
            {
                MessageBox.Show("Odaberite piće za narudžbu.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nazivPica = ((ComboboxItem)comboBoxNarudzba.SelectedItem).Text;

            int idPica;
            int kolicina = (int)numericUpDownNarudzba.Value;

            using (SqlConnection veza = new SqlConnection(connectionString))
            {
                veza.Open();

                string upitDohvatiIdPica = "SELECT id_pica FROM Pica WHERE naziv_pica = @nazivPica";

                using (SqlCommand cmdDohvatiIdPica = new SqlCommand(upitDohvatiIdPica, veza))
                {
                    cmdDohvatiIdPica.Parameters.AddWithValue("@nazivPica", nazivPica);

                    object rezultat = cmdDohvatiIdPica.ExecuteScalar();

                    if (rezultat != null && rezultat != DBNull.Value)
                    {
                        idPica = Convert.ToInt32(rezultat);
                    }
                    else
                    {
                        MessageBox.Show("Nije moguće pronaći identifikator pića za odabrani naziv.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                string dodajNarudzbu = "INSERT INTO Narudzba (id_pica, id_konobar, kolicina, datum_naruceno, dostavljeno) " +
                                        "VALUES (@idPica, @idKonobar, @kolicina, @datumNaruceno, 'N')";

                using (SqlCommand cmdDodajNarudzbu = new SqlCommand(dodajNarudzbu, veza))
                {
                    cmdDodajNarudzbu.Parameters.AddWithValue("@idPica", idPica);
                    cmdDodajNarudzbu.Parameters.AddWithValue("@idKonobar", id_ulogirani);
                    cmdDodajNarudzbu.Parameters.AddWithValue("@kolicina", kolicina);
                    cmdDodajNarudzbu.Parameters.AddWithValue("@datumNaruceno", DateTime.Now);

                    cmdDodajNarudzbu.ExecuteNonQuery();
                    MessageBox.Show("Narudžba je uspješno dodana.", "Uspjeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            PrikaziSveNarudzbe();
        }

        private void dataGridViewNarudzba_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DialogResult rezultat = MessageBox.Show("Jeste li sigurni da želite označiti narudžbu kao dostavljenu?", "Potvrda dostavljanja", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (rezultat == DialogResult.Yes)
                {
                    int idNarudzbe = (int)dataGridViewNarudzba.Rows[e.RowIndex].Cells["id_narudzba"].Value;

                    PromijeniStatusDostave(idNarudzbe);

                    PrikaziSveNarudzbe();
                }
            }
        }

        private void PromijeniStatusDostave(int idNarudzbe)
        {
            using (SqlConnection veza = new SqlConnection(connectionString))
            {
                veza.Open();

                string provjeraDostave = "SELECT dostavljeno FROM Narudzba WHERE id_narudzba = @idNarudzbe";

                using (SqlCommand cmdProvjeriDostavu = new SqlCommand(provjeraDostave, veza))
                {
                    cmdProvjeriDostavu.Parameters.AddWithValue("@idNarudzbe", idNarudzbe);

                    object rezultat = cmdProvjeriDostavu.ExecuteScalar();

                    if (rezultat != null && rezultat != DBNull.Value && rezultat.ToString() == "D")
                    {
                        MessageBox.Show("Narudžba je već označena kao dostavljena.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                string dohvatiNarudzbu = "SELECT id_pica, kolicina FROM Narudzba WHERE id_narudzba = @idNarudzbe";

                using (SqlCommand cmdDohvatiNarudzbu = new SqlCommand(dohvatiNarudzbu, veza))
                {
                    cmdDohvatiNarudzbu.Parameters.AddWithValue("@idNarudzbe", idNarudzbe);

                    using (SqlDataReader citac = cmdDohvatiNarudzbu.ExecuteReader())
                    {
                        while (citac.Read())
                        {
                            int idPica = citac.GetInt32(0);
                            int kolicina = citac.GetInt32(1);

                            string azurirajKolicinuSkladista = "UPDATE Pica SET kolicina_skladista = kolicina_skladista + @kolicina WHERE id_pica = @idPica";

                            using (SqlCommand cmdAzurirajKolicinu = new SqlCommand(azurirajKolicinuSkladista, veza))
                            {
                                cmdAzurirajKolicinu.Parameters.AddWithValue("@idPica", idPica);
                                cmdAzurirajKolicinu.Parameters.AddWithValue("@kolicina", kolicina);

                                cmdAzurirajKolicinu.ExecuteNonQuery();
                            }
                        }
                        citac.Close();
                    }
                }

                string azurirajDostavu = "UPDATE Narudzba SET dostavljeno = 'D' WHERE id_narudzba = @idNarudzbe";

                using (SqlCommand cmdAzurirajDostavu = new SqlCommand(azurirajDostavu, veza))
                {
                    cmdAzurirajDostavu.Parameters.AddWithValue("@idNarudzbe", idNarudzbe);

                    cmdAzurirajDostavu.ExecuteNonQuery();
                }
            }
        }

        private void buttonNarudzbaZaliha_Click(object sender, EventArgs e)
        {
            PrikaziNiskeZalihe();
        }

        private void PrikaziNiskeZalihe()
        {
            using (SqlConnection veza = new SqlConnection(connectionString))
            {
                veza.Open();

                string upit = "SELECT naziv_pica AS 'Naziv pića', (kolicina_skladista + kolicina_kafic) AS 'Ukupne zalihe' " +
                              "FROM Pica " +
                              "WHERE (kolicina_skladista + kolicina_kafic) < najmanja_kolicina";

                SqlDataAdapter adapter = new SqlDataAdapter(upit, veza);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridViewNarudzbaZaliha.DataSource = dt;
            }
        }

        /// <summary>
        /// Klikom na gumb prikazuju se svi računi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonPrikaziRacune_Click(object sender, EventArgs e)
        {
            PrikaziSveRacune();
        }


        /// <summary>
        /// funkcija koja iz baze dohvaća sve račune i sortira ih od najnovijeg do najstarijeg
        /// </summary>
        public void PrikaziSveRacune()
        {
            using (SqlConnection veza = new SqlConnection(connectionString))
            {
                veza.Open();

                string upit = "SELECT R.id_racun AS 'id_racun', K.korisnicko_ime AS 'Izdao konobar', R.datum_vrijeme AS 'Datum i vrijeme', " +
                    "R.iznos AS 'Iznos računa' " +
                    "FROM Racun R " +
                    "JOIN Osobe K ON R.id_konobar = K.id_osobe " +
                    "ORDER BY R.datum_vrijeme DESC";

                SqlDataAdapter adapter = new SqlDataAdapter(upit, veza);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                //zaokruzivanje iznosa računa na dvije decimale
                dt.Columns["Iznos računa"].DataType = typeof(decimal);
                foreach (DataRow row in dt.Rows)
                {
                    if (!row.IsNull("Iznos računa"))
                    {
                        row["Iznos računa"] = ((decimal)row["Iznos računa"]).ToString("N2");
                    }
                }

                dataGridViewRacuni.DataSource = dt;

                if (dt.Columns.Contains("id_racun"))
                {
                    dataGridViewRacuni.Columns["id_racun"].Visible = false;
                }
            }
        }


        /// <summary>
        /// Klikom na ćeliju u tablici sa računima, prvo se prikažu detalji odabranog računa, a zatim i mogućnost storiranja računa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewRacuni_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                int idRacuna = (int)dataGridViewRacuni.Rows[e.RowIndex].Cells["id_racun"].Value;

                PrikaziDetaljeRacuna(idRacuna);

                DialogResult rezultat = MessageBox.Show("Jeste li sigurni da želite stornirati odabrani račun?", "Potvrdi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (rezultat == DialogResult.Yes)
                { 

                    ObrisiRacun(idRacuna);

                    PrikaziSveRacune();
                }
            }
        }


        /// <summary>
        /// Funkcija koja za odabrani račun prikazuje sve stavke tog računa u obliku MessageBoxa
        /// </summary>
        /// <param name="idRacuna"></param>
        private void PrikaziDetaljeRacuna(int idRacuna)
        {
            try
            {
                using (SqlConnection veza = new SqlConnection(connectionString))
                {
                    veza.Open();

                    string detaljiUpit = "SELECT RS.id_pica, P.naziv_pica, RS.kolicina, P.cijena_pica " +
                        "FROM RacunStavke RS " +
                        "JOIN Pica P " +
                        "ON RS.id_pica = P.id_pica " +
                        "WHERE RS.id_racun = @idRacuna";

                    using (SqlCommand detaljiNaredba = new SqlCommand(detaljiUpit, veza))
                    {
                        detaljiNaredba.Parameters.AddWithValue("@idRacuna", idRacuna);

                        using (SqlDataReader reader = detaljiNaredba.ExecuteReader())
                        {
                            StringBuilder detalji = new StringBuilder();

                            while (reader.Read())
                            {
                                int idPica = reader.GetInt32(0);
                                string naziv = reader.GetString(1);
                                int kolicina = reader.GetInt32(2);
                                decimal cijena = reader.GetDecimal(3);

                                detalji.AppendLine($"Naziv: {naziv}, Količina: {kolicina}, Cijena: {cijena.ToString("0.00")} EUR");
                            }

                            if (detalji.Length > 0)
                            {
                                MessageBox.Show(detalji.ToString(), "Detalji računa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Nema dostupnih detalja za odabrani račun.", "Detalji računa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }

                    veza.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greška prilikom dohvaćanja detalja računa: {ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// Funkcija koja briše račun iz tablice Racun, briše sve stavke tog računa iz tablice RacunStavke i dodaje stornirane količiine u stanje šanka
        /// </summary>
        /// <param name="idRacuna"></param>
        private void ObrisiRacun(int idRacuna)
        {
            try
            {
                using (SqlConnection veza = new SqlConnection(connectionString))
                {
                    veza.Open();

                    using (SqlTransaction transakcija = veza.BeginTransaction())
                    {
                        try
                        {
                            // Dohvaćanje svih stavki koje se nalaze na računu koji želimo brisati
                            string dohvatiStavkeUpit = "SELECT id_pica, kolicina FROM RacunStavke WHERE id_racun = @idRacuna";

                            List<Tuple<int, int>> stavkeZaDodati = new List<Tuple<int, int>>();

                            using (SqlCommand dohvatiStavkeNaredba = new SqlCommand(dohvatiStavkeUpit, veza, transakcija))
                            {
                                dohvatiStavkeNaredba.Parameters.AddWithValue("@idRacuna", idRacuna);

                                using (SqlDataReader reader = dohvatiStavkeNaredba.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        int idPica = reader.GetInt32(0);
                                        int kolicinaStavke = reader.GetInt32(1);

                                        stavkeZaDodati.Add(new Tuple<int, int>(idPica, kolicinaStavke));
                                    }
                                }
                            }

                            // Brisanje iz RacunStavke
                            string obrisiRacunStavkeUpit = "DELETE FROM RacunStavke WHERE id_racun = @idRacuna";

                            using (SqlCommand naredbaObrisiStavke = new SqlCommand(obrisiRacunStavkeUpit, veza, transakcija))
                            {
                                naredbaObrisiStavke.Parameters.AddWithValue("@idRacuna", idRacuna);
                                naredbaObrisiStavke.ExecuteNonQuery();
                            }

                            // Ažuriranje stanja na šanku
                            foreach (var stavka in stavkeZaDodati)
                            {
                                string azurirajKolicinuUpit = "UPDATE Pica SET kolicina_kafic = kolicina_kafic + @kolicinaStavke WHERE id_pica = @idPica";

                                using (SqlCommand naredbaAzurirajKolicinu = new SqlCommand(azurirajKolicinuUpit, veza, transakcija))
                                {
                                    naredbaAzurirajKolicinu.Parameters.AddWithValue("@kolicinaStavke", stavka.Item2);
                                    naredbaAzurirajKolicinu.Parameters.AddWithValue("@idPica", stavka.Item1);

                                    naredbaAzurirajKolicinu.ExecuteNonQuery();
                                }
                            }

                            // Brisanje računa
                            string obrisiRacunUpit = "DELETE FROM Racun WHERE id_racun = @idRacuna";

                            using (SqlCommand naredbaObrisiRacun = new SqlCommand(obrisiRacunUpit, veza, transakcija))
                            {
                                naredbaObrisiRacun.Parameters.AddWithValue("@idRacuna", idRacuna);
                                naredbaObrisiRacun.ExecuteNonQuery();
                            }

                            transakcija.Commit();

                            MessageBox.Show("Račun je storniran!");
                            AzurirajStanjeSanka();
                        }
                        catch (Exception ex)
                        {
                            transakcija.Rollback();
                            throw; 
                        }
                    }

                    veza.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greška prilikom storniranja računa: {ex.Message}");
            }
        }


    }
}