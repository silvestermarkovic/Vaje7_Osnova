using System;
using System.Collections.Generic;
using System.Linq;

namespace Naloga1
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime dtStart, dtEnd;
            TimeSpan ts;

            //ustvarimo vhodne podatke, podatki so besede v spletni strani
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

            //primer klica
            //NALOGA 1A ustvarite  vrniVsebino, ki bo vrala HTML vsebino async
            List<seznamdodatek> seznamZap = new List<seznamdodatek>();

            dtStart = DateTime.Now;
            seznam.ForEach(i =>
            {
                string temp = vrniVsebino(i);
                seznamZap.Add(new seznamdodatek(temp, temp.Length));
            });
            dtEnd = DateTime.Now;
            ts = dtEnd - dtStart;
            Console.WriteLine($"Čas zaporednega izvajanja: {ts.TotalSeconds}. Št. zapisov: {seznamZap.Count()}");



            //Naloga1B: ustvarite nov seznam seznamPar in ga napolnite v parallel načinu



            //Naloga1C: ustvarite nov seznam seznamParLock in ga napolnite v parallel načinu




            //***************************************
            //Drugi del
            //Uporaba Paralel v Linq ukazu
            //Naloga 1 Drugi del, 
            List<seznamdodatek> seznam_stevil = new List<seznamdodatek>();
            //ustvarimo seznam
            for (int i = 0; i < 1000; i++)
            {
                seznam_stevil.Add(new seznamdodatek("stev" + i.ToString(), i));
            }

            //uporaba Lamda izraza
            dtStart = DateTime.Now;
            seznam.ForEach(i =>
            {
                Console.Write($"{i.Length * i.Length },");
            });
            dtEnd = DateTime.Now;
            ts = dtEnd - dtStart;
            Console.WriteLine($"Čas zaporednega izvajanja: {ts.TotalSeconds}.");

            //Naloga 1D predelajte zgodnjo kodo, da bo klicana v paralel načinu


        }




        public static string vrniVsebino(string url)
        {
            string vsebina = "";

            //NALOGA1 A
            //ustvarite async klice metode, ki vrne spletno stran HTML
            //pomagajte si lahko z obstoječo kodo
            return vsebina; 

        }

        public class seznamdodatek
        {
            public string naziv;
            public int vrednost;

            public seznamdodatek(string pnaziv, int pvred)
            {
                naziv = pnaziv;
                vrednost = pvred;

            }
        }
    }

}
