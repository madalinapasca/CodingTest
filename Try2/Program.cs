
using System.Diagnostics.Metrics;
using System.Threading.Tasks;
using System.Timers;
using Try2;
using Timer = System.Timers.Timer;

public  class Program
{
    public static Timer aTimer = new Timer(5000);
    public static string username;
   

    static void GenerateOnetimePassword(string username)
    {
        Random randomNumber = new Random();
        string password = (randomNumber.Next(100000, 999999)).ToString();

        for (int seconds = 5; seconds > 0; seconds--)
        {
            Console.Write("\rCode for {0}: {1} -valid for {2} seconds.", username, password, seconds);
            System.Threading.Thread.Sleep(1000);
        }

    }

    private static void Main(string[] args)
    {
        Console.WriteLine("Introduceti username");
        username = Console.ReadLine();
        Console.WriteLine("Your one-time password will be generated below. Press any key to exit.");
       
        aTimer.Elapsed += ATimer_Elapsed;
        aTimer.Enabled = true;
        aTimer.AutoReset = true;
        aTimer.Start();

        Console.ReadKey();
    }

    private static void ATimer_Elapsed(object? sender, ElapsedEventArgs e)
    {
        GenerateOnetimePassword(username);
        
    }
}