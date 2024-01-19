using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CaffeBar
{
    public partial class PrijavaForm : Form
    {
        public string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ivana\Desktop\RP\Caffe-Bar\Caffe-Bar\Caffe-Bar\baza.mdf;Integrated Security=True;MultipleActiveResultSets=True;";
        /// <summary>
        /// Konstruktor za PrijavaForm
        /// </summary>
        public PrijavaForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Klikom na gumb Odustani, odustajemo od prijave u sustav i zatvara se prozor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gumbOdustani_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Klikom na gumb prijave u bazi provjeravamo je li prijava dopustena 
        /// i ovisno o ulozi biramo koju formu prikazujemo sljedece
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gumbPrijava_Click(object sender, EventArgs e)
        {
            String korisnicko_ime, lozinka;

            korisnicko_ime = textBoxIme.Text;
            lozinka = textBoxLozinka.Text;

            SqlConnection veza = new SqlConnection(connectionString);
            veza.Open();

            try
            {
                String upit = "SELECT * FROM Osobe WHERE korisnicko_ime = '" + korisnicko_ime + "' AND lozinka = '" + lozinka + "'";
                SqlDataAdapter sda = new SqlDataAdapter(upit,veza);

                DataTable tablica = new DataTable(); 
                sda.Fill(tablica);

                if (tablica.Rows.Count > 0)
                {
                    int uloga = Convert.ToInt32(tablica.Rows[0]["uloga"]);

                    if (uloga == 1)
                    {
                        KonobarForm forma = new KonobarForm(
                                            Convert.ToInt32(tablica.Rows[0]["id_osobe"]),
                                            tablica.Rows[0]["ime"].ToString(),
                                            tablica.Rows[0]["prezime"].ToString(),
                                            tablica.Rows[0]["korisnicko_ime"].ToString()
                                        );
                        forma.Show();
                        this.Hide();
                    }
                    else if (uloga == 2)
                    {
                        VlasnikForm forma = new VlasnikForm(tablica.Rows[0]["korisnicko_ime"].ToString());
                        forma.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Nepoznata uloga", "Greška!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Neispravni podaci", "Greška!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxIme.Clear();
                    textBoxLozinka.Clear();

                    textBoxIme.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Greška!");
            }
            finally
            {
                veza.Close();
            }
        }

        /// <summary>
        /// Klikom na enter mozemo iz textboxa za ime preci u textbox za lozinku
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxIme_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                textBoxLozinka.Focus(); 
            }
        }

        /// <summary>
        /// Klikom na enter mozemo iz textboxa se ulogirati bez pritska na gumb za prijavu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxLozinka_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            { 
                gumbPrijava_Click(sender, e);
            }
        }
    }
}
