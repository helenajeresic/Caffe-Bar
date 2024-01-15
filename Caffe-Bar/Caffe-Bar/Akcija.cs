using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaffeBar
{
    internal class Akcija
    {
        public int id_akcija {  get; set; }
        public int id_pica { get; set; }
        public DateTime od {  get; set; }
        public DateTime do_ {  get; set; }
        public decimal popust {  get; set; }
    }
}
