using MVCSample.Services;
using MVCSample.Views;

using System;
using System.Windows.Forms;

using UsersService;

namespace MVCSample;

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
        new ContextApp(new UsersRepository("users.xml")).Run();
    }
}