namespace ConsoleApp
{
    internal class ProjectInformation
    {
        private static readonly string _projectName = "ATM";
        private static readonly string _projectType = "Console Application";
        private static readonly string _projectVersion = "8.0";

        internal static void Show()
        {
            Utilities.ShowGreenMessage($"{_projectName} - {_projectType}: {_projectVersion}");
            Console.WriteLine();
        }
    }
}
