using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Timer = System.Timers.Timer;

namespace Try2
{
    public class OneTimePassword
    {
        private static Timer timer;
        private static string userId;

        public OneTimePassword(string userId)
        {
            UserId = userId;
            timer = new Timer(1000);

        }

        public string UserId
        {
            get { return userId; }
            set { userId = value; }
        }



        private static void GenerateOnetimePassword(string userId)
        {
            DateTime validFrom = DateTime.Now;
            DateTime validTo = validFrom.AddSeconds(30);
            Random randomNumber = new Random();
            string password = (randomNumber.Next(100000, 999999)).ToString();

            timer.Interval = 30000;


            for (int seconds = 30; seconds > 0; seconds--)
            {
                Console.Write("\rPassword for {0}: {1} -> valid for {2} seconds. (from {3} to {4})", userId, password, seconds, validFrom.ToLongTimeString(), validTo.ToLongTimeString());

                System.Threading.Thread.Sleep(1000);
            }

        }

        private static void ATimer_Elapsed(object? sender, ElapsedEventArgs e)
        {
            GenerateOnetimePassword(userId);

        }

        public void StartGenerating()
        {
            timer.Elapsed += ATimer_Elapsed;
            timer.Enabled = true;
            timer.AutoReset = true;
            timer.Start();

            Console.ReadKey();
        }


    }
}
