using MVPSample.Presenters;
using MVPSample.Views;

using System;
using System.Windows.Forms;

using UsersService;

namespace MVPSample
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
            
            // Здесь происходит установление связей между классами приложения
            var mainForm = new UserListView();
            var presenter = new UsersPresenter(mainForm,
                                               new UserEditView(),
                                               new UserEditView(),
                                               new UserDeleteView(),
                                               new MessageView(),
                                               new UsersRepository("users.xml"));

            Application.Run(mainForm);
        }
    }
}