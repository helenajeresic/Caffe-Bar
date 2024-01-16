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
        static string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\\\\wsl.localhost\\Ubuntu-18.04\\home\\doriblas\\Caffe-Bar\\Caffe-Bar\\Caffe-Bar\\baza.mdf;Integrated Security=True";
        public VlasnikForm()
        {
            InitializeComponent();
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
                ime = txtIme.Text,
                prezime = txtPrezime.Text,
                uloga = 1,
                korisnicko_ime = txtKorisnickoIme.Text,
                lozinka = txtLozinka.Text
            };
            SqlConnection veza = new SqlConnection(connectionString);
            veza.Open();

            string upit = "INSERT INTO "
                + "Osobe (ime, prezime, uloga, korisnicko_ime, lozinka) "
                + "VALUES (@ime, @prezime, @uloga, @korisnicko_ime, @lozinka)";
            SqlCommand naredba = new SqlCommand(upit, veza);
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

            string upit = "SELECT ime as 'Ime', prezime as 'Prezime', korisnicko_ime as 'Korisničko ime' FROM Osobe WHERE uloga = 1"; 
            SqlDataAdapter adapter = new SqlDataAdapter(upit, veza);
            DataTable dt  = new DataTable();
            adapter.Fill(dt);

            dataGridViewKonobari.DataSource = dt;

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

            string upit = "DELETE FROM Osobe WHERE korisnicko_ime = @korisnicko_ime";
            SqlCommand naredba = new SqlCommand(upit, veza);
            naredba.Parameters.AddWithValue("@korisnicko_ime", txtOtpustiKonobara.Text);

            //Treba dodati da izbaci grešku ako konobar s tim usernameom ne postoji
            try
            {
                naredba.ExecuteNonQuery();
                MessageBox.Show("Konobar otpušten!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Došlo je do greške: " + ex.Message);
            }


            veza.Close();

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

            Pice pice = new Pice()
            {
                naziv_pica = txtNazivPica.Text,
                cijena_pica = Convert.ToDecimal(txtCijenaPica.Text),
                id_kategorija_pica = int.Parse(txtKategorija.Text),
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


        }
    }
}
