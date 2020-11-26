using System;
using System.Collections.Generic;
using System.Text;

namespace Naloga2
{
    class pajek
    {
        //napolni vhodne podatke
        public List<Strani> seznamStrani = new List<Strani>();


        public void naloziPodatke()
        {
            List<string> seznam = new List<string>
            {
                "https://www.kirupa.com/html5/loading_random_page_inline_pg1.htm",
                "https://moodle.fis.unm.si",
                "https://www.arnes.si",
                "https://www.rtvslo.si",
                "https://www.siol.net",
                "http://www.kosarka.si",
                "https://slo-tech.com/",
                "https://cnn.com/",
                "http://ddv.inetis.com/",
                "https://artros.si/",
                "https://www.morela.si/"

            };

            //3A
            //uporabite lahko metode (pomagajte si z metodami, ki so že pripravljene
            //za vsako stran naložite vsebino HTML v lastnost vsebina v seznamStrani 

            foreach (string p in seznam)
            {
                seznamStrani.Add(new Strani(p, vrniVsebino(p)));
            }

            //z kreiranim seznamom, zaporedno, paralelno obdelaj sezname, tako da najdeš spletne povezave na strani
            //in jih shraiš v zapis Strani, Povezave


            //naloga C
            //obdelavo kliči zaporedno in paralelno

        }

        public void obdelajSeznam(Strani pstran)
        {

            //koda
            //z uporabo paralelnih klicev, poiščite HTML povezave v dokumentih
            //izpišite jih v konzolo
            //ustvarite razred  Povezave, in jih dodajte seznamStrani.seznam_povezav (kreirajte metodo za dodajanje)
            //iščite <a href=" 

            
        }

        //NALOGA 2C uporabi kodo iz prejšnje strani
        public static string vrniVsebino(string url)
        {

            //ustvarite async metodo, ki vrne vsebino spletne strani


            return "";

        }
    }
}
