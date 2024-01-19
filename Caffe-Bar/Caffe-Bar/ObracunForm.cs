using CaffeBar;
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

namespace CaffeBar
{
    public partial class ObracunForm : Form
    {
        public string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Elena\Desktop\Caffe-Bar-novo\Caffe-Bar\Caffe-Bar\baza.mdf;Integrated Security=True;MultipleActiveResultSets=True;";
        public int id_ulogirani;
        /// <summary>
        /// Konstruktor za ObracunForm prima parametar id_konobar koji mu sluzi za daljnji obracun prometa
        /// </summary>
        /// <param name="id_konobar"></param>
        public ObracunForm(int id_konobar)
        {
           InitializeComponent();
            id_ulogirani = id_konobar;
        }

        /// <summary>
        /// Klikom na gumb potvrde zavrssava se odjavljivanje konobara iz sustava
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOK_Click(object sender, EventArgs e)
        {
            PrijavaForm formaPrijava = new PrijavaForm();
            formaPrijava.Show();
            this.Hide();
        }

        /// <summary>
        /// Prilikom otvaranja forme obracuna popunjavaju se podaci u tablicama
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ObracunForm_Load(object sender, EventArgs e)
        {
            PopuniPodatke();
        }

        /// <summary>
        /// Funkcija koja popunjava podatke u tablicama iz baze
        /// </summary>
        private void PopuniPodatke()
        {
            using (SqlConnection veza = new SqlConnection(connectionString))
            {
                veza.Open();

                string upitRacuni = "SELECT R.id_racun AS 'id_racun', " +
                                            "K.korisnicko_ime AS 'Izdao konobar', " +
                                            "R.datum_vrijeme AS 'Datum i vrijeme'," +
                                            "R.iznos AS 'Iznos računa'" +
                                            "FROM Racun R " +
                                            "JOIN Osobe K ON R.id_konobar = K.id_osobe " +
                                            "WHERE id_konobar = @idKonobara AND CONVERT(date, datum_vrijeme) = CONVERT(date, GETDATE())";
                SqlDataAdapter adapterRacuni = new SqlDataAdapter(upitRacuni, veza);
                adapterRacuni.SelectCommand.Parameters.AddWithValue("@idKonobara", id_ulogirani);

                DataTable dtRacuni = new DataTable();
                adapterRacuni.Fill(dtRacuni);

                dtRacuni.Columns["Iznos računa"].DataType = typeof(decimal);
                foreach (DataRow row in dtRacuni.Rows)
                {
                    if (!row.IsNull("Iznos računa"))
                    {
                        row["Iznos računa"] = ((decimal)row["Iznos računa"]).ToString("N2");
                    }
                }

                dataGridViewUkupniRacuni.DataSource = dtRacuni;

                if (dtRacuni.Columns.Contains("id_racun"))
                {
                    dataGridViewUkupniRacuni.Columns["id_racun"].Visible = false;
                }

                decimal ukupnaZarada = 0;
                foreach (DataRow row in dtRacuni.Rows)
                {
                    ukupnaZarada += Convert.ToDecimal(row["Iznos računa"]);
                }

                labelUkupnaZaradaIznos.Text = ukupnaZarada.ToString("F2") + " EUR";
            }

            using (SqlConnection veza = new SqlConnection(connectionString))
            {
                veza.Open();

                string upitPromet = "SELECT P.naziv_pica AS 'Naziv pića', SUM(RS.kolicina) AS 'Ukupna količina' " +
                                    "FROM RacunStavke RS " +
                                    "JOIN Pica P ON RS.id_pica = P.id_pica " +
                                    "JOIN Racun R ON RS.id_racun = R.id_racun " +
                                    "WHERE R.id_konobar = @idKonobara AND CONVERT(date, R.datum_vrijeme) = CONVERT(date, GETDATE()) " +
                                    "GROUP BY P.naziv_pica";

                SqlDataAdapter adapterPromet = new SqlDataAdapter(upitPromet, veza);
                adapterPromet.SelectCommand.Parameters.AddWithValue("@idKonobara", id_ulogirani);

                DataTable dtPromet = new DataTable();
                adapterPromet.Fill(dtPromet);

                dataGridViewUkupniPromet.DataSource = dtPromet;
            }
        }
    }
}
