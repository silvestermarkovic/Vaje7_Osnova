using System;
using System.Collections.Generic;

namespace Naloga2
{
    class Program
    {
        static void Main(string[] args)
        {
            pajek paj = new pajek();

            paj.naloziPodatke();
        }
    }

    class Strani
    {
        public string url = "";
        public string vsebina = "";
        public List<Povezave> seznam_povezav = new List<Povezave>();

        public Strani(string purl, string pvsebina)
        {
            //konstruktor
            url = purl;
            vsebina = pvsebina;
        }
    }

    class Povezave
    {
        public string url;
        public string vsebina;
        public bool pregledane;

        public Povezave(string purl, string pvsebina)
        {
            //konstruktor
            url = purl;
            vsebina = pvsebina;
        }
    }
}
