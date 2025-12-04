namespace ElectronicsFactory
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Database.Initialize("Host=localhost;Database=ElectronicsFactory;Port=5432;Username=postgres;Password=virtual");
            Application.Run(new AuthorizationForm());
        }
    }
}