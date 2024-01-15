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

namespace CaffeBar
{
    public partial class VlasnikForm : Form
    {
        static int id_konobara = 6;
        static string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Elena\\Desktop\\Caffe-Bar\\Caffe-Bar\\Caffe-Bar\\baza.mdf;Integrated Security=True";
        public VlasnikForm()
        {
            InitializeComponent();

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
            Osoba konobar = new Osoba()
            { 
                id_osobe = 10,
                ime = txtIme.Text,
                prezime = txtPrezime.Text,
                uloga = 1,
                korisnicko_ime = txtKorisnickoIme.Text,
                lozinka = txtLozinka.Text
            };
            SqlConnection veza = new SqlConnection(connectionString);
            veza.Open();

            string upit = "INSERT INTO "
                + "Osobe (id_osobe, ime, prezime, uloga, korisnicko_ime, lozinka) "
                + "VALUES (@id_osobe, @ime, @prezime, @uloga, @korisnicko_ime, @lozinka)";
            SqlCommand naredba = new SqlCommand(upit, veza);
            naredba.Parameters.AddWithValue("@id_osobe", konobar.id_osobe);
            naredba.Parameters.AddWithValue("@ime", konobar.ime);
            naredba.Parameters.AddWithValue("@prezime", konobar.prezime);
            naredba.Parameters.AddWithValue("@uloga", konobar.uloga);
            naredba.Parameters.AddWithValue("@korisnicko_ime", konobar.korisnicko_ime);
            naredba.Parameters.AddWithValue("@lozinka", konobar.lozinka);

            try
            {
                naredba.ExecuteNonQuery();
                MessageBox.Show("Konobar uspješno zaposlen!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Došlo je do greške: " + ex.Message);
            }

            veza.Close();
        }

        private void btnPrikaziKonobare_Click(object sender, EventArgs e)
        {
            SqlConnection veza = new SqlConnection(connectionString);

            veza.Open();

            string upit = "SELECT ime, prezime, korisnicko_ime FROM Osobe WHERE uloga = 1"; 
            SqlDataAdapter adapter = new SqlDataAdapter(upit, veza);
            DataTable dt  = new DataTable();
            adapter.Fill(dt);

            dataGridViewKonobari.DataSource = dt;

            veza.Close();
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
    }
}
