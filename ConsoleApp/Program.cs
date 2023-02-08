using Library.Data;
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
                Authentication authentication;
                do { authentication = new(); }
                while (authentication.AuthenticatedAccount is null);
                new Menu(authentication.AuthenticatedAccount).Run();
            } while (true);
        }
    }
}