using System.Text.RegularExpressions;
using Try2;

Console.WriteLine("Please enter your user ID:");
string userId = Console.ReadLine();

while (!Regex.IsMatch(userId, @"^[a-zA-Z0-9]+$"))
{
    Console.WriteLine("Your username is not valid. It can contain only letters and/or numbers. Please try again.");
    userId = Console.ReadLine();
}

OneTimePassword otp = new OneTimePassword(userId);

Console.WriteLine("Your One time password will be generated below. Press any key to exit.");
otp.StartGenerating();
