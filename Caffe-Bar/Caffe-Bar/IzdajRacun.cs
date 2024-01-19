using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CaffeBar
{
    public partial class IzdajRacun : Form
    {
        public string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Elena\Desktop\Caffe-Bar-novo\Caffe-Bar\Caffe-Bar\baza.mdf;Integrated Security=True;MultipleActiveResultSets=True;";
       
        private string tekstRacuna;
        private int id_konobar;
        private string ime_konobar;
        private string prezime_konobar;
        private string infoPopust;
        private decimal total;
        private DateTime vrijeme;

        /// <summary>
        /// Konstruktor za IzdajRacunForm.
        /// </summary>
        /// <param name="tekstRacuna"></param>
        /// <param name="id_konobar"> Id prijavljenog konobara.</param>
        /// <param name="ime_konobar"> Ime prijavljenog konobara. </param>
        /// <param name="prezime_konobar"> Prezime prijavljenog konobara. </param>
        /// <param name="infoPopust"> Podaci o popustu koji se dodaju na kraj računa. </param>
        /// <param name="total"> Ukupan iznos računa. </param>
        /// <param name="vrijeme"> Vrijeme izdavanja računa. </param>
        public IzdajRacun(string tekstRacuna, int id_konobar, string ime_konobar, string prezime_konobar, string infoPopust, decimal total, DateTime vrijeme)
        {
            this.tekstRacuna = tekstRacuna;
            this.id_konobar = id_konobar;
            this.ime_konobar = ime_konobar;
            this.prezime_konobar = prezime_konobar;
            this.infoPopust = infoPopust;
            this.total = Math.Round(total, 2);
            this.vrijeme = vrijeme;
            InitializeComponent();
        }

        /// <summary>
        /// Metoda koja na tekst finalnog računa dodaje podatke 
        /// o cijeni, vremenu i wifi lozinci.
        /// </summary>
        public void updateFinalniRacun()
        {
            finalniRacun.Clear();
            finalniRacun.Rtf = tekstRacuna;
            finalniRacun.SelectionAlignment = HorizontalAlignment.Right;
            finalniRacun.AppendText("\n\n");
            finalniRacun.AppendText("-------------------------------------\n\n");
            finalniRacun.AppendText("Ukupna cijena: " + total.ToString() + " €\n\n");
            finalniRacun.AppendText("--------------------------------------\n\n");
            finalniRacun.AppendText(vrijeme + "\n\n");
            finalniRacun.AppendText("Wifi password: caffebar123\n\n");
        }

        /// <summary>
        /// Metoda koja na kraj finalnog računa dodaje tekst o iskorištenim popustima
        /// i podatke o konobaru koji je izdao račun.
        /// </summary>
        public void updateKonobarInfo()
        {
            finalniRacun.AppendText("--------------------------------------\n\n");
            finalniRacun.AppendText(infoPopust);
            string racunPotpis = "Konobar: " + ime_konobar + " " + prezime_konobar + "\n\n";
            finalniRacun.AppendText(racunPotpis);
            finalniRacun.AppendText("--------------------------------------\n\n");
        }

        /// <summary>
        /// Metoda koja klikom na gumb 'Izračunaj ostatak' računa koliko treba konobar vratiti
        /// klijentu, te ažurira label s dobivenim iznosom. 
        /// Dobiveni iznos od klijenta, konobar unosi u tekstualni box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonIzracunajOstatak_Click(object sender, EventArgs e)
        {
            if (textDaniIznos == null)
            {
                MessageBox.Show("Unesite danu količinu!", "Upozorenje");
            }
            else
            {
                decimal danIznos = decimal.TryParse(textDaniIznos.Text, out decimal result) ? result : 0;
                decimal ostatak = danIznos - total;
                if (ostatak >= 0)
                {
                    labelVratitiIznos.Text = ostatak.ToString() + " €";
                }
                else
                {
                    MessageBox.Show("Unesen iznos manji od ukupne cijene računa!", "Greška!");
                    textDaniIznos.Clear();
                    labelVratitiIznos.Text = " ";
                }
                
            }
        }

        /// <summary>
        /// Klikom na gumb 'Izdaj račun' se u bazu podataka dodaje zapis o računu, id konobara
        /// kojiga je izdao, ukupan iznos računa i vrijeme izdavanja računa.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gumbIzdajRacun_Click(object sender, EventArgs e)
        {
            SqlConnection veza = new SqlConnection(connectionString);
            veza.Open();

            string upit = "INSERT INTO "
                + "Racun (id_konobar, iznos, datum_vrijeme) "
                + "VALUES (@id_konobar, @iznos, @datum_vrijeme)";
            SqlCommand naredba = new SqlCommand(upit, veza);
            naredba.Parameters.AddWithValue("@id_konobar", id_konobar);
            naredba.Parameters.AddWithValue("@iznos", total);
            naredba.Parameters.AddWithValue("@datum_vrijeme", vrijeme);

            try
            {
                int brojDodanih = naredba.ExecuteNonQuery();
                if(brojDodanih > 0)
                {
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Nije dodan nijedan red.","Greška");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Došlo je do greške: " + ex.Message);
            }
            veza.Close();
        }
            
    }
}