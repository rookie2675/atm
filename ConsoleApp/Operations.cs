using Library.Models;

namespace ConsoleApp
{
    internal class Operations
    {
        internal static void MakeDeposit(Account account)
        {
            ShowPossibleAmounts();
            Console.Write("Please select the amount that you wish to deposit: ");
            decimal amount = GetAmount();

            account?.MakeDeposit(amount);

            Console.WriteLine();
            Console.WriteLine();
            Console.Write("You successfuly deposited ");
            Utilities.ShowGreenMessage(string.Format("{0:C}", amount));
            Utilities.ShowPressAnyKeyToContinueMessage();
        }

        internal static void MakeWithdrawal(Account account)
        {
            Console.WriteLine("Please select the amount that you wish to withdraw: ");
            decimal amount = GetAmount();
            Console.Clear();
            ProjectInformation.Show();

            if (account is not null)
                try
                {
                    account.MakeWithdraw(amount);
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
            Utilities.ShowPressAnyKeyToContinueMessage();
        }

        private static decimal GetAmount()
        {
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
    }
}
