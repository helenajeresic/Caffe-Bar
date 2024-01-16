using System;
using System.Windows.Forms;

namespace Caffe_Bar
{
    public partial class UnosKolicine : Form
    {
        public int Quantity { get; private set; }

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
            if (int.TryParse(numericUpDownKolicina.Text, out int quantity))
            {
                Quantity = quantity;
                DialogResult = DialogResult.OK;
            }
            else
            {
                //nema tolike kolicine u sanku
                Quantity = 0;   
                MessageBox.Show("Neispravan unos količine.", "Upozorenje");
            }
        }

        public void updateLabel(string newLabel)
        {
            labelPice.Text = newLabel;
        }

    }
}
