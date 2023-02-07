using Library.Services;
using Library.Models;

namespace ConsoleApp
{
    internal class Authentication
    {
        private static string? _cardNumber;
        private static string? _cardPin;

        internal static void Run(out Account? account)
        {
            do
            {
                do
                {
                    RequestDetails();
                } while (string.IsNullOrEmpty(_cardNumber) || string.IsNullOrEmpty(_cardPin));

                account = new CardValidation(_cardNumber, _cardPin).AuthenticatedAccount;

                if (account is not null)
                    GreetUser(account.Holder.GetName());

                else if (account is null)
                    ShowAuthFailedMessage();

            } while (account is null);
        }

        private static void RequestDetails()
        {
            ProjectInformation.Show();
            Console.Write("Please insert your card number: ");
            _cardNumber = Console.ReadLine();
            Console.Write("Please insert your pin: ");
            _cardPin = Console.ReadLine();

            if (string.IsNullOrEmpty(_cardNumber) || string.IsNullOrEmpty(_cardPin))
                ShowAuthFailedMessage();
        }

        private static void ShowAuthFailedMessage()
        {
            Console.WriteLine();
            Utilities.ShowRedMessage("Authentication has failed.");
            Console.WriteLine("Press any key to try again...");
            Console.ReadLine();
            Console.Clear();
        }

        private static void GreetUser(string name)
        {
            Console.WriteLine();
            Utilities.ShowGreenMessage("Authentication has been successfull");
            Console.WriteLine($"Welcome {name}!");
            Utilities.ShowPressAnyKeyToContinueMessage();
        }
    }
}
