using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;
using wscad.BusinessLogic.Services;

namespace wscad
{
    public static class Program
    {
        private static IServiceProvider CreateServiceProvider()
        {
            var services = new ServiceCollection();
            services.AddTransient<IFileLoader, JsonFileLoader>();
            return services.BuildServiceProvider();
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            var serviceProvider = CreateServiceProvider();
            Application.Run(new Form1(serviceProvider));
        }
    }
}
