﻿using System;
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
        public string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ivana\Desktop\RP\Caffe-Bar\Caffe-Bar\Caffe-Bar\baza.mdf;Integrated Security=True;MultipleActiveResultSets=True;"; 
        private SqlCommand naredba;
        public Dictionary<Pice, decimal> narucenaPica;
        public Dictionary<Pice, int> konobarskiPopust;
        public string infoPopust;
        public decimal popust = 0.20M;
        public bool Popust;
        public int id_ulogirani;
        public string ime_ulogirani;
        public string prezime_ulogirani;
        public string username_ulogirani;
        public string popustUsername;

        /// <summary>
        /// Konstrktor za KonobarForm. Primaju se podaci o prijavljenom konobaru,
        /// inicijaliziraju svi potrebni objekti.
        /// </summary>
        /// <param name="id_konobar"></param>
        /// <param name="ime_konobar"></param>
        /// <param name="prezime_konobar"></param>
        /// <param name="username_konobar"></param>
        public KonobarForm(int id_konobar, string ime_konobar, string prezime_konobar, string username_konobar)
        {
            InitializeComponent();
            naredba = new SqlCommand();
            id_ulogirani = id_konobar;
            ime_ulogirani = ime_konobar;
            prezime_ulogirani = prezime_konobar;
            username_ulogirani = username_konobar;
            Popust = false;
            buttonKonobarskiPopust.Enabled = false;
            infoPopust = "";

            narucenaPica = new Dictionary<Pice, decimal>();
            konobarskiPopust = new Dictionary<Pice, int>();
            labelUsername.Text = "Prijavljen konobar: " + username_konobar;
            dataGridViewPica.CellFormatting += dataGridViewPica_CellFormatting;
            UcitajPicaUComboBoxNarudzba();
            UcitajPicaUComboBoxSkladiste();
        }

        /// <summary>
        /// Metoda koja u listu sprema sva piće u bazi iz tablice Pica.
        /// </summary>
        /// <param name="upit"> Upit prema kojem se dohvaćaju pića. </param>
        /// <returns></returns>
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

        /// <summary>
        /// Prikaz pića u data grid viewu. Postavlja se nazivi i vidljivost stupaca,
        /// te boja snizenih pića.
        /// </summary>
        /// <param name="pica"></param>
        private void prikaziPicaDataGridView(string upit)
        {
            dataGridViewPica.DataSource = GetPicaFromDatabase(upit);
            dataGridViewPica.Columns[0].Visible = false;
            dataGridViewPica.Columns[3].Visible = false;
            //dataGridViewPica.Columns[4].Visible = false;
            dataGridViewPica.Columns[5].Visible = false;
            dataGridViewPica.Columns[6].Visible = false;

            if (provjeraAkcije().Count > 0)
            {
                List<int> listaSnizenih = provjeraAkcije().Keys.ToList();
                foreach (DataGridViewRow row in dataGridViewPica.Rows)
                {
                    if (listaSnizenih.Contains((int)row.Cells["id_pica"].Value))
                    {
                        row.DefaultCellStyle.ForeColor = Color.Blue;
                    }
                }
            }

            foreach (DataGridViewColumn column in dataGridViewPica.Columns)
            {
                if (column.Visible)
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }

            dataGridViewPica.Columns[1].HeaderText = "Naziv pića";
            dataGridViewPica.Columns[2].HeaderText = "Cijena pića";
            dataGridViewPica.Columns[4].HeaderText = "Stanje šank";
        }

        /// <summary>
        /// Klikom na gumb 'Prikaži pića' prikazuje se ime, cijena i količina dostupnog
        /// na šanku. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonPrikaziPica_Click(object sender, EventArgs e)
        {
            List<Pice> pica = GetPicaFromDatabase("SELECT * FROM Pica");

            if (provjeraAkcije().Count > 0)
            {
                labelAkcijaUTijeku.Text = "U tijeku je akcija!";
            }
            prikaziPicaDataGridView("SELECT * FROM Pica");
        }

        /// <summary>
        /// Promjenom u text boxu za pretraživanje, šalje se upit na bazu
        /// i ažurira tablica pića.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxTrazi_TextChanged(object sender, EventArgs e)
        {
            //List<Pice> pica = GetPicaFromDatabase("SELECT * FROM Pica");
            string upit = "SELECT * FROM Pica";
            
            if (textBoxTrazi.Text.Length > 0)
            {
                //pica = GetPicaFromDatabase("SELECT * FROM Pica WHERE naziv_pica LIKE @unos");
                upit = "SELECT * FROM Pica WHERE naziv_pica LIKE @unos";
            }
            prikaziPicaDataGridView(upit);
        }

        /// <summary>
        /// Formatiranje cijene na dvije decimale.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Klikom na redak tablice pića, sprema se piće, dohvaća se količina pomoću
        /// UnosKolicineForm, te se piće zajedno sa količinom sprema u Dictionary 
        /// naručenih pića. Generira se tekst koji se prikazuje na računu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void dataGridViewPica_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (narucenaPica.Count == 0)
            {
                initializeBill();
                buttonKonobarskiPopust.Enabled = true;
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
                        //MessageBox.Show("Dodano na račun: " + info, "Obavijest");
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
                        //MessageBox.Show("Dodano na račun: " + piceInfo, "Obavijest");
                        textRacuna.AppendText(piceInfo + "\n\n");
                    }

                }
            }
        }

        /// <summary>
        /// Inicijalizacija računa. 
        /// </summary>
        private void initializeBill()
        {
            textRacuna.SelectionStart = 0;
            textRacuna.SelectionLength = 0;
            textRacuna.SelectionAlignment = HorizontalAlignment.Center;

            textRacuna.AppendText("\n");
            textRacuna.AppendText("Caffe-Bar CAFE \n\n");
            textRacuna.AppendText("Bijenička cesta 30\n");
            textRacuna.AppendText("10000 Zagreb\n");
            textRacuna.AppendText("--------------------------------------\n\n");
            textRacuna.SelectionAlignment = HorizontalAlignment.Left;
            textRacuna.AppendText($"{"Naziv",-20}{"Cijena",-10}{"Količina",-5}  {"Ukupno",-5}\n\n");
            textRacuna.Font = new Font(FontFamily.GenericMonospace, textRacuna.Font.Size);

            textRacuna.SelectionStart = textRacuna.Text.Length;
            textRacuna.ScrollToCaret();
        }

        /// <summary>
        /// Dohvaćanje unesene količine pomoću UnosKoličineForm, te
        /// provjer dostupnosti.
        /// </summary>
        /// <param name="label"> Label koji se prikazuje na UnosKolicineForm. </param>
        /// <param name="idPica"> Id odabranog pića za račun. </param>
        /// <returns></returns>
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
                    if (narucenaPica.Count == 0)
                    {
                        textRacuna.Clear();
                    }
                    return 0;
                }
            }
        }

        /// <summary>
        /// Kliknom na gumb 'Izdaj račun' poziva se forma IzdajRacun, šalju se potrebni podaci.
        /// Ako je rezultat forme OK zapisuje se račun u bazu, u tablice Racun, RacunStavke i 
        /// KonobarskiPopust ako ga je bilo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void gumbIzdajRacun_Click(object sender, EventArgs e)
        {
            if(narucenaPica.Count == 0)
            {
                MessageBox.Show("Odaberite pića", "Upozorenje!");
            }
            else
            {
                decimal total = izracunajTotal();
                DateTime vrijeme = DateTime.Now;
                IzdajRacun izdajRacun = new IzdajRacun(textRacuna.Rtf, id_ulogirani, ime_ulogirani, prezime_ulogirani, infoPopust, total, vrijeme);

                izdajRacun.updateFinalniRacun();
                izdajRacun.updateKonobarInfo();

                DialogResult result = izdajRacun.ShowDialog();


                if (result == DialogResult.OK)
                {
                    updateKolicinaPica(narucenaPica);
                    zapisRacunStavke(vrijeme);
                    if(konobarskiPopust.Count > 0)
                    {
                        zapisiKonobarPopust(popustUsername, konobarskiPopust, vrijeme);
                    }
                    AzurirajStanjeSanka();
                    PrikaziSveRacune();

                    MessageBox.Show("Račun uspješno evidentiran!", "Obavijest");
                    textRacuna.Clear();
                    narucenaPica.Clear();
                    konobarskiPopust.Clear();
                    Popust = false;
                    infoPopust = "";
                    //buttonKonobarskiPopust.Enabled = true;
                    prikaziPicaDataGridView("SELECT * FROM Pica");
                }
                else
                {
                    MessageBox.Show("Račun nije evidentiran!", "Obavijest");
                }
            }
        }

        /// <summary>
        /// Klikom na gumb 'Konobarski popust' otvara se forma PopustForm 
        /// koja omogućava konobaru korištenje popusta.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonKonobarskiPopust_Click(object sender, EventArgs e)
        {
            PopustForm popustForm = new PopustForm(narucenaPica);

            DialogResult result = popustForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                konobarskiPopust = popustForm.besplatnaPica;
                popustUsername = popustForm.UsernameKonobara;
                Popust = popustForm.Popust;
                if (popustForm.tekstPopusta != null)
                {
                    infoPopust += popustForm.tekstPopusta;
                    buttonKonobarskiPopust.Enabled = false;
                }
            }
        }

        /// <summary>
        /// Metoda koja računa ukupan iznos računa. Uzimaju se u obzir akcije i 
        /// konobarski popust.
        /// </summary>
        /// <returns></returns>
        private decimal izracunajTotal()
        {
            decimal total = 0;

            if (narucenaPica != null)
            {
                foreach (KeyValuePair<Pice, decimal> keyValuePair in narucenaPica)
                {
                    total += keyValuePair.Value * keyValuePair.Key.cijena_pica;
                }
            }
            if (konobarskiPopust != null)
            {
                foreach (KeyValuePair<Pice, int> keyValuePair in konobarskiPopust)
                {
                    total -= (keyValuePair.Key.cijena_pica * keyValuePair.Value);
                }
            }
            if (total == 0) return 0;
            if (provjeraAkcije().Count > 0)
            {
                Dictionary<int, decimal> akcije = provjeraAkcije();
                foreach(KeyValuePair<Pice, decimal> kupljenaPica in narucenaPica)
                {
                    foreach (var akcija in akcije)
                    {
                        if (akcija.Key ==  kupljenaPica.Key.id_pica) 
                        {
                            decimal iznos = akcija.Value / 100;
                            infoPopust += "Akcija " + akcija.Value + "% na " + kupljenaPica.Key.naziv_pica + "\n";
                            total -= kupljenaPica.Key.cijena_pica * iznos;
                        }
                    }
                }
            }
            if (Popust == true)
            {
                total -= total * popust;
            }
            return total;
        }

        /// <summary>
        /// Metoda koja ažurira količinu dostupnih pića na šanku nakon izdavanja računa.
        /// </summary>
        /// <param name="narucenaPica"> Dictionary liste prodanih pića zajedno s količinama. </param>
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

        /// <summary>
        /// Metoda koja zapisuje stavke računa u bazu u tablicu RacunStavke.
        /// </summary>
        /// <param name="vrijeme"></param>
        private void zapisRacunStavke(DateTime vrijeme)
        {
            int id_racuna = -1;

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

                if (id_racuna == -1)
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

        /// <summary>
        /// Metoda koja zapisuje korištenje konobarskog popusta u bazu u tablicu KonobarPopust.
        /// </summary>
        /// <param name="username"> Usernam konobara koji je koristio popust. </param>
        /// <param name="popust"> Dictionary pića i količina iskorištenog popusta. </param>
        /// <param name="vrijeme"> Vrijeme korištenja popusta. </param>
        private void zapisiKonobarPopust(string username, Dictionary<Pice, int> popust, DateTime vrijeme)
        {
            int id_osobe = -1;
            List<Pice> pica = popust.Keys.ToList();
            using (SqlConnection veza = new SqlConnection(connectionString))
            {
                veza.Open();

                string selectQuery = "SELECT id_osobe FROM Osobe WHERE korisnicko_ime = @username";
                SqlCommand selectCommand = new SqlCommand(selectQuery, veza);
                selectCommand.Parameters.AddWithValue("@username", username);

                using (SqlDataReader čitač = selectCommand.ExecuteReader())
                {
                    if (čitač.Read())
                    {
                        id_osobe = čitač.GetInt32(0);
                    }
                }

                if (id_osobe == -1)
                {
                    MessageBox.Show("Greška u dohvatu id_racuna", "Greška");
                }
                else
                {
                    foreach (KeyValuePair<Pice, int> pice in konobarskiPopust)
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            string insertQuery = "INSERT INTO KonobarPopust (id_konobara, id_pica, datum) " +
                                "VALUES (@id_racun, @id_pica, @datum)";
                            SqlCommand insertCommand = new SqlCommand(insertQuery, connection);

                            insertCommand.Parameters.AddWithValue("@id_racun", id_osobe);
                            insertCommand.Parameters.AddWithValue("@id_pica", pice.Key.id_pica);
                            insertCommand.Parameters.Add("@datum", SqlDbType.Date).Value = vrijeme;
                    
                            try
                            {
                                insertCommand.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Greška prilikom upisa u KonobarPopust: " + ex.Message, "Greška");
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Metoda koja dohvaća dostupnu količinu pića na šanku iz baze podataka, tablice
        /// pića.
        /// </summary>
        /// <param name="idPica"> Id pića za koje se dohvaća količina. </param>
        /// <returns></returns>
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

        /// <summary>
        /// Kliknom na gumb 'Očisti račun' briše se odabir naručenih pića, popusta, 
        /// te se brišu tekstovi računa i popusta.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOcistiRacun_Click(object sender, EventArgs e)
        {
            textRacuna.Clear();
            narucenaPica.Clear();
            konobarskiPopust.Clear();
            Popust = false;
            infoPopust = "";
            buttonKonobarskiPopust.Enabled = false;
        }

        /// <summary>
        /// Metoda koja provjerava ima li trenutačnih akcija u tijeku.
        /// </summary>
        /// <returns> Dictionary id pića i količina popusta na ta pića. </returns>
        private Dictionary<int, decimal> provjeraAkcije()
        {
            Dictionary<int, decimal> akcije = new Dictionary<int, decimal>();

            using (SqlConnection veza = new SqlConnection(connectionString))
            {
                veza.Open();
                string upit = "SELECT id_pica, popust FROM Akcija WHERE GETDATE() BETWEEN od AND do;";
                using (SqlCommand naredba = new SqlCommand(upit, veza))
                {
                    using (SqlDataReader čitač = naredba.ExecuteReader())
                    {
                        while (čitač.Read())
                        {
                            int idPice = čitač.GetInt32(0);
                            decimal popust = čitač.GetDecimal(1);

                            akcije.Add(idPice, popust);
                        }
                    }
                }
            }
            return akcije;
        }

        /// <summary>
        /// Klikom na odjavu korisniku se prikaze forma za obracun te nakon toga ga odjavljuje
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gumbOdjavaKonobara_Click(object sender, EventArgs e)
        {
            labelUsername.Text = "";
            ObracunForm forma = new ObracunForm(id_ulogirani);
            forma.Show();
            this.Hide();
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
            veza.Close();
        }

        /// <summary>
        /// Funkcija ucitava sva pica koja su trenutno u ponudi u combobox za premještanje iz skladišta u šank
        /// </summary>
        public void UcitajPicaUComboBoxSkladiste()
        {
            SqlConnection veza = new SqlConnection(connectionString);

            veza.Open();
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

        /// <summary>
        /// Klikom na gumb prikazuju se sve narudzbe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonNarudžba_Click(object sender, EventArgs e)
        {
            PrikaziSveNarudzbe();
        }

        /// <summary>
        /// Funkcija koja iz baze dohvaca podatke o svim narudzbama
        /// </summary>
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

        /// <summary>
        /// Funkcija ucitava sva pica koja su trenutno u ponudi u combobox narudzbe
        /// </summary>
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

        /// <summary>
        /// Klikom na gumb, ako su svi podaci dobro popunjeni, dodaje se nova narudzba u bazu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Klikom na redak u prikazu tablice nudi se opcija mijenjanja statusa iz nedostavljeno u dostavljno
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                    AzurirajStanjeSkladista();
                }
            }
        }

        /// <summary>
        /// Funckija koja u bazi mijenja status iz nedostavljeno u dostavljno
        /// </summary>
        /// <param name="idNarudzbe"></param>
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

        /// <summary>
        /// Klikom na gumb prikazuju se pica koja su na malim zalihama 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonNarudzbaZaliha_Click(object sender, EventArgs e)
        {
            PrikaziNiskeZalihe();
        }

        /// <summary>
        /// Funckija koja u bazi provjerava koja su to pica na malim zalihama
        /// </summary>
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
                            MessageBox.Show(ex.Message, "Greška prilikom brisanja računa!");
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