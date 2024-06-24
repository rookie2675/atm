using Library.Models;

namespace ConsoleApp
{
    internal class Menu(Account? account)
    {
        private readonly Account? _account = account is null ? throw new ArgumentNullException(nameof(account)) : account;
        private bool _running = true;

        internal void Run()
        {
            do
            {
                ProjectInformation.Show();
                ShowBalance();
                ShowOptions();
                ChooseOption();
            } while (_running);
        }

        private void ShowBalance()
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

        private void ChooseOption()
        {
            ConsoleKeyInfo userInput = Console.ReadKey(true);
            Console.Clear();
            ProjectInformation.Show();

            switch (userInput.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    if (_account is not null)
                        Operations.MakeDeposit(_account);
                    break;

                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    if (_account is not null)
                        Operations.MakeWithdrawal(_account);
                    break;

                case ConsoleKey.D0:
                case ConsoleKey.NumPad0:
                    _running = false;
                    break;

                default:
                    break;
            }

            Console.Clear();
        }
    }
}
