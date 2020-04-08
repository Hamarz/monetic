using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace monetic.Data.Model
{
    public class Tosite
    {
        public uint Tositenumero { get; set; }
        public List<Kirjanpitovienti> Debet { get; set; }
        public List<Kirjanpitovienti> Kredit { get; set; }

        public bool LisaaVienti(Kirjanpitovienti vienti)
        {
            if(VientiLoytyy(vienti))
                return false;

            if(vienti.Summa < 0)
                Debet.Add(vienti);
            else
                Kredit.Add(vienti);

            return false;
        }

        public bool PoistaVienti(Kirjanpitovienti vienti)
        {
            if(!VientiLoytyy(vienti))
                return false;

            // Jos se on plussa etsi se debet osiosta
            if(vienti.Summa > 0)
                Debet.Remove(vienti);
            else
                Kredit.Remove(vienti);
            return true;
        }

        public bool VientiLoytyy(Kirjanpitovienti vienti)
        {
            return Debet.Find((e) => vienti.Id == e.Id) != null || Kredit.Find((e) => e.Id == vienti.Id) != null;
        }

        private double debetSumma()
        {
            double sum = 0;
            foreach(var vienti in Debet)
                sum += vienti.Summa;
            return sum;
        }

        private double kreditSumma()
        {
            double sum = 0;
            foreach(var vienti in Kredit)
                sum += vienti.Summa;
            return sum;
        }

        public double Erotus => debetSumma() + kreditSumma();
    }
}
