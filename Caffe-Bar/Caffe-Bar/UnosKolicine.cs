using System;
using System.Windows.Forms;

namespace CaffeBar
{
    public partial class UnosKolicine : Form
    {
        public decimal Kolicina { get; private set; }

        public decimal DostupnaKolicina { get; private set; }

        public UnosKolicine()
        {
            InitializeComponent();
        }

        private void gumbOdustani_Click(object sender, EventArgs e)
        {
            Close();
        }

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

        public void urediLabel(string newLabel)
        {
            labelPice.Text = newLabel;
        }

        public void setDostupnaKolicina(decimal kolicina)
        {
            DostupnaKolicina = kolicina;
        }
    }
}
