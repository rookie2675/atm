using Library.Services;
using Library.Models;

namespace ConsoleApp
{
    internal class Authentication
    {
        internal Account? AuthenticatedAccount { get; init; }
        private string? _cardNumber;
        private string? _cardPin;

        public Authentication() 
        {
            do
            {
                RequestDetails();
            } while (string.IsNullOrEmpty(_cardNumber) || string.IsNullOrEmpty(_cardPin));

            AuthenticatedAccount = new CardValidation(_cardNumber, _cardPin).AuthenticatedAccount;

            if (AuthenticatedAccount is not null)
                GreetUser(AuthenticatedAccount.Holder.GetName());

            else if (AuthenticatedAccount is null)
                ShowAuthFailedMessage();
        }

        private void RequestDetails()
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
