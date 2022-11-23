using Library.Data;
using Library.Models;
using System.Globalization;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main()
        {
            Database.FeedData();
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Thread.CurrentThread.CurrentCulture = new CultureInfo("de-DE");

            do
            {
                Authentication.Run(out Account? account);

                if (account is not null)
                    Menu.Initialize(account);
            } while (true);
        }
    }
}