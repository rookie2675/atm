using Library.Models;

namespace ConsoleApp
{
    internal static class Menu
    {
        private static Account? _account;
        private static bool _running;

        internal static void Initialize(Account account)
        {
            if (account is not null)
                _account = account;

            _running = true;

            do
            {
                ProjectInformation.Show();
                ShowBalance();
                ShowOptions();
                ChooseOption(); 
            } while (_running);
        }

        private static void ShowBalance()
        {
            if (_account is not null)
            {
                Console.Write("Current Balance: ");
                Utilities.ShowGreenMessage(string.Format("{0:C}", _account.Balance));
            }
        }

        private static void ShowOptions()
        {
            Console.WriteLine("1) Deposit");
            Console.WriteLine("2) Withdraw");
            Console.WriteLine("0) Exit");
            Console.Write("Please choose one of the options above: ");
        }

        private static void ChooseOption()
        {
            ConsoleKeyInfo userInput = Console.ReadKey(true);
            Console.Clear();
            ProjectInformation.Show();

            switch (userInput.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    MakeDeposit();
                    break;

                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    MakeWithdrawal();
                    break;

                case ConsoleKey.D0:
                case ConsoleKey.NumPad0:
                    _running = false;
                    break;

                default:
                    break;
            }
        }

        private static void MakeDeposit()
        {
            Console.Write("Please select the amount that you wish to deposit: ");
            decimal amount = GetAmount();

            if (_account is not null)
                _account.MakeDeposit(amount);
            
            ShowPossibleAmounts();
            Console.Write("You successfuly deposited ");
            Utilities.ShowGreenMessage(string.Format("{0:C}", amount));
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        private static void MakeWithdrawal()
        {
            Console.Write("Please select the amount that you wish to withdraw: ");
            decimal amount = GetAmount();
            Console.Clear();
            ProjectInformation.Show();

            if (_account is not null)
                try
                {
                    _account.MakeWithdraw(amount);
                }
                catch (Exception exception)
                {
                    Console.Clear();
                    ProjectInformation.Show();
                    Console.WriteLine();
                    Utilities.ShowRedMessage(exception.Message);
                }   

            Console.Write("You successfuly withdrew ");
            Utilities.ShowGreenMessage(string.Format("{0:C}", amount));

            Console.WriteLine(string.Format("{0:C}", amount));

            Console.ResetColor();

            Console.WriteLine("Press any key to continue...");

            Console.ReadLine();
        }

        private static void ShowPossibleAmounts()
        {
            Console.WriteLine(string.Format("1) {0:C}", 10));
            Console.WriteLine(string.Format("2) {0:C}", 20));
            Console.WriteLine(string.Format("3) {0:C}", 50));
            Console.WriteLine(string.Format("4) {0:C}", 100));
            Console.WriteLine(string.Format("5) {0:C}", 250));
            Console.WriteLine(string.Format("6) {0:C}", 500));
            Console.WriteLine(string.Format("7) {0:C}", 1000));
        }

        private static decimal GetAmount()
        {
            ShowPossibleAmounts();

            ConsoleKeyInfo userInput = Console.ReadKey(true);
            return userInput.Key switch
            {
                ConsoleKey.D1 or ConsoleKey.NumPad1 => 10,
                ConsoleKey.D2 or ConsoleKey.NumPad2 => 20,
                ConsoleKey.D3 or ConsoleKey.NumPad3 => 50,
                ConsoleKey.D4 or ConsoleKey.NumPad4 => 100,
                ConsoleKey.D5 or ConsoleKey.NumPad5 => 250,
                ConsoleKey.D6 or ConsoleKey.NumPad6 => 500,
                ConsoleKey.D7 or ConsoleKey.NumPad7 => 1000,
                _ => throw new NotImplementedException(),
                };
            }
        }
}
