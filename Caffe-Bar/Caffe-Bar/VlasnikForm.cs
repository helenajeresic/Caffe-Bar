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
    }
}
