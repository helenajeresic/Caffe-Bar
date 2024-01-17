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
        private SqlCommand naredba;

        public PopustForm(Dictionary<Pice, decimal> narucenaPica)
        {
            InitializeComponent();
            naredba = new SqlCommand();
            this.narucenaPica = narucenaPica;
            List<string> lista = dohvatiKonobare();
        }

        private List<string> dohvatiKonobare()
        {
            SqlConnection veza = new SqlConnection(connectionString);
            veza.Open();
            string upit = "SELECT * FROM Osobe WHERE uloga = 1";
            SqlCommand naredba = new SqlCommand(upit, veza);
            List<string> listaKonobara = new List<string>();
            using (SqlDataReader citac = naredba.ExecuteReader())
            {
                while (citac.Read())
                {
                    listaKonobara.Add(citac.GetString(1) + " " + citac.GetString(2));
                }
            }
            veza.Close();
            listaKonobara.Sort((x, y) => x.CompareTo(y));
            foreach (string pica in listaKonobara)
            {
                odabirKonobara.Items.Add(pica);
            }
            return listaKonobara;
        }

        private int dohvatiIdIzBaze(string upit)
        {
            int id = -1;
            naredba.Parameters.AddWithValue("@nazivKava", "Kava s mlijekom");
            naredba.Parameters.AddWithValue("@nazivSok", "Cijedeni sok");

            SqlConnection veza = new SqlConnection(connectionString);
            veza.Open();
            naredba = new SqlCommand(upit, veza);

            using (SqlDataReader čitač = naredba.ExecuteReader())
            {
                while (čitač.Read())
                {
                    id = čitač.GetInt32(0);
                }
            }
            veza.Close();
            if (id >= 0)
            {
                MessageBox.Show("Dohvacen id.", "Obavijest");
                return id;
            }
            else
            {
                MessageBox.Show("Greška u dohvatu ida.", "Obavijest");
            }
            return id;
        }

        private int dohvatiIdKave()
        {
            string upit = "SELECT id_pica FROM Pica WHERE naziv_pica = @nazivKava";
            return dohvatiIdIzBaze(upit);
        }

        private int dohvatiIdCijedeniSok()
        {
            string upit = "SELECT id_pica FROM Pica WHERE naziv_pica = @nazivSok";
            return dohvatiIdIzBaze(upit);
        }

        private void provjeraIskoristenihPopusta(int id_konobar)
        {

        }

        public Dictionary<Pice, decimal> azurirajRacun()
        {
            //azuiraj pica na racunu, 
            return new Dictionary<Pice, decimal>();
        }

        public string dodajTekst()
        {
            //koji konobar iskoristio koju akciju
            return "";
        }

        //provjeri kolko je konobar iskoristio danas
        //za odabir kaj moze iskoristiti
        //korigira se cijena u listi - tj salje se natrag Dictionary<Pice, decimal> narucenaPica
    }
}
