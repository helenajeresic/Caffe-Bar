using System;
using System.Windows.Forms;

namespace CaffeBar
{
    public partial class UnosKolicine : Form
    {
        public decimal Kolicina { get; private set; }

        public decimal DostupnaKolicina { get; private set; }

        /// <summary>
        /// Konstruktor za UnosKolicineForm.
        /// </summary>
        public UnosKolicine()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Klikom na gumb Odustani, zatvara se forma. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gumbOdustani_Click(object sender, EventArgs e)
        {
            Close();
        }
        /// <summary>
        /// Klikkom na gumb potvrdi provjerava se unesena količina. Ako je unesena
        /// količina manja ili jednaka dostupnoj količini na šanku, prozor se zatvara
        /// sa rezultatom OK, inače se upozorava konobara da nadopuni šank.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gumbPotvrdi_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(numericUpDownKolicina.Text, out decimal kolicina))
            {
                if(kolicina <= DostupnaKolicina)
                {
                    Kolicina = kolicina;
                    DialogResult = DialogResult.OK;   
                }
                else
                {
                    Kolicina = 0;
                    numericUpDownKolicina.Value = 1;
                    MessageBox.Show("Unesena prevelika količina, nadopunite šank.", "Upozorenje!");
                }
            }
            else
            {
                Kolicina = 0;
                MessageBox.Show("Nije uspjela konverzija količine.", "Greška!");
            }
        }
        /// <summary>
        /// Metoda koja ažurira label naziva proizvoda na temelju odabranog proizvoda.
        /// </summary>
        /// <param name="newLabel"> String koji predstavlja ime proizvoda. </param>
        public void urediLabel(string newLabel)
        {
            labelPice.Text = newLabel;
        }

        /// <summary>
        /// Metoda koja postavlja količinu na dostupnu količinu poslanu od KonobarForm.
        /// </summary>
        /// <param name="kolicina"> Dostupna količina. </param>
        public void setDostupnaKolicina(decimal kolicina)
        {
            DostupnaKolicina = kolicina;
        }
    }
}
