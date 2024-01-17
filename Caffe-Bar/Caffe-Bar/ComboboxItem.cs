using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caffe_Bar
{
    internal class ComboboxItem
    {
        public string Text { get; set; } // Tekst koji će se prikazati u ComboBox-u
        public object Value { get; set; } // Povezana vrijednost, npr. ID iz baze

        public override string ToString()
        {
            return Text; // Kada se item prikaže u ComboBox-u, prikazat će se ovaj tekst
        }
    }
}
