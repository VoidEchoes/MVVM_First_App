using System.Configuration;
using System.Data;
using System.Windows;
using ExpenseApp.Services;
using ExpenseApp.ViewModels;
using ExpenseApp.Views;
using Microsoft.Extensions.DependencyInjection;

namespace ExpenseApp
{
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IExpenseService, ExpenseService>();
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<MainWindow>(provider => new MainWindow
            {
                DataContext = provider.GetRequiredService<MainViewModel>()
            });
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }
    }

}
