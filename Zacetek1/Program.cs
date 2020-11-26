using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Zacetek1
{
    class Program
    {
        static void Main(string[] args)
        {
            razredAsync prim = new razredAsync();
            prim.izvediPrimer1();


            Console.ReadKey();



            Console.WriteLine("Prenos slike s spleta");
            shraniSliko("https://www.lokalno.si/img/logoLokalno240.jpg", "test.jpg");
            Console.WriteLine("Konec");



            
        }


        class razredAsync
        {
            //ustvarite async metodo, ki se bo izvajal

            public string status = "";


            public razredAsync()
            {
                //TODO 2
                //ustvarite timer, ki bo sakih 10 sekund izpisal vsebino spremenljivke status;
            }

            //kličite async metodo
            public void izvediPrimer1()
            {

                CancellationTokenSource source = new CancellationTokenSource();
                CancellationToken token = source.Token;

                status = "klic";
                Console.WriteLine($"1{status}");

                Task<string> text = cakalnaMetoda(4, token);

                source.Cancel();

                Console.WriteLine($"3{status}");
                Console.ReadKey();

                Console.WriteLine($"5{status}");

            }




            //
            public async Task<string> cakalnaMetoda(int pcas, CancellationToken cancelToken)
            {
                try
                {
                    await Task.Delay(pcas * 1000);
                }
                catch (AggregateException ae)
                {
                    foreach (Exception e in ae.InnerExceptions)
                    {
                        if (e is TaskCanceledException)
                        {
                            status = "Task preklican: " + ((TaskCanceledException)e).Message;
                            Console.WriteLine($"{status}");
                            return ("Task preklican: " + ((TaskCanceledException)e).Message);
                        }
                        else
                        {
                            status = "Druga izjema: " + e.GetType().Name;
                            Console.WriteLine($"{status}");
                            return ("Druga izjema: " + e.GetType().Name);
                        }
                    }
                }
                status = "Koncano";
                Console.WriteLine($"{status}");
                return "OK";

            }
        }




        static void shraniSliko(string p_url, string p_slika)
        {
            string imageUrl = p_url; // @"http://www.somedomain.com/image.jpg";
            string saveLocation = p_slika; // @"C:\someImage.jpg";

            byte[] imageBytes;
            HttpWebRequest imageRequest = (HttpWebRequest)WebRequest.Create(imageUrl);
            WebResponse imageResponse = imageRequest.GetResponse();

            Stream responseStream = imageResponse.GetResponseStream();

            using (BinaryReader br = new BinaryReader(responseStream))
            {
                imageBytes = br.ReadBytes(500000);
                br.Close();
            }
            responseStream.Close();
            imageResponse.Close();

            FileStream fs = new FileStream(saveLocation, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            try
            {
                bw.Write(imageBytes);
            }
            finally
            {
                fs.Close();
                bw.Close();
            }
        }
    }
}
