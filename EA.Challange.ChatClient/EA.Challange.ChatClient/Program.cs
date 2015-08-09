using System;
using System.Windows.Forms;
using Autofac;
using Autofac.Core;
using EA.Challange.ChatClient.Contracts.IService;

namespace EA.Challange.ChatClient
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ChatClientForm());
        }
    }
}
