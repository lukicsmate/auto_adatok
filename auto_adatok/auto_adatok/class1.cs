using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auto_adatok
{
    internal class autok
    {
        public string Márka {  get; set; }

        public string Típus { get; set; }
        public string Üzemanyag { get; set; }
        public int Teljesítmény_LE {  get; set; }
        public int Vételár_EUR {  get; set; }
        public short Gyártási_év {  get; set; }
        public int Átlagos_CO2_g_km { get; set; }
    }
}
