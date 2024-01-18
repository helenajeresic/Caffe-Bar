using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaffeBar
{
    public class Pice
    {
        public int id_pica {  get; set; }
        public string naziv_pica { get; set; }
        public decimal cijena_pica { get; set; }
        public int id_kategorija_pica { get; set; }
        public decimal kolicina_kafic { get; set; }
        public decimal kolicina_skladista {  get; set; }
        public string najmanja_kolicina { get; set; }
        public override bool Equals(object objekt)
        {
            if (objekt == null || GetType() != objekt.GetType())
            {
                return false;
            }
            Pice drugoPice = (Pice)objekt;
            return id_pica == drugoPice.id_pica;
        }

        public override int GetHashCode()
        {
            return id_pica;
        }
    }
}
