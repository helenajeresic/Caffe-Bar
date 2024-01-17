using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CaffeBar
{
    public partial class IzdajRacun : Form
    {
        public string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\baza.mdf;Integrated Security=True";
        private decimal Total { get; set; }
        public DateTime VrijemeRacuna { get; private set; }
        
        public int Id_konobar { get; private set; }

        public IzdajRacun()
        {
            InitializeComponent();
        }

        public void updateFinalniRacun(string text)
        {
            finalniRacun.Clear();
            finalniRacun.Rtf = text;
            finalniRacun.SelectionAlignment = HorizontalAlignment.Right;
            finalniRacun.AppendText("\n\n");
            finalniRacun.AppendText("-------------------------------------\n\n");
            finalniRacun.AppendText("Ukupna cijena: " + Total.ToString() + "\n\n");
            finalniRacun.AppendText("--------------------------------------\n\n");
            finalniRacun.AppendText(VrijemeRacuna + "\n\n");
            finalniRacun.AppendText("Wifi password: caffebar123\n\n");
        }

        public void updateKonobarInfo(int id_konobara, string ime, string prezime)
        {
            Id_konobar = id_konobara;
            string racunPotpis = "Konobar: " + ime + " " + prezime + "\n\n";
            finalniRacun.AppendText(racunPotpis);
            finalniRacun.AppendText("--------------------------------------\n\n");
        }


        public decimal calculateTotal(Dictionary<Pice, decimal> narucenaPica)
        {
            decimal total = 0;
            foreach (KeyValuePair<Pice, decimal> pica in narucenaPica)
            {
                Pice pice = pica.Key;
                decimal quantity = pica.Value;

                total += pice.cijena_pica * quantity;
            }
            Total = Math.Round(total,2);
            VrijemeRacuna = DateTime.Now;
            finalniRacun.AppendText("Ukupna cijena " + Total.ToString());
            return total;
        }

        private void buttonIzracunajOstatak_Click(object sender, EventArgs e)
        {
            if (textDaniIznos == null)
            {
                MessageBox.Show("Unesite danu količinu!", "Upozorenje");
            }
            else
            {
                decimal danIznos = decimal.TryParse(textDaniIznos.Text, out decimal result) ? result : 0;
                decimal ostatak = danIznos - Total;
                if (ostatak > 0)
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

        private void gumbIzdajRacun_Click(object sender, EventArgs e)
        {
            SqlConnection veza = new SqlConnection(connectionString);
            veza.Open();

            string upit = "INSERT INTO "
                + "Racun (id_konobar, iznos, datum_vrijeme) "
                + "VALUES (@id_konobar, @iznos, @datum_vrijeme)";
            SqlCommand naredba = new SqlCommand(upit, veza);
            naredba.Parameters.AddWithValue("@id_konobar", Id_konobar);
            naredba.Parameters.AddWithValue("@iznos", Total);
            naredba.Parameters.AddWithValue("@datum_vrijeme", VrijemeRacuna);

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
