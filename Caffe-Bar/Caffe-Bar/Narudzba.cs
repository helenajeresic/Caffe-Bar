using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaffeBar
{
    internal class Narudzba
    {
        public int id_narudzba{ get; set; }
        public int id_pica { get; set; }
        public int id_konobar { get; set; }
        public int kolicina { get; set; }
        public DateTime datum_naruceno { get; set; }
        public string dostavljeno { get; set; }
    }
}
