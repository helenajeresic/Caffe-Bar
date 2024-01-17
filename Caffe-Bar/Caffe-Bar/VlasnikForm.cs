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
        static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=\\wsl.localhost\Ubuntu-18.04\home\doriblas\Caffe-Bar\Caffe-Bar\Caffe-Bar\baza.mdf;Integrated Security=True";
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

            var odabrano_pice = comboBoxPicaModificiraj.SelectedItem.ToString();
            var novi_naziv = txtPromijeniNaziv.Text;

            IzvrsiUpdatePica("naziv_pica", novi_naziv, odabrano_pice);
            UcitajPicaUComboBox();
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

        private void groupBoxModifikacija_Enter(object sender, EventArgs e)
        {

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
    }
}
