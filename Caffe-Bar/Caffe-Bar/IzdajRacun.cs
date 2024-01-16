using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CaffeBar
{
    public partial class IzdajRacun : Form
    {
        private decimal Total { get; set; }
        private DateTime VrijemeRacuna { get; set; }

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
            finalniRacun.AppendText("Ukupna cijena: " + Total.ToString());
            finalniRacun.AppendText("\n\n");
            finalniRacun.AppendText(VrijemeRacuna + "\n");
            finalniRacun.AppendText("Wifi password: caffebar123\n\n");
            finalniRacun.AppendText("--------------------------------------\n\n");
            finalniRacun.SelectionAlignment = HorizontalAlignment.Left;
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
            // zapisi racun

            //ako sve proslo okej
            DialogResult = DialogResult.OK;
        }
    }
}
