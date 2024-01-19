using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CaffeBar
{
    public partial class PopustForm : Form
    {
        public string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ivana\Desktop\RP\Caffe-Bar\Caffe-Bar\Caffe-Bar\baza.mdf;Integrated Security=True";

        private Dictionary<Pice, decimal> narucenaPica;
        public Dictionary<Pice, int> besplatnaPica {  get; set; }
        public string tekstPopusta { get; private set; }
        public bool Popust {  get; private set; }
        public int Id_konobara { get; private set; }
        public string UsernameKonobara { get; private set; }

        private SqlCommand naredba;

        public PopustForm(Dictionary<Pice, decimal> narucenaPica)
        {
            InitializeComponent();
            this.narucenaPica = narucenaPica;
            Popust = false;
            tekstPopusta = "";
            besplatnaPica = new Dictionary<Pice, int>();

            checkBoxIskoristiBespalatanSok.Enabled = false;
            checkBoxIskoristiBesplatnuKavu.Enabled = false;
            checkBoxIskoristiPopust.Enabled = false;

            SqlConnection veza = new SqlConnection(connectionString);
            veza.Open();
            string upit = "SELECT * FROM Osobe WHERE uloga = 1";
            SqlCommand naredba = new SqlCommand(upit, veza);
            List<string> listaKonobara = new List<string>();
            using (SqlDataReader citac = naredba.ExecuteReader())
            {
                while (citac.Read())
                {
                    listaKonobara.Add(citac.GetString(4));
                }
            }
            veza.Close();
            listaKonobara.Sort((x, y) => x.CompareTo(y));
            foreach (string konobar in listaKonobara)
            {
                odabirKonobara.Items.Add(konobar);
            }
        }

        private Pice dohvatiPiceIzBaze(string upit)
        {
            Pice dohvat = new Pice();
            SqlConnection veza = new SqlConnection(connectionString);
            veza.Open();
            naredba = new SqlCommand(upit, veza);
            naredba.Parameters.AddWithValue("@nazivKava", "Kava s mlijekom");
            naredba.Parameters.AddWithValue("@nazivSok", "Cijedeni sok");

            using (SqlDataReader čitač = naredba.ExecuteReader())
            {
                while (čitač.Read())
                {

                    dohvat.id_pica = čitač.GetInt32(0);
                    dohvat.cijena_pica = čitač.GetDecimal(2);
                    dohvat.id_kategorija_pica = čitač.GetInt32(3);
                    dohvat.kolicina_kafic = čitač.GetDecimal(4);
                    dohvat.kolicina_skladista = čitač.GetDecimal(5);
                    dohvat.najmanja_kolicina = čitač.GetString(6);
                }
            }
            veza.Close();
            if (dohvat.id_pica >= 0)
            {
                //MessageBox.Show("Dohvacen id.", "Obavijest");
                return dohvat;
            }
            else
            {
                MessageBox.Show("Greška u dohvatu ida.", "Obavijest");
            }
            return dohvat;
        }

        private Pice dohvatiPiceKava()
        {
            string upit = "SELECT * FROM Pica WHERE naziv_pica = @nazivKava";
            Pice kava = dohvatiPiceIzBaze(upit);
            kava.naziv_pica = "Kava s mlijekom";
            return kava;
        }

        private Pice dohvatiPiceCijedeniSok()
        {
            string upit = "SELECT * FROM Pica WHERE naziv_pica = @nazivSok";
            Pice sok = dohvatiPiceIzBaze(upit);
            sok.naziv_pica = "Cijedeni sok";
            return sok;
        }

        private int provjeraDostupnihPopusta(string usernameKonobara, Pice pice)
        {
            List<int> kolicina = new List<int>();
            DateTime datum = DateTime.Now.Date;
            int id_konobara = dohvatiKonobaraPoUsername(usernameKonobara);
            SqlConnection veza = new SqlConnection(connectionString);

            veza.Open();
            string upit = "SELECT * FROM KonobarPopust WHERE id_konobara = @idKonobara "
                + "AND FORMAT(datum, 'dd-MM-yyyy') = @datum AND id_pica = @idPica";

            SqlCommand naredba = new SqlCommand(upit, veza);
            naredba.Parameters.AddWithValue("@idKonobara", id_konobara);
            naredba.Parameters.AddWithValue("@datum", datum.ToString("dd-MM-yyyy"));
            naredba.Parameters.AddWithValue("@idPica", pice.id_pica);
            using (SqlDataReader citac = naredba.ExecuteReader())
            {
                while (citac.Read())
                {
                    kolicina.Add(citac.GetInt32(0));
                }
            }
            veza.Close();
            if (kolicina.Count == 1 && dohvatiPiceKava().id_pica == pice.id_pica)
                return 1;
            else if (kolicina.Count == 0 && dohvatiPiceKava().id_pica == pice.id_pica)
                return 2;
            else if (kolicina.Count == 0 && dohvatiPiceCijedeniSok().id_pica == pice.id_pica)
                return 1;
            else
                return 0;
        }

        private int dohvatiKonobaraPoUsername(string usernameKonobara)
        {
            int id_konobara = -1;

            using (SqlConnection veza = new SqlConnection(connectionString))
            {
                veza.Open();
                string upit = "SELECT id_osobe FROM Osobe WHERE korisnicko_ime = @korisnicko_ime";

                using (SqlCommand naredba = new SqlCommand(upit, veza))
                {
                    naredba.Parameters.AddWithValue("@korisnicko_ime", usernameKonobara);

                    using (SqlDataReader citac = naredba.ExecuteReader())
                    {
                        if (citac.Read())
                        {
                            id_konobara = citac.GetInt32(0);
                        }
                    }
                }
            }
            return id_konobara;
        }

        private void odabirKonobara_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (odabirKonobara.SelectedIndex == -1)
            {
                MessageBox.Show("Nije odabran nijedan konobar!");
                return;
            }
            else
            {
                string odabraniKonobar = odabirKonobara.SelectedItem.ToString();
                UsernameKonobara = odabirKonobara.SelectedItem.ToString();
                Pice kava = dohvatiPiceKava();
                Pice sok = dohvatiPiceCijedeniSok();

                int rezultatKava = provjeraDostupnihPopusta(odabraniKonobar, kava);
                int rezultatSok = provjeraDostupnihPopusta(odabraniKonobar, sok);

                //MessageBox.Show($" {odabraniKonobar} Result for Kava: {rezultatKava}, Result for Sok: {rezultatSok}");
                if (rezultatKava > 0 && narucenaPica.ContainsKey(kava))
                {
                    checkBoxIskoristiBesplatnuKavu.Enabled = true;
                } 
                if(rezultatSok > 0 && narucenaPica.ContainsKey(sok))
                {
                    checkBoxIskoristiBespalatanSok.Enabled = true;
                }
                checkBoxIskoristiPopust.Enabled = true;
            }
        }

        private void buttonIskoristiPopust_Click(object sender, System.EventArgs e)
        {
            if(checkBoxIskoristiBespalatanSok.Checked == true)
            {
                besplatnaPica.Add(dohvatiPiceCijedeniSok(), 1);
                tekstPopusta += "Iskorišten popust: Besplatni sok\n";
                labelStanjeNakonAkcije.Text += "Iskorišten popust: Besplatni sok\n";
                checkBoxIskoristiBespalatanSok.Enabled = false;
            }
            if (checkBoxIskoristiBesplatnuKavu.Checked == true)
            {
                Pice kava = dohvatiPiceKava();
                if (!besplatnaPica.ContainsKey(kava))
                {
                    besplatnaPica.Add(kava, 1);
                    tekstPopusta += "Iskorišten popust: Besplatna kava\n";
                    labelStanjeNakonAkcije.Text += "Iskorišten popust: Besplatna kava\n";
                    checkBoxIskoristiBesplatnuKavu.Checked = false;
                    checkBoxIskoristiBesplatnuKavu.Enabled = false;
                }
                else
                {
                    besplatnaPica[kava] += 1;
                    tekstPopusta += "Iskorišten popust: Besplatna kava\n";
                    labelStanjeNakonAkcije.Text += "Iskorišten popust: Besplatna kava\n";
                    checkBoxIskoristiBesplatnuKavu.Enabled = false;
                }
            }
            
            if(checkBoxIskoristiPopust.Checked == true)
            {
                Popust = true;
                tekstPopusta += "Iskorišten popust: 20%\n";
                labelStanjeNakonAkcije.Text += "Iskorišten popust: 20%\n";
                checkBoxIskoristiPopust.Enabled = false;
            }
            odabirKonobara.Enabled = false;
        }

        private void gumbOdustaniPopust_Click(object sender, System.EventArgs e)
        {
            if(besplatnaPica != null)
            {
                besplatnaPica.Clear();
            }
            Popust = false;
            Close();
        }

        private void gumbPopustIzdajRacun_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
