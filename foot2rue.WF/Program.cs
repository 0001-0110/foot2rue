using foot2rue.WF.Services;
using System.Globalization;
using foot2rue.WF.HomePage;

namespace foot2rue.WF
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static int Main()
        {
            try
            {
                // To customize application configuration such as set high DPI settings or default font,
                // see https://aka.ms/applicationconfiguration.
                ApplicationConfiguration.Initialize();
                Application.Run(new HomePageForm());
                return 0;
            }
            catch (Exception exception)
            {
#if DEBUG
                Console.WriteLine(exception);
#endif
                return 1;
            }
        }
    }
}
