namespace ConsoleApp
{
    internal class Utilities
    {
        internal static void ShowPressAnyKeyToContinueMessage()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
            Console.Clear();
        }

        internal static void ShowGreenMessage(string message) => ShowColoredMessage(message, ConsoleColor.Green);

        internal static void ShowRedMessage(string message) => ShowColoredMessage(message, ConsoleColor.Red);

        private static void ShowColoredMessage(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
