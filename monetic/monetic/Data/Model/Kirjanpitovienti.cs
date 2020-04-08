using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace monetic.Data.Model
{
    // 1 -123.15 Ruokaostos
    // 2 -123.15 Pankkitili
    public class Kirjanpitovienti
    {
        public uint Id { get; }
        public uint Tili { get; set;}
        public double Summa { get; set; }
        public string Selite { get; set; }

        public void MuutaTili(uint uusiTili)
        {
            Tili = uusiTili;
        }

        public void MuutaSelite(string uusiSelite)
        {
            Selite = uusiSelite;
        }

        public void MuutaSumma(double uusiSumma)
        {
            Summa = uusiSumma;
        }
    }
}
