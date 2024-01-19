using System;
using System.Collections.Generic;
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

        /// <summary>
        /// Konstruktor za PopustForm. Inicijalizacija svih objekata.
        /// Popunjava se dropdown sa korisničkim imenima konobara.
        /// </summary>
        /// <param name="narucenaPica"> Lista naručenih pića iz KonobarForm. </param>
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

        /// <summary>
        /// Metoda koja dohvaća piće iz baze s danim upitom.
        /// </summary>
        /// <param name="upit"> Upit na bazu prema kojem se dohvaća piće. </param>
        /// <returns></returns>
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

        /// <summary>
        /// Metoda koja dohvaća id kave prema nazivu.
        /// </summary>
        /// <returns></returns>
        private Pice dohvatiPiceKava()
        {
            string upit = "SELECT * FROM Pica WHERE naziv_pica = @nazivKava";
            Pice kava = dohvatiPiceIzBaze(upit);
            kava.naziv_pica = "Kava s mlijekom";
            return kava;
        }

        /// <summary>
        /// Metoda koja dohvaća piće cijedjeni dok prema nazivu.
        /// </summary>
        /// <returns></returns>
        private Pice dohvatiPiceCijedeniSok()
        {
            string upit = "SELECT * FROM Pica WHERE naziv_pica = @nazivSok";
            Pice sok = dohvatiPiceIzBaze(upit);
            sok.naziv_pica = "Cijedeni sok";
            return sok;
        }

        /// <summary>
        /// Metoda koja provjerava ima li konobar s danim korisničkim imenom 
        /// pravo na popust, odnosno besplatna pića.
        /// Konkretno, konobar ima pravo na dvije kave i jedan cijedeni sok dnevno,
        /// te popust od 20% na iznos cijelog računa.
        /// </summary>
        /// <param name="usernameKonobara"> Korisničko ime odabranog konobara. </param>
        /// <param name="pice"> Piće za koje se provjerava popust. </param>
        /// <returns></returns>
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

        /// <summary>
        /// Metoda koja vraća id konobara za dano korisničko ime.
        /// </summary>
        /// <param name="usernameKonobara"> Korisničko ime konobara. </param>
        /// <returns></returns>
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

        /// <summary>
        /// Na promjenu odabira konobara, provjerava se pravo na besplatna pića, te
        /// se ovisno o tome onemogućuju checkboxevi.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Klikom na gumb 'Iskoristi popust' se spremaju odabrana pića u listu.
        /// Dodaje se tekst u label iskorištenih popusta i u info o popustima.
        /// Onemogućuju se potrebni checkboxevi.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonIskoristiPopust_Click(object sender, System.EventArgs e)
        {
            if(checkBoxIskoristiBespalatanSok.Checked == true)
            {
                besplatnaPica.Add(dohvatiPiceCijedeniSok(), 1);
                tekstPopusta += "Iskorišten popust: Besplatni sok\n\n";
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

        /// <summary>
        /// Klikom na gumb 'Odustani' prazni se lista besplatnih pića i popust postavlja 
        /// na false, te se zatvara forma.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gumbOdustaniPopust_Click(object sender, System.EventArgs e)
        {
            if(besplatnaPica != null)
            {
                besplatnaPica.Clear();
            }
            Popust = false;
            Close();
        }

        /// <summary>
        /// Klikom na gumb 'Potvrdi' potvrđuje se odabir, te je rezultat forme OK.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gumbPopustIzdajRacun_Click(object sender, System.EventArgs e)
        {
            if(besplatnaPica.Count == 0 && Popust == false) 
            {
                MessageBox.Show("Odaberite piće ili popust i kliknite primijeni.", "Obavijest");
            }
            else
            {
                DialogResult = DialogResult.OK;
            }
        }
    }
}
