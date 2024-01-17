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
using System.Configuration;
using Caffe_Bar;

namespace CaffeBar
{
    public partial class VlasnikForm : Form
    {
        static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Helena\Desktop\moje\Caffe-Bar\Caffe-Bar\baza.mdf;Integrated Security=True";
        public string username_ulogirani;
        public VlasnikForm(string username_vlasnik)
        {
            InitializeComponent();

            username_ulogirani = username_vlasnik;
            
            //inicijalno popunjavanje dropdowna kod statistike sa svim picima u kaficu
            SqlConnection veza = new SqlConnection(connectionString);
            veza.Open();
            string upit = "SELECT * from Pica";
            SqlCommand naredba = new SqlCommand(upit, veza);
            List<string> lista_pica = new List<string>();
            using (SqlDataReader citac = naredba.ExecuteReader())
            {
                while (citac.Read())
                {
                    lista_pica.Add(citac.GetString(1));
                }
            }
            veza.Close();
            lista_pica.Sort((x, y) => x.CompareTo(y));
            foreach(string pica in lista_pica)
            {
                odabirPica.Items.Add(pica);
                comboBoxPicaModificiraj.Items.Add(pica);
            }
            UcitajPicaUComboBoxAkcija();
            UcitajKategorijeUComboBox();

        }
        public void ResetirajFormu(Control kontrola)
        {
            foreach (Control child in kontrola.Controls)
            {
                if (child is TextBox)
                {
                    ((TextBox)child).Text = String.Empty;
                }
                else if (child is ComboBox)
                {
                    ((ComboBox)child).SelectedIndex = -1;
                }
                else if (child is CheckBox)
                {
                    ((CheckBox)child).Checked = false;
                }
                // Ovdje možete dodati više uvjeta za druge vrste kontrola

                // Rekurzivno resetiranje za kontejnere koji sadrže druge kontrole
                if (child.HasChildren)
                {
                    ResetirajFormu(child);
                }
            }
        }

        private void btnSpremiKonobara_Click(object sender, EventArgs e)
        {
            foreach (Control kontrola in gBoxDodajKonobara.Controls)
            {
                if (kontrola is TextBox t && t.Text.Length == 0)
                {
                    MessageBox.Show("Nisu popunjena sva polja!");
                    return;
                }
            }

            using (SqlConnection veza = new SqlConnection(connectionString))
            {
                veza.Open();

                // Provjeravamo postoji li već konobar s istim korisničkim imenom
                string provjeraUpita = "SELECT COUNT(*) FROM Osobe WHERE korisnicko_ime = @korisnickoIme";
                SqlCommand provjeraNaredba = new SqlCommand(provjeraUpita, veza);
                provjeraNaredba.Parameters.AddWithValue("@korisnickoIme", txtKorisnickoIme.Text);

                int brojPostojecih = Convert.ToInt32(provjeraNaredba.ExecuteScalar());
                if (brojPostojecih > 0)
                {
                    MessageBox.Show("Konobar s istim korisničkim imenom već postoji.");
                    return;
                }

                // Umetanje novog konobara
                string upit = "INSERT INTO Osobe (ime, prezime, uloga, korisnicko_ime, lozinka) " +
                              "VALUES (@ime, @prezime, @uloga, @korisnicko_ime, @lozinka)";
                SqlCommand naredba = new SqlCommand(upit, veza);
                naredba.Parameters.AddWithValue("@ime", txtIme.Text);
                naredba.Parameters.AddWithValue("@prezime", txtPrezime.Text);
                naredba.Parameters.AddWithValue("@uloga", 1); // Uloga konobara
                naredba.Parameters.AddWithValue("@korisnicko_ime", txtKorisnickoIme.Text);
                naredba.Parameters.AddWithValue("@lozinka", txtLozinka.Text); // Trebalo bi hashirati lozinku

                try
                {
                    naredba.ExecuteNonQuery();
                    MessageBox.Show("Konobar uspješno zaposlen!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Došlo je do greške: " + ex.Message);
                }
            }

            ResetirajFormu(gBoxDodajKonobara);
        }


        private void btnPrikaziKonobare_Click(object sender, EventArgs e)
        {
            PrikaziKonobare();
        }

        private void PrikaziKonobare()
        {
            using (SqlConnection veza = new SqlConnection(connectionString))
            {
                veza.Open();

                string upit = "SELECT ime as 'Ime', prezime as 'Prezime', korisnicko_ime as 'Korisničko ime' FROM Osobe WHERE uloga = 1";
                SqlDataAdapter adapter = new SqlDataAdapter(upit, veza);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridViewKonobari.DataSource = dt;
            }
        }


        private void buttonPrikaziStatistiku_Click(object sender, EventArgs e)
        {
            //prvo provjerim jel odabrano pice, datum ne treba, on je po defaultu danasnji
            if(odabirPica.SelectedIndex  == -1)
            {
                MessageBox.Show("Nije odabrano nijedno piće!");
                return;
            }
            else
            {
                var odabrano_pice = odabirPica.SelectedItem.ToString();
                var datum = monthCalendar1.SelectionStart;
                SqlConnection veza = new SqlConnection(connectionString);

                veza.Open();

                string upit = "SELECT kolicina FROM RacunStavke "
                    + "JOIN Pica "
                    + "ON RacunStavke.id_pica = Pica.id_pica "
                    + "WHERE naziv_pica = '"
                    + odabrano_pice + "'"
                    + " AND CONVERT(date, vrijeme) = '"
                    + datum.ToString("yyyy-MM-dd") + "'";

                SqlCommand naredba = new SqlCommand(upit, veza);
                List<int> kolicine = new List<int>();
                using (SqlDataReader citac = naredba.ExecuteReader())
                {
                    while (citac.Read())
                    {
                        kolicine.Add(citac.GetInt32(0));
                    }
                }
                int zbroj = 0;
                foreach(int i in kolicine)
                {
                    zbroj += i;
                }
                labelPrikaziKolicinu.Text = "Količina : " + zbroj;



                veza.Close();
            }
        }

        private void buttonPrikaziStatistiku1_Click(object sender, EventArgs e)
        {
            SqlConnection veza = new SqlConnection(connectionString);

            veza.Open();
            var datum = monthCalendar2.SelectionStart;
            string upit = "SELECT naziv_pica AS 'Naziv pica', SUM(kolicina) AS 'Ukupna količina' FROM Pica " +
                "JOIN RacunStavke " +
                "ON RacunStavke.id_pica = Pica.id_pica " +
                "WHERE CONVERT(date, vrijeme) = '"
                + datum.ToString("yyyy-MM-dd") + "' " +
                "GROUP BY naziv_pica " +
                "ORDER BY SUM(kolicina) DESC";
            SqlDataAdapter adapter = new SqlDataAdapter(upit, veza);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            dataGridViewKolicinePica.DataSource = dt;

            veza.Close();
        }

        private void btnOtpusti_Click(object sender, EventArgs e)
        {
            foreach (Control kontrola in groupBoxOtpusti.Controls)
            {
                if (kontrola is TextBox t && t.Text.Length == 0)
                {
                    MessageBox.Show("Nisu popunjena sva polja!");
                    return;
                }
            }

            SqlConnection veza = new SqlConnection(connectionString);
            veza.Open();

            string upit = "UPDATE Osobe SET uloga = 3 WHERE korisnicko_ime = @korisnicko_ime";
            SqlCommand naredba = new SqlCommand(upit, veza);
            naredba.Parameters.AddWithValue("@korisnicko_ime", txtOtpustiKonobara.Text);

            try
            {
                if (ProvjeriPostojiLiKonobar(txtOtpustiKonobara.Text))
                {
                    naredba.ExecuteNonQuery();
                    MessageBox.Show("Konobar otpušten!");

                    // Osvježavanje prikaza konobara
                    PrikaziKonobare();
                }
                else
                {
                    MessageBox.Show("Konobar s tim korisničkim imenom ne postoji.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Došlo je do greške: " + ex.Message);
            }


            veza.Close();
            ResetirajFormu(this);
        }
        private bool ProvjeriPostojiLiKonobar(string korisnickoIme)
        {
            using (SqlConnection veza = new SqlConnection(connectionString))
            {
                veza.Open();
                string upit = "SELECT COUNT(*) FROM Osobe WHERE korisnicko_ime = @korisnickoIme";
                SqlCommand naredba = new SqlCommand(upit, veza);
                naredba.Parameters.AddWithValue("@korisnickoIme", korisnickoIme);

                int brojZapisa = Convert.ToInt32(naredba.ExecuteScalar());

                veza.Close();
                return brojZapisa > 0;
            }
        }

        private void btnUnosPica_Click(object sender, EventArgs e)
        {
            foreach (Control kontrola in groupBoxNovoPice.Controls)
            {
                if (kontrola is TextBox t && t.Text.Length == 0)
                {
                    MessageBox.Show("Nisu popunjena sva polja!");
                    return;
                }
            }

            if (comboBoxNovoPiceKategorija.SelectedItem is ComboboxItem odabranaKategorija)
            {
                string nazivPica = txtNazivPica.Text;

                if (ProvjeriPostojiLiNaziv(nazivPica))
                {
                    MessageBox.Show("Piće s ovim nazivom već postoji.");
                    return;
                }

                Pice pice = new Pice()
                {
                    naziv_pica = txtNazivPica.Text,
                    cijena_pica = Convert.ToDecimal(txtCijenaPica.Text),
                    id_kategorija_pica = (int)odabranaKategorija.Value,
                    kolicina_kafic = 0,
                    kolicina_skladista = 0,
                    najmanja_kolicina = txtUpozorenje.Text
                };

                SqlConnection veza = new SqlConnection(connectionString);
                veza.Open();
                string upit = "INSERT INTO "
                    + "Pica (naziv_pica, cijena_pica, id_kategorija_pica, kolicina_kafic, kolicina_skladista, najmanja_kolicina) "
                    + "VALUES (@naziv_pica, @cijena_pica, @id_kategorija_pica, @kolicina_kafic, @kolicina_skladista, @najmanja_kolicina)";
                SqlCommand naredba = new SqlCommand(upit, veza);
                naredba.Parameters.AddWithValue("@naziv_pica", pice.naziv_pica);
                naredba.Parameters.AddWithValue("@cijena_pica", pice.cijena_pica);
                naredba.Parameters.AddWithValue("@id_kategorija_pica", pice.id_kategorija_pica);
                naredba.Parameters.AddWithValue("@kolicina_kafic", pice.kolicina_kafic);
                naredba.Parameters.AddWithValue("@kolicina_skladista", pice.kolicina_skladista);
                naredba.Parameters.AddWithValue("@najmanja_kolicina", pice.najmanja_kolicina);

                try
                {
                    naredba.ExecuteNonQuery();
                    MessageBox.Show("Piće uspješno dodano!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Došlo je do greške: " + ex.Message);
                }
                veza.Close();
                ResetirajFormu(groupBoxNovoPice);
                UcitajPicaUComboBox();
                UcitajPicaUComboBoxAkcija();
            }
            else
            {
                MessageBox.Show("Niste odabrali kategoriju.");
            }

        }

        private void gumbOdjavaVlasnika_Click(object sender, EventArgs e)
        {
            PrijavaForm forma = new PrijavaForm();
            forma.Show();
            this.Hide();
        }


        private void PrikaziPicaModificiraj()
        {
            if (comboBoxPicaModificiraj.SelectedIndex == -1)
            {
                MessageBox.Show("Nije odabrano nijedno piće!");
                return;
            }

            using (SqlConnection veza = new SqlConnection(connectionString))
            {
                veza.Open();
                var odabranoPice = comboBoxPicaModificiraj.SelectedItem.ToString();

                // Parametrizirani SQL upit
                string upit = "SELECT naziv_pica as 'Naziv', " +
                              "CAST(cijena_pica AS DECIMAL(10, 2)) as 'Cijena', " +
                              "najmanja_kolicina as 'Najmanja količina' " +
                              "FROM Pica WHERE naziv_pica = @nazivPica";

                SqlCommand cmd = new SqlCommand(upit, veza);
                cmd.Parameters.AddWithValue("@nazivPica", odabranoPice);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridViewPicaModificiraj.DataSource = dt;
            }
        }

        private void btnPiceModificiraj_Click(object sender, EventArgs e)
        {
            PrikaziPicaModificiraj();
        }

        private void btnPromijeniCijenu_Click(object sender, EventArgs e)
        {
            if(txtPromijeniCijenu.Text.Length == 0)
            {
                MessageBox.Show("Niste unijeli novu cijenu.");
                return;
            }
            if (comboBoxPicaModificiraj.SelectedIndex == -1)
            {
                MessageBox.Show("Nije odabrano nijedno piće!");
                return;
            }

            SqlConnection veza = new SqlConnection(connectionString);
            veza.Open();
            var odabrano_pice = comboBoxPicaModificiraj.SelectedItem.ToString();
            var nova_cijena = Convert.ToDecimal(txtPromijeniCijenu.Text);

            string upit = "UPDATE Pica SET cijena_pica = '" + nova_cijena + "'"
                + "WHERE naziv_pica = '" + odabrano_pice + "'";

            SqlCommand naredba = new SqlCommand(upit, veza);
            if (naredba.ExecuteNonQuery() > 0) 
            {
                MessageBox.Show("Nova cijena unesena!");
            }
            else
                MessageBox.Show("Nije uspjelo!");
            veza.Close();
            ResetirajFormu(groupBoxModifikacija);
            dataGridViewPicaModificiraj.DataSource = null;
        }

        private void btnPromijeniNaziv_Click(object sender, EventArgs e)
        {
            if (txtPromijeniNaziv.Text.Length == 0)
            {
                MessageBox.Show("Niste unijeli novi naziv.");
                return;
            }
            if (comboBoxPicaModificiraj.SelectedIndex == -1)
            {
                MessageBox.Show("Nije odabrano nijedno piće!");
                return;
            }

            var odabranoPice = comboBoxPicaModificiraj.SelectedItem.ToString();
            var noviNaziv = txtPromijeniNaziv.Text;

            if (ProvjeriPostojiLiNaziv(noviNaziv))
            {
                MessageBox.Show("Piće s ovim nazivom već postoji.");
            }
            else
            {
                IzvrsiUpdatePica("naziv_pica", noviNaziv, odabranoPice);
                UcitajPicaUComboBox();
                UcitajPicaUComboBoxAkcija();
            }
        }

        private bool ProvjeriPostojiLiNaziv(string naziv)
        {
            using (SqlConnection veza = new SqlConnection(connectionString))
            {
                veza.Open();
                string upit = "SELECT COUNT(*) FROM Pica WHERE naziv_pica = @naziv";
                SqlCommand cmd = new SqlCommand(upit, veza);
                cmd.Parameters.AddWithValue("@naziv", naziv);
                int brojPostojecih = Convert.ToInt32(cmd.ExecuteScalar());
                return brojPostojecih > 0;
            }
        }


        private void btnPromijeniNajmanjuKolicinu_Click(object sender, EventArgs e)
        {
            if (txtPromijeniNajmanjuKolicinu.Text.Length == 0)
            {
                MessageBox.Show("Niste unijeli novu najmanju količinu.");
                return;
            }
            if (comboBoxPicaModificiraj.SelectedIndex == -1)
            {
                MessageBox.Show("Nije odabrano nijedno piće!");
                return;
            }

            var odabrano_pice = comboBoxPicaModificiraj.SelectedItem.ToString();
            var nova_kolicina = txtPromijeniNajmanjuKolicinu.Text;

            IzvrsiUpdatePica("najmanja_kolicina", nova_kolicina, odabrano_pice);
        }

        private void IzvrsiUpdatePica(string kolona, string novaVrijednost, string nazivPica)
        {
            using (SqlConnection veza = new SqlConnection(connectionString))
            {
                veza.Open();
                string upit = $"UPDATE Pica SET {kolona} = @novaVrijednost WHERE naziv_pica = @nazivPica";

                SqlCommand naredba = new SqlCommand(upit, veza);
                naredba.Parameters.AddWithValue("@novaVrijednost", novaVrijednost);
                naredba.Parameters.AddWithValue("@nazivPica", nazivPica);

                try
                {
                    if (naredba.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Uspješno promijenjeno!");
                    }
                    else
                    {
                        MessageBox.Show("Promjena nije uspjela.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Došlo je do greške: " + ex.Message);
                }

                ResetirajFormu(groupBoxModifikacija);
                dataGridViewPicaModificiraj.DataSource = null;
            }
        }

        private void UcitajPicaUComboBox()
        {
            comboBoxPicaModificiraj.Items.Clear();
            odabirPica.Items.Clear();

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
                        comboBoxPicaModificiraj.Items.Add(item);
                        odabirPica.Items.Add(item);
                    }
                }
            }
        }

        private void UcitajKategorijeUComboBox()
        {
            comboBoxNovoPiceKategorija.Items.Clear();

            using (SqlConnection veza = new SqlConnection(connectionString))
            {
                veza.Open();
                string upit = "SELECT id_kategorija_pica, naziv_kategorije FROM Kategorija";
                SqlCommand cmd = new SqlCommand(upit, veza);

                using (SqlDataReader citac = cmd.ExecuteReader())
                {
                    while (citac.Read())
                    {
                        ComboboxItem item = new ComboboxItem
                        {
                            Text = citac["naziv_kategorije"].ToString(),
                            Value = citac["id_kategorija_pica"]
                        };
                        comboBoxNovoPiceKategorija.Items.Add(item);
                    }
                }
            }
        }

        private void btnNovaKategorija_Click(object sender, EventArgs e)
        {
            foreach (Control kontrola in groupBoxNovaKategorija.Controls)
            {
                if (kontrola is TextBox t && t.Text.Length == 0)
                {
                    MessageBox.Show("Nisu popunjena sva polja!");
                    return;
                }
            }
            Kategorija kategorija = new Kategorija()
            {
                naziv_kategorije = txtNovaKategorija.Text
            };

            SqlConnection veza = new SqlConnection(connectionString);
            veza.Open();
            string upit = "INSERT INTO "
                + "Kategorija (naziv_kategorije) "
                + "VALUES (@naziv_kategorije)";
            SqlCommand naredba = new SqlCommand(upit, veza);
            naredba.Parameters.AddWithValue("@naziv_kategorije", kategorija.naziv_kategorije);

            try
            {
                naredba.ExecuteNonQuery();
                MessageBox.Show("Kategorija uspješno dodana!");
                ResetirajFormu(this);
                UcitajKategorijeUComboBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Došlo je do greške: " + ex.Message);
            }

            veza.Close();

        }

        private void buttonSveAkcije_Click(object sender, EventArgs e)
        {
            PrikaziSveAkcije();
        }

        private void PrikaziSveAkcije()
        {
            using (SqlConnection veza = new SqlConnection(connectionString))
            {
                veza.Open();

                string upit = "SELECT A.id_akcija AS 'id_akcija', P.naziv_pica AS 'Naziv pića', A.od AS 'Traje od', A.do AS 'Traje do', A.popust AS 'Popust (%)'" +
                              "FROM Akcija A " +
                              "JOIN Pica P ON A.id_pica = P.id_pica ";
                SqlDataAdapter adapter = new SqlDataAdapter(upit, veza);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridViewAkcija.DataSource = dt;

                if (dt.Columns.Contains("id_akcija"))
                {
                    dataGridViewAkcija.Columns["id_akcija"].Visible = false;
                }
            }
        }

        private void UcitajPicaUComboBoxAkcija()
        {
            comboBoxAkcija.Items.Clear();
            odabirPica.Items.Clear();

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
                        comboBoxAkcija.Items.Add(item);
                        odabirPica.Items.Add(item);
                    }
                }
            }
        }

        private void buttonAkcija_Click(object sender, EventArgs e)
        {
            if (comboBoxAkcija.SelectedItem == null)
            {
                MessageBox.Show("Odaberite piće za koje želite dodati akciju.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nazivPica = ((ComboboxItem)comboBoxAkcija.SelectedItem).Text;

            int idPica;

            int popust = (int)numericUpDownAkcija.Value;

            DateTime datumOd = dateTimePickerAkcijaOdDatum.Value.Date + dateTimePickerAkcijaOdVrijeme.Value.TimeOfDay;
            DateTime datumDo = dateTimePickerAkcijaDoDatum.Value.Date + dateTimePickerAkcijaDoVrijeme.Value.TimeOfDay;

            if (datumOd > datumDo)
            {
                MessageBox.Show("Datum početka akcije mora biti prije datuma završetka akcije.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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

                // Provjeri preklapanje s postojećim akcijama za odabrano piće
                string provjeraPreklapanja = "SELECT COUNT(*) FROM Akcija WHERE id_pica = @idPica " +
                                             "AND ((@datumOd BETWEEN od AND do) OR (@datumDo BETWEEN od AND do))";

                using (SqlCommand cmdProvjeriPreklapanje = new SqlCommand(provjeraPreklapanja, veza))
                {
                    cmdProvjeriPreklapanje.Parameters.AddWithValue("@idPica", idPica);
                    cmdProvjeriPreklapanje.Parameters.AddWithValue("@datumOd", datumOd);
                    cmdProvjeriPreklapanje.Parameters.AddWithValue("@datumDo", datumDo);

                    int brojPreklapanja = (int)cmdProvjeriPreklapanje.ExecuteScalar();

                    if (brojPreklapanja > 0)
                    {
                        MessageBox.Show("Već postoji akcija za odabrano piće koja se preklapa s odabranim vremenskim periodom.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // Dodaj akciju u bazu
                string dodajAkciju = "INSERT INTO Akcija (id_pica, od, do, popust) VALUES (@idPica, @datumOd, @datumDo, @popust)";

                using (SqlCommand cmdDodajAkciju = new SqlCommand(dodajAkciju, veza))
                {
                    cmdDodajAkciju.Parameters.AddWithValue("@idPica", idPica);
                    cmdDodajAkciju.Parameters.AddWithValue("@datumOd", datumOd);
                    cmdDodajAkciju.Parameters.AddWithValue("@datumDo", datumDo);
                    cmdDodajAkciju.Parameters.AddWithValue("@popust", popust); 

                    cmdDodajAkciju.ExecuteNonQuery();
                    MessageBox.Show("Akcija je uspješno dodana.", "Uspjeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            PrikaziSveAkcije();
        }

        private void dataGridViewAkcija_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DialogResult rezultat = MessageBox.Show("Jeste li sigurni da želite obrisati odabranu akciju?", "Potvrda brisanja", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (rezultat == DialogResult.Yes)
                {
                    int idAkcije = (int)dataGridViewAkcija.Rows[e.RowIndex].Cells["id_akcija"].Value;

                    ObrisiAkciju(idAkcije);

                    PrikaziSveAkcije();
                }
            }
        }

        private void ObrisiAkciju(int idAkcije)
        {
            using (SqlConnection veza = new SqlConnection(connectionString))
            {
                veza.Open();

                string upitBrisanje = "DELETE FROM Akcija WHERE id_akcija = @idAkcije";

                using (SqlCommand cmdBrisanje = new SqlCommand(upitBrisanje, veza))
                {
                    cmdBrisanje.Parameters.AddWithValue("@idAkcije", idAkcije);
                    cmdBrisanje.ExecuteNonQuery();
                }
            }
        }

    }
}
