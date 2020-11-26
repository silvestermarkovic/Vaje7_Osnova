using System;
using System.Threading;
using System.Threading.Tasks;


namespace Zacetek
{
    class Program
    {

        static void Main(string[] args)
        {

        //primer klicev


        //direktni klic
        Console.WriteLine("Direktni klice");

        Task.Factory.StartNew(() => { Console.WriteLine("Test klica Taska: "); });

        Console.WriteLine("Direktni klice");
        //Uporaba Action
        Task task1 = new Task(new Action(IzpisiSporocilo));
        task1.Start();


        //Uporaba Delagatov
        Console.WriteLine("Delegate");
        Task task2 = new Task(delegate { IzpisiSporocilo(); });
        task2.Start();

        //lambda
        Console.WriteLine("Lambda");
        //Lambda and named method
        Task task3 = new Task(() => IzpisiSporocilo());
        task3.Start();



        Console.WriteLine("Lambda async");
        //Lambda and anonymous method
        Task task4 = new Task(() => { IzpisiSporocilo(); });
        task4.Start();

        //Using Task.Run in .NET4.5!!!
        //Task.Run and Task.FromResult 
        Console.WriteLine("Run priporočljivo");
        var task5 = Task.Run(IzpisiSporocilo);

        Console.ReadLine();




        Console.WriteLine("Primer: Čakamo prekinitev:");
        CancellationTokenSource tokenSource = new CancellationTokenSource();
        CancellationToken token = tokenSource.Token;

        Task.Run(() => IzpisiSporociloPrekinitev(token));

        //var taskprekini = Task.Run(IzpisiSporociloPrekinitev, token);
        Console.WriteLine("Ob pritisku tipke se prekine izvajanje");

        Console.ReadLine();


        // #1 create a token source with timeout
        //tokenSource = newCancellationTokenSource(TimeSpan.FromSeconds(2));

        // #2 request cancellation after timeout
        tokenSource.CancelAfter(TimeSpan.FromSeconds(2));

        // #3 directly request cancellation
        //tokenSource.Cancel();
        // or
        //tokenSource.Cancel(true);


        Console.WriteLine("Konec?");
        Console.ReadLine();



        Console.WriteLine("Primer klica Async metode?");

        // primer klica Async s parametri
        Random _random = new Random();
        int teza = _random.Next(10, 30);
        //zaženemo Task in nadaljujemo
        Task<int> naloga = ObremenitevAsync(_random.Next(2, 6), teza);
        Console.WriteLine("Čakamo na konec");

        naloga.Wait();
        Console.WriteLine("Konec");



        Console.WriteLine("Nalaganje strani!");
        sync raz = new sync();
        raz.test();
        Console.ReadLine();
    }

    public static void IzpisiSporocilo()
    {
        Console.WriteLine("Začetek!");
        Thread.Sleep(2000);
        Console.WriteLine("Konec!");
    }


    public static void IzpisiSporociloPrekinitev(CancellationToken token)
    {
        Console.WriteLine("Začetek, čakamo prekinitev!");

        while (true)
        {

            if (token.IsCancellationRequested)
            {
                Console.WriteLine("Dočakali smo prekinitev!");
                return;
            };
        }

    }


    //primer async

    public static async Task<int> ObremenitevAsync(double cas, int pteza)
    {
        //povečamo StKlicev

        //podatki moramo v milisekundah zato * 1000            
        int sek = (int)cas * 1000;
        //await pove, da async počaka, da se izvrši ukaz, sicer bi nadaljevalo takoj
        await Task.Delay(sek);
        //odstranimo obremenitev

        return 0;
    }
}
}