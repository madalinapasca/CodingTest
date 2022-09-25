
using System.Diagnostics.Metrics;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Timer = System.Timers.Timer;

public  class Program
{
    private static Timer aTimer = new Timer(1000);
    private static string username;
    private static void GenerateOnetimePassword(string username)
    {
        DateTime validFrom= DateTime.Now;
        DateTime validTo= validFrom.AddSeconds(30);
        Random randomNumber = new Random();
        string password = (randomNumber.Next(100000, 999999)).ToString();

        aTimer.Interval = 30000;

        for (int seconds = 30; seconds > 0; seconds--)
        {
            Console.Write("\rCode for {0}: {1} -> valid for {2} seconds. (from {3} to {4})", username, password, seconds, validFrom.ToLongTimeString(), validTo.ToLongTimeString());
          
            System.Threading.Thread.Sleep(1000);
        }
        
    }

    private static void ATimer_Elapsed(object? sender, ElapsedEventArgs e)
    {
        GenerateOnetimePassword(username);

    }

    private static void Main(string[] args)
    {     
        Console.WriteLine("Introduceti username");
        username = Console.ReadLine();
        
        Console.WriteLine($"Welcome, {username}! Your one-time password will be generated below. Press any key to exit.");

        aTimer.Elapsed += ATimer_Elapsed;
        aTimer.Enabled = true;
        aTimer.AutoReset = true;
        aTimer.Start();

        Console.ReadKey();
    }

   
}